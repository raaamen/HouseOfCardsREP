using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_Run : StateMachineBehaviour
{

    public int attemptedAttacks;


    public float attackRange = 3f;
    public float timer;

    Transform player;
    Rigidbody2D boss;
    JackScript jack;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("first phase");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = animator.GetComponent<Rigidbody2D>();
        jack = animator.GetComponent<JackScript>();
        animator.ResetTrigger("CanStart");
        timer = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //after 3 attempted attacks
        jack.LookAtPlayer();
        Vector3 target = new Vector3(player.position.x, player.position.y);
        float newspeed = 10 * Time.deltaTime;
        Vector3 newPos = Vector3.MoveTowards(boss.position, target, newspeed);
        
        boss.MovePosition(newPos);

        timer += Time.fixedDeltaTime;

        

        if (timer >= 5f)
        {
            Debug.Log("charging");
            animator.SetTrigger("Charging");
            
        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        attemptedAttacks = 0;
        animator.ResetTrigger("Charging");
    }


}
