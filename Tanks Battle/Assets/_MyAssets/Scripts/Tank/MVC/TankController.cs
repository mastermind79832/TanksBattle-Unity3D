using System.Collections;
using UnityEngine;
using TanksBattle.Service.Tank;

namespace TanksBattle.Tank.MVC
{
	public class TankController
	{
		protected readonly TankView m_View;
		protected readonly TankModel m_Model;

		public TankController(TankView tankView, TankTypeSO typeSO, Vector3 spawnPoint)
		{
			m_Model = new TankModel(typeSO);

			m_View = Object.Instantiate(tankView);
			m_View.transform.position = spawnPoint;
			m_View.SetTankController(this);
			m_View.SetMaterial(m_Model.GetColor());
		}

		public void FireShell(float velocityMutiplier)
		{
			Mathf.Clamp(velocityMutiplier, 0.5f, 1f);
			TankService.Instance.ShellFired(m_View.firePoint, velocityMutiplier, m_Model.GetDamage());
		}

		public void TakeDamage(float value)
		{
			m_Model.currentHealth -= value;
			Debug.Log(m_Model.currentHealth);
			m_View.SetHealthBar(m_Model.currentHealth / m_Model.GetMaxHealth());

			if (m_Model.currentHealth <= 0)
			{
				m_View.PlayerDead();
			}
		}

		public virtual void Movement(Vector3? direction) { }
		public virtual void RunAI() { }

		public GameObject GetGameobject() => m_View.gameObject;
	}
}
