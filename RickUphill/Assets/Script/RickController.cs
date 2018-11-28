using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ez.Msg;

public class RickController : MonoBehaviour
{

    // Script used to move rick and update his health and score

    #region Variables

    public float JumpForce;
	private bool _groundCheck = true;
	private Animator _anim;
	private Rigidbody2D _rb;
    public int? score;
    Text scoretext;
    Text healthtext;
    bool didScore;
    public Vector2 jumpHeight;
    bool invincible;
    public int health = 3;
    float timer = 0.0f;
    public int seconds;

    public GameObject scoreMgr;
    public GameObject rickMgr;

    private float _jumpStartTime;

    public AudioClip jump;
    public AudioClip hit;
    public AudioClip restore;
    AudioSource source;

    #endregion

    void Awake ()
	{
        #region Initializing Variables
        source = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody2D>();
        scoretext = GameObject.Find("Score").GetComponent<Text>();
        healthtext = GameObject.Find("Health").GetComponent<Text>();
        health = 3;
        //score = 0;
        didScore = false;
        #endregion
    }

	void Update () {

        #region Score and Health Text Update

        // using EzMsg / standard form (using lambda)
        score = EzMsg.Request<IScore, int?>(scoreMgr, _ => _.GetScore());

        scoretext.text = "SCORE: " + score;
        healthtext.text = "HP: " + health;
        #endregion

        invincible = EzMsg.Request<IInvincibility, bool>(rickMgr, _ => _.GetInvincible());

        #region Invincibility

        //if (invincible == true) {
        //    Color tmp = _rb.GetComponent<SpriteRenderer>().color;
        //    tmp.a = 0.5f;
        //    _rb.GetComponent<SpriteRenderer>().color = tmp;
        //    timer += Time.deltaTime;
        //    seconds = (int)timer % 60;
        //    if (seconds == 3) {
        //        tmp.a = 1.0f;
        //        _rb.GetComponent<SpriteRenderer>().color = tmp;
        //        source.PlayOneShot(restore);
        //        invincible = false;
        //        timer = 0;
        //    }
        //}

        if (invincible == true)
        {
            Debug.Log("OLHA LA");
            EzMsg.Send<IInvincibility>(rickMgr, _ => _.isInvincible()).
            Wait(3f).
            Send<IInvincibility>(rickMgr, _ => _.isNotInvincible()).
            Run();
        }

        #endregion

        #region Calling Jump Method
        if ((Input.GetButton("Jump") || Input.touches.Length > 0) && _groundCheck == true)
        {
            _anim.SetBool("isjumping", true);
            DoJump();
        }
        #endregion

        #region Ground Check
        if (Input.GetKeyDown("space")){
            source.PlayOneShot(jump, 0.5f);
        }

        if (_rb.transform.position.y >= 0.2)
            _groundCheck = false;

        if (_rb.transform.position.y <= -0.4)
            _groundCheck = true;

        #endregion

        #region Raycast to Score
        int layerMask = 1 << 11;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, layerMask);

        if (hit.collider != null)
        {
            didScore = true;
        }
        #endregion

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        #region Updating Score
        if (collision.gameObject.name == "Ground_Rick" && didScore == true) {
            didScore = false;
            _anim.SetBool("isjumping", false);
            //using EzMsg / shorthand form
            scoreMgr.Send<IScore>(_ => _.AddToScore());
        }
        #endregion

        #region Take Damage / Game Over
        if (!invincible)
        {
            if (collision.gameObject.tag == "rock") {
                if (health == 1) {
                    StartCoroutine(Death());
                }
                else {
                    source.PlayOneShot(hit);
                    health -= 1;
                    //invincible = true;
                    rickMgr.Send<IInvincibility>(_ => _.setInvincible());
                }
            }
        }
        #endregion
    }

    #region Jump Method
    void DoJump()
	{
        _rb.AddForce(Vector2.up * JumpForce);
	}
    #endregion
   public IEnumerator Death ()
    {
        _anim.SetTrigger("isdead");
        yield return new WaitForSeconds(2f);
        GameSceneManager.LoadLevel(4);
    }
}

