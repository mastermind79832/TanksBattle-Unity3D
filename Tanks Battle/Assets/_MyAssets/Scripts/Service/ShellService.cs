using System;
using UnityEngine;
using TanksBattle.Core.Generic;
using TanksBattle.Shell;

namespace TanksBattle.Service.Shell
{
	public class ShellService : MonoSingletonGeneric<ShellService>
	{
		[SerializeField]
		private ShellFactory shellFactory;

		private ObjectPool<ShellScript> shellPool;
		private int playerShellFiredCount = 0;

		private void Start()
		{
			shellPool = new ObjectPool<ShellScript>();
		}

		public void ShellFired(Transform exitPoint, float mutiplier, float damage)
		{
			ShellScript shell = shellPool.GetItem();
			if(shell == default(ShellScript))
			{
				shell = shellFactory.CreateBullet();
				shellPool.NewItem(shell);
			}

			shell.SetShellProperties(exitPoint, mutiplier, damage);
		}

		public void PlayerFiredShell()
		{
			playerShellFiredCount++;
			ServiceEvents.Instance.OnShellFired?.Invoke(playerShellFiredCount);
		}

		internal void FreeShell(ShellScript shell)
		{
			shellPool.FreeItem(shell);
		}
	}
}