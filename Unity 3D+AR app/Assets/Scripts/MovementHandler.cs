using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the motion of the object
/// </summary>
public class MovementHandler : MonoBehaviour
{
    public SwipeHandler swipe;
    public GameObject model;

    private Animator animator;
	
	void Start () {
        animator = model.GetComponent<Animator>();
	}
	
    /// <summary>
    /// Play specific animation depending on the swipe type
    /// </summary>
	void Update () {
        //if user touches the screen with two fingers
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
