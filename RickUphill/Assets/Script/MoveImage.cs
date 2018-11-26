using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImage : MonoBehaviour {

	// Script used for moving the logo on the splash screen

	void Start () {

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(DOTween.To(() => transform.position, x => transform.position = x, new Vector3(transform.position.x, 1000, transform.position.z), 2));
        mySequence.Append(transform.DOScale(new Vector3(3, 3, 3), 2));
        mySequence.Insert(1, transform.DORotate(new Vector3(40, 40, 40), mySequence.Duration()));
	}

}
