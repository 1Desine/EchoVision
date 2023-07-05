using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotsParent : MonoBehaviour {
    public static DotsParent Instance { get; private set; }


    [SerializeField] private Image dotImage;



    private void Awake() {
        Instance = this;
    }




    public void SpawnDot(Vector3 position) {
        Image spawnedImage = Instantiate(dotImage, this.transform);
        spawnedImage.transform.position = position;
    }


}
