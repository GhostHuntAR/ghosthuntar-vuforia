using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour {
	public float moveSpeed = 0.1f;
	private Vector3 cameraPosition; 
	private Vector3 ghostPosition;
	// Use this for initialization
	void Start () {
		cameraPosition = GameObject.Find ("ARCamera").transform.position;
		ghostPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {

		ghostPosition = Vector3.MoveTowards(ghostPosition, cameraPosition, moveSpeed);
		transform.position = ghostPosition;

		if (ghostPosition == cameraPosition) {
			Destroy (gameObject);
			//Player takes damage
		}

	}
}


