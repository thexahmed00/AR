using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ARLessons : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlaced;

    GameObject instaGameObject;
    private ARRaycastManager raycastManager;
    List<ARRaycastHit> _hits=new List<ARRaycastHit>();
     private Vector2 touch;
     public Camera Arcam;
    
    void Awake()
  {
      raycastManager = GetComponent<ARRaycastManager>();
  }
    void Update()
    {
        if (Arcam == null)
        {
            return;
            
        }   
        if (Input.GetMouseButton(0))
        {
            Ray ray = Arcam.ScreenPointToRay(Input.mousePosition);


            if (raycastManager.Raycast(ray, _hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = _hits[0].pose;
                if (instaGameObject == null)
                {

                    instaGameObject = Instantiate<GameObject>(objectToPlaced, hitPose.position, hitPose.rotation);

                }
                else
                {

                    instaGameObject.transform.position = hitPose.position;
                }
            }
        }

    }

    }
    
     
     

