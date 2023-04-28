using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAttackState : StateMachineBehaviour
{
    EnemyManager em;
    public NavMeshAgent agent;
    public Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        em = animator.GetComponent<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(em.meleeAttackCount == 3)
        {
            animator.SetBool("isHeavyAttacking", true);
            animator.SetBool("isMeleeAttacking", false);
        }
        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (distance > 10)
        {
            em.meleeAttackCount = 0;
            animator.SetBool("isRangeAttacking", false);
            animator.SetBool("isMeleeAttacking", false);
            animator.SetBool("isChasing", true);
        }

        if (distance >= 6)
        {
            em.meleeAttackCount = 0;
            animator.SetBool("isRangeAttacking", true);
            animator.SetBool("isMeleeAttacking", false);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
