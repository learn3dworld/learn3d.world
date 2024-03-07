using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{ 
    public void toLesson1_1()
    {
        SceneManager.LoadScene("Lesson 1.1", LoadSceneMode.Single);
    }

    public void toLesson1_2()
    {
        SceneManager.LoadScene("Lesson 1.2", LoadSceneMode.Single);
    }


}
