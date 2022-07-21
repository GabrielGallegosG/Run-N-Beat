using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public void Reiniciar() {
        SceneManager.LoadScene("MainScene");
    }

    public void BackToMainMenu() {
        //SceneManager.LoadScene("MainMenuScene");
    }
}
