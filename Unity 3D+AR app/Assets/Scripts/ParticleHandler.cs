﻿using UnityEngine;
using System.Collections;

//This script allows to play particle system at mouse click / tap position
public class ParticleHandler : MonoBehaviour
{
    //Particle system that have to be instantiated
    public ParticleSystem particle;
    public GameObject head;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Checks if the ray hit the head
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetInstanceID() == head.GetInstanceID())
            {
                ParticleSystem clone = Instantiate(particle, hit.point, hit.transform.rotation, hit.transform);
                Destroy(clone.gameObject, 1);
            }
        }
    }
}



