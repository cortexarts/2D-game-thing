using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	public float MovementSpeed = 1;
	public float TimeBeforeTurning;

	public bool isCar;
	float startPos;
	int turnedState;

	void Start () {
		StartCoroutine(UpTimer());
	}
	
	void Update () {
		if (isCar) 
		{
			transform.Translate (Vector3.up * Time.deltaTime * MovementSpeed);

		}else {
				transform.Translate (Vector3.left * Time.deltaTime * MovementSpeed);
	}
}





	IEnumerator UpTimer() {
		{
			yield return new WaitForSeconds (TimeBeforeTurning);
			transform.Rotate (0, 0, 180);
			if(isCar) {
				transform.Translate(1.75f,0f,0f);
			} else {
				transform.Translate(.75f,0f,0f);
			}

			StartCoroutine (DownTimer ());
		}
	}

		IEnumerator DownTimer() {
			{
				yield return new WaitForSeconds(TimeBeforeTurning);
				transform.Rotate(0,0,-180);
			if(isCar) {
				transform.Translate(1.75f,0f,0f);
					  } else {
				transform.Translate(.75f,0f,0f);
						     }
				
				StartCoroutine(UpTimer());
			}
       }

}