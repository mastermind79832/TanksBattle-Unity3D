using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoSingletonGeneric<JoyStick>
{
    [Header("Joy Stick")]
    public RectTransform joyBase;
    public RectTransform joyHead;

    private Vector3 m_InitalJoyPos;
    private Vector3 m_FirstTouchPos;
    private Vector3 m_DragPos;

	public Vector3 dragDirection { get; private set; }

	private void Start()
	{
		m_InitalJoyPos = joyBase.position;
	}
	private void Update()
    {
        TouchInput();
    }

	private void TouchInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			joyBase.gameObject.SetActive(true);
			m_FirstTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			joyBase.position = m_FirstTouchPos;
		}

		if (Input.GetMouseButton(0))
		{
			m_DragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			Vector3 offset = m_DragPos - m_FirstTouchPos;
			offset = Vector3.ClampMagnitude(offset, joyBase.rect.width / 2);
			joyHead.position = joyBase.position + offset;

			dragDirection = new Vector3(offset.normalized.x, 0, offset.normalized.y);
		}

		if (Input.GetMouseButtonUp(0))
		{
			joyBase.position = m_InitalJoyPos;
			joyHead.position = m_InitalJoyPos;
			dragDirection = Vector3.zero;
		}
	}
}
