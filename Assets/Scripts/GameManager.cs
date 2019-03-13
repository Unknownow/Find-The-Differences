using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    [SerializeField]
    private float seconds = 120;
    private float timerCooldown;
    private UILabel timer;
    private Coroutine countDown;
	// Use this for initialization
	void Start () {
        timerCooldown = seconds;
        countDown = StartCoroutine(timeCountdown(1));
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<UILabel>();
    }
	
	// Update is called once per frame
	void Update () {
        if (timerCooldown >= 0)
        {
            timerCountdown();
        }
	}



    private void timerCountdown()
    {
        float seconds = timerCooldown % 60;
        float minutes = 0;
        if (seconds > 59)
        {
            minutes = Mathf.Floor(timerCooldown / 60) + 1;
            seconds = 0;
        }
        else
        {
            minutes = Mathf.Floor(timerCooldown / 60);
        }
        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    IEnumerator timeCountdown(int seconds)
    {
        while (timerCooldown >= 0)
        {
            yield return new WaitForSeconds(seconds);
            timerCooldown -= 1;
        }

    }

    public void decreaseTimer(int seconds)
    {
        if(timerCooldown < seconds)
        {
            timerCooldown = 0;
            return;
        }
        timerCooldown -= seconds;
    }

    public void stopTimer(bool stop)
    {
        if (stop)
        {
            StopCoroutine(countDown);
            return;
        }
        countDown = StartCoroutine(timeCountdown(1));
    }
}
