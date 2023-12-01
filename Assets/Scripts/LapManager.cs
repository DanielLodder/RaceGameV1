using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
    [SerializeField] private float checkpointNumber = 0;
    [SerializeField] private float maxCheckpointNumber = 0;
    [SerializeField] private float lapNumber = 0;
    [SerializeField] private float maxLapNumber = 0;
    [SerializeField] public bool Hasfinished = false;
    [SerializeField] private GameObject lapCheck;
    [SerializeField] private GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            checkpointNumber++;
            Debug.Log("checkpoint" + checkpointNumber);
        }
        if (checkpointNumber == maxCheckpointNumber && lapCheck.transform.position == Player.transform.position)
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
