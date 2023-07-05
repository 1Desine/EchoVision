using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour {
    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;


    private void Awake() {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.FreeFly.Enable();

    }


    public Vector3 GetMovementVectorNormalized() {
        return playerInputActions.FreeFly.Move.ReadValue<Vector3>();
    }
    public Vector2 GetRotationVectorNormalized() {
        return playerInputActions.FreeFly.Look.ReadValue<Vector2>();
    }



}
