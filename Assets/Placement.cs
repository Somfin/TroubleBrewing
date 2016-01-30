using UnityEngine;
using System.Collections;

public class Placement : MonoBehaviour
{
    public Ingredient[] canTake;

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
                return true;
            }
        }
        return false;
    }
}