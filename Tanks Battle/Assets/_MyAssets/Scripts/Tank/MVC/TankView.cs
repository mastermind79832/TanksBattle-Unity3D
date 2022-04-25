using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    protected TankController m_controller;
    protected Vector3 m_moveDirection;

    public Image healthBar;
    public Rigidbody rb;

    public delegate void OnUpdate();
    protected OnUpdate onUpdate;
    public delegate void OnFixedUpdate();
    protected OnFixedUpdate onFixedUpdate;

    //Setter
    public void SetTankController(TankController controller) => m_controller = controller;
    public void SetHealthBar(float value) => healthBar.fillAmount = value;

    //Getter
    public Vector3 GetMoveDirection() => m_moveDirection;
    public Rigidbody GetRigidbody() => rb;

	protected virtual void OnEnable()
	{
        onFixedUpdate += MoveTank;
        print("Added");
	}

	protected virtual void OnDisable()
	{
        onFixedUpdate -= MoveTank;
        print("removed fixed");
    }

    private void MoveTank()
	{
        m_controller.Movement();
    }

    void FixedUpdate() => onFixedUpdate?.Invoke();
    void Update() => onUpdate?.Invoke();
    
}
