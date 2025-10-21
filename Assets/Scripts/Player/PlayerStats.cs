using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerStats
{
	public GameObject lockOn, enemy;

    private float health = 100f;

    private float dashSpeed = 600f;
    private float lookSpeed = 300f;
    public float dashDelay { get; set; }
    [Range (0f, 15f)] public float dashTimeLimit = 10f;

    public string HeavyMeeleAttack;

    public Slider HealthSlider;
    public Renderer playerRend;
    public Material normalMat, hitMat;

    public Quaternion TargetRotation { get; set; }
    public Quaternion lookAtEmeny { get; set; }
    public Vector3 PlayerDirection { get; set; }

    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    public float DashSpeed
    {
        get { return dashSpeed; }
        set { dashSpeed = value; }
    }
    public float LookSpeed
    {
        get { return lookSpeed; }
        set { lookSpeed = value; }
    }
    public bool AllowDash { get; set; }
    public bool Hurt { get; set; }
    public float flashTime { get; set; }
    public float MoveSpeed { get; set; }

    public bool Dash { get; set; }
}
