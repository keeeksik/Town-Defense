using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utilities : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);

    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
