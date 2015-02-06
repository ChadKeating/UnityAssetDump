using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
	
	}

	float delayCounter = 0;
	// Update is called once per frame
	void Update () {
		delayCounter += Time.deltaTime;
		if(delayCounter < 1){
		return;
		}else{
		delayCounter = 0;
		}

		Vector3 enemyPosition = transform.position + new Vector3(Random.Range(-10f, 10f), 0, 0);
		Instantiate(enemy, enemyPosition, transform.rotation);
	}
}
