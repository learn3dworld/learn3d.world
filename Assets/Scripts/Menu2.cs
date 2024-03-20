using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu2 : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons = new Button[4];
    [SerializeField]
    private TextMeshProUGUI[] texts = new TextMeshProUGUI[4];

    public void OnEnable()
    {
        InstantiateMainMenu();
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

    public void InstantiateMainMenu()
    {
        Debug.Log("Instantiated Main Menu");
        clearListeners();
        buttons[0].onClick.AddListener(InstantiateLessonsMenu);
        texts[0].text = "    Lessons";

        buttons[1].onClick.AddListener(InstantiateSettingsMenu);
        texts[1].text = "    Settings";
        
        buttons[2].onClick.AddListener(InstantiateAboutMenu);
        texts[2].text = "    About";

        buttons[3].onClick.AddListener(Application.Quit);
        texts[3].text = "    Exit";
    }

    public void InstantiateLessonsMenu()
    {
        Debug.Log("Instantiated Lessons Menu");
        clearListeners();
        buttons[0].onClick.AddListener(InstantiateLessonsMenu);
        buttons[0].interactable = false;
        texts[0].text = "    Unit 1";

        buttons[1].onClick.AddListener(() => loadScene("Lesson 1.1"));
        texts[1].text = "    Lesson 1.1";
        
        buttons[2].onClick.AddListener(() => loadScene("Lesson 1.2"));
        texts[2].text = "    Lesson 1.2";

        buttons[3].onClick.AddListener(InstantiateMainMenu);
        texts[3].text = "    Back";
    }

    public void InstantiateAboutMenu()
    {
        Debug.Log("Instantiated About Menu");
        clearListeners();
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);

        buttons[3].onClick.AddListener(InstantiateMainMenu);
        texts[3].text = "    Back";
    }

    public void InstantiateSettingsMenu()
    {
        Debug.Log("Instantiated Settings Menu");
        clearListeners();
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);

        buttons[3].onClick.AddListener(InstantiateMainMenu);
        texts[3].text = "    Back";
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
