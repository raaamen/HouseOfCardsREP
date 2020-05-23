using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_Dash : StateMachineBehaviour
{

    public float speed = 6f;

    Transform player;
    Rigidbody2D boss;
    JackScript jack;

    public Vector3 target;
    public Vector3 newPos;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = animator.GetComponent<Rigidbody2D>();
        jack = animator.GetComponent<JackScript>();

        jack.LookAtPlayer();
        target = new Vector3(player.position.x, player.position.y);
        

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        newPos = Vector3.MoveTowards(boss.position, target, speed * Time.fixedDeltaTime);
        boss.MovePosition(newPos);
        if ((Vector3)boss.position == target)
        {
            animator.SetTrigger("Recharge");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Recharge");
    }
}
