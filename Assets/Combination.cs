﻿using UnityEngine;
using System.Collections;

public class Combination : MonoBehaviour {

    public Ingredient in1, in2;
    public GameObject combinedIngredient;

    public GameObject CombineIngredients()
    {
        Instantiate(combinedIngredient);
        return combinedIngredient;
    }

}
