using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView :  TankView
{
	private static PlayerView _instance;
	public static PlayerView Instance { get { return _instance; } }

	// Virtual Awake for Extendability
	protected virtual void Awake()
	{
		CreateInstance();
	}

	private void CreateInstance()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		onUpdate += GetInputFromJoy;
		onUpdate += SetCameraPosition;
		onUpdate += GetFiringInput;

		JoyStick.Instance.fireButton.onClick.AddListener(this.FireBullet);
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		onUpdate -= GetInputFromJoy;
		onUpdate -= SetCameraPosition;
		onUpdate -= GetFiringInput;
		JoyStick.Instance.fireButton.onClick.RemoveListener(this.FireBullet);
	}

	private void GetInputFromJoy()
	{
		m_moveDirection = JoyStick.Instance.DragDirection;
		if (m_moveDirection == null)
			return;

		RotateDirection(60*4);
	}

	// Rotating the vector 60deg to adjust to camera rotation
	private void RotateDirection(float angle)
	{
		Vector3 dir = (Vector3)m_moveDirection;
		dir = new Vector3(
			dir.x * MathF.Cos(angle) + dir.z * MathF.Sin(angle),0,
			-dir.x * MathF.Sin(angle) + dir.z * MathF.Cos(angle));
		m_moveDirection = dir;
	}
	
	// Set camera to follow player
	private void SetCameraPosition()
	{
		CameraFollow.Instance.SetToPlayerPosition(transform.position);
	}

	public void FireBullet()
	{
		m_controller.FireBullet(20);
	}

	private void GetFiringInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			FireBullet();
	}
}
