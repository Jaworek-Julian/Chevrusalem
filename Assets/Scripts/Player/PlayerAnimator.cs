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

    private float m_counter = 0;
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
        m_combo = true;
    }

    public void Hit()
    {
        SetActiveHands();

        if (m_combo == true)
        {
            anim.SetTrigger("AttackNormal2");
            Debug.Log("ça combote");
        }

        //Play animation
        anim.SetTrigger("AttackNormal");
        m_combo = true;

        //penser à voir pour le combo

        //sert pour le proto

        // playerAtk.pointDroit.SetActive(true);
    }

    private void SetActiveHands()
    {
        handScript[] hands = GetComponentsInChildren<handScript>();

        foreatch(handScript hand in handScripts)
            {

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

    private void Update()
    {
        
        if (m_combo  == true)
        {
            m_counter += Time.deltaTime;

            if (m_counter >= 20)
            {
                m_combo = false;
                m_counter = 0;
            }
        }
    }

}
