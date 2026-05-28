/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public ZombieHand zombieHand;
    public int zombieDamage;
    [SerializeField] private int HP=100;
    private Animator animator;
    private UnityEngine.AI.NavMeshAgent navAgent;
    // Start is called before the first frame update
    private void Start()
    {   
        zombieHand.damage=zombieDamage;
        animator=GetComponent<Animator>();
        navAgent=GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
public void TakeDamage(int damageAmount)
{
    HP-=damageAmount;
    if(HP<=0)
    {
        int randomvalue=Random.Range(0,2);
        if(randomvalue==0)
        {
           animator.SetTrigger("DIE1");
        }
        else
        {
           animator.SetTrigger("DIE2");
        }
       
        
    }
    else
    {
        animator.SetTrigger("DAMAGE");
    }
}
/*private void Update()
{
    if(navAgent.velocity.magnitude>0.1f)
    {
        animator.SetBool("isWalking",true);
    }
    else
    {
        animator.SetBool("isWalking",false);
    }
}  */
/*private void OnDrawGizmos()
{

    Gizmos.color=Color.red;
    Gizmos.DrawWireSphere(transform.position,2.5f);

    Gizmos.color=Color.blue;
    Gizmos.DrawWireSphere(transform.position,18f);

    Gizmos.color=Color.green;
    Gizmos.DrawWireSphere(transform.position,21f);

}*/


   
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public ZombieHand zombieHand;
    public int zombieDamage;
    
    [SerializeField] private int HP = 100;
    private Animator animator;
    private NavMeshAgent navAgent;

    public bool isDead = false;

    private void Start()
    {
        zombieHand.damage = zombieDamage;
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return;

        HP -= damageAmount;
        if (HP <= 0)
        {
            isDead = true;

            int randomValue = Random.Range(0, 2);
            if (randomValue == 0)
            {
                animator.SetTrigger("DIE1");
            }
            else
            {
                animator.SetTrigger("DIE2");
            }

            // optionally stop the nav agent
            navAgent.isStopped = true;

            // destroy the zombie after a delay
            Destroy(gameObject, 3f);
        }
        else
        {
            animator.SetTrigger("DAMAGE");
        }
    }

    /*private void Update()
    {
        if (navAgent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 18f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 21f);
    }
}

