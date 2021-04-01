// namespaces 
// don't forget to "use" all the necessary namespaces, because otherwise,
// some variable types or functions will not exist
// TMPro is a collection of all classes related to TextMeshPro
// UnityEngine is a collection of all classes related to unity
// UnityEngine.SceneManagement is a subcollection of UnityEngine that holds all classes related to scene management
// UnityEngine.UI is a subcollection of UnityEngine that holds all classes related to UI
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// this script is attached to the player
public class Timer : MonoBehaviour
{
    // timeRemaining is assigned in the inspector
    /* timerIsRunning is checked or not checked in the inspector
     * actually timerIsRunning doesn't need to be checked or not in inspector
     * because in the Start() function, it's set to true anyway
     * so when the game begins, it's true no matter what - checked or not */
    /* timeText is a TextMeshProUGUI element that is assigned to the TextMeshPro UI element that displays the time
     * use TextMeshProUGUI for TextMeshPro UI elements -- TextMeshPro is a type for meshes in 3d world space */
    /* fridge is a GameObject type that is assigned to the fridge game object in the game
     * it's used here to determine whether the player has the key, since
     * it's the fridge that the key is in, and the fridge has a hasKey boolean variable */
    // variables that are to be assigned in inspector must be public
    // if private, variable will not show up in inspector to be assigned
    public float timeRemaining;
    private bool timerIsRunning;
    public TextMeshProUGUI timeText;
    public GameObject fridge;
    public GameObject theLock;

    // when the game starts, the timer is running
    private void Start()
    {
        timerIsRunning = true;
        DisplayTime(timeRemaining);
    }

    // the game calls Update() every frame
    void Update()
    {
        /* remember, GameObject fridge is attached to the Fridge object
         * and the Fridge object has a script component attached to it, called FridgeOperation
         * if the variable hasKey in FridgeOperation is true, then the timerIsRunning variable is set to false
         * so that the timer stops running */
        // if (fridge.GetComponent<FridgeOperation>().hasKey == true)
        // timerIsRunning = false;

        if (theLock.GetComponent<LockOperations>().lockReachedWithKey == true)
                timerIsRunning = false;

        // otherwise, the player does not have the key yet and the timer must be running
        if (timerIsRunning)
        {
            // say timeRemaining = 50
            // say Time.deltaTime = 0.05
            // then timeRemaining -= 0.05, so timeRemaining = 50 - 0.05 = 49.95
            // display the time remaining
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            // otherwise, timeRemaining = 0
            else
            {
                Debug.Log("Time has run out!");
                // timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float fraction = timeToDisplay * 100;
        fraction %= 100;

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
    }
}