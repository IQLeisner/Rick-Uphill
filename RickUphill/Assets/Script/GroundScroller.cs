using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour {

    // Script used to scroll the ramps downward

    Vector3 _startPos;
	public Vector3 DestinationPos;
	public float ScrollSpeed;

	void Start ()
	{
		_startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position,
			DestinationPos, ScrollSpeed);
		
		if (Mathf.Approximately(Vector3.Distance( transform.position, DestinationPos ), 0f))
			ResetPosition();
	}

	void ResetPosition()
	{
		transform.position = _startPos;
	}
}
