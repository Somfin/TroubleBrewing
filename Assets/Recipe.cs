using UnityEngine;
using System.Collections;

public class Recipe : MonoBehaviour
{
    public Ingredient[] ingredients;
    public int currentIndex;
    private bool started;

    void Start()
    {
        started = false;
    }

    public bool nextIngredientCheck(Ingredient next)
    {
        if (!started)
        {
            started = true;
            currentIndex = 0;
        }
        Debug.Log(currentIndex);
        if (ingredients[currentIndex] == next){
            currentIndex ++;
            return true;
        }
        return false;
    }
}