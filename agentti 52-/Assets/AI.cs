using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.Mathematics;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player;

    public GameObject head;

    public Animator animator;


    public bool idle;
    public bool attacking;

    [HideInInspector]
    public bool canSeePlayer;
    public bool noticedPlayer;

    private void Start()
    {

    }

    private void Update()
    {
        noticedPlayer = canSeePlayer;
        animator.SetFloat("Forward", agent.velocity.magnitude);
        animator.SetBool("noticedPlayer", attacking);

        if (noticedPlayer)
        {
            setAttacking();
            noticedPlayer = false;
        }

        if (attacking)
        {
            agent.SetDestination(player.transform.position);

            Vector3 lookDir = player.transform.position - transform.position;
            Quaternion q = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 10);


        }
    }




    #region setStates

    void setAttacking()
    {
        idle = false;
        attacking = true;
    }


    #endregion

}

