using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCamera : MonoBehaviour {
    // Start is called before the first frame update
    public Transform target;
    public Vector3 oldPos;
    public Quaternion oldRotation;

    public float speed;

    public bool reverse = false;

    void OnEnable() {
        oldPos = transform.position;
        oldRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update() {
        if (!reverse) {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);

            transform.LookAt(target.parent);
        } else {
            transform.position = Vector3.Lerp(transform.position, oldPos, Time.deltaTime * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, oldRotation, Time.deltaTime * speed);
            // print((transform.position - oldPos).magnitude);
            if ((transform.position - oldPos).magnitude < 0.1f) {
                FindObjectOfType<CameraControl>().enabled = true;
                reverse = false;
                FindObjectOfType<ShopCamera>().enabled = false;
                Buttons.GotoMenu();
            }
        }
    }
}