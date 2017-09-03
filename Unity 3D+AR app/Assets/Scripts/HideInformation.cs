using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

/// <summary>
/// The information is hidden if marker is recognized 
/// </summary>
public class HideInformation : MonoBehaviour, ITrackableEventHandler
{
    public Text information;

    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    /// <summary>
    /// Hide the information if the target is found
    /// </summary>
    /// <param name="previousStatus"></param>
    /// <param name="newStatus"></param>
    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            information.enabled = false; 
        }

    }
}