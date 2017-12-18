using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    GameObject[] HowToPlayObject;
    GameObject[] objectsToHide;
    GameObject[] hardmodeobjects;

    void Start()
    {
        HowToPlayObject = GameObject.FindGameObjectsWithTag("ShowOnHowToPlay");
        objectsToHide = GameObject.FindGameObjectsWithTag("OtherButtons");
        hardmodeobjects = GameObject.FindGameObjectsWithTag("ShowOnPlay");
        hideHowToPlay();
        hideDifficulty();
    }


    public void play()
    {
        SceneManager.LoadScene("Main2");
    }
    public void instructions()
    {

    }

    public void hideHowToPlay()
    {
        foreach (GameObject g in HowToPlayObject)
        {
            g.SetActive(false);
        }
        showObjects();
    }

    public void showHowToPlay()
    {
        foreach (GameObject g in HowToPlayObject)
        {
            g.SetActive(true);
        }
        hideObjects();
    }

    public void hideObjects()
    {
        foreach (GameObject g in objectsToHide)
        {
            g.SetActive(false);
        }
    }

    public void showObjects()
    {
        foreach (GameObject g in objectsToHide)
        {
            g.SetActive(true);
        }
    }

    public void showDifficulty()
    {
        foreach (GameObject g in hardmodeobjects)
        {
            g.SetActive(true);
        }
    }

    public void hideDifficulty()
    {
        foreach (GameObject g in hardmodeobjects)
        {
            g.SetActive(false);
        }
    }
}
