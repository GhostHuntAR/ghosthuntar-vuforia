using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

	// Use this for initializat
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Input.acceleration.x, Input.acceleration.y, Input.acceleration.z);

	}
}
