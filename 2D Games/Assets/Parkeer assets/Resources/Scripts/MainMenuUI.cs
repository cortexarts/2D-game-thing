using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuUI : MonoBehaviour {
	public GameObject MenuPanel;
	public GameObject SelectPanel1;
	public GameObject SelectPanel2;
	public GameObject SelectPanel3;
	public GameObject SelectPanel4;
	public GameObject SettingsPanel;
	public Text txtGraphics;
	public Text MuteText;
	public AudioClip LockedSound;

	public void Start()
	{
		if (PlayerPrefs.GetInt("SoundSettings") == 1)
		{
		  GetComponent<AudioSource>().mute = false;
			MuteText.text = "";
		} else if (PlayerPrefs.GetInt ("SoundSettings") == 0) 
		{
		  GetComponent<AudioSource>().mute = true;
			MuteText.text = "/";
		}


		txtGraphics.text = GetQualityName (QualitySettings.GetQualityLevel());
	}
	

	public void SwitchToSelection(string GameMode)
	{
		PlayerPrefs.SetString("GameMode", GameMode);

		SelectPanel1.SetActive (true);
		MenuPanel.SetActive (false);
		SettingsPanel.SetActive (false);

	}


	//Here we switch the select menu screens based on an integer value that is passed into the function when the button is clicked.
	//add more panels and then update this function based on how many panels you have added (see example, commented out below).

	public void ToggleSelectMenus(int MenuNo)
	{
		if (MenuNo == 1)
		{
			SelectPanel1.SetActive(true);
			SelectPanel2.SetActive(false);
			SelectPanel3.SetActive(false);
			SelectPanel4.SetActive(false);
		}

		if( MenuNo == 2)
		{
			SelectPanel1.SetActive(false);
			SelectPanel2.SetActive(true);
			SelectPanel3.SetActive(false);
			SelectPanel4.SetActive(false);
		}

		//EXAMPLE OF 3RD PANEL
		 if(MenuNo ==3)
		  {
		 SelectPanel1.SetActive(false);
		 SelectPanel2.SetActive(false);
		 SelectPanel3.SetActive(true);
		 SelectPanel4.SetActive(false);
		 }

		if(MenuNo ==4)
		{
			SelectPanel1.SetActive(false);
			SelectPanel2.SetActive(false);
			SelectPanel3.SetActive(false);
			SelectPanel4.SetActive(true);
		}
	}

	public void SwitchToMenu()
	{
		MenuPanel.SetActive (true);
		SelectPanel1.SetActive (false);
		SelectPanel2.SetActive (false);
		SelectPanel3.SetActive(false);
		SelectPanel4.SetActive(false);
		SettingsPanel.SetActive (false);
	}

	public void SwitchToSettings()
	{
		SettingsPanel.SetActive (true);
		SelectPanel1.SetActive (false);
		SelectPanel2.SetActive (false);
		SelectPanel3.SetActive(false);
		SelectPanel4.SetActive(false);
		MenuPanel.SetActive (false);
		}



	public void ChangeGraphics(string GraphicsSet)
	{
		if(GraphicsSet == "up")
			{ 
			QualitySettings.IncreaseLevel();
		}else if(GraphicsSet == "down") 
			{
			QualitySettings.DecreaseLevel();
		 }
		txtGraphics.text = GetQualityName (QualitySettings.GetQualityLevel());
	}



	public void ToggleSound()
	{
				int tempSound = PlayerPrefs.GetInt ("SoundSettings");

				if (tempSound == 1) {
			PlayerPrefs.SetInt("SoundSettings",0);
			//audio.mute = true;
			AudioListener.pause = true;
			MuteText.text = "/";
				} else if (tempSound == 0) {
			PlayerPrefs.SetInt("SoundSettings",1);
			//audio.mute = false;
			MuteText.text = "";
			AudioListener.pause = false;
				}
	}


	public void SelectLevel (int levelNo) 
	{
		if(PlayerPrefs.GetInt ("LevelsUnlocked") < levelNo)
		{
		GetComponent<AudioSource>().PlayOneShot(LockedSound);

		} else {
		Application.LoadLevel (levelNo);
		}

	}

	public string GetQualityName(int qualityNo)
	{
		 string[] names;
		names = QualitySettings.names;

		return names[qualityNo];
		}

}


















