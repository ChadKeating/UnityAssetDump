using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireGun : MonoBehaviour {
	
	public GameObject projectile;
	public AudioClip fireSound;

	private GameObject projectileClone;
	private AudioSource source;
	private float volLow = 0.5f;
	private float volHigh = 1.0f;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			float randVol = Random.Range(volLow, volHigh);
			source.PlayOneShot(fireSound, randVol);

			projectileClone = Instantiate(projectile, transform.position, transform.rotation ) as GameObject;
			projectileClone.rigidbody.AddForce(transform.up * 100, ForceMode.Impulse);
		}
	}
}
