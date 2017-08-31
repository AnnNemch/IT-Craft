using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveTapsHandler : MonoBehaviour
{

    public GameObject model;

    private Animator animator;
    //Current click count
    private int currentCount = 0;
    //Time passed after last click
    private float lastClickTime = 0;
    //Time between clicks/taps
    private float timeInterval = 0.4f;

    private void Start()
    {
        animator = model.GetComponent<Animator>();
    }

    private void Update()
    {
        if (currentCount != 0 && lastClickTime <= timeInterval)
        {
            lastClickTime += Time.deltaTime;
            return;
        }

        Debug.Log(currentCount);

        //Play animation
        if (currentCount == 5)
        {
            animator.SetTrigger("armRaise");
        }

        //Reset values
        currentCount = 0;
        lastClickTime = 0;
    }

    private void OnMouseUp()
    {
        currentCount++;
        lastClickTime = 0;
    }
}
