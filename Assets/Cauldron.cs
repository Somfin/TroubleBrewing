using UnityEngine;
using System.Collections;

public class Cauldron : Placement
{
    public GameObject recipe;
    public int currentIndex;
    public GameObject winShine;
    public GameObject failShine;

    void Start(){
        currentIndex = 0;
    }

    public override bool place(GameObject core){
        Placeable toPlace = core.GetComponent<Placeable>();
        if (toPlace == null){
            return false;
        }
        Ingredient incoming = toPlace.nature;
        Recipe rec = recipe.GetComponent<Recipe>();
        Destroy(core);
        if (rec.ingredientCheck(currentIndex, incoming))
        {
            GameObject.Destroy(GameObject.Instantiate(winShine), 4);
        }
        else
        {
            GameObject fail = GameObject.Instantiate(failShine);
            fail.transform.parent = gameObject.transform;
        }
        return true;
    }
}