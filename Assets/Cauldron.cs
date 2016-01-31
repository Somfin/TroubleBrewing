using UnityEngine;
using System.Collections;

public class Cauldron : Placement
{
    public GameObject recipe;
    public GameObject pedestal;
    public GameObject mySound;
    public GameObject book;
    public int currentIndex;
    public GameObject winShine;
    public GameObject failShine;
    public bool failed;

    void Start(){
        currentIndex = 0;
        book.GetComponent<Information>().info = GameObject.Instantiate(recipe.GetComponent<Recipe>().book);
        book.GetComponent<Information>().info.transform.SetParent(GameObject.Find("CameraCanvas").transform, false);
    }

    public override bool place(GameObject core){
        Placeable toPlace = core.GetComponent<Placeable>();
        if (toPlace == null){
            return false;
        }
        Ingredient incoming = toPlace.nature;
        Recipe rec = recipe.GetComponent<Recipe>();
        Destroy(core);
        bool success = false;
        if (rec.ingredientCheck(currentIndex, incoming))
        {
            success = true;
        }
        else
        {
            // Assume failure means that it might need to check the pedestal
            Pedestal catalyst = pedestal.GetComponent<Pedestal>();
            if (rec.ingredientCheck(currentIndex, catalyst.currentIngredient))
            {
                success = true;
            }
        }
        if (success)
        {
            GameObject win = GameObject.Instantiate(winShine);
            win.transform.position = this.gameObject.transform.position;
            GameObject.Destroy(win, 4);
            currentIndex++;
        }
        else
        {
            GameObject fail = GameObject.Instantiate(failShine);
            fail.transform.position = this.gameObject.transform.position;
            failed = true;
        }
        AudioSource audio = mySound.GetComponent<AudioSource>();
        audio.Stop();
        audio.Play();
        return true;
    }

    public bool isFinished()
    {
        return recipe.GetComponent<Recipe>().isComplete(currentIndex);
    }

    public bool isFailed()
    {
        return failed;
    }
}