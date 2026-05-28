/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttackState : StateMachineBehaviour
{
    public float stopAttackingDistance=2.5f;
    private Transform player;
    private NavMeshAgent agent;
     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        agent=animator.GetComponent<NavMeshAgent>(); 
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LockAtPlayer();
        float distanceFromPlayer=Vector3.Distance(player.position,animator.transform.position);

        if(distanceFromPlayer>stopAttackingDistance)
        {
            animator.SetBool("isAttacking",false);
        }
    }

     private void LockAtPlayer()
    {
       Vector3 direction=player.position-agent.transform.position;
       agent.transform.rotation=Quaternion.LookRotation(direction);

       var yRotation=agent.transform.eulerAngles.y;
       agent.transform.rotation=Quaternion.Euler(0,yRotation,0);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAttackState : StateMachineBehaviour
{
    public float stopAttackingDistance = 2.5f;

    private Transform player;
    private NavMeshAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LockAtPlayer();

        float distanceFromPlayer = Vector3.Distance(player.position, animator.transform.position);

        if (distanceFromPlayer > stopAttackingDistance)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void LockAtPlayer()
    {
        Vector3 direction = player.position - agent.transform.position;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            agent.transform.rotation = Quaternion.Slerp(
                agent.transform.rotation,
                lookRotation,
                5f * Time.deltaTime
            );
        }
    }
}

