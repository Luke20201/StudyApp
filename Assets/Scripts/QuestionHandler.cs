using System;
using System.Linq;
using UnityEngine;
using MySql.Data.MySqlClient;

public class QuestionHandler : MonoBehaviour
{
    public TextAsset file;

    public Questions questionsList = new Questions();

    void Start()
    {
        string q = GetQuestionsFromDatabase();
        questionsList = JsonUtility.FromJson<Questions>(q);
        //questionsList = JsonUtility.FromJson<Questions>(file.text);
    }
    [System.Serializable]
    public class Question
    {
        public string title;
        public string category;
        public string answer;
        public string answer1;
        public string answer2;
        public string answer3;
    }

    [System.Serializable]
    public class Questions
    {
        public Question[] questions;
    }

    public Question SelectQuestion(string category)
    {
        System.Random x = new System.Random();
        int itemIndex = x.Next(questionsList.questions.Length);
        var item = questionsList.questions[itemIndex];
        if (item.category != category)
        {
            Debug.Log("Selected question is not of the correct category");
            return null;
        }
        else
        {
            return item;
        }
    }

    string GetQuestionsFromDatabase()
    {
        string connstr = "This is a mySQL connection string. This is redacted for the github release for obvious reasons.";
        string x = "{\n\"questions\":\n[";
        string y = "{\n\"title\": \"Which nation is accepted to have started the second world war?\", \n\"category\": \"History\",\n\"answer\": \"Germany\",\n\"answer1\": \"Poland\",\n\"answer2\": \"USSR\",\n\"answer3\": \"China\"\n}\n]\n}";
        // This is pre entered question which serves to be the final item added to the JSON. This is to prevent validation errors.
        MySqlConnection conn = new MySqlConnection(connstr);
        try
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `Questions`", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string z = "{" +
                    "\"title\": \"" + rdr[0] + "\"," +
                    "\"category\": \"" + rdr[1] + "\"," +
                    "\"answer\": \"" + rdr[2] + "\"," +
                    "\"answer1\": \"" + rdr[3] + "\"," +
                    "\"answer2\": \"" + rdr[4] + "\"," +
                    "\"answer3\": \"" + rdr[4] + "\"" +
                    "},";
                x = x.Insert(x.Length, z);
                Debug.Log("Inserted " + rdr[0]);
            }
            rdr.Close();
            conn.Close();
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.ToString());
            conn.Close();
        }

        Debug.Log(x + y);
        return x + y;
    }
}
