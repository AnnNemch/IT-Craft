using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Detects dragging gestures on screen 
/// </summary>
public class SwipeHandler : MonoBehaviour
{
    private bool doubleTouch, left, right, up, down;
    private Vector2 startTouch, swipeDelta;
    private bool isDragging = false;

    private void Update()
    {
        doubleTouch = left = right = up = false;

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
        //Double touch is detected if the user touches screen with two fingers
        if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Ended)
            doubleTouch = true;
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

    /// <summary>
    /// Resets the values to their original values
    /// </summary>
    private void Reset()
    {
        isDragging = false;
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
    }

    /// <summary>
    /// The function handles gestures
    /// </summary>
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
                    left = true;
                else //right
                    right = true;
            }
            else
            {
                //vertical
                if (y > 0) //up                    
                    up = true;
            }

            Reset();

        }
    }
     
    public bool Left { get { return left; } }
    public bool Right { get { return right; } }
    public bool Up { get { return up; } }
    public bool DoubleTouch { get { return doubleTouch; } }
}
