using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFactory : MonoBehaviour
{
	[Header("Player")]
	public TankView playerTankPrefab;
	public Transform playerSpawn;
	
	[Header("Player")]
	public TankView enemyTank;
	public Transform[] enemySpawn;
	private int m_currentSpawn = 0;

	public List<TankTypeSO> tankTypes;
	
	private void Start()
	{
		SpawnPlayer();
		//SpawnEnemy();
	}

	private void SpawnPlayer()
	{
		new TankController(playerTankPrefab, tankTypes[0], playerSpawn.position);
	}
	
	public void SpawnEnemy()
	{
		new TankController(playerTankPrefab,
			tankTypes[Random.Range(0,tankTypes.Count)],
			enemySpawn[Random.Range(0,enemySpawn.Length)].position);

		m_currentSpawn = (m_currentSpawn + 1) % enemySpawn.Length;
	}
}