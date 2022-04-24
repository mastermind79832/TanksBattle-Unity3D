using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView :  TankView
{
	protected override void OnEnable()
	{
		base.OnEnable();
		onUpdate += GetInputFromJoy;
		onUpdate += SetCameraPosition;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		onUpdate -= GetInputFromJoy;
		onUpdate -= SetCameraPosition;
	}

	private void GetInputFromJoy()
	{
		m_moveDirection = JoyStick.Instance.dragDirection;
	}

	private void SetCameraPosition()
	{
		CameraFollow.Instance.SetToPlayerPosition(transform.position);
	}
}
