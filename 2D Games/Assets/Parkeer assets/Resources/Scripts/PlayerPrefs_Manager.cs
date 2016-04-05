using UnityEngine;
using System.Collections;

public class PlayerPrefs_Manager : MonoBehaviour {
	public int Number_of_Levels = 3;



   // void Start()
   // {
    //    PlayerPrefs.DeleteAll();
   // }


	// Use this for initialization
	void Start () {

		

		//Adding the sound settings key
		if (!PlayerPrefs.HasKey ("SoundSettings")) 
		{
			PlayerPrefs.SetInt ("SoundSettings", 1);
		}

		//Adding the key that holds the amount of levels the user has unlocked.
		if(!PlayerPrefs.HasKey ("LevelsUnlocked"))
		{
			PlayerPrefs.SetInt ("LevelsUnlocked", 1);
		}


		//Adding the key that holds what game mode the user 
		//has selected. 

		if(!PlayerPrefs.HasKey ("GameMode"))
		{
			PlayerPrefs.SetString("GameMode","Timed");	
		}

        if (!PlayerPrefs.HasKey("Levels"))
        {
            PlayerPrefs.SetInt("Levels", Number_of_Levels);
        }

		CreateStars ();

	}


	void CreateStars()
	{

		for(int i = 0; i < Number_of_Levels; i++)
		{
			if(!PlayerPrefs.HasKey("Level" + i.ToString() + "Stars"))
			{
				PlayerPrefs.SetInt("Level" + i.ToString() + "Stars",0);
			}

            if (!PlayerPrefs.HasKey("Level" + i.ToString() + "BestTime"))
            {
                PlayerPrefs.SetFloat("Level" + i.ToString() + "BestTime", 0.0f);
            }
		}



	}
}
