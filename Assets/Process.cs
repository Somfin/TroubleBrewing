using UnityEngine;
using System.Collections;

public class Process : MonoBehaviour {

    public Reageant.Ingredient original;
    public GameObject processedIngredient;

	public GameObject ProcessIngredient()
    {
        Instantiate(processedIngredient);
        return processedIngredient;
    }
}
