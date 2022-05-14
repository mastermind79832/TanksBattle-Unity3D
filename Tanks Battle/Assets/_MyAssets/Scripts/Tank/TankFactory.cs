using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksBattle.Tank.MVC;

namespace TanksBattle.Tank
{
	internal class TankFactory : MonoBehaviour
	{
		[Header("Player")]
		public TankView playerTankPrefab;
		public Transform playerSpawn;

		[Header("Enemy")]
		public EnemyView enemyTankPrefab;
		public Transform[] enemySpawn;
		private int m_currentSpawn = 0;

		public List<TankTypeSO> tankTypes;

		public GameObject SpawnPlayer()
		{
			PlayerController player = new PlayerController(playerTankPrefab, tankTypes[Random.Range(0, tankTypes.Count)], playerSpawn.position);
			return player.GetGameobject();
		}

		public GameObject SpawnEnemy()
		{
			EnemyController enemy =
			new EnemyController(enemyTankPrefab,
				tankTypes[Random.Range(0, tankTypes.Count)],
				enemySpawn[m_currentSpawn].position);

			m_currentSpawn = (m_currentSpawn + 1) % enemySpawn.Length;
			return enemy.GetGameobject();
		}
	}
}