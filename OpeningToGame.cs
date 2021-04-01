// namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// class name must be the same as the file name
public class OpeningToGame : MonoBehaviour
{
    // this script is attached to the openingnote image in the OpeningNote scene
    // the game calls update every frame
    // if a left button click (0) is detected, then the scene with the next index is loaded
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}