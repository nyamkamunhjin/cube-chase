using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Transform playerTransform;

    public Vector3 cameraPos = new Vector3(0f, 25f, -10f);

    private void Start() {
        transform.LookAt(playerTransform);
    }
    
    void Update() {
        
        if (playerTransform != null) {
            
            transform.position = playerTransform.position + cameraPos;
        }

    }

}