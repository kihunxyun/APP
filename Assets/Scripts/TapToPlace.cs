
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject cubePrefab;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            if (raycastManager.Raycast(
                touch.position,
                hits,
                TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                Instantiate(
                    cubePrefab,
                    hitPose.position,
                    hitPose.rotation
                );
            }
        }
    }
}
