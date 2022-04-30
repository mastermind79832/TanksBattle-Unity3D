using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoSingletonGeneric<CameraFollow>
{
    public Vector3 topBound;
    public Vector3 bottomBound;

    public void SetToPlayerPosition(Vector3 playerPos)
	{
        transform.position = 
            new Vector3(
                Mathf.Clamp(playerPos.x,bottomBound.x, topBound.x),
                0,
                Mathf.Clamp(playerPos.z, bottomBound.z, topBound.z));
	}
}
