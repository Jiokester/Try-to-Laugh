using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Monaghan, Devin
/// 02/04/2024
/// handle ui buttons
/// </summary>

public class UiManager : MonoBehaviour
{
    // Start game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Quit Game
    public void Quit()
    {
        Application.Quit();
        print("quit");
    }
}