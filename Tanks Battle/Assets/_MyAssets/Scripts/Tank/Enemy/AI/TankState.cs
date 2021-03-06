using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksBattle.Service.Tank;

namespace TanksBattle.Tank
{
	public class TankState
	{
		public enum STATE
		{
			IDLE,
			PATROL,
			CHASE,
			SHOOT
		}

		public enum EVENT
		{
			ENTER,
			UPDATE,
			EXIT
		}

		protected STATE name;
		protected EVENT stage;

		protected TankState nextState;
		protected EnemyController enemy;
		protected Transform player;

		public TankState(EnemyController enemy)
		{
			this.enemy = enemy;
			stage = EVENT.ENTER;
			if(TankService.Instance.Player != null)
				player = TankService.Instance.Player.transform;
		}

		public virtual void Enter() { stage = EVENT.UPDATE; }
		public virtual void Update() { stage = EVENT.UPDATE; }
		public virtual void Exit() { stage = EVENT.EXIT; }

		public TankState Process()
		{
			if (stage == EVENT.ENTER) Enter();
			if (stage == EVENT.UPDATE) Update();
			if (stage == EVENT.EXIT)
			{
				Exit();
				return nextState;
			}
			return this;
		}
	}
}