using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerSelection : MonoBehaviour
{
    public bool answered = false;
    public void Selection(Button btn)
    {
        answered = true;
        if(btn.tag == "CA")
        {
            btn.GetComponentInParent<Image>().color = Color.green;
        }
        else
        {
            btn.GetComponentInParent<Image>().color = Color.red;
        }
    }
}
