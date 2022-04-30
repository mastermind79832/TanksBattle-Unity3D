using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellFactory : MonoSingletonGeneric<ShellFactory>
{
    public ShellScript shellPrefab;

    public ShellScript CreateBullet(Transform exitPoint)
	{
		ShellScript newShell = Instantiate(shellPrefab, exitPoint.transform.position, exitPoint.transform.rotation);

		return newShell;
	}
}
