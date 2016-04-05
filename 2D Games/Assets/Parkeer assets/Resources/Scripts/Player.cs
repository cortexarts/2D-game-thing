using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float power  = 5;
	public  float maxspeed   = 10;
	public  float turnpower  = 5;
	public float friction  = 5; 
	public GameObject SmokeFX;
	public AudioClip EngineNoise;

	bool blnGO;
	bool blnTarget1;
	bool blnTarget2;
	GameManager  gamemanager;
	Joystick leftJoy;
	Joystick rightJoy;

	
	void Start ()
	{
		GetComponent<AudioSource>().clip = EngineNoise;
		GetComponent<AudioSource>().Play();
		leftJoy = GameObject.Find("LeftJoystick").GetComponent<Joystick>(); //defining the left joystick.
		rightJoy = GameObject.Find("RightJoystick").GetComponent<Joystick>();//defining the right joystick.
		gamemanager = GameObject.Find("_GameManager").GetComponent<GameManager>(); //defining the gamemanager GameObject.
		blnGO = false; //defining the GameOver boolean (set to true when player crashes).

	}


	void FixedUpdate ()
	{
		//Change engine noise pitch to sound like increase in engine revs.
		GetComponent<AudioSource>().pitch = .3f + (GetComponent<Rigidbody2D>().velocity.sqrMagnitude * .1f);


		//if run mobile or PC controls depending on platform.
		if(Application.isMobilePlatform)
		{
			MobileControls();
		} else {
			KeyboardControls();
		}
	}
	
	void MobileControls()
	{
		//Vector2 mobForce =  -Vector2.up * rightJoy.position.y * power;
		Vector3 mobRotate = Vector3.forward * -rightJoy.position.x * turnpower;

		//rigidbody2D.AddForce(mobForce);
		GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up*leftJoy.position.y * power);
		transform.Rotate(mobRotate);
	}

	void KeyboardControls()
	{
		if(Input.GetKey(KeyCode.UpArrow) && !blnGO)
		{
//			GetComponent<Rigidbody2D>().drag = 2;
			GetComponent<Rigidbody2D>().AddForce(transform.up * power);
		}


		if(Input.GetKey(KeyCode.DownArrow)&& !blnGO)
		{
//			GetComponent<Rigidbody2D>().drag = 2;
			GetComponent<Rigidbody2D>().AddForce(-(transform.up) * power);
		}

		if(Input.GetKeyUp(KeyCode.UpArrow) && !blnGO)
		{
//			GetComponent<Rigidbody2D>().drag = friction;
//			GetComponent<Rigidbody2D>().angularDrag = friction;
		}
		
		
		if(Input.GetKeyUp(KeyCode.DownArrow)&& !blnGO)
		{
//			GetComponent<Rigidbody2D>().drag = friction;
//			GetComponent<Rigidbody2D>().angularDrag = friction;
		}

		
		if(Input.GetKey(KeyCode.LeftArrow)&& !blnGO)
		{

			transform.Rotate (Vector3.forward * GetComponent<Rigidbody2D>().velocity.magnitude);
		}
		
		if(Input.GetKey(KeyCode.RightArrow)&& !blnGO)
		{
		
			transform.Rotate(-Vector3.forward * GetComponent<Rigidbody2D>().velocity.magnitude);
		}
	}


	void OnCollisionEnter2D (Collision2D collision)
	{
		if (collision.gameObject.tag == "Obst") 
		{
			Instantiate(SmokeFX, new Vector3(collision.contacts[0].point.x,collision.contacts[0].point.y,0), Quaternion.identity);//creates a smoke effect at the collision point.
			GameOver();
		}

		
	}


	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Star") 
		{
			Debug.Log ("penis");
			Destroy(collision.gameObject);
			gamemanager.CollectStar();
			
		}

		if (collision.gameObject.tag == "TimeBonus") 
		{
			float TTA = collision.GetComponent<TimeBonus>().TimeToAdd;
			GameObject.Find ("Timer").GetComponent<TimerScript>().TimerValue += TTA;
			Destroy(collision.gameObject);	
			gamemanager.CollectTime();
		}

		if (collision.gameObject.tag == "WinZone")
		{
			GameWin ();
		}
	}
	
	void GameOver ()
	{
		GetComponent<AudioSource>().Stop();
		gamemanager.LevelLose ();
		blnGO = true;

	}
	
	void GameWin()
	{
		GetComponent<AudioSource>().Stop();
		gamemanager.LevelWin ();
	}
}
