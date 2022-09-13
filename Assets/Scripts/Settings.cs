using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject OtherUI;
    public GameObject SettingsUI;
    public void SettingsStateChange(bool open)
    {
        if (open)
        {
            OtherUI.SetActive(false);
            SettingsUI.SetActive(true);
        }
        else
        {
            OtherUI.SetActive(true);
            SettingsUI.SetActive(false);
        }
    }

    public void ResetQuestion()
    {
        SceneManager.LoadScene("AddAQuestion");
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
