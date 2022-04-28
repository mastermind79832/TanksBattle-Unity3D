using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : TankController
{
	public EnemyController(TankView tankView, TankTypeSO typeSO, Vector3 spawnPoint) 
		: base(tankView, typeSO, spawnPoint)
	{
	}
}
