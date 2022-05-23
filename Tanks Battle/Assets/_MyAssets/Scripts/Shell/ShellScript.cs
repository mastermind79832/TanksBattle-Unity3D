using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksBattle.Core.Interface;
using TanksBattle.Service.Shell;

namespace TanksBattle.Shell
{
	internal class ShellScript : MonoBehaviour
	{
		public ParticleSystem explosion;
		public AudioSource source;
		public Rigidbody shellBody;
		public MeshRenderer shellMesh;
		public Collider shellCollider;
		public float maxVelocity = 20f;
		public float shellLifeTime = 5f;
		public float explosionRadius = 5f;
		public float explosionForce = 1000f;
		public float maxDamage = 5f;
		public LayerMask tankMask;          // To detect explosion hit only on tanks

		private bool exploded = false;
		private ShellService service;

		private void Start()
		{
			service = ShellService.Instance;
		}
		//Setter
		public void SetVelocity(float factor) => shellBody.velocity = factor * maxVelocity * transform.forward;

		public void SetShellProperties(Transform exitPoint, float mutiplier, float damage)
		{
			SetShellActive(true);
			transform.SetPositionAndRotation(exitPoint.position, exitPoint.rotation);
			SetVelocity(mutiplier);
			maxDamage = damage;

			// just precaution, if the shell didnt hit anything
			// it'll still explode after lifetime
			exploded = false;
			Invoke(nameof(Explode), shellLifeTime);
		}

		private void Explode()
		{
			if(exploded)
				return;
			exploded = true;
			SetShellActive(false); ;
			GiveDamageToNearbyDamageable();
			SetOffExplosion();
		}

		private void SetShellActive(bool active)
		{
			shellMesh.enabled = active;
			shellCollider.enabled = active;
		}

		private void GiveDamageToNearbyDamageable()
		{
			// Finds all tanks in the overlapsed radius
			Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, tankMask);

			for (int i = 0; i < colliders.Length; i++)
			{
				IDamageable damageable = colliders[i].GetComponent<IDamageable>();
				if (damageable != null)
				{
					damageable.TakeDamage(CalcualteDamage(colliders[i].transform.position));
					Rigidbody rb = colliders[i].GetComponent<Rigidbody>();
					if (rb != null)
						rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
				}
			}
		}

		// returns damage base on the tank distance from the explosion center
		private float CalcualteDamage(Vector3 tankPos)
		{
			float explosionDist = (tankPos - transform.position).magnitude;
			float unitDist = (explosionRadius - explosionDist) / explosionRadius;
			float damage = unitDist * maxDamage;
			if (damage < 0)
				damage = 0;
			return damage;
		}

		private void SetOffExplosion()
		{
			explosion.transform.SetPositionAndRotation(transform.position, Quaternion.Euler(-90, 0, 0));

			explosion.Play();
			source.Play();

			float waitTime = Mathf.Max(explosion.main.duration, source.clip.length);
			StartCoroutine(FreeItemToPool(waitTime));
		}

		IEnumerator FreeItemToPool(float waitTime)
		{
			yield return new WaitForSeconds(waitTime);
			service.FreeShell(this);
		}

		private void Update()
		{
			transform.forward = shellBody.velocity;
		}

		private void OnCollisionEnter(Collision collision) => Explode();

	}
}