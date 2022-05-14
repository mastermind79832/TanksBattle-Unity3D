using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksBattle.Core.Generic;
using TanksBattle.Tank;

namespace TanksBattle.Service.Tank
{
	public class TankService : MonoSingletonGeneric<TankService>
	{
		[SerializeField]
		private TankFactory tankFactory;

		public GameObject Player { get; private set; }
		public List<GameObject> Enemy { get; private set; }
		private void Start()
		{
			Enemy = new List<GameObject>();
			Player = tankFactory.SpawnPlayer();
			for (int i = 0; i < tankFactory.enemySpawn.Length; i++)
			{
				Enemy.Add(tankFactory.SpawnEnemy());
			}
		}

		// UI calls
		public Vector3? GetJoyDirection() => 
			UI.UIService.Instance.GetJoyMoveDirection();
		public bool IsFirePressed() =>
			UI.UIService.Instance.IsFirePressed();

		// Shell calls
		public void ShellFired(Transform firePoint, float mutiplier, float damage) =>
			Shell.ShellService.Instance.ShellFired(firePoint, mutiplier, damage);
	}
}
