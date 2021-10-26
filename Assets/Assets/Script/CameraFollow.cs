using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float CameraMoveSpeed = 6000.0f;
	public GameObject CameraFollowObj;
	Vector3 FollowPOS;
	public float clampAngle = 80.0f;
	public float inputSensitivity = 1.0f;
	public GameObject CameraObj;
	public GameObject PlayerObj;
	public float camDistanceXToPlayer;
	public float camDistanceYToPlayer;
	public float camDistanceZToPlayer;
	public float mouseX;
	public float mouseY;
	public float finalInputX;
	public float finalInputZ;
	public float smoothX;
	public float smoothY;
	private float rotY = 0.0f;
	private float rotX = 0.0f;



	// Use this for initialization
	void Start () {
		inputSensitivity = 6;
		CameraMoveSpeed = 60000000.0f;
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = -Input.GetAxis ("Mouse Y");
		finalInputX = mouseX;
		finalInputZ = mouseY;

		rotY += finalInputX * inputSensitivity;
		rotX += finalInputZ * inputSensitivity;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

	}

	void LateUpdate () {
		CameraUpdater ();
	}

	void CameraUpdater() {
		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;

		// set the target object to follow
		Transform target = CameraFollowObj.transform;

		//move towards the game object that is the target
		float step = CameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
}
