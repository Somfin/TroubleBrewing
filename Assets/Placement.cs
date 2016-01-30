using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour
{
    public Ingredient[] canTake;
    public GameObject[] processes;
    public GameObject spawnPoint;

    public bool place(GameObject core){
        Placeable toPlace = core.GetComponent<Placeable>();
        if (toPlace == null){
            return false;
        }
        Ingredient incoming = toPlace.nature;
        for (int i = 0; i < canTake.Length; i++){
            if (canTake[i] == incoming)
            {
                GameObject.Destroy(core);
                GameObject processed = GameObject.Instantiate(process(incoming)) as GameObject;
                processed.transform.position = spawnPoint.transform.position;
                return true;
            }
        }
        return false;
    }

    private GameObject process(Ingredient ingredient)
    {
        foreach (GameObject processor in processes){
            Process process = processor.GetComponent<Process>();
            if (process.original == ingredient)
            {
                return process.processedIngredient;
            }
        }
        return null;
    }
}