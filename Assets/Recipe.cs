using UnityEngine;
using System.Collections;

public class Recipe : MonoBehaviour
{
    public Ingredient[] ingredients;
    private int currentIndex = 0;

    public bool nextIngredientCheck(Ingredient next){
        if (ingredients[currentIndex] == next){
            currentIndex ++;
            return true;
        }
        return false;
    }
}