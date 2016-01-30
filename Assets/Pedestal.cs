using UnityEngine;
using System.Collections;

public class Pedestal : Placement
{
    public Ingredient[] canTake;
    public Ingredient currentIngredient;
    public GameObject heldObjectPosition;

    public override bool place(GameObject core){
        Placeable placed = core.GetComponent<Placeable>();
        if (placed == null)
        {
            return false;
        }
        Ingredient incoming = placed.nature;
        for (int i = 0; i < canTake.Length; i ++)
        {
            if (incoming == canTake[i]){
                currentIngredient = incoming;
                core.transform.position = heldObjectPosition.transform.position;
                core.GetComponent<Rigidbody>().useGravity = false;
                core.GetComponent<Rigidbody>().velocity = Vector3.zero;
                core.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                return true;
            }
        }
        return false;
    }
}