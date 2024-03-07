using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{

    public VisualTreeAsset mainMenu;
    public VisualTreeAsset lessonsMenu;
    public VisualTreeAsset aboutMenu;
    private UIDocument document;

    public void OnEnable()
    {
        document = GetComponent<UIDocument>();
        InstantiateMainMenu();
    }

    public void InstantiateMainMenu()
    {
        document.visualTreeAsset = mainMenu;

        Button lessonsButton = document.rootVisualElement.Q<Button>("LessonsButton");
        lessonsButton.RegisterCallback<ClickEvent>((_)=> InstantiateLessonsMenu());

        Button settingsButton = document.rootVisualElement.Q<Button>("SettingsButton");
        settingsButton.RegisterCallback<ClickEvent>((_) => { }); // TODO: Add settings menu

        Button aboutButton = document.rootVisualElement.Q<Button>("AboutButton");
        aboutButton.RegisterCallback<ClickEvent>((_) => InstantiateAboutMenu());
    }

    public void InstantiateLessonsMenu()
    {
        document.visualTreeAsset = lessonsMenu;

        Button backButton = document.rootVisualElement.Q<Button>("ExitButton");
        backButton.RegisterCallback<ClickEvent>((_) => InstantiateMainMenu());

        Button lesson1_1 = document.rootVisualElement.Q<Button>("1_1_Button");
        lesson1_1.RegisterCallback<ClickEvent>((_) => loadScene("Lesson 1.1"));

        Button lesson1_2 = document.rootVisualElement.Q<Button>("1_2_Button");
        lesson1_2.RegisterCallback<ClickEvent>((_) => loadScene("Lesson 1.2"));
    }

    public void InstantiateAboutMenu()
    {
        document.visualTreeAsset = aboutMenu;

        Button backButton = document.rootVisualElement.Q<Button>("ExitButton");
        backButton.RegisterCallback<ClickEvent>((_) => InstantiateMainMenu());
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
