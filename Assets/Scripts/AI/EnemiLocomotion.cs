using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiLocomotion : MonoBehaviour
{
    private EnemieManager enemyManager;
    private EnemyAnimatorManager enemyAnimatorManager;
    private EnemieStats enemyStats;
    private NavMeshAgent navMeshAgent;
    public CharacterController controller;
    
    public CharacterStats currentTarget;
    public LayerMask detectionLayer;

    public float distanceFromTarget;
    public float stoppingDistance = 1f;
    public bool m_canMove = true;

    public bool m_isEjected = false;         // HandScript
    
    private void Awake()
    {
        enemyManager = GetComponent<EnemieManager>();
        enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        enemyStats = GetComponent<EnemieStats>();
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        navMeshAgent.enabled = false;
    }

    public void HandleDetection()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

            if (characterStats != null && m_canMove == true)
            {
                //Check for team ID
                Vector3 targetDirection = characterStats.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                {
                    currentTarget = characterStats;
                }
            }
        }
    }

    public void HandleMoveToTarget()
    {

        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        distanceFromTarget = Vector3.Distance(currentTarget.transform.position, transform.position);
        float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

        //Si on est en train de faire une action, arret du mouvement
        if (enemyManager.isPerformingAction)
        {
            //enemieManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            navMeshAgent.enabled = false;
        }
        else
        {
            if (distanceFromTarget > stoppingDistance)
            {
                //enemyAnimatorManager.anim.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
            }
            else if(distanceFromTarget <= stoppingDistance)
            {
                //enemyAnimatorManager.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                
            }
        }

        HandleRotateTowardTarget();
        
        navMeshAgent.transform.localPosition = Vector3.zero;
        navMeshAgent.transform.localRotation = Quaternion.identity;
        

    }

    private void HandleRotateTowardTarget()
    {
        //rotation manuelle
        if (enemyManager.isPerformingAction && m_canMove == true)
        {
            Vector3 direction = currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.forward)
            {
                direction = transform.forward;
            }
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, enemyStats.speedRotation / Time.deltaTime);
            
        }
        //Rotation avec le pathfinding (navmesh agent)
        else
        {
            Vector3 relativeDirection = navMeshAgent.desiredVelocity;
            
            navMeshAgent.enabled = true;
            navMeshAgent.SetDestination(currentTarget.transform.position);
            
            relativeDirection.Normalize();

            if (distanceFromTarget > stoppingDistance && m_canMove == true)
                controller.Move(relativeDirection * Time.deltaTime * enemyStats.speed);
            else
                controller.Move(relativeDirection * 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, enemyStats.speedRotation / Time.deltaTime);
            
        }
        
    }
    
    void FixedUpdate()
    {
        if (m_isEjected == true)
        {
            Debug.Log("OhLALA JE SUIS EJECTE");
            Vector3 direction = (transform.position - currentTarget.transform.position).normalized;
            direction.y += 10f;
            //direction.normalized;
            controller.Move(direction * Time.deltaTime * enemyStats.speed * 5f);
        }
    }
    
    
}
