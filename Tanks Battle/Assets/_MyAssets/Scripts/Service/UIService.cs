using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksBattle.Core.Generic;
using TanksBattle.UI;

namespace TanksBattle.Service.UI
{
	public class UIService : MonoSingletonGeneric<UIService>
	{
		[SerializeField]
		private JoyStick joy;
		
		public Vector3? GetJoyMoveDirection()=>
			joy.DragDirection;
		
		public bool IsFirePressed() =>
			joy.isFirePressed;
	}
}
