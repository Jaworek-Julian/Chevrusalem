﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handScript : MonoBehaviour
{
   [SerializeField] float m_projectPower = 50;
    CharacterStats m_thisStat;

    void Start()
    {
        m_thisStat = GetComponentInParent<CharacterStats>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject target = collision.gameObject;
            target.GetComponent<EnemiLocomotion>().m_canMove = false;

           if (target.GetComponent<CharacterStats>() != null)
           {
                m_thisStat.Attack(target.GetComponent<CharacterStats>());
           }

            StartCoroutine(TargetProjection(target));
        };
        
    }

    IEnumerator TargetProjection(GameObject p_target)
    {
        
        yield return new WaitForSeconds(3);
        p_target.gameObject.GetComponent<EnemiLocomotion>().m_canMove = true;

    }


}