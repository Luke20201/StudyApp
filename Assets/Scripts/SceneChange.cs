using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void GoToQuestionCreater()
    {
        SceneManager.LoadScene("AddAQuestion");
    }
    public void GoToQuestionMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
