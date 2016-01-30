using UnityEngine;
using System.Collections;

public abstract class LimitedPlacement : Placement
{
    public Reageant.Ingredient[] canTake;

    public override bool place(GameObject core){
        Placeable toPlace = core.GetComponent<Placeable>();
        if (toPlace == null){
            return false;
        }
        Reageant.Ingredient incoming = toPlace.nature;
        for (int i = 0; i < canTake.Length; i++){
            if (canTake[i] == incoming)
            {
                GameObject.Destroy(core);
                process(incoming);
                return true;
            }
        }
        return false;
    }

    public abstract void process(Reageant.Ingredient ingredient);
}