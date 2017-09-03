using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// Counts the number of consecutive clicks/taps
/// and plays the 'ArmRaise' animation if the click amount is 5
/// </summary>
public class FiveTapsHandler : MonoBehaviour
{

    public GameObject model;

    private Animator animator;
    private int currentCount = 0;  //current click count
    private float lastClickTime = 0; //time passed after the last click
    private float timeInterval = 0.4f; //time between clicks

    private void Start()
    {
        animator = model.GetComponent<Animator>();
    }

    private void Update()
    {
        //Continue to calculate the time between clicks
        //if the time since the last click doesn't exceed needed time interval
        if (currentCount != 0 && lastClickTime <= timeInterval)
        {
            lastClickTime += Time.deltaTime;
            return;
        }

        //Play needed animation
        if (currentCount == 5)
        {
            animator.SetTrigger("armRaise");
        }

        //Reset values
        currentCount = 0;
        lastClickTime = 0;
    }

    /// <summary>
    /// New click is detected when the user taps on a related object
    /// </summary>
    private void OnMouseUp()
    {
        currentCount++;
        lastClickTime = 0;
    }
}
