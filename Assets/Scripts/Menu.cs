using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void keMain() {
        SceneManager.LoadScene("Main");
    }

    public void keInfo() {
        //Application.LoadLevel("Info");
    }

    public void keQuit() {
        Application.Quit();
    }
}
