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

		private int ShellFiredCount = 0;

		public void ShellFired(Transform exitPoint, float mutiplier, float damage)
		{
			ShellFactory.CreateBullet(exitPoint, mutiplier, damage);
			ShellFiredCount++;
			ServiceEvents.Instance.OnShellFired?.Invoke(ShellFiredCount);
		}
	}
}