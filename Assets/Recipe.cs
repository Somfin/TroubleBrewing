using UnityEngine;
using System.Collections;

public class Recipe : MonoBehaviour
{
    public Ingredient[] ingredients;
    public GameObject book;
    public string leftTextBox;
    public string rightTextBox;

    public bool ingredientCheck(int index, Ingredient next)
    {
        if (ingredients[index] == next){
            return true;
        }
        return false;
    }

    public bool isComplete(int index)
    {
        return index == ingredients.Length;
    }
}