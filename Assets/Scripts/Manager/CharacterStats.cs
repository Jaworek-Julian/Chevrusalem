using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharacterStats : MonoBehaviour
{
    public float hp;
    public float mpMax;
    public float speed;
    public float speedRotation;

    [SerializeField] protected float attack;
    void Attack(CharacterStats p_target)
    {
        p_target.hp -= this.attack;
    }
}
