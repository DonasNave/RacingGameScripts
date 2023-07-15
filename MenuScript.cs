using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void LaunchGame()
    {
        SceneManager.LoadScene("Valley");
    }
    
    public void ExitGame() {
        Application.Quit();
    }
}
