using UnityEngine;
using System.Collections;

public class Process : MonoBehaviour {

    public Ingredient original;
    public GameObject processedIngredient;

	public GameObject ProcessIngredient()
    {
        Instantiate(processedIngredient);
        return processedIngredient;
    }
}
