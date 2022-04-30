using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStick : MonoSingletonGeneric<JoyStick>
{
    [Header("Joy Stick")]
    public RectTransform joyBase;
    public RectTransform joyHead;

	public Button fireButton;
	public bool isFirePressed;
	private bool m_IsMouseOverAnything;

    private Vector3 m_InitalJoyPos;
    private Vector3 m_FirstTouchPos;
    private Vector3 m_DragPos;
	private bool b_isFirstTouched = false;

	public Vector3? DragDirection { get; private set; }

	private void Start()
	{
		m_InitalJoyPos = joyBase.position;
	}
	private void Update()
    {
        TouchInput();
    }

	public void SetMouseOverAnything(bool enabled) => m_IsMouseOverAnything = enabled;
	public void SetFirePressed(bool enabled) => isFirePressed = enabled;

	private void TouchInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (m_IsMouseOverAnything)
				return;

			joyBase.gameObject.SetActive(true);
			m_FirstTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			joyBase.position = m_FirstTouchPos;
			b_isFirstTouched = true;
		}

		if (Input.GetMouseButton(0))
		{
			if (!b_isFirstTouched)
				return;

			m_DragPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
			Vector3 offset = m_DragPos - m_FirstTouchPos;
			offset = Vector3.ClampMagnitude(offset, joyBase.rect.width / 2);
			joyHead.position = joyBase.position + offset;

			DragDirection = new Vector3(offset.normalized.x, 0, offset.normalized.y);
		}

		if (Input.GetMouseButtonUp(0))
		{
			b_isFirstTouched = false;
			joyBase.position = m_InitalJoyPos;
			joyHead.position = m_InitalJoyPos;
			DragDirection = null;
		}
	}
}
