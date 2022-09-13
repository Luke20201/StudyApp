using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UILoader : MonoBehaviour
{
    public Text title;
    public string currentAnswer;
    public QuestionHandler.Question question;
    public GameObject category;

    public void Request()
    {
        string cate = category.GetComponentInChildren<Text>().text;
        QuestionHandler qh = GetComponentInParent<QuestionHandler>();
        question = qh.SelectQuestion(cate);
        while(question == null)
        {
            question = qh.SelectQuestion(cate);
        }
        currentAnswer = question.answer;

        title.text = question.title;

        List<int> numbers = new List<int> { 1, 2, 3, 4 };
        List<int> nums = new List<int>();

        for(int i = numbers.Count; i > 0 ; i--)
        {
            int j = Random.Range(0, i);
            Debug.Log("num = " + numbers[j]);
            nums.Add(numbers[j]);
            numbers.RemoveAt(j);
        }

        Color standardColor = new Color(0.3254902f, 0.0f, 0.5f, 1.0f);
        GameObject.Find("Answer" + nums[0]).GetComponentInChildren<Text>().text = question.answer;
        GameObject.Find("Answer" + nums[0]).tag = "CA";
        GameObject.Find("Answer" + nums[0]).GetComponentInChildren<Image>().color = standardColor;
        GameObject.Find("Answer" + nums[1]).GetComponentInChildren<Text>().text = question.answer2;
        GameObject.Find("Answer" + nums[1]).tag = "WA";
        GameObject.Find("Answer" + nums[1]).GetComponentInChildren<Image>().color = standardColor;
        GameObject.Find("Answer" + nums[2]).GetComponentInChildren<Text>().text = question.answer3;
        GameObject.Find("Answer" + nums[2]).tag = "WA";
        GameObject.Find("Answer" + nums[2]).GetComponentInChildren<Image>().color = standardColor;
        GameObject.Find("Answer" + nums[3]).GetComponentInChildren<Text>().text = question.answer1;
        GameObject.Find("Answer" + nums[3]).tag = "WA";
        GameObject.Find("Answer" + nums[3]).GetComponentInChildren<Image>().color = standardColor;
    }
}
