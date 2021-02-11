﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAnimator : PlayerManager
{
   // private PlayerAtk playerAtk;
    private PlayerLocomotion playerLocomotion;
    private PlayerStats playerStats;
    private PlayerAtk playerAtk;
    private Animator anim;

    private void Awake()
    {
        //playerAtk = GetComponent<PlayerAtk>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        playerStats = GetComponent<PlayerStats>();
        playerAtk = GetComponent<PlayerAtk>();
        anim = GetComponentInChildren<Animator>();
    }

    public void OnRun()
    {
        //Play animation
        anim.SetInteger("Speed", playerStats.speed);
        
    }

    public void onStop()
    {
        anim.SetInteger("Speed", 0);
    }
    
    public void Hit()
    {
        //Play animation
        
        //penser à voir pour le combo
        
        //sert pour le proto
        
        playerAtk.pointDroit.SetActive(true);
        StartCoroutine(DontMoveDuringAPunch(0.5f));
    }

    private IEnumerator DontMoveDuringAPunch(float WaitingTime)
    {
        
        
        yield return new WaitForSeconds(WaitingTime);
        
        playerAtk.pointDroit.SetActive(false);
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

    public void SuperAtk1()
    {
        Debug.Log("Charge");
    }

    public void SuperAtk2()
    {
        Debug.Log("Cheeeeeeeeeh !!!!!!");
    }

    public void SuperAtk3()
    {
        Debug.Log("Zone");
    }
    
}
