using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour {

    private float lifeTime = 20f;



    void FixedUpdate() {
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0 ) {
            DestroySelf();
        }
    }


    private void DestroySelf() {
        Destroy(this.gameObject);
    }

}
