using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour {
    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward;
    public bool moveBackward;

    private CharacterController cc;


	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
            moveBackward = false;
        }
        else if (vrCamera.eulerAngles.x > 270 && vrCamera.eulerAngles.x <= 320f)
        {
            moveForward = false;
            moveBackward = true;
        }
        else
        {
            moveForward = false;
            moveBackward = false;
        }
        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
        if (moveBackward)
        {
            Vector3 backward = -1 * vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(backward * speed);
        }
	}
}
