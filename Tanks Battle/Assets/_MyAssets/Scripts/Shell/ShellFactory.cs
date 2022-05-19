using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TanksBattle.Shell
{
	internal class ShellFactory : MonoBehaviour
	{
		[SerializeField]
		private ShellScript m_ShellPrefab;

		public ShellScript CreateBullet()
		{
			return Instantiate(m_ShellPrefab);
		}
	
	}
}