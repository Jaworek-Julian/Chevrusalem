using System.Collections;
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

    // attack if the hand collide
    private void OnTriggerEnter(Collider collision)
    {
        // get enemy tag
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
        bool canMove = p_target.gameObject.GetComponent<EnemiLocomotion>().m_canMove;
        bool isEjected = p_target.GetComponent<EnemiLocomotion>().m_isEjected;

        isEjected = true;
        canMove = false;

        yield return new WaitForSeconds(3);
        canMove = true;
        isEjected = false;

    }
}
