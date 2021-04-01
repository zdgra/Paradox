// namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// all unity classes derive from the base class MonoBehaviour
public class MainMenu : MonoBehaviour
{
    // this function was attached to PlayButton's click operation
    // scenemanager gets the current scene's index, adds one for the next scene, and loads that next scene
    public void OpeningNote()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // outputs "Quit!" to the debugging log
    // quits application
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}