using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    [SerializeField] float chaseDistance = 1f;
    NavMeshAgent agent;
    Animator animator;
    GameObject player;
    int health = 100;
    float targetDistance = Mathf.Infinity;
    bool isProvoked = false;
    bool alreadyAttacked = false;
    weapon hilt;
    public float time = 1;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        hilt = GameObject.FindGameObjectWithTag("weapon").GetComponent<weapon>();
        hilt.TakeHit(0);
    }
    void Update()
    {
        targetDistance = Vector3.Distance(player.transform.position, transform.position);
        if (targetDistance <= agent.stoppingDistance) //attack
        {
            faceTarget();
            animator.SetBool("Attack", true);
            animator.SetBool("Chase", false);
            animator.SetBool("Idle", false);
            if(!alreadyAttacked)
            {
                hilt.TakeHit(20);
                alreadyAttacked = true;
                Invoke("resetAttack", time);
            }
        }
        else if (targetDistance <= chaseDistance || isProvoked) //chasing
        {
            faceTarget();
            agent.SetDestination(player.transform.position);
            animator.SetBool("Chase", true);
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", false);
        }
        else //idle
        {
            animator.SetBool("Chase", false);
            animator.SetBool("Attack", false);
            animator.SetBool("Idle", true);
        }
    }

    public void EnemyHit()
    {
        isProvoked = true;
    }
    private void faceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    //to create visualization of chase range
    }
    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void resetAttack()
    {
        alreadyAttacked = false;
    }
}
