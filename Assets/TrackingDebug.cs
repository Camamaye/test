using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackingDebug : MonoBehaviour
{
    private ARTrackedImageManager manager;

    void Awake() => manager = GetComponent<ARTrackedImageManager>();
    void OnEnable() => manager.trackedImagesChanged += OnChanged;
    void OnDisable() => manager.trackedImagesChanged -= OnChanged;

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var img in eventArgs.added)
            Debug.Log($"[AR] FOUND IMAGE: {img.referenceImage.name} at {img.transform.position}");

        foreach (var img in eventArgs.updated)
            Debug.Log($"[AR] UPDATING: {img.referenceImage.name} | State: {img.trackingState}");
    }
}