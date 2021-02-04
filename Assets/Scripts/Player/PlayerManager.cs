using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   protected Animator anim;
   protected PlayerAtk playerAtk;

   protected void Start()
   {
      anim = GetComponent<Animator>();
      playerAtk = GetComponent<PlayerAtk>();
   }

}
