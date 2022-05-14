using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TanksBattle.Tank
{
	public class Chase : TankState
	{
		public Chase(EnemyController enemy) : base(enemy)
		{
			name = STATE.CHASE;
		}

		public override void Enter()
		{
			base.Enter();
		}

		public override void Update()
		{
			if (player == null)
			{
				MoveToIdleState();
				return;
			}

			enemy.GetAgent().SetDestination(player.position);

			float distance = Vector3.Distance(
				enemy.GetPosition(), player.position);

			if (distance > 20)
			{
				MoveToIdleState();
			}
			else if (distance < 10)
			{
				nextState = new Shoot(enemy);
				stage = EVENT.EXIT;
			}
		}

		private void MoveToIdleState()
		{
			nextState = new Idle(enemy);
			stage = EVENT.EXIT;
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}