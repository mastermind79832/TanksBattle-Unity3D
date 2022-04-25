using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellScript : MonoBehaviour
{
    public ParticleSystem explosion;
	public AudioSource source;
	public Rigidbody rb;
	public float shellLifeTime = 5f;


	private void Start()
	{
		Invoke(nameof(Explode), shellLifeTime);
	}

	private void Explode()
	{
		explosion.transform.SetParent(null);
		explosion.transform.position = transform.position;
		explosion.transform.rotation = Quaternion.Euler(-90,0,0);
		explosion.Play();
		source.Play();
		Destroy(explosion.gameObject, 
			Mathf.Max(explosion.main.duration, source.clip.length));
		Destroy(gameObject);
	}

	private void Update()
	{
		transform.forward = rb.velocity;
	}

	private void OnCollisionEnter(Collision collision)
	{
		Explode();
	}
}
