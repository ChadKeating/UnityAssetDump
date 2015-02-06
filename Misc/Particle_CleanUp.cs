using UnityEngine;
using System.Collections;
//Self Destruction for one shot particle systems
public class Particle_CleanUp : MonoBehaviour
{
	ParticleSystem oneShotSystem;
	void Start()
	{
		oneShotSystem = GetComponent<ParticleSystem>();
	}
	void Update()
	{
		if (oneShotSystem)
		{
			if (!oneShotSystem.IsAlive())
			{
				Destroy(this.gameObject);
			}
		}
	}
}
