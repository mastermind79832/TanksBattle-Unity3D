using System;
using System.Collections.Generic;
using UnityEngine;
using TanksBattle.Tank.MVC;
using TanksBattle.Service.Tank;

namespace TanksBattle.Tank
{
	public class EnemyView : TankView
	{
		private void Update()
		{
			m_controller.RunAI();
		}

		public override void TankDeath()
		{
			base.TankDeath();
			TankService.Instance.EnemyDeath();
		}
	}

}