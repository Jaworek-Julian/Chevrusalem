using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // distance à laquelle l'unité sera aggro par le joueur
    [SerializeField] float m_distanceAggro;     
    // distance à laquelle l'unité s'arrêtera pour taper le joueur
    [SerializeField] float m_distanceStop;
    Stat m_stat;                                // get moveSpeed
    EnemyAttack m_attackScript;
    [SerializeField] GameObject m_Player;
    void Start()
    {
        m_stat = GetComponent<Stat>();
        m_attackScript = GetComponent<EnemyAttack>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(m_Player.transform.position, transform.position);
        
        if (distance <= m_distanceAggro && distance >= m_distanceAggro)
        {
            transform.position += (m_Player.transform.position - transform.position).normalized * Time.deltaTime * m_stat.m_moveSpeed;
        }
        else if (distance > m_distanceStop)
        {
            m_attackScript.Attack();
        }
    }
}
