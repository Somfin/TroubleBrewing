using UnityEngine;
using System.Collections;

public class Combination : MonoBehaviour {

    public Reageant.Ingredient in1, in2;
    public GameObject combinedIngredient;

    public GameObject CombineIngredients()
    {
        Instantiate(combinedIngredient);
        return combinedIngredient;
    }

}
