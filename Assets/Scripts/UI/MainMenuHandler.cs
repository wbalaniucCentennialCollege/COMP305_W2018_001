using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NEW USING STATEMENTS BELOW
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    public void Play()
    {
        // Debug.Log("Play");
        SceneManager.LoadScene("Week6_2");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
