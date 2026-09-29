using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackedImageInfoManager : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    // Start is called before the first frame update
    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnChanged;
        Debug.Log("TrackedImageInfoManager had loaded");
    }

    // Update is called once per frame
    void OnDisable()
    {
        if (m_TrackedImageManager != null)
            m_TrackedImageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var newImage in eventArgs.added)
        {
            // Handle added event
            Debug.Log($"[XREAL TIIM] New image detected: {newImage.referenceImage.name}");
        }

        foreach (var updatedImage in eventArgs.updated)
        {
            // Handle updated event
            if(updatedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
                updatedImage.gameObject.SetActive(true);
            else   
                updatedImage.gameObject.SetActive(false);
        }

        foreach (var removedImage in eventArgs.removed)
        {
            // Handle removed event
            Debug.Log($"[XREAL TIIM] Lost tracking for: {removedImage.referenceImage.name}");
        }
    }

    
}
