using UnityEngine;
using System.Collections;

public class Alchemy : LimitedPlacement
{
    public GameObject[] combinations;
    public GameObject spawnPoint;
    private Reageant.Ingredient currentIngredient;
    private bool ingredientSet;

    public override void process(Reageant.Ingredient ingredient)
    {
        if (!ingredientSet)
        {
            currentIngredient = ingredient;
            ingredientSet = true;
        }
        else
        {
            bool comboFound = false;
            foreach (GameObject combination in combinations)
            {
                Combination combo = combination.GetComponent<Combination>();
                if ((combo.in1 == currentIngredient && combo.in2 == ingredient)
                    || (combo.in2 == currentIngredient && combo.in1 == ingredient))
                {
                    comboFound = true;
                    GameObject combined = GameObject.Instantiate(combo.combinedIngredient) as GameObject;
                    combined.transform.position = spawnPoint.transform.position;
                }
            }
            if (!comboFound)
            {
                // failure event
            }
            ingredientSet = false;
        }
    }
}