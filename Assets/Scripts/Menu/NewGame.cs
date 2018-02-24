using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {

    public AudioSource select_sound;
    public AudioSource back_sound;

    public Button select_level;
    public Button[] levels;
    public Button new_game;
    public Button how_to_play;
    public Button credits;
    public Button back;
    public Button exit;

   

    public GameObject instructions;
    public GameObject credit_roll;
	// Use this for initialization
	void Start () {
      
		
	}

    public void openCredits()
    {
        select_sound.Play();
        credit_roll.SetActive(true);
        back.gameObject.SetActive(true);
        new_game.gameObject.SetActive(false);
        select_level.gameObject.SetActive(false);
        how_to_play.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }

    public void howToPlay()
    {
        select_sound.Play();
        back.gameObject.SetActive(true);
        credit_roll.SetActive(false);
        new_game.gameObject.SetActive(false);
        select_level.gameObject.SetActive(false);
        how_to_play.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);

        instructions.SetActive(true);

    }

    public void quitApplication()
    {
        select_sound.Play();
        Application.Quit();
    }

    public void goBack()
    {
        back_sound.Play();
        back.gameObject.SetActive(false);
        instructions.SetActive(false);
        credit_roll.SetActive(false);
        new_game.gameObject.SetActive(true);
        select_level.gameObject.SetActive(true);
        how_to_play.gameObject.SetActive(true);
        credits.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);

        for(int i = 1; i < levels.Length + 1; i++)
        {
            levels[i - 1].gameObject.SetActive(false);
        }
    }

    public void levelSelect()
    {
        select_sound.Play();
        back.gameObject.SetActive(true);
        new_game.gameObject.SetActive(false);
        credit_roll.SetActive(false);
        select_level.gameObject.SetActive(false);
        how_to_play.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        for(int i = 1; i < levels.Length + 1; i++)
        {
            Debug.Log("Level" + i.ToString() + "Unlocked");
            if(PlayerPrefs.GetString("Level" + i.ToString() + "Unlocked") == "yes")
            {
                levels[i - 1].gameObject.SetActive(true);
            }
            
        }
    }

    public void loadLevel(int index)
    {
        select_sound.Play();
        SceneManager.LoadScene(index);
    }

    public void newGame()
    {
        select_sound.Play();

        PlayerPrefs.SetString("Level1Unlocked", "yes");
        PlayerPrefs.SetString("Level2Unlocked", "no");
        PlayerPrefs.SetString("Level3Unlocked", "no");
        PlayerPrefs.SetString("Level4Unlocked", "no");
        PlayerPrefs.SetString("Level5Unlocked", "no");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
