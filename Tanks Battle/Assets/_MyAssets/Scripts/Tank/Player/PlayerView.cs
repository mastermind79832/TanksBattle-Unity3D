using System;
using UnityEngine;
using UnityEngine.UI;
using TanksBattle.Tank.MVC;
using TanksBattle.Service.Tank;

namespace TanksBattle.Tank
{
	public class PlayerView : TankView
	{
		private TankService _service;

		protected Vector3? m_moveDirection;

		private bool m_IsLoading;
		private bool m_Fired = false;

		public Slider loader;
		private float LoadForce
		{
			get { return loader.value; }
			set
			{
				if (value < 0.3f)
					value = 0.3f;
				loader.value = value;
				loader.gameObject.SetActive(value != 0.3f);
			}
		}
		public Vector3? GetMoveDirection() => m_moveDirection;

		private void Awake()
		{
			_service = TankService.Instance;
		}

		private void FixedUpdate()
		{
			m_controller.Movement(m_moveDirection);
			SetCameraPosition();
		}

		private void Update()
		{
			GetInputFromJoy();
			GetFiringInput();
		}

		private void GetInputFromJoy()
		{
			m_moveDirection = _service.GetJoyDirection();
		}

		// Set camera to follow player
		private void SetCameraPosition()
		{
			CameraFollow.Instance.SetToPlayerPosition(transform.position);
		}

		public void FireBullet()
		{
			m_IsLoading = false;
			m_Fired = true;
			m_controller.FireShell(LoadForce);
			LoadForce = 0;
		}

		private void GetFiringInput()
		{
			if (Input.GetKey(KeyCode.Space) || _service.IsFirePressed() && !m_Fired)
			{
				m_IsLoading = true;
				// start loading cannon
				LoadForce += 0.6f * Time.deltaTime;
				if (LoadForce >= 1)
					FireBullet();
			}

			if (Input.GetKeyUp(KeyCode.Space) || !_service.IsFirePressed())
			{
				m_Fired = false;
				if (m_IsLoading)
					FireBullet();
			}

		}
	}
}