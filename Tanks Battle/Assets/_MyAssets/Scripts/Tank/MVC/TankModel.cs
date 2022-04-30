public class TankModel 
{
	private TankController m_controller;
	private readonly TankTypeSO m_type;
	private float m_currentHealth;

	public TankModel(TankTypeSO typeSO, TankController controller)
	{
		m_type = typeSO;
		m_controller = controller;

		m_currentHealth = m_type.maxHealth;
	}

	public float GetSpeed() => m_type.speed;
}
