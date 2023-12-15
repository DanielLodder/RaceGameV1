using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    //[SerializeField] private bool finish;
    //[SerializeField] private bool halfway; 

    //public int checkpointId;
    
    public LapManager manager;
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        if (other.CompareTag("Player"))
        {
            manager.checkpointNumber++;
            Debug.Log("checkpoint" + manager.checkpointNumber);
        }
    }

    /*public void halfwayCheck()
    {
        if (manager.maxCheckpointNumber / 2 == manager.checkpointNumber)
        {

        }
    }*/
}
