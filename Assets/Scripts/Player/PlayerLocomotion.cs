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
    private PlayerAnimator playerAnim;

    [SerializeField]private Camera cam;
    private Vector3 cameraOffset;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
        playerAtk = GetComponent<PlayerAtk>();
        playerAnim = GetComponentInChildren<PlayerAnimator>();
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

            playerAnim.OnRun(direction.magnitude);
        }
        else if(playerAtk.isInteracting)
        {
            // Debug.Log("je marche pas");
        }
        
        cam.transform.position = cameraOffset + transform.position;
    }
}
