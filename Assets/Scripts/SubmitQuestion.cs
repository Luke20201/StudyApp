using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;

public class SubmitQuestion : MonoBehaviour
{
    public Text Title;
    public Text Category;
    public Text Answer;
    public Text Answer2;
    public Text Answer3;
    public Text Answer4;

    public void InsertData()
    {
        string title = Title.text;
        string category = Category.text;
        string answer = Answer.text;
        string answer2 = Answer2.text;
        string answer3 = Answer3.text;
        string answer4 = Answer4.text;

        title = title.Replace("\"", "'");
        answer = answer.Replace("\"", "'");
        answer2 = answer2.Replace("\"", "'");
        answer3 = answer3.Replace("\"", "'");
        answer4 = answer4.Replace("\"", "'");

        MySqlConnection conn = new MySqlConnection("This is a mySQL connection string. This is redacted for the github release for obvious reasons.");
        try
        {
            conn.Open();
            string command = "INSERT INTO `Questions`(`title`, `category`, `answer`, `answer1`, `answer2`, `answer3`) VALUES (" +
                "'" + title + "'," +
                "'" + category + "'," +
                "'" + answer + "'," +
                "'" + answer2 + "'," +
                "'" + answer3 + "'," +
                "'" + answer4 + "'" +
                ")";
            MySqlCommand cmd = new MySqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        catch(Exception ex)
        {
            Debug.LogError(ex.ToString());
            conn.Close();
        }
    }
}
