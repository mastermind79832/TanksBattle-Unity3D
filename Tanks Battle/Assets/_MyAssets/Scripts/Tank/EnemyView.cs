using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : TankView
{
	protected override void OnEnable()
	{
		base.OnEnable();
		onUpdate += CalculateDirection;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		onUpdate -= CalculateDirection;
	}

	private void CalculateDirection()
	{
		m_moveDirection = Vector3.forward;
	}
}
