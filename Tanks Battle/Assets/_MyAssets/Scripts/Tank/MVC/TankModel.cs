using UnityEngine;
public class TankModel 
{
	public TankTypeSO m_type;
	public float currentHealth;

	public TankModel(TankTypeSO typeSO)
	{
		m_type = typeSO;
		currentHealth = m_type.maxHealth;
	}

	public float GetSpeed() => m_type.speed;
	public Material GetColor() => m_type.color;
	public float GetMaxHealth() => m_type.maxHealth;	
	public float GetDamage() => m_type.damage;
}
