using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

    public float timer;
    public Text timerText;
    public GameObject MainTheme;
    public GameObject Cauldron;
    public GameObject MerlinKnock;
    public GameObject MerlinIntro;
    public GameObject MerlinMumble;
    public GameObject MerlinLetMeIn;
    public GameObject MerlinTrouble;
    public GameObject MerlinBreach;
    public GameObject FailJingle;
    public GameObject WinJingle;
    private bool stop = false;
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (Cauldron.GetComponent<Cauldron>().isFinished() && !stop)
        {
            Win();
            stop = true;
        }
        if (Cauldron.GetComponent<Cauldron>().isFailed() && !stop){
            Lose();
            stop = true;
        }
        if (timer % 23 < 5 && timer % 23 > 4)
        {
            MerlinKnock.GetComponent<AudioSource>().Stop();
            MerlinKnock.GetComponent<AudioSource>().Play();
        }
        if (timer < 180 && timer > 179 && !MerlinIntro.GetComponent<AudioSource>().isPlaying)
        {
            MerlinIntro.GetComponent<AudioSource>().Play();
        }
        if (timer < 120 && timer > 119 && !MerlinMumble.GetComponent<AudioSource>().isPlaying)
        {
            MerlinMumble.GetComponent<AudioSource>().Play();
        }
        if (timer < 60 && timer > 59 && !MerlinLetMeIn.GetComponent<AudioSource>().isPlaying)
        {
            MerlinLetMeIn.GetComponent<AudioSource>().Play();
        }
        if(timer <= 11)
        {
            timerText.color = Color.red;
        }
        if (timer < 5 && timer > 4 && !MerlinTrouble.GetComponent<AudioSource>().isPlaying)
        {
            MerlinTrouble.GetComponent<AudioSource>().Play();
        }
        if(timer <= 0 && !stop)
        {
            timer = 0;
            MerlinBreach.GetComponent<AudioSource>().Play();
            Lose();
            stop = true;
        }
	}

    public void Win()
    {
        MainTheme.GetComponent<AudioSource>().Stop();
        WinJingle.GetComponent<AudioSource>().Play();
    }

    public void Lose()
    {
        MainTheme.GetComponent<AudioSource>().Stop();
        FailJingle.GetComponent<AudioSource>().Play();
    }

    void OnGUI()
    {
        timerText.text = (Mathf.Floor(timer / 60).ToString("0") + ":" + Mathf.Floor(timer % 60).ToString("00"));
    }
}
