﻿using UnityEngine;
using System.Collections;

public class Processor : LimitedPlacement
{
    public GameObject[] processes;
    public GameObject spawnPoint;

    public override void process(Ingredient ingredient)
    {
        foreach (GameObject processor in processes){
            Process process = processor.GetComponent<Process>();
            if (process.original == ingredient)
            {
                GameObject processed = GameObject.Instantiate(process.processedIngredient) as GameObject;
                processed.transform.position = spawnPoint.transform.position;
                if (GetComponent<AudioSource>() != null)
                {
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}