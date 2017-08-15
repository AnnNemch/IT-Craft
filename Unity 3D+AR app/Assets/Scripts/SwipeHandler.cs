using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//This script detects dragging gestures on screen and controls the character movements 
public class SwipeHandler : MonoBehaviour
{
    public GameObject model;

    private Animator animator;
    private Vector2 startTouch, swipeDelta;
    private bool isDragging = false;

    private void Start()
    {
        animator = model.GetComponent<Animator>();
    }

    private void Update()
    {
        //If the app is tested on a computer (works without character jumping)
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true; //the swipe is detected
            startTouch = Input.mousePosition; //the start point
        }
        else if (Input.GetMouseButtonUp(0)) //detecting the end of dragging
        {
              Reset();
        }


        //For testing the app with mobile phone
        //Plays 'jump' animation if the user touches screen with two fingers
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Ended)
            animator.SetTrigger("Jump");
        //If user touches the screen with one finger
        else if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                isDragging = true; //the swipe is detected
                startTouch = Input.GetTouch(0).position; //the start point of swipe
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }

        Swipe();          
    }

    //Resets the values to their original values
    private void Reset()
    {
        isDragging = false;
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
    }

    //The function handles gestures
    private void Swipe()
    {
        swipeDelta = Vector2.zero;

        //If there is a some gesture, the distance between the start point and the end point is calculated
        if (isDragging)
        {
            if (Input.touchCount == 1) //for touch gestures
            {
                swipeDelta = Input.GetTouch(0).position - startTouch;
            }
            else if (Input.GetMouseButton(0)) //for mouse gestures
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > 50)
        {
            //Detecting the direction of swipe
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //horizontal
                if (x < 0) //left
                    OnDraggingLeft();
                else //right
                    OnDraggingRight();
            }
            else
            {
                //vertical
                if (y > 0) //up                    
                    OnDraggingUp();
            }

            Reset();

        }
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
