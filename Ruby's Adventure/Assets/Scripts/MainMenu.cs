using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene("MainScene"); //This load the level one of the game when pressing the play button.
    }


    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelection"); //This load the level selection menu scene of the game.
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("QuitGame"); //This load a scene that ask you are you sure you want to quit game with a yes and a no option.
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // this load the main menu screen S
    }

    public void BossLevel()
    {
        SceneManager.LoadScene("Level 2"); //This load the level selection menu scene of the game.
    }

}
