using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : TankView
{
	private void CalculateDirection()
	{
		m_moveDirection = Vector3.forward;
	}

}
