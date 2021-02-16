using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAnimator : PlayerManager
{
    private PlayerLocomotion playerLocomotion;
    private PlayerStats playerStats;
    private Rigidbody rb;

    private bool m_combo = false;

    // Animator anim;
    // PlayerAtk playerAtk;

    private void Awake()
    {
        //playerAtk = GetComponent<PlayerAtk>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStats = GetComponent<PlayerStats>();
        // playerAtk = GetComponent<PlayerAtk>();
        rb = GetComponentInParent<Rigidbody>();
    }

    public void OnRun(float magnitude)
    {
        //Play animation
        anim.SetFloat("MoveSpeed", magnitude);
    }

    public void Hit()
    {       

        // attaque combo 2
        if (m_combo == true)
        {
            StartCoroutine(SetActiveHands());

            anim.SetTrigger("AttackNormal2");
            m_combo = false;
        }
        // attaque combo 1
        else
        {
            StartCoroutine(SetActiveHands());
            anim.SetTrigger("AttackNormal");
            m_combo = true;
            StartCoroutine(ResetCombo());
        }
    }

    // active les collider des mains lors de l'attaque
    IEnumerator SetActiveHands()
    {
        activeHands(true);
        
        yield return new WaitForSeconds(1.5f);
        activeHands(false);
    }

    // empeche de combo après 2 sec d'attente
    IEnumerator ResetCombo()
    { 
        yield return new WaitForSeconds(1f);
        m_combo = false;
        Debug.Log(m_combo);
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
