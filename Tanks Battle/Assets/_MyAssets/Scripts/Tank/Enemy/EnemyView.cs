using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : TankView
{
	private void Update()
	{
		m_controller.RunAI();
	}
}

