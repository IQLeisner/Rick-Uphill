using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    // Script used to destroy rocks that leave the scene

	void Update () {
        if (transform.position.x < -1.5) {
            Destroy(gameObject);
        }
    }
}
