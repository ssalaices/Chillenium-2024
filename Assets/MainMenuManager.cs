using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    GameObject shop;

    private void Start()
    {
        shop = GameObject.Find("Shop");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Dungeon");
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void EnterShop()
    {
        SceneManager.LoadScene("Shop");
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Entered Trigger " + other.gameObject.name);


        if (other.gameObject.name == "Player")
        {
            EnterShop();
        }
        
    }
}