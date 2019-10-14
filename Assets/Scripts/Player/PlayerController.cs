using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;
	public PlayerStats player;
	public Rigidbody rb;
	public GunStats gun;
	public UIManager ui;
	[HideInInspector]public Animator anim;
	public bool stationary = false;
	public bool heavyShotCharging = false;
	public bool GameOver;
	public int a = 0;
	public float delay;
	public Text GoToMenu;
	public Text O;
	public GameObject particles;
	public float countDown = 2;
	public bool start = false;

    // Use this for initialization
    void Start ()
	{		
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!GameOver) 
		{
			anim = this.transform.GetChild (0).GetComponent<Animator> ();
			player.currentState.UpdateState (this);


			if (GameManager.instance.StartFight)
			{
				transitions ();
				EndOfGame ();
				//CheckAmmo ();
			}

			if (a== 2) 
			{
				SceneManager.LoadScene ("Menu");
			}
		}
	}

	public void EndOfGame()
	{
		if (this.player.Health <= 0 && this.gameObject.name == "Player 2") 
		{
			GameOver = true;
			gameObject.SetActive (false);
			a = 2;
			GameManager.instance.FightText.text = "WINNER : PLAYER 1";
			GoToMenu.text = "Press    to go back to Menu";
			O.text = "  O";


		} 
		else 
		{
			if (this.player.Health <= 0 && this.gameObject.name == "Player 1") 
			{
				GameOver = true;
				gameObject.SetActive (false);
				a = 1;
				GameManager.instance.FightText.text = "WINNER : PLAYER 2";
				GoToMenu.text = "Press   to go back to Menu";
				O.text = "O";

				if (Input.GetButton ("Menu")) 
				{
					SceneManager.LoadScene ("Menu");
				}
			} 
		}
	}

	public void transitions()
	{
		gun.firedelay += Time.deltaTime;
		player.dashDelay += Time.deltaTime;
		if ((Mathf.Abs(Input.GetAxis (player.VertMovementForAnalogStick1)) > 0.2 || Mathf.Abs(Input.GetAxis (player.HoriMovementForAnalogStick1)) > 0.2 
			|| Mathf.Abs(Input.GetAxis (player.VertMovementForAnalogStick1)) < -0.2 || Mathf.Abs(Input.GetAxis (player.HoriMovementForAnalogStick1)) < -0.2) && (!stationary))
		{
			
			anim.SetBool ("IsHeavyShot", false);
			anim.SetBool ("IsShooting", false);
			if (Input.GetButton (gun.FireButton) && !heavyShotCharging)
			{
				anim.SetBool ("IsRunShooting", true);
				anim.SetBool ("IsRunning", false);
				anim.SetBool ("IsDashing", false);
				anim.SetBool ("IsHeavyShot", false);
				player.currentState = FindObjectOfType<StateManager> ().whichState ("Movement/ShootingState");
			} 
			else 
			{
				anim.SetBool ("IsRunShooting", false);
				if (Input.GetButton (player.DashButton) && player.dashDelay > player.dashLimit)
				{
					particles.SetActive (true);
					player.movespeed = 300f;
					anim.SetBool ("IsDashing", true);
					anim.SetBool ("IsRunning", false);
					anim.SetBool ("IsHeavyShot", false);
					player.currentState = FindObjectOfType<StateManager> ().whichState ("DashState");
					player.dashDelay = 0f;
					start = true;
				} 
				else 
				{
					if(Input.GetButtonUp (player.DashButton) || start == false)
					{
						player.movespeed = 75f;
					}

					if (start && countDown > 0)
					{
						countDown -= Time.deltaTime;
					}
					else
					{
						start = false;
						countDown = 0.5f;
					}

					if (!start)
					{
						particles.SetActive (false);
					}

					anim.SetBool ("IsRunning", true);
					anim.SetBool ("IsDashing", false);
					player.currentState = FindObjectOfType<StateManager> ().whichState ("MovementState");
				}
			}
		} 
		else 
		{
			anim.SetBool ("IsRunShooting", false);
			anim.SetBool ("IsRunning", false);
			anim.SetBool ("IsDashing", false);
			if (Input.GetButton (gun.FireButton) && !heavyShotCharging)
			{
				anim.SetBool ("IsShooting", true);
				player.currentState = FindObjectOfType<StateManager> ().whichState ("ShootingState");
			}
			else
			{
				anim.SetBool ("IsShooting", false);
				player.currentState = FindObjectOfType<StateManager> ().whichState ("IdleState");
			}
		}
			
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		if (Input.GetButton (gun.HeavyFireButton) && gun.HeavyShotReload == true)
		{
			heavyShotCharging = true;
			gun.chargeSound.SetActive (true);
			ui.ChargeSlider.value += Time.deltaTime;
			gun.chargeDelay += Time.deltaTime;
			anim.SetBool ("IsHeavyShot", true);
			player.currentState = FindObjectOfType<StateManager> ().whichState ("LockOnState");
		} 
		else 
		{
			if(Input.GetButtonUp (gun.HeavyFireButton) && gun.HeavyShotReload == true)
			{
				gun.HeavyShotReload = false;
				player.currentState = FindObjectOfType<StateManager> ().whichState ("ChargedShotState");

				if(!gun.HeavyShotReload)
				{
					player.aimAssist.SetActive (false);
				}
			}

			heavyShotCharging = false;

			gun.chargeSound.SetActive (false);
			anim.SetBool ("IsHeavyShot", false);
			if (ui.ChargeSlider.value >= 0)
			{ 
				ui.ChargeSlider.value -= Time.deltaTime;
				if (ui.ChargeSlider.value == 0)
				{
					gun.HeavyShotReload = true;
					gun.chargeDelay = 0f;
				}
			}
		}

		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

		if (Input.GetButton (player.stopMovementButton) && gun.HeavyShotReload)
		{
			anim.SetBool ("IsRunShooting", false);
			player.currentState = FindObjectOfType<StateManager> ().whichState ("StoppingState");
			stationary  = true;
		}
		else
		{
			if (Input.GetButtonUp (player.stopMovementButton) && gun.HeavyShotReload)
			{
				player.aimAssist.SetActive (false);
			}
			stationary  = false;
		}

		if (Input.GetButtonDown (player.HeavyMeeleAttack))
		{
			anim.SetBool ("IsHeavyMelee", true);
			//player.currentState = FindObjectOfType<StateManager> ().whichState ("ShootingState");
		}
		else
		{
			if (Input.GetButtonUp (player.HeavyMeeleAttack))
			{
				anim.SetBool ("IsHeavyMelee", false);
				//player.currentState = FindObjectOfType<StateManager> ().whichState ("ShootingState");
			}
		}

		if (Input.GetButtonDown (player.LightMeeleAttack))
		{
			anim.SetBool ("IsHeavyAttack", true);
			//player.currentState = FindObjectOfType<StateManager> ().whichState ("ShootingState");
		}
		else
		{
			if (Input.GetButtonUp (player.LightMeeleAttack))
			{
				anim.SetBool ("IsHeavyAttack", false);
				//player.currentState = FindObjectOfType<StateManager> ().whichState ("ShootingState");
			}
		}
	}

	void CheckAmmo()
	{
		switch(gun.numberOfBullets / 10)
		{
		case 0:
			player.movespeed = 65f;
			break;
		case 1:
			player.movespeed = 60f;
			break;
		case 2:
			player.movespeed = 55f;
			break;
		case 3:
			player.movespeed = 50f;
			break;
		case 4:
			player.movespeed = 45f;
			break;
		case 5:
			player.movespeed = 40f;
			break;
		case 6:
			player.movespeed = 35f;
			break;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Bullet")
		{
			player.Health = player.Health - 2;
			ui.decreasingHealth (2f);
		}
		else if (col.gameObject.tag == "Cannon1")
		{
			player.Health = player.Health - 5;
			ui.decreasingHealthCannon (5f);
		}
		else if (col.gameObject.tag == "Cannon2")
		{
			player.Health = player.Health - 10;
			ui.decreasingHealthCannon (10f);
		}
		else if (col.gameObject.tag == "Cannon3")
		{
			player.Health = player.Health - 15;
			ui.decreasingHealthCannon (15f);
		}
		else if (col.gameObject.tag == "Cannon4")
		{
			player.Health = player.Health - 20;
			ui.decreasingHealthCannon (20f);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Ammo") 
		{
			gun.numberOfBullets += 20;
			Destroy (col.gameObject);
		}
	}
}