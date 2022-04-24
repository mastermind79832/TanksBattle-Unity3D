using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFactory : MonoBehaviour
{
	[Header("Player")]
	public TankView playerTankPrefab;
	public Transform playerSpawn;
	
	public List<TankTypeSO> tankTypes;

	//Enemy
	//public TankView enemyTank;

	private void Start()
	{
		new TankController(playerTankPrefab, tankTypes[0], playerSpawn.position);
	}

}
