using System;
using UnityEngine;

public enum TankTypes
{
	Normal  = 0,
    Heavy   = 1,
    Light   = 2
}

[CreateAssetMenu(menuName = "Create Tank Type", fileName ="NewTankType")]
public class TankTypeSO : ScriptableObject
{
    [Header("Properties")]
    public TankTypes tankType;
    public float maxHealth;

    [Header("Movement")]
    public float speed;

    [Header("Power")]
    public float damage;
    public float range;

    [Header("Drops")]
    public float points;

    [Header("material")]
    public Material color;
}
