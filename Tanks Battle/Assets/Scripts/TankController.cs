using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankController : MonoSingletonGeneric<TankController>
{
    [Header("Joy Stick")]
    public RectTransform joyBase;
    public RectTransform joyHead;

    private Vector3 _InitalJoyPos;

    private Vector3 _FirstTouchPos;
    private Vector3 _DragPos;

    [Header("Tank Properties")]
    private Vector3 _Direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _InitalJoyPos = joyBase.position;
		_Direction = Vector3.zero;
	}

    // Update is called once per frame
    void Update()
	{
		TouchInput();
	}

	private void FixedUpdate()
	{
		if (_Direction != Vector3.zero)
		{
			float angle = Mathf.Atan2(_Direction.x, _Direction.z) * Mathf.Rad2Deg;

			transform.rotation = Quaternion.Euler(0, angle + 60, 0);
			transform.position += transform.forward * speed * _Direction.magnitude * Time.deltaTime;		
		}
	}

	private void TouchInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			joyBase.gameObject.SetActive(true);
			_FirstTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			joyBase.position = _FirstTouchPos;
		}

		if (Input.GetMouseButton(0))
		{
			_DragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			Vector3 offset = _DragPos - _FirstTouchPos;
			offset = Vector3.ClampMagnitude(offset, joyBase.rect.width / 2);
			joyHead.position = joyBase.position + offset;

			_Direction = new Vector3(offset.normalized.x, 0, offset.normalized.y);
		}

		if (Input.GetMouseButtonUp(0))
		{
			joyBase.position = _InitalJoyPos;
			joyHead.position = _InitalJoyPos;
			_Direction = Vector3.zero;
		}
	}
}
