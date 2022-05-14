using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksBattle.Shell
{
	internal class ShellFactory : MonoBehaviour
	{
		[SerializeField]
		private ShellScript m_ShellPrefab;

		public void CreateBullet(Transform exitPoint, float mutiplier, float damage)
		{
			ShellScript newShell = Instantiate(m_ShellPrefab, exitPoint.transform.position, exitPoint.transform.rotation);
			newShell.SetVelocity(mutiplier);
			newShell.maxDamage = damage;
		}
	}
}