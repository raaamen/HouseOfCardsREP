using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_Attack : StateMachineBehaviour
{
    public GameObject player;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerScript>().Damage(2);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attacking");
    }

    
}
