using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
	public GameObject aimAssist;
	public GameObject enemy;

	public float Health;
	public float movespeed;
	public float dashLimit;
	[HideInInspector]public float dashDelay;
	public float lookSpeed;
	public float maxAngle;

	[HideInInspector]public Quaternion targetRotation;
	[HideInInspector]public Quaternion lookAtEmeny;

	[HideInInspector]public Vector3 playerDirection;

	public string HoriMovementForAnalogStick1;
	public string VertMovementForAnalogStick1;
	public string DashButton;
	public string stopMovementButton;
	public string LightMeeleAttack;
	public string HeavyMeeleAttack;

	/*[HideInInspector]*/public State currentState;
}
