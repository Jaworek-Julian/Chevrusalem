using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharacterStats : MonoBehaviour
{
    public float hp;
    public float hpMax;
    public float speed;
    public float speedRotation;

    [SerializeField] protected float attack;
    public void Attack(CharacterStats p_target)
    {
        p_target.hp -= this.attack;
        Debug.Log(p_target.hp);
    }
}
