using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
       Debug.Log("Hello");
    }
}
