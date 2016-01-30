using UnityEngine;
using System.Collections;

public class Cauldron : Placement
{
    public GameObject recipe;

    public override bool place(GameObject core){
        Placeable toPlace = core.GetComponent<Placeable>();
        if (toPlace == null){
            return false;
        }
        Ingredient incoming = toPlace.nature;
        Recipe rec = recipe.GetComponent<Recipe>();
        if (rec.nextIngredientCheck(incoming))
        {

        }
        else
        {

        }
        Destroy(core);
        return true;
    }
}