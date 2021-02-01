using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Stat : MonoBehaviour
{
    [SerializeField] private float m_hp;
    [SerializeField] private float m_att;
    [SerializeField] public float m_moveSpeed;
    public bool m_isInvincible = false; 
    public bool m_canMove = false;

    public void Attack(Stat p_target)
     {
         if (p_target.m_isInvincible == false)
         {
             p_target.m_hp -= m_att;
         }
     } 
}
