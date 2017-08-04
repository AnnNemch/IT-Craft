using UnityEngine;
using System.Collections;

//This script allows to play particle system at mouse click / tap position
public class ParticleHandler : MonoBehaviour
{
    //Particle system that have to be instantiated
    public ParticleSystem particle;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit; 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Checks if the ray hit a collider
            if (Physics.Raycast(ray, out hit) && hit.collider != null)
            {
                ParticleSystem clone = Instantiate(particle, hit.point, transform.rotation);
                Destroy(clone.gameObject, 1);
            }
        }
    }

}

