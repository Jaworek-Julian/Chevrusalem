using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Stat m_stat;
    void Start()
    {
        m_stat = GetComponent<Stat>();
    }

    public void Attack()
    {

    }
}
