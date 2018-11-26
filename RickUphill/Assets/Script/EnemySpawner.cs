using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ez.Msg;

public class EnemySpawner : MonoBehaviour {

    // Script used to spawn rocks in the main scene

    private float timeUntilSpawn;
    public GameObject rock;
    public GameObject scoreMgr;
    int? score;

    void Awake() {
        timeUntilSpawn = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {

        // using unity getComponent system
        //score = GameObject.Find("Rick").GetComponent<RickController>().score;

        // using EzMsg / standard form (using lambda)
        score = EzMsg.Request<IScore, int?>(scoreMgr, _ => _.GetScore());

        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0) {

            Vector3 newPos = new Vector3(1.5f, 1.5f, 0);
            Instantiate(rock, newPos, Quaternion.identity);

            if (score <= 5)
                timeUntilSpawn = Random.Range(1.8f, 2.2f);
            else if (score > 5 && score <= 10)
            {
                Debug.Log("oi");
                timeUntilSpawn = Random.Range(1.3f, 1.8f);
            }
            else if (score > 10 && score <= 15)
                timeUntilSpawn = Random.Range(1.0f, 1.4f);
            else if (score > 15)
                timeUntilSpawn = Random.Range(0.5f, 1.0f);
        }
	}
}
