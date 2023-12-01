using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloppyLapmanager : MonoBehaviour
{
    [SerializeField] private GameObject EndScreen;

    [SerializeField] private int Maxlap = 3;
    [SerializeField] private int currentlap = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentlap++;
        }
        if (currentlap == Maxlap)
        {
            Time.timeScale = 0;
            EndScreen.SetActive(true);
        }
    }
}
