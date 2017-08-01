using UnityEngine;
using System.Collections;

public class TapHandler : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject model;

    private int myClickCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit) && hit.collider != null)
            {
                myClickCount = ++myClickCount % 5;
                if (myClickCount != 0)
                {
                    ParticleSystem clone = Instantiate(particle, hit.point, transform.rotation);
                    Destroy(clone.gameObject, 1);
                }
                else
                {
                    //Animator modelAnimator = model.GetComponent<Animator>();
                    model.GetComponent<Animation>().Play();
                }
            }
        }
    }

}

