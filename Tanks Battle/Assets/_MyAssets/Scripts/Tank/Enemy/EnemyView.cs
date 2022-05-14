using System;
using System.Collections.Generic;
using UnityEngine;
using TanksBattle.Tank.MVC;
public class EnemyView : TankView
{
	private void Update()
	{
		m_controller.RunAI();
	}
}

