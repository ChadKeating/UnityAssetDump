using UnityEngine;
using System.Collections;

public class BulletHit : MonoBehaviour {

	public GameObject onHitObject;

	void Start() {
		Destroy(this.gameObject, 5);
	}

	void OnCollisionEnter(Collision collision)
	{
		Instantiate(onHitObject, collision.contacts[0].point, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
