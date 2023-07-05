using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour {
    public static CameraScript Instance { get; private set; }


    [SerializeField] private Vector3 dotSpawnSpreadVector = new Vector3(.3f, .3f, .3f);
    private Vector3 raycastDirection;
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
                Random.Range(-dotSpawnSpreadVector.x, dotSpawnSpreadVector.x),
                Random.Range(-dotSpawnSpreadVector.y, dotSpawnSpreadVector.y),
                Random.Range(-dotSpawnSpreadVector.z, dotSpawnSpreadVector.z)
                );
            raycastDirection.Normalize();

            // Debug.DrawRay(transform.position, raycastDirection);
            if(Physics.Raycast(transform.position, raycastDirection, out RaycastHit hitInfo, viewDistance)) {
                SpawnDot(hitInfo.point, hitInfo.normal);
            }
        }
    }


    private void SpawnDot(Vector3 position, Vector3 normal) {
        DotsParent.Instance.SpawnDot(position, normal);
    }



}
