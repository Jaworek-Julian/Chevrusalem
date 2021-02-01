using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   private Animator anim;
   private PlayerAtk playerAtk;

   private void Start()
   {
      anim = GetComponent<Animator>();
      playerAtk = GetComponent<PlayerAtk>();
   }

   private void Update()
   {
      
   }

}
