using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Information : MonoBehaviour {
    public int displayTime = 5;
    public float currentDisplay;
    public GameObject info;
	
	// Update is called once per frame
	void Update () {
        currentDisplay -= Time.deltaTime;
        if (currentDisplay > 0)
        {
            info.SetActive(true);
        }
        else
        {
            info.SetActive(false);
        }
	}

    public void display()
    {
        currentDisplay = displayTime;
    }
}
