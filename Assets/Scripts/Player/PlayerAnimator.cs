using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAnimator : PlayerManager
{
    private PlayerLocomotion playerLocomotion;
    private PlayerStats playerStats;

    // Animator anim;
    // PlayerAtk playerAtk;

    private void Awake()
    {
        //playerAtk = GetComponent<PlayerAtk>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStats = GetComponent<PlayerStats>();
        // playerAtk = GetComponent<PlayerAtk>();
    }

    public void OnRun()
    {
        //Play animation
    }

    public void Hit()
    {
        //Play animation
        anim.SetTrigger("AttackNormal");

        //penser à voir pour le combo

        //sert pour le proto

        // playerAtk.pointDroit.SetActive(true);
        StartCoroutine(DontMoveDuringAPunch(0.5f));
    }

    private IEnumerator DontMoveDuringAPunch(float WaitingTime)
    {
        
        
        yield return new WaitForSeconds(WaitingTime);
        
        // playerAtk.pointDroit.SetActive(false);
        playerAtk.isInteracting = false;
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
