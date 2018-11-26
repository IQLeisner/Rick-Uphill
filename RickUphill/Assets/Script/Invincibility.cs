using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour, IInvincibility
{
    public Rigidbody2D _rb;
    public bool invincibility = false;

    public IEnumerable isInvincible () {
        Debug.Log("FICOU INVENCIVEL");
        invincibility = true;
        Color tmp = _rb.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        _rb.GetComponent<SpriteRenderer>().color = tmp;
        yield break;
	}
	
	public IEnumerable isNotInvincible () {
        Debug.Log("PAROU");
        Color tmp = _rb.GetComponent<SpriteRenderer>().color;
        tmp.a = 1.0f;
        _rb.GetComponent<SpriteRenderer>().color = tmp;
        invincibility = false;
        yield break;
	}

    public IEnumerable setInvincible()
    {
        invincibility = true;
        yield break;
    }

    public bool GetInvincible()
    {
        return invincibility;
    }
}
