using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : PlayerManager
{
    private PlayerStats playerStats; 
    public VariableJoystick variableJoystick;
    private CharacterController controller;
    private PlayerAtk playerAtk;
    private PlayerAnimator playerAnimator;
   
    [SerializeField]private Camera cam;
    private Vector3 cameraOffset;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        playerAtk = GetComponent<PlayerAtk>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void FixedUpdate()
    {
        
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal; 
        cameraOffset = cam.transform.position - transform.position;
        

        if (direction.magnitude > 0 && playerAtk.isInteracting == false)
        {
            controller.Move(direction * Time.deltaTime * playerStats.speed);
            
            Quaternion targetAngle = Quaternion.LookRotation(direction);
            //change la rotation du personnage (exemple je tourne à droite, donc je regarde vers la droite)
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle, Time.deltaTime * playerStats.speedRotation);

            playerAnimator.OnRun();
        }
        else if(playerAtk.isInteracting)
        {
            Debug.Log("je marche pas");
            playerAnimator.onStop();
        }
        
        cam.transform.position = cameraOffset + transform.position;
    }
}
