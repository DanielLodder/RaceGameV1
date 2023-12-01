using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FInish : MonoBehaviour
{
public void MainMenu(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
