using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TankController
{
	public PlayerController(TankView tankView, TankTypeSO typeSO, Vector3 spawnPoint) 
		: base(tankView, typeSO, spawnPoint)
	{
	}

	public override void Movement(Vector3? direction)
	{
		if (direction == null)
			return;

		direction = RotateDirection(60 * 2, (Vector3)direction);
		base.Movement(direction);
	}

	private Vector3 RotateDirection(float angle, Vector3 dir)
	{
		dir = new Vector3(
			dir.x * Mathf.Cos(angle) + dir.z * Mathf.Sin(angle), 0,
			-dir.x * Mathf.Sin(angle) + dir.z * Mathf.Cos(angle));
		return dir;

	}
}
