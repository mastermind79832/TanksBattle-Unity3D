using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFactory : MonoBehaviour
{
	[Header("Player")]
	public TankView playerTankPrefab;
	public Transform playerSpawn;
	
	[Header("Enemy")]
	public EnemyView enemyTankPrefab;
	public Transform[] enemySpawn;
	private int m_currentSpawn = 0;

	public List<TankTypeSO> tankTypes;
	
	private void Start()
	{
		SpawnPlayer();
		for (int i = 0; i < 3; i++)
		{
			SpawnEnemy();
		}
	}

	private void SpawnPlayer()
	{
		new PlayerController(playerTankPrefab, tankTypes[Random.Range(0,tankTypes.Count)], playerSpawn.position);
	}
	
	public void SpawnEnemy()
	{
		new EnemyController(enemyTankPrefab,
			tankTypes[Random.Range(0,tankTypes.Count)],
			enemySpawn[m_currentSpawn].position);

		m_currentSpawn = (m_currentSpawn + 1) % enemySpawn.Length;
	}
}