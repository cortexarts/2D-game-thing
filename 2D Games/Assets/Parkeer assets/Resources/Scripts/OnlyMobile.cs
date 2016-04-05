using UnityEngine;
using System.Collections;

public class OnlyMobile : MonoBehaviour {

	public GameObject Joystick;

	// Use this for initialization
	void Start () {
	
		if(!Application.isMobilePlatform)
		{
			Joystick.SetActive(false);
		}

	}
	

}