using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    GameObject[] gameOverObject;
    GameObject[] objectsToHide;
    GameObject[] VictoryHide;
    // Use this for initialization
    void Start ()
    {
        gameOverObject = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
        objectsToHide = GameObject.FindGameObjectsWithTag("GameOverHide");
        VictoryHide = GameObject.FindGameObjectsWithTag("ShowOnVictory");
        hideGameOver();
        hideVictory();
    }

    public void showGameOver()
    {
        foreach (GameObject g in gameOverObject)
        {
            g.SetActive(true);
        }
    }

    public void hideObjects()
    {
        foreach (GameObject g in objectsToHide)
        {
            g.SetActive(false);
        }
    }

    public void hideGameOver()
    {
        foreach (GameObject g in gameOverObject)
        {
            g.SetActive(false);
        }
    }

    public void hideVictory()
    {
        foreach (GameObject g in VictoryHide)
        {
            g.SetActive(false);
        }
    }

    public void showVictory()
    {
        foreach (GameObject g in VictoryHide)
        {
            g.SetActive(true);
        }
    }

    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void nextLevel()
    {
        if(SceneManager.GetActiveScene().name.Equals("Main2"))
        {
            SceneManager.LoadScene("Main");
        }
        else if(SceneManager.GetActiveScene().name.Equals("Main"))
        {
            SceneManager.LoadScene("Main3");
        }
        else if (SceneManager.GetActiveScene().name.Equals("Main3"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
