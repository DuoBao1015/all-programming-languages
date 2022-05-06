using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy01 : MonoBehaviour
{

    Transform m_transform;
    public Transform m_player;
    UnityEngine.AI.NavMeshAgent m_agent;
    public float m_movSpeed = 5f;
    public Animator m_ani;
    public float m_rotSpeed = 5.0f;
    float m_timer = 0;
    public bool dead = false;

    void Start()
    {
        m_transform = this.transform;

        m_agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        m_agent.speed = m_movSpeed;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Player01.instance.life <= 0)
            return;
     
        m_timer -= Time.deltaTime;

        m_player = m_player.gameObject.transform;

        AnimatorStateInfo stateInfo = m_ani.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.Idle") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("idle", false);

            if (m_timer > 0)
                return;

            if (Vector3.Distance(m_transform.position, m_player.transform.position) < 6000f)
            {
                if (Vector3.Distance(m_transform.position, m_player.transform.position) < 4f)
                {
                    m_agent.ResetPath();
                    m_ani.SetBool("attack", true);
                }
                else
                {       
                    m_timer = 1;
            
                    m_ani.SetBool("run", true);
                    m_agent.SetDestination(m_player.transform.position);
                }
            }
        }


        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.run") && !m_ani.IsInTransition(0))
        {
            m_ani.SetBool("run", false);
 
            if (m_timer < 0)
            {
                m_agent.SetDestination(m_player.transform.position);
                m_timer = 1;
            }
        }


        if (Vector3.Distance(m_transform.position, m_player.transform.position) < 4f)
        {
            m_agent.ResetPath();
  
            m_ani.SetBool("attack", true);
        }

        if (stateInfo.fullPathHash == Animator.StringToHash("Base Layer.attack01") && !m_ani.IsInTransition(0) && Player01.instance.IsRun == true)
        {   
            RotateTo();
            m_ani.SetBool("attack", false);

            if (stateInfo.normalizedTime >= 1.0f)
            {
                m_ani.SetBool("idle", true);
 
                m_timer = 1;
             
                Player01.instance.OnDamage(1);
            }

        }
    }

    void RotateTo()
    {
        Vector3 targetdir = m_player.transform.position - m_transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetdir, m_rotSpeed * Time.deltaTime, 0.0f);
        m_transform.rotation = Quaternion.LookRotation(newDir);
    }
}
