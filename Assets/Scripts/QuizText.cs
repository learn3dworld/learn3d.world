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
    [SerializeField]
    private GameObject wrongText;

    private string[] questionNames = new string[4]
    {
        "A", "B", "C", "D",
    };


    public enum QuestionButton
    {
        A1, A2, A3, A4
    }

    [SerializeField]
    private int correctAnswer;

    public void OnButtonClick(int questionButton)
    {
        Debug.Log(questionButton);
        if (correctAnswer == questionButton)
        {
            if (nextTimeline != null)
            {
                Debug.Log("helo");
                wrongText.SetActive(false);
                nextTimeline.SetActive(true);
                gameObject.SetActive(false);
            }
        } else
        {
            wrongText.SetActive(true);
        }
    }


    public void OnEnable()
    {
        clearListeners();

        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i])
            {
                int j = i;
                buttons[i].onClick.AddListener(() => {
                    OnButtonClick(j);
                });

                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionNames[i] + ". " + answers[i];
            }
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

    public void show()
    {
        this.gameObject.SetActive(true);
    }

    public void hide()
    {
        this.gameObject.SetActive(true);
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
