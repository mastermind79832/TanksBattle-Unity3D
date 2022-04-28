using System.Collections;
using UnityEngine;

public class TankController
{
	private readonly TankView m_View;
	private readonly TankModel m_Model;

	public TankController (TankView tankView, TankTypeSO typeSO, Vector3 spawnPoint)
	{
		m_Model = new TankModel(typeSO);

		m_View = Object.Instantiate(tankView);
		m_View.transform.position = spawnPoint;
		m_View.SetTankController(this);
		m_View.SetMaterial(m_Model.GetColor());
	}

	public virtual void Movement(Vector3? direction)
	{
		m_View.GetRigidbody().rotation = Quaternion.LookRotation((Vector3)direction);
		m_View.GetRigidbody().velocity = m_View.transform.forward * m_Model.GetSpeed();
	}

	public void FireBullet(float velocityMutiplier)
	{
		ShellScript shell = ShellFactory.Instance.CreateBullet(m_View.firePoint);
		shell.maxDamage = m_Model.GetDamage();
		shell.SetVelocity(velocityMutiplier);
	}

	public void TakeDamage(float value)
	{
		m_Model.currentHealth -= value;
		Debug.Log(m_Model.currentHealth);
		m_View.SetHealthBar(m_Model.currentHealth / m_Model.GetMaxHealth());

		if(m_Model.currentHealth <= 0)
		{
			m_View.PlayerDead();
		}
	}
}
