using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
