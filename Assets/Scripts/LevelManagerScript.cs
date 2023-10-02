using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 2f;
    
    ScoreKeeperScript scoreKeeperScript;

    void Awake()
    {
        scoreKeeperScript = FindObjectOfType<ScoreKeeperScript>();
    }

    public void LoadGame()
    {
        scoreKeeperScript.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad("MainMenu", sceneLoadDelay));
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay)); 
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game....");
        //tùy nền tảng mà nó sẽ hoạt động, đối với ƯebGL thì ko hoạt động
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string scenename, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scenename);
    }
}
