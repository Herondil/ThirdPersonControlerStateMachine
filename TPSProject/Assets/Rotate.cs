using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : StateMachineBehaviour
{
    //ce state a une influence sur le mouvement du personnage
    Movement m_movement;

    private void Awake()
    {
        m_movement = GameObject.Find("Logic").GetComponent<Movement>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_movement.AllowRotation = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_movement.AllowRotation = false;   
    }
}
