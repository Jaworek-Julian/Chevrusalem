using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAnimator : PlayerManager
{
    private PlayerLocomotion m_playerLocomotion;
    private PlayerStats m_playerStats;
    private PlayerAtk m_playerAtk;
    private Rigidbody rb;

    int m_atkCombo = 0;

    Animator m_anim;
    AnimatorClipInfo[] m_CurrentClipInfo;
    // m_PlayerAtk m_playerAtk;

    private void Awake()
    {
        m_playerLocomotion = GetComponent<PlayerLocomotion>();
        m_playerStats = GetComponent<PlayerStats>();
        m_playerAtk = GetComponent<PlayerAtk>();
        m_anim = GetComponentInChildren<Animator>();

        rb = GetComponentInParent<Rigidbody>();
    }

    public void OnRun(float magnitude)
    {
        //Play animation
        anim.SetFloat("MoveSpeed", magnitude);
    }

    public void Hit()
    {       
        switch(m_atkCombo)
        {
            case 0:
                anim.SetTrigger("AttackNormal");
                StartCoroutine(SetActiveHands());
                m_atkCombo = 1;
                break;

            case 1:
                // Call animation
                m_anim.SetTrigger("AttackNormal2");
                StartCoroutine(SetActiveHands());
                m_atkCombo = 2;
                break;

            case 2:
                m_anim.SetTrigger("AttackNormal3");
                StartCoroutine(SetActiveHands());
                m_atkCombo = 0;
                break;
        }

        StartCoroutine(ResetCombo(m_atkCombo));
    }

    void GetCurrentAnimationTime()
    {
        m_CurrentClipInfo = m_anim.GetCurrentAnimatorClipInfo(0);
    }

    // During the animation, the character can't move and the hands are active
    IEnumerator SetActiveHands()
    {
        GetCurrentAnimationTime();

        activeHands(true);
        
        yield return new WaitForSeconds(m_CurrentClipInfo[0].clip.length);
        
        activeHands(false);
        m_playerAtk.isInteracting = false;
    }

    // empeche de combo après 3 sec d'attente
    IEnumerator ResetCombo(int p_comboNumber)
    { 
        yield return new WaitForSeconds(3f);
        // si le numéro du combo n'a pas changer, on reset le combo
        if (p_comboNumber == m_atkCombo)
        {
            m_atkCombo = 0;
        }
    }

    
    void activeHands(bool p_action)
    {
        handScript[] hands = GetComponentsInChildren<handScript>();

        foreach (handScript hand in hands)
        {
            switch(p_action)
            {
                case true:
                    hand.enabled = true;
                    break;

                case false:
                    hand.enabled = false;
                    break;
            }
        }
    }

    public void TakingDamage()
    {
        //Animation de prise de coup ou apparition d'une connerie pour le faire comprendre
    }

    public void DeadAnim()
    {
        //Play animation
    }
}
