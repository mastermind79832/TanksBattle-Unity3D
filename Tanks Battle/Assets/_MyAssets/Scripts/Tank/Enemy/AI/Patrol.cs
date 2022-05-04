using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : TankState
{
	private Vector3 patrolPoint1;
	private Vector3 patrolPoint2;
	private Vector3 currentPoint;

	public Patrol(EnemyController enemy) : base(enemy)
	{
		name = STATE.PATROL;
	}

	public override void Enter()
	{
		patrolPoint1 = enemy.spawnPoint + enemy.GetAgent().transform.forward * 5;
		patrolPoint2 = enemy.spawnPoint - enemy.GetAgent().transform.forward * 5;	
		currentPoint = patrolPoint1;
		base.Enter();
	}

	public override void Update()
	{
		// Is player in Range
		float distance = Vector3.Distance(
			enemy.GetPosition(),
			player.position);
		if (distance < 15)
		{
			nextState = new Chase(enemy);
			stage = EVENT.EXIT;
			return;
		}

		enemy.GetAgent().SetDestination(currentPoint);
		if (Vector3.Distance(enemy.GetPosition(), patrolPoint1) < 0.5)
			currentPoint = patrolPoint2;

		if (Vector3.Distance(enemy.GetPosition(), patrolPoint2) < 0.5)
			currentPoint = patrolPoint1;
	}

	public override void Exit()
	{

		base.Exit();
	}
}
