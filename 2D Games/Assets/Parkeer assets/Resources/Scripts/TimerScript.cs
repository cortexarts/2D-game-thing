using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
	public float TimerValue = 20;
	public Text txtTimer;
    bool TimedMode;
	GameManager  gamemanager;

	void Start () {
	gamemanager = GameObject.Find("_GameManager").GetComponent<GameManager>();
	if(PlayerPrefs.GetString("GameMode") != "Timed")
		{
			gameObject.SetActive (false);
		} else {
			TimedMode = true;
		}
		
	}
	

	void Update () {
	
		if(TimedMode)
		{
			RunTimer();
		}
	}

	void RunTimer()
	{
		TimerValue -= Time.deltaTime;
		txtTimer.text = TimerValue.ToString("n2");
		if(TimerValue <= 0)
		{
			gamemanager.LevelLose();
		}

	}
}
