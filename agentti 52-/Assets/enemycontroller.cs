using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;


public class enemycontroller : MonoBehaviour
{


    public NavMeshAgent agent;

    public ThirdPersonCharacter character;





    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        


        /*float dist = agent.remainingDistance; 
        if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }*/


        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
        

    }


   

    

}