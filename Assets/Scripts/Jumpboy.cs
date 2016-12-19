using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpboy : MonoBehaviour {

	void Update () {


		Vector3 dir = Vector3.zero;
		// dir.x = Input.acceleration.x;
		dir.y=-Input.acceleration.x;
		dir.y = Input.acceleration.y;
		dir.x = Input.acceleration.y;


		if (dir.sqrMagnitude > 1)
			dir.Normalize();

		dir *= Time.deltaTime;
		transform.Translate(dir * 5);

	}
}
