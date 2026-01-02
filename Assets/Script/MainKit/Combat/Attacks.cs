using System;
using UnityEngine;

[Serializable]
public class Attacks
{
    [field: SerializeField] public string AttackAnimationName { get; set; }
    [field: SerializeField] public int AttackAnimationNextIndex { get; set; } = -1;
    [field: SerializeField] public int AttackDamage { get; set; }
    [field: SerializeField] public float AttackAnimationTime { get; set; } = .8f;

}
