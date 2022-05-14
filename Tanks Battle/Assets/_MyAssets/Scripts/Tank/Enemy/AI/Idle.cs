using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksBattle.Tank
{
	public class Idle : TankState
	{
		public Idle(EnemyController enemy) : base(enemy)
		{
			name = STATE.IDLE;
		}

		public override void Enter()
		{
			base.Enter();
		}

		public override void Update()
		{
			// If player in Range
			// Chase
			if (player != null)
			{
				float distance = Vector3.Distance(
					enemy.GetPosition(),
					player.position);
				if (distance < 15)
				{
					nextState = new Chase(enemy);
					stage = EVENT.EXIT;
					return;
				}
			}
			// If enemy not in its original positon
			// Go back to original position
			if (Vector3.Distance(enemy.GetPosition(), enemy.spawnPoint) > 0.5)
			{
				enemy.GetAgent().SetDestination(enemy.spawnPoint);
			}
			else
			{
				// 10 in 5000 chance that enemy goes to Patrol state
				if (Random.Range(0, 5000) < 10)
				{
					nextState = new Patrol(enemy);
					stage = EVENT.EXIT;
				}
			}
		}

		public override void Exit()
		{

			base.Exit();
		}
	}
}