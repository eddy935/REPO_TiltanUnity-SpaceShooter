using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void NewGameButton (string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGameButton ()
    {
        Application.Quit();
    }
}
