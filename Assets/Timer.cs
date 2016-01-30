using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public float timer;
    public Text timerText;
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 11)
        {
            timerText.color = Color.red;
        }
        if(timer <= 0)
        {
            timer = 0;
        }
	}

    void OnGUI()
    {
        timerText.text = (Mathf.Floor(timer / 60).ToString("0") + ":" + Mathf.Floor(timer % 60).ToString("00"));
    }
}
