using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : AnimatorManager
{
    private EnemiLocomotion enemyLocomotion;
    private EnemieStats enemyStats;
    
   private void Awake()
   {
       anim = GetComponent<Animator>();
       enemyLocomotion = GetComponent<EnemiLocomotion>();
       enemyStats = GetComponent<EnemieStats>();
   }

   private void OnAnimatorMove()
   {
       float delta = Time.deltaTime;
       Vector3 deltaPosition = anim.deltaPosition;
       deltaPosition.y = 0;
       Vector3 velocity = deltaPosition * delta;

       Vector3 direction = enemyLocomotion.currentTarget.transform.position - transform.position;
       direction.y = 0;
       direction.Normalize();

       if (enemyLocomotion.distanceFromTarget > enemyLocomotion.stoppingDistance)
       {
           Debug.Log("whalla je cours");
           enemyLocomotion.controller.Move(direction * Time.deltaTime * enemyStats.speed);
       }
       else
       {
           Debug.Log("je m'arrete");
           enemyLocomotion.controller.Move(direction * 0);
       }
   }
}
