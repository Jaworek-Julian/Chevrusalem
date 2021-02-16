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

    public Vector3 m_tamponDir;

    int m_atkCombo = 0;

    Animator m_anim;
    AnimatorClipInfo[] m_CurrentClipInfo;
    bool isRunning = false;
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

    //---------------------------------------------------------------------------------
    // ANIMATION
    //---------------------------------------------------------------------------------

    public void AnimHit()
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

    public void AnimCharge()
    {
        anim.SetTrigger("Charge");
        StartCoroutine(ChargeMovement());
    }

    public void TakingDamage()
    {
        //Animation de prise de coup ou apparition d'une connerie pour le faire comprendre
    }

    public void DeadAnim()
    {
        //Play animation
    }

    //---------------------------------------------------------------------------------
    // FUNCTIONS
    //---------------------------------------------------------------------------------

    public IEnumerator ChargeMovement()
    {
        GetCurrentAnimationTime();
        isRunning = true;

        yield return new WaitForSeconds(m_CurrentClipInfo[0].clip.length);
        isRunning = false;
        m_playerAtk.isInteracting = false;
    }

    void GetCurrentAnimationTime()
    {
        m_CurrentClipInfo = m_anim.GetCurrentAnimatorClipInfo(0);
    }

    // During the animation, the character can't move and the hands are active
    IEnumerator SetActiveHands()
    {
        GetCurrentAnimationTime();

        ActiveHands(true);
        
        yield return new WaitForSeconds(m_CurrentClipInfo[0].clip.length);
        
        ActiveHands(false);
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
    
    void ActiveHands(bool p_action)
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

    void FixedUpdate()
    {
        if (isRunning)
        {
            m_playerLocomotion.controller.Move(m_tamponDir * Time.deltaTime * 10f);
        }
    }
}
