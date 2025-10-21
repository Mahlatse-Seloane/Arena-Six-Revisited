using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public State CurrentState, RemainInState;
    public Animator anim;
    public GameObject DashTrail, PickUpEffect, LightSaber;
    public float emoteDuration = 0f, earthShatterDuration = 0f;
    public KeyCode LeftKey, RightKey, UpKey, DownKey, DashKey;
    public KeyCode lockOnKey, EarthShatterKey, EmoteKey;
    public KeyCode LightMeleeKey;
    public KeyCode HeavyFireKey, FireKey;
    public PlayerStats stats;
    public GunStats gun;
    public GameObject[] sounds;

    public Rigidbody rb { get; set; }
    public float HitDelay { get; set; }
    public float EmoteDelay { get; set; }
    public float EarthShatterDelay { get; set; }
    public float MoveHorizontal { get; set; }
    public float MoveVertical { get; set; }
    public bool PlayerStationary { get; set; }
    public bool HeavyHit { get; set; }
    public bool LockedOn { get; set; }
    public bool StopLightMelee { get; set; }
    public bool StopHeavyMelee { get; set; }
    public bool Emote { get; set; }
    public bool Shooting { get; set; }
    public bool EarthShatter { get; set; }
    public bool Moving { get; set; }
    public bool LightMelee { get; set;}

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        stats.dashDelay = stats.dashTimeLimit;
        LightMelee = false;
    }

    void Update()
    {
        if (!GameManager.instance.IsGameOver)
            GamePlay();
    }

    private void GamePlay()
    {
        if (CurrentState == null || InputManager.instance.paused || !GameManager.instance.StartFight)
            return;

        CurrentState.UpdateState(this);

        gun.increaseFireTime();
        IncreaseDashStamina();

        MoveHorizontal = PlayerHorizontalMovement();
        MoveVertical = PlayerVerticalMovement();
        Moving = Mathf.Abs(MoveHorizontal) > 0 || Mathf.Abs(MoveVertical) > 0f;

        if (CurrentState.name != "DashState")
        {
            anim.SetBool("Dash", false);
            sounds[1].SetActive(false);
            DashTrail.SetActive(false);
        }
    }

    private float PlayerHorizontalMovement()
    {
        if (Input.GetKey(LeftKey))
            return -1f;
        else if (Input.GetKey(RightKey))
            return 1f;

        return 0f;
    }

    private float PlayerVerticalMovement()
    {
        if (Input.GetKey(UpKey))
            return -1f;
        else if (Input.GetKey(DownKey))
            return 1f;

        return 0f;
    }

    public void IncreaseDashStamina()
    {
        if (!stats.AllowDash || !Input.GetKey(DashKey))
        {
            if (stats.dashDelay < stats.dashTimeLimit)
                stats.dashDelay += Time.deltaTime;
            else if (!stats.AllowDash)
                stats.AllowDash = true;
        }
    }

    public void DecreaseDashStamina()
    {
        stats.dashDelay -= Time.deltaTime;
        if (stats.dashDelay <= 0)
            stats.AllowDash = false;
    }

    public void CheckAmmo(int value)
    {
        if (value < 40)
            stats.MoveSpeed = 150f;
        else if (value >= 40 && value < 50)
            stats.MoveSpeed = 140f;
        else if (value >= 50 && value < 60)
            stats.MoveSpeed = 130f;
        else if (value >= 60 && value < 70)
            stats.MoveSpeed = 120f;
        else if (value >= 70 && value < 80)
            stats.MoveSpeed = 110f;
        else if (value >= 80 && value < 90)
            stats.MoveSpeed = 100f;
        else if (value >= 90)
            stats.MoveSpeed = 90f;
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != RemainInState)
            CurrentState = nextState;
    }

    private void TakeDamage(float damage)
    {
        stats.HealthSlider.value -= damage;
        stats.Health -= damage;

        if (stats.Health <= 0)
            PlayerManager.instance.WhoWon((gameObject.name == "Player 1") ? 1 : 2);
    }

    private void OnCollisionEnter(Collision col)
    {
        if ((col.gameObject.tag == "Ring1" && name == "Player 1") || (col.gameObject.tag == "Ring2" && name == "Player 2"))
        {
            stats.flashTime = 0.6f;
            stats.Hurt = true;
            TakeDamage(15f);
        }
        else if (col.gameObject.tag.Contains("Cannon"))
        {
            float damage = 0f; 
            for (int i = 1; i < 4; i++)
            {
                if (col.gameObject.tag.Contains("Cannon" + i.ToString()))
                {
                    damage = 15f + (5 * (i - 1));
                    break;
                }
            }

            stats.flashTime = 1f;
            stats.Hurt = true;
            TakeDamage(damage);
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ammo")
        {
            Destroy(col.gameObject);
            Vector3 spawnPos = transform.position + new Vector3(0f, 7f, 0f);
            Instantiate(PickUpEffect, spawnPos, transform.rotation);
            audioManager.instance.Play("PickUp");
            gun.reload();
        }
        else if (col.tag == "Sword" || col.tag == "Bullet")
        {
            float damage = (col.tag == "Sword") ? 3f : 2f;
            stats.flashTime = (col.tag == "Sword") ? 0.6f : 0.3f;
            stats.Hurt = true;
            TakeDamage(damage);

            if (col != null && col.gameObject != null && col.tag != "Sword")
                Destroy(col.gameObject);
        }
    }
}