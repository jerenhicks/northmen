using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Camera theCamera;
    private Transform cameraRig;
    private Vector3 lastMousePos;
    private float cameraZAugment = 5f;

	// Use this for initialization
	void Start () {
		if (theCamera == null) {
            theCamera = GetComponent<Camera>();
        }

        if (theCamera == null) {
            theCamera = Camera.main;
        }

        if (theCamera == null) {
            Debug.LogError("Camera was null");
            return;
        }

        cameraRig = theCamera.transform.parent;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)) {
            lastMousePos = Input.mousePosition;
        } else if (Input.GetMouseButton(1)) {
            Vector3 currentMousePos = Input.mousePosition;

            Vector3 mouseMovement = currentMousePos - lastMousePos;


            float xPos = cameraRig.position.x - mouseMovement.x / 100;
            if (xPos < -1f) {
                xPos = -1;
            }
            if (xPos > Map.getWidth() + 1) {
                xPos = Map.getWidth() + 1;
            }
            float yPos = cameraRig.position.y;
            float zPos = cameraRig.position.z - mouseMovement.y / 100;
            if (zPos < -2f) {
                zPos = -2;
            }
            if (zPos > Map.getHeight() + 2) {
                zPos = Map.getHeight() + 2;
            }
            cameraRig.position = new Vector3(xPos, yPos, zPos);

            lastMousePos = currentMousePos;
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0) {

            Vector3 currentMousePos = Input.mousePosition;

            Vector3 mouseMovement = currentMousePos - lastMousePos;

            float xPos = cameraRig.position.x;
            float yPos = cameraRig.position.y - 1;
            if (yPos < (-1 * cameraZAugment)) {
                yPos = (-1 * cameraZAugment);
            }
            float zPos = cameraRig.position.z;

            cameraRig.position = new Vector3(xPos, yPos, zPos);

            lastMousePos = currentMousePos;
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            Vector3 currentMousePos = Input.mousePosition;

            Vector3 mouseMovement = currentMousePos - lastMousePos;

            float xPos = cameraRig.position.x;
            float yPos = cameraRig.position.y + 1;
            if (yPos > 0) {
                yPos = 0;
            }
            float zPos = cameraRig.position.z;

            cameraRig.position = new Vector3(xPos, yPos, zPos);

            lastMousePos = currentMousePos;
        }

    }
}
