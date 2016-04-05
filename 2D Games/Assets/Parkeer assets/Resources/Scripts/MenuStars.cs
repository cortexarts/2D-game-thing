using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuStars : MonoBehaviour {

	public int LevelNumber;
	public Image Star1;
	public Image Star2;
	public Image Star3;
	public Sprite FullStar;
	public Sprite Locked;

    public Text txtTime;

	void Start () {
		int tempStars = PlayerPrefs.GetInt ("Level" + LevelNumber.ToString () + "Stars");
        float BestTime = PlayerPrefs.GetFloat("Level" + LevelNumber.ToString() + "BestTime");

        if (BestTime <= 0)
        {
            txtTime.text = "NA";
        }
        else
        {
            txtTime.text = BestTime.ToString("n2");
        }

		switch (tempStars) 
		{

		case 1:
			Star1.sprite = FullStar;
			Star1.color = Color.white;
			break;

		case 2:
			Star1.sprite = FullStar;
			Star1.color = Color.white;

			Star2.sprite = FullStar;
			Star2.color = Color.white;
			break;

		case 3:
			Star1.sprite = FullStar;
			Star1.color = Color.white;

			Star2.sprite = FullStar;
			Star2.color = Color.white;

			Star3.sprite = FullStar;
			Star3.color = Color.white;
			break;
	
		}



		if(PlayerPrefs.GetInt("LevelsUnlocked") < LevelNumber)
		{
			gameObject.GetComponent<Image>().sprite = Locked;
		}
	}

}























