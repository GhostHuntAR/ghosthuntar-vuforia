using UnityEngine;
using System.Collections;

public class touchManager : MonoBehaviour {

	public GameObject explosion;
	public AudioClip explosionSoundClip;
	public float fireRate = 0.25f;
	
	AudioSource explosionSound;

	private float nextFire = 0f;

	// Use this for initialization
	void Start () {
		explosionSound = GetComponent<AudioSource>();
		explosionSound.mute = true;
		//explosionSound.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButton(0) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate; 

			Vector3 mousePosFar = new Vector3(Input.mousePosition.x,
											Input.mousePosition.y,
											Camera.main.farClipPlane);
			Vector3 mousePosNear = new Vector3(Input.mousePosition.x,
											Input.mousePosition.y,
											Camera.main.nearClipPlane);
			// translates the screen pos into game world positions
			Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
			Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
			Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.green);

			RaycastHit hit; // reports back if we hit an object

			if (Physics.Raycast(mousePosN, mousePosF - mousePosN, out hit)) 
			{
				Debug.Log("You hit someting");
				//Debug.Log(hit.transform.gameObject);
				//Debug.Log(hit.transform);

				Instantiate(explosion, hit.transform.position, Quaternion.identity);
				//explosionSound.Play();
				//AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
				AudioSource.PlayClipAtPoint(explosionSoundClip, hit.transform.position);

				Destroy(hit.transform.gameObject);

			}
		}

	}
}
