using UnityEngine;
using System.Collections;

public class Recipe : MonoBehaviour
{
    public Ingredient[] ingredients;

    public bool ingredientCheck(int index, Ingredient next)
    {
        if (ingredients[index] == next){
            return true;
        }
        return false;
    }
}