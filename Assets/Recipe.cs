using UnityEngine;
using System.Collections;

public class Recipe : MonoBehaviour
{
    public Reageant.Ingredient[] ingredients;

    public bool ingredientCheck(int index, Reageant.Ingredient next)
    {
        if (ingredients[index] == next){
            return true;
        }
        return false;
    }
}