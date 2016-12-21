using UnityEngine;
using System.Collections;

public class destroyParticleAfterFinish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, GetComponent<ParticleSystem>().duration); 
	}
	
}
