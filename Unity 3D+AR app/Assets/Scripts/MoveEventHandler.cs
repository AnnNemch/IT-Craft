using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEventHandler : MonoBehaviour
{
    public SwipeHandler swipe;
    //public GameObject model;
    private Animator animator;
	
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (swipe.DoubleTouch)
            animator.SetTrigger("Jump");
		if(swipe.Left)
            OnDraggingLeft();
        if (swipe.Right)
            OnDraggingRight();
        if (swipe.Up)
            OnDraggingUp();
	}

    //Functions for playing specific animations 

    private void OnDraggingUp()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
            animator.SetTrigger("Run");
    }

    private void OnDraggingRight()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("CrouchIdle"))
            animator.SetTrigger("CrouchRight");
        else if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
            animator.SetTrigger("RunRight");
        else
            animator.SetTrigger("StandTurnRight");
    }

    private void OnDraggingLeft()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("CrouchIdle"))
            animator.SetTrigger("CrouchLeft");
        else if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Run"))
            animator.SetTrigger("RunLeft");
        else
            animator.SetTrigger("StandTurnLeft");
    }
}
