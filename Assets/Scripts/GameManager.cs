using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    [SerializeField]
    private float seconds = 120;
    private float timerCooldown;
    private UILabel timer;
    private bool timeStop = false;
	// Use this for initialization
	void Start () {
        timerCooldown = seconds;
        StartCoroutine(decreaseRemainingTimePerSecond(1));
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<UILabel>();
        timeStop = false;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(timeStop);
        if (timerCooldown >= 0)
        {
            timerCountdown();
            /*
             * if have any additional function add it before return!
            */
            return;
        }
        outOfTime();
	}


    // Time countdown function
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

    //decrease remaining time by *seconds every 1 second in real life
    IEnumerator decreaseRemainingTimePerSecond(int seconds)
    {
        while (timerCooldown >= 0)
        {
            if (!timeStop)
            {
                yield return new WaitForSeconds(seconds);
                timerCooldown -= 1;
            }
            yield return new WaitForSeconds(0);
        }
    }

    //decrease *seconds to remaining time
    public void decreaseRemainingTimeBySecond(int seconds)
    {
        if(timerCooldown < seconds)
        {
            timerCooldown = 0;
            return;
        }
        timerCooldown -= seconds;
    }


    /*
     * stop timer countdown:
     * true == stop
     * false == continue
    */
    public void stopTime(bool stop)
    {
        Debug.Log("time stop == " + stop);
        timeStop = stop;
    }

    // Call when time is up
    public void outOfTime()
    {
        //write code down here
        gameObject.GetComponent<OutOfTimePanel>().openOutOfTimePanel();
    }
}
