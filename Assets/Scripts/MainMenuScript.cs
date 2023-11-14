using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;
    public void Starting()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void Quit()
    {
        Debug.Log("Application has been Quit");
        Application.Quit();
    }
    public void Credits()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void Back()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

}
