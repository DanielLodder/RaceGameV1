using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    public int checkpointNumber = 0;
    public int maxCheckpointNumber = 0;
    [SerializeField] private int lapNumber = 0;
    [SerializeField] private int maxLapNumber = 0;
    [SerializeField] public bool Hasfinished = false;
    [SerializeField] private BoxCollider lapCheck;
    [SerializeField] private BoxCollider Player;
    [SerializeField] private GameObject[] checkpoints;

    private void Start()
    {
        maxCheckpointNumber = checkpoints.Length;
    }
    private void Update()
    {
        
        if (checkpointNumber >= maxCheckpointNumber && lapCheck)
        {
            lapNumber++;
        }
        if (lapNumber == maxLapNumber)
        {
            Debug.Log("Finished");
            Hasfinished = true;
            Time.timeScale = 0;
        }
    }
}
