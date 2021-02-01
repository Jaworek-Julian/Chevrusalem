using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieManager : MonoBehaviour
{
    public bool isPerformingAction;
    private EnemiLocomotion enemiLocomotion;

    public float detectionRadius = 20;
    //Angle du champs de vision
    public float maximumDetectionAngle = 100;
    public float minimumDetectionAngle = -100;
    
    
    private void Awake()
    {
        enemiLocomotion = GetComponent<EnemiLocomotion>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        HandleCurrentAction();
    }

    private void HandleCurrentAction()
    {
        if (enemiLocomotion.currentTarget == null)
        {
            enemiLocomotion.HandleDetection();
        }
        enemiLocomotion.HandleMoveToTarget();
    }
    
}
