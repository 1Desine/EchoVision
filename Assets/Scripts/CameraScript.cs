using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour {
    public static CameraScript Instance { get; private set; }

    //[SerializeField] private Vector3 RotationAxis;
    //[SerializeField] private Vector3 SourceVector;
    [SerializeField] private Vector3 spreadVector = new Vector3(.3f, .3f, .3f);
    private Vector3 raycastDirection;
    private float fov = 50;
    private float viewDistance = 1000;

    [SerializeField] private int amountOfDots;

    private void Awake() {
        if(Instance != null) {
            Debug.Log("CameraScript - more then one Instance");
        }
        Instance = this;
    }


    private void FixedUpdate() {

        for(int i = 0; i < amountOfDots; i++) {
            raycastDirection = transform.forward;

            raycastDirection += new Vector3(
                Random.Range(-spreadVector.x, spreadVector.x),
                Random.Range(-spreadVector.y, spreadVector.y),
                Random.Range(-spreadVector.z, spreadVector.z)
                );
            raycastDirection.Normalize();

            Debug.DrawRay(transform.position, raycastDirection);
            if(Physics.Raycast(transform.position, raycastDirection, out RaycastHit hitInfo, viewDistance)) {
                SpawnDot(hitInfo.point);
            }
        }

    }


    private void SpawnDot(Vector3 position) {
        DotsParent.Instance.SpawnDot(position);
    }



}
