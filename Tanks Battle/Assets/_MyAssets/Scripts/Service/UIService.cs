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

		[SerializeField]
		private AchivementNotification notification;

		[SerializeField]
		private ScoreDisplay scoreDisplay;

		private void OnEnable()
		{
			ServiceEvents.Instance.OnShellFired += SetShellShotCount;
			ServiceEvents.Instance.OnEnemyDeath += SetEnemyKillCount;
		}

		private void OnDisable()
		{
			ServiceEvents.Instance.OnShellFired += SetShellShotCount;
			ServiceEvents.Instance.OnEnemyDeath += SetEnemyKillCount;
		}

		public Vector3? GetJoyMoveDirection()=>
			joy.DragDirection;
		
		public bool IsFirePressed() =>
			joy.isFirePressed;

		public void SetShellShotCount(int count)
		{
			scoreDisplay.SetShotCount(count);
		}

		public void SetEnemyKillCount(int count)
		{
			scoreDisplay.SetKillCount(count);
		}

		public void ShowAchievement(string mainText, string subText)
		{
			notification.ShowAchievement(mainText, subText);
			Debug.Log("show ach");
		}
	}
}
