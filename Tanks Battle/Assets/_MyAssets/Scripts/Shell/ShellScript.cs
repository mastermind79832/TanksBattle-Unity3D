using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{
    public ParticleSystem explosion;
	public AudioSource source;
	public Rigidbody rb;
	public float maxVelocity = 20f;	
	public float shellLifeTime = 5f;
	public float explosionRadius = 5f;
	public float explosionForce = 1000f;
	public float maxDamage = 5f;
	public LayerMask tankMask;			// To detect explosion hit only on tanks

	private void Start()
	{
		// just precaution, if the shell didnt hit anything
		// it'll still explode after lifetime
		Invoke(nameof(Explode), shellLifeTime);
	}
	//Setter
	public void SetVelocity(float multiplier) => rb.velocity = multiplier * maxVelocity * transform.forward;
	private void Explode()
	{
		SetDamageToNearbyTanks();
		SetOffExplosion();
		Destroy(gameObject);
	}

	private void SetDamageToNearbyTanks()
	{
		// Finds all tanks in the overlapsed radius
		Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

		for (int i = 0; i < colliders.Length; i++)
		{
			TankView tankView = colliders[i].GetComponent<TankView>();
			if (tankView != null)
			{
				tankView.GetRigidbody().AddExplosionForce(explosionForce,transform.position,explosionRadius);
				tankView.TakeDamage(CalcualteDamage(tankView.transform.position));
			}
		}
	}

	// returns damage base on the tank distance from the explosion center
	private float CalcualteDamage(Vector3 tankPos)
	{
		float explosionDist = (tankPos - transform.position).magnitude;
		float unitDist = (explosionRadius - explosionDist) / explosionRadius;
		float damage = unitDist * maxDamage;
		return damage;
	}

	private void SetOffExplosion()
	{
		//Unparenting so that destroying gamobjec will not destroy explosion and sound effect
		explosion.transform.SetParent(null);
		explosion.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(-90, 0, 0));

		explosion.Play();
		source.Play();

		Destroy(explosion.gameObject,
			Mathf.Max(explosion.main.duration, source.clip.length));
	}

	private void Update()
	{
		transform.forward = rb.velocity;
	}

	private void OnCollisionEnter(Collision collision) => Explode();

}