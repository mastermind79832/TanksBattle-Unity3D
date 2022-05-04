using System.Collections;
using UnityEngine;

public class TankController
{
	protected readonly TankView m_View;
	protected readonly TankModel m_Model;

	public TankController (TankView tankView, TankTypeSO typeSO, Vector3 spawnPoint)
	{
		m_Model = new TankModel(typeSO);

		m_View = Object.Instantiate(tankView);
		m_View.transform.position = spawnPoint;
		m_View.SetTankController(this);
		m_View.SetMaterial(m_Model.GetColor());
	}

	public void FireBullet(float velocityMutiplier)
	{
		Mathf.Clamp(velocityMutiplier, 0.5f, 1f);
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

	public virtual void Movement(Vector3? direction) { }
	public virtual void RunAI() { }
}
