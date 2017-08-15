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

    void Update()
    {
        ClickCounter();
    }

    //Checks if the user taps/clicks on a collider
    private bool OnCollider()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider != null)
                return true;
        }
        return false;
    }

    //Counts mouse clicks, and if the amount of serial clicks is 5, the animation of GameObject is played
    private void ClickCounter()
    {
        //If the user taps/clicks on a collider, new click is detected
        if (OnCollider())
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
        if (currentCount == 5)
            model.GetComponent<Animation>().Play();

        //Reset values
        currentCount = 0;
        lastClickTime = 0;
    }

}