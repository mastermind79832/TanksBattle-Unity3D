 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TanksBattle.Tank.MVC;

namespace TanksBattle.Tank
{
	public class EnemyController : TankController
	{
		private TankState _currentState;
		public Vector3 spawnPoint;

		public EnemyController(TankView tankView, TankTypeSO typeSO, Vector3 spawnPoint)
			: base(tankView, typeSO, spawnPoint)
		{
			_currentState = new Idle(this);
			GetAgent().speed = m_Model.GetSpeed() / 2;
			this.spawnPoint = spawnPoint;
		}

		public NavMeshAgent GetAgent() => m_View.GetComponent<NavMeshAgent>();
		public override void RunAI() => _currentState = _currentState.Process();
		public Vector3 GetPosition() => m_View.transform.position;
		public Transform GetFirePoint() => m_View.firePoint;
	}
}