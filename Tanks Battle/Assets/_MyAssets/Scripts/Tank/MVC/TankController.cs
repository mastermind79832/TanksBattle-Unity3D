using System.Collections;
using UnityEngine;

public class TankController
{
	private TankView m_view;
	private	TankModel m_model;

	public TankController (TankView tankView, TankTypeSO typeSO, Vector3 spawnPoint)
	{
		m_view = Object.Instantiate(tankView);
		m_view.transform.position = spawnPoint;
		m_view.SetTankController(this);

		m_model = new TankModel(typeSO,this);
	}

	public void Movement()
	{
		Vector3 direction = m_view.GetMoveDirection();
		if (direction == Vector3.zero)
			return;

		//m_view.transform.position += m_model.GetSpeed() * Time.deltaTime * new Vector3(direction.x,0,direction.y);
		m_view.GetRigidbody().rotation = Quaternion.LookRotation(direction);
		m_view.GetRigidbody().velocity = m_view.transform.forward * m_model.GetSpeed();
	}

	public void FireBullet()
	{

	}
}
