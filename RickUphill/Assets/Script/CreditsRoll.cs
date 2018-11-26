using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsRoll : MonoBehaviour {

	// Script used for moving the credits on the credits screen

	void Start () {
        transform.DOLocalMoveY(20, 3);
        transform.DOLocalMoveY(274, 5).SetDelay(3);
    }
	
}
