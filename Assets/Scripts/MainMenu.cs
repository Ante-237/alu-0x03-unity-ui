using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// controls various menu settings for main menu
/// </summary>
public class MainMenu : MonoBehaviour
{

    /// <summary>
    ///  quits application
    /// </summary>
    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    
    /// <summary>
    /// loads maze scene
    /// </summary>
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }
    
    
    
    
}
