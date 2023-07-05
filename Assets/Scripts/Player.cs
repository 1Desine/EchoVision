using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private GameInput gameInput;

    private Vector3 lookRoation;

    [SerializeField] private float mouseSensitivity = 0.1f;



    void Start() {
        gameInput = GameInput.Instance;

    }



    void Update() {
        Vector3 inputDir = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = transform.forward * inputDir.y + transform.right * inputDir.x + transform.up * inputDir.z;

        transform.position += moveDir * Time.deltaTime;


        lookRoation.x = gameInput.GetRotationVectorNormalized().y;
        lookRoation.y = gameInput.GetRotationVectorNormalized().x;
        transform.eulerAngles += lookRoation * mouseSensitivity;
    }
}
