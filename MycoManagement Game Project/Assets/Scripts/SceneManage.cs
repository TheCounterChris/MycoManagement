using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void TitleScene ()
    {
        SceneManager.LoadScene("Title Scene");
    }
    public void SplashScene ()
    {
        SceneManager.LoadScene("Splash Screen");
    }
    public void GameScene ()
    {
        SceneManager.LoadScene("Game Jam");
    }
    public void EndGame ()
    {
        Application.Quit();
    }
}
