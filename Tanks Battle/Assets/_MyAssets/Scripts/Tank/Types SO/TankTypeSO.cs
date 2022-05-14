using System;
using UnityEngine;

namespace TanksBattle.Tank
{
    public enum TANKTYPES
    {
        NORMAL = 0,
        HEAVY = 1,
        LIGHT = 2
    }

    [CreateAssetMenu(menuName = "Create Tank Type", fileName = "NewTankType")]
    public class TankTypeSO : ScriptableObject
    {
        [Header("Properties")]
        public TANKTYPES tankType;
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
}