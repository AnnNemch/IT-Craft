using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script allows to play animation if user taps/clicks 5 times on the head
public class AnimationHandler : MonoBehaviour
{
    public GameObject model;

    //Current click count
    private int currentCount = 0;
    //Time passed after last click
    private float lastClickTime = 0;
    //Time between clicks/taps
    private float timeInterval = 0.4f;
    private Animator animator;

    void Start()
    {
        animator = model.GetComponent<Animator>();
    }

    void Update()
    {
        ClickCounter();
    }

    //Counts mouse clicks, and if the amount of serial clicks is 5, the animation of GameObject is played
    private void ClickCounter()
    {
        //If the user taps/clicks on a collider, new click is detected
        if (Input.GetMouseButtonUp(0))
        {
            currentCount++;
            lastClickTime = 0;
        }

        //Checks if the time since the last click doesn`t exceed needed time interval
        if (currentCount != 0 && lastClickTime <= timeInterval)
        {
            lastClickTime += Time.deltaTime;
            return;
        }

        //Play animation
        if (currentCount == 2)
        {
            Debug.Log("CLICK!!!");
            animator.SetTrigger("armRaise");
        }            

        //Reset values
        currentCount = 0;
        lastClickTime = 0;
    }

}