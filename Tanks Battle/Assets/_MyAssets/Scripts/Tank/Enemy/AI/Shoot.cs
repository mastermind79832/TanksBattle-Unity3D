using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : TankState
{
	private float fireRate = 1.5f;
	private float firePointHeight;
	private float firePointAngle;
	private float maxBulletVelocity;
	private float bulletVelocityFactor;
	private float timer;

	public Shoot(EnemyController enemy) : base(enemy)
	{
		timer = 0;
		enemy.GetAgent().isStopped = true;
		firePointHeight = enemy.GetFirePoint().position.y;
		firePointAngle = enemy.GetFirePoint().rotation.x;
		maxBulletVelocity = ShellFactory.Instance.shellPrefab.GetComponent<ShellScript>().maxVelocity;
	}
	public override void Enter()
	{
		base.Enter();
	}

	public override void Update()
	{
		float distance = Vector3.Distance(
			enemy.GetPosition(), player.position);
		if(distance > 15)
		{
			nextState = new Chase(enemy);
			stage = EVENT.EXIT;
		}
		else
		{
			timer += Time.deltaTime;
			enemy.GetAgent().transform.LookAt(player.position);
			if(timer >= fireRate)
			{
				enemy.FireBullet(CalculateVelocityFactor(distance));
				timer = 0;
			}
		}
	}

	private float CalculateVelocityFactor(float distance)
	{
		/* V0y = V0 * Sin(angle)
		* V0x = V0 * Cos(angle)
		* x = distance
		* x0 = 0
		* y = 0
		* y0 = height
		* gravity(g) = -9.8
		* 
		* for Horizontal component
		* x = x0 + V0x*t + 0
		* distance = 0 + V0*Cos(angle)*t
		* => t = distance / (V0*Cos(angle)) 
		* 
		* for vertical component
		* y = y0 + V0y*t + (1/2)*g*t^2
		* 0 = height + V0*Sin(angle)*t + (1/2)*-9.8*t^2
		* substituting for t
		* => 0 = height + V0*Sin(angle)*(distance / (V0*Cos(angle))) + (1/2)*-9.8*(distance / (V0*Cos(angle)))^2
		* 0 = height + tan(angle) * distance - (1/2)*9.8*distance^2 / (V0*Cos(angle))^2
		* (1/2)*9.8*distance^2 / (V0*Cos(angle))^2 = height + tan(angle) * distance
		* 1 / (V0*Cos(angle))^2 = (height + tan(angle) * distance) / (1/2)*9.8*distance^2
		* (V0*Cos(angle))^2 = (1/2)*9.8*distance^2 / (height + tan(angle) * distance)
		* V0 = sqrt((1/2)*9.8*distance^2 / ((height + tan(angle) * distance) * cos(angle)^2))
		* factor = V0 / V0max
		*/
		float a = MathF.Pow(distance, 2);
		float b = MathF.Pow(MathF.Cos(firePointAngle), 2);
		float c = (firePointHeight + MathF.Tan(firePointAngle) * distance) * b;
		//float bulletVelocity = MathF.Sqrt((float)((1 / 2) * 9.8 * MathF.Pow(distance,2) / ((firePointHeight + MathF.Tan(firePointAngle) * distance) * MathF.Pow(MathF.Cos(firePointAngle),2))));
		float bulletVelocity = MathF.Sqrt(a/c);
		bulletVelocityFactor = bulletVelocity / maxBulletVelocity;
		Debug.Log("FireFactor " + bulletVelocity);
		return bulletVelocityFactor;
	}

	public override void Exit()
	{
		enemy.GetAgent().isStopped = false;
		base.Exit();
	}
}
