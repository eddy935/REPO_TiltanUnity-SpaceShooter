using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Text musicText;
    public Text SFXText;
    public Text controlsText;

    public void SceneChangeButton (string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGameButton ()
    {
        Application.Quit();
    }

    public void OnOffMusic()
    {
        if (musicText.text == "On")
        {
            musicText.text = "Off";
        }
        else
        {
            musicText.text = "On";
        }
    }

    public void OnOffSFX()
    {
        if (SFXText.text == "On")
        {
            SFXText.text = "Off";
        }
        else
        {
            SFXText.text = "On";
        }
    }

    public void ControlsTextTouchGyro()
    {
        if (controlsText.text == "Touch")
        {
            controlsText.text = "Gyro";
        }
        else
        {
            controlsText.text = "Touch";
        }
    }
}
