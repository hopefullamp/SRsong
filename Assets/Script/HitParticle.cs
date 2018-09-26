using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticle : MonoBehaviour {

	public ParticleSystem hitParticle;

	void Start () {
		Destroy(hitParticle.gameObject,hitParticle.duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
