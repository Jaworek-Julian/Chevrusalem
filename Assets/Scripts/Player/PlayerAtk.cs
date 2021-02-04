using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerAtk : PlayerManager
{
    public BaseAtk baseAtk;
    [FormerlySerializedAs("point")] public GameObject pointDroit;
    private PlayerAnimator playerAnimator;
    
    public bool isInteracting = false;
    
    private void Awake()
    {
        //point = GameObject.Find("Cube""); 
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    private void FixedUpdate()
    {
        if (baseAtk.isHitting && isInteracting == false)
        {
            // pointDroit.SetActive(true);
            isInteracting = true;
            playerAnimator.Hit();
        }
    }
}
