using System;
using UnityEngine;
using TanksBattle.Core.Generic;
using TanksBattle.Shell;

namespace TanksBattle.Service.Shell
{
	public class ShellService : MonoSingletonGeneric<ShellService>
	{
		[SerializeField]
		private ShellFactory ShellFactory;

		public void ShellFired(Transform exitPoint,float mutiplier, float damage) => 
			ShellFactory.CreateBullet(exitPoint,mutiplier,damage);
	}
}