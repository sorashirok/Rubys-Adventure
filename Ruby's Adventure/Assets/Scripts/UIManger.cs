using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManger : MonoBehaviour
{

    public static UIManger instance;
    [SerializeField]
    TextMeshProUGUI RobotCounter;
    public int scoreCount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UpdateRobotCounterUI()
    {
        RobotCounter.text = scoreCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
         //If R is hit, restart the current scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            /*
            If Q is hit, quit the game
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Application Quit");
                Application.Quit();
            }
           */
    }
}
