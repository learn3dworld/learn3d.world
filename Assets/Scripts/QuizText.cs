using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;



public class QuizText : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons = new Button[4];
    [SerializeField]
    private TextMeshProUGUI questionTextElement;
    [SerializeField]
    private string[] answers = new string[4] { "", "", "", "" };
    [SerializeField]
    private string questionText = "";
    [SerializeField]
    private GameObject nextTimeline;

    private string[] questionNames = new string[4]
    {
        "A", "B", "C", "D",
    };


    public enum QuestionButton
    {
        A1, A2, A3, A4
    }

    [SerializeField]
    private QuestionButton correctAnswer;

    public void OnButtonClick(QuestionButton questionButton)
    {
        if (correctAnswer == questionButton)
        {
            if (nextTimeline != null)
            {
                nextTimeline.SetActive(true);
            }
        }
    }


    public void OnEnable()
    {
        clearListeners();

        buttons[0].onClick.AddListener(() => {
            OnButtonClick(QuestionButton.A1);
        });

        buttons[1].onClick.AddListener(() => {
            OnButtonClick(QuestionButton.A2);
        });

        buttons[2].onClick.AddListener(() => {
            OnButtonClick(QuestionButton.A3);
        });

        buttons[3].onClick.AddListener(() => {
            OnButtonClick(QuestionButton.A4);
        });

        for (int i = 0; i < buttons.Length; i++)
        {

            buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionNames[i] + ". " + answers[i];
        }

        questionTextElement.text = "Question: " + questionText;
    }

    private void clearListeners()
    {
        foreach (Button button in buttons)
        {
            button.onClick.RemoveAllListeners();
            button.enabled = true;
            button.interactable = true;
            button.gameObject.SetActive(true);
        }
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
