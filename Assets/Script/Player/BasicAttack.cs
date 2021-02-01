using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    Animator m_animator;
    StatPlayer m_PlayerStat;

    // charge animation
    bool m_isCharging = false;
    float m_chargeCounter = 0;

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_PlayerStat = GetComponent<StatPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_animator.SetTrigger("Attack");
        }
        else if(Input.GetMouseButtonDown(1) || m_isCharging == true)
        {
                AnimationCharge(ref m_PlayerStat.m_moveSpeed);
                Debug.Log(m_PlayerStat.m_moveSpeed);
        }
    }


    // we take the movement speed of the character to up it
    void AnimationCharge(ref float p_move)
    {
        m_isCharging = true;
        m_chargeCounter += Time.deltaTime;

        p_move *= 2;
        m_animator.SetTrigger("Charge");
        
    }
}
