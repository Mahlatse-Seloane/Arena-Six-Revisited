using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float dampTime = 0.2f; //The amount of time we want our camera to take to move to the position that its required
	public float screenEdgeBuffer = 4f; // The number we add to the sizes to ensure that the that the tanks arent athe the egde of the screen
	public float minSize = 6.5f; // The limit in which the camera can zoom in
	/*[HideInInspector]*/public Transform[] targets; // A transform array with the objects to consider when zooming in

	private Camera camera; // Referenxe  to the camera
	private float zoomSpeed; // A variable to damp the zoom speed of the camera
	private Vector3 moveVelocity; // A variable to damp the movement of the camera
	private Vector3 desiredPosition; // The position that the camera is trying to reach. (The average position of the tanks)

	private void Awake()
	{
		camera = GetComponentInChildren<Camera> (); // Finding the camera component which is a child to the CameraRig
	}
	 
	private void Update()
	{
		Move ();
		Zoom ();
	}
		
	private void Move()
	{
		FindAveragePosition (); // Find average position and once found, set desired position to that value. 

		transform.position = Vector3.SmoothDamp (transform.position, desiredPosition, ref moveVelocity, dampTime); // Smoothly moves that camera between its current position and the desired position
	}

	private void FindAveragePosition()
	{
		Vector3 averagePos = new Vector3 ();
		int numOfTargets = 0;

		for (int i = 0; i < targets.Length; i++) {
			/* This if statement if the target's game object is active. 
			Because when a target dies, they are deactivated. Therefore
			we do not want to zoom in on deactivated players*/
			if (!targets [i].gameObject.activeSelf) {
				continue; 
			}

			averagePos += targets [i].position; // Adding each target's position to the average posiotion
			numOfTargets++; // Increasing the numer of targets there are
		}

		if (numOfTargets > 0) 
		{
			averagePos /= numOfTargets; // Dividing the average position by how much targets there are
		}

		averagePos.y = transform.position.y; //Keeping the y coordinate of the average position to that of the camera rig.

		desiredPosition = averagePos;
	}

	private void Zoom()
	{
		float requiredSize = FindRequiredSize ();
		camera.orthographicSize = Mathf.SmoothDamp (camera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);  
	}

	private float FindRequiredSize()
	{
		/*Finding desired position of the camera in the camera rig's local space*/
		Vector3 desiredLocalPos = transform.InverseTransformPoint (desiredPosition);

		float size = 0f;

		//Finding the position of the targets, and which ever one is furtherest, zoom out to accomodate that one, resulting in capturing all of them
		for (int i = 0; i < targets.Length; i++) 
		{
			if (!targets [i].gameObject.activeSelf)
			{
				continue; 
			}

			//Finding that target in the local position of the camera rig
			Vector3 targetLocalPos = transform.InverseTransformPoint (targets [i].position);

			Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

			size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / camera.aspect);
		}

		size += screenEdgeBuffer;

		size = Mathf.Max (size, minSize);

		return size;
	}

	public void SetStartPositionAndSize()
	{
		FindAveragePosition ();

		transform.position = desiredPosition;

		camera.orthographicSize = FindRequiredSize ();
	}
}
