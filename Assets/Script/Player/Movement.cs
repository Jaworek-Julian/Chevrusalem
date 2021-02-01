using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float m_rotateSpeed;
    Rigidbody m_rb;
    StatPlayer m_stat;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>(); 
        m_stat = GetComponent<StatPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (m_stat.m_canMove == true)
        {
            // transform.position += Vector3.forward * vertical * Time.deltaTime * m_stat.m_moveSpeed;
            transform.Translate(Vector3.forward * vertical * Time.deltaTime * m_stat.m_moveSpeed);
            // m_rb.AddForce(Vector3.forward * vertical * Time.deltaTime * m_stat.m_moveSpeed, ForceMode.Force);
            transform.Rotate(Vector3.up * horizontal * Time.deltaTime * m_stat.m_rotateSpeed);
        }
        

        m_rb.velocity = Vector3.zero;
        
    }
}
