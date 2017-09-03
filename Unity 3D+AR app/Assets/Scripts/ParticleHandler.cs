using UnityEngine;
using System.Collections;

/// <summary>
/// Plays particle system at mouse click/tap position
/// </summary>
public class ParticleHandler : MonoBehaviour
{
    
    public ParticleSystem particle; 

    /// <summary>
    /// Instantiate the particle system
    /// if the user taps on the objectss
    /// </summary>
    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            ParticleSystem clone = Instantiate(particle, hit.point, hit.transform.rotation, hit.transform);
            Destroy(clone.gameObject, 1);
        }

    }
}



