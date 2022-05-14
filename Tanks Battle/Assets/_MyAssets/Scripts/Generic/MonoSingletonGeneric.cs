using System.Collections.Generic;
using UnityEngine;

namespace TanksBattle.Core.Generic
{
	public class MonoSingletonGeneric<T> : MonoBehaviour where T: MonoSingletonGeneric<T>
	{
		private static T _instance;
		public static T Instance { get { return _instance; } }

		// Virtual Awake for Extendability
		protected virtual void Awake()
		{
			CreateInstance();
		}

		private void CreateInstance()
		{
			if (_instance == null)
			{
				_instance = (T)this;
			}
			else
			{
				Destroy(this);
			}
		}
	}
}