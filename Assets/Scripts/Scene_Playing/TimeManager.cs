using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour {

    [SerializeField]
    private float _seconds = 120;
    private float _timerCooldown;
    private UILabel _timer;
    private bool _timeStop = false;
	// Use this for initialization
	void Start () {
        _timerCooldown = _seconds;
        StartCoroutine(decreaseRemainingTimePerSecond(1));
        _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<UILabel>();
        _timeStop = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (_timerCooldown >= 0)
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
        float seconds = _timerCooldown % 60;
        float minutes = 0;
        if (seconds > 59)
        {
            minutes = Mathf.Floor(_timerCooldown / 60) + 1;
            seconds = 0;
        }
        else
        {
            minutes = Mathf.Floor(_timerCooldown / 60);
        }
        _timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    //decrease remaining time by *seconds every 1 second in real life
    IEnumerator decreaseRemainingTimePerSecond(int seconds)
    {
        while (_timerCooldown >= 0)
        {
            if (!_timeStop)
            {
                yield return new WaitForSeconds(seconds);
                _timerCooldown -= 1;
            }
            yield return new WaitForSeconds(0);
        }
    }

    //decrease *seconds to remaining time
    public void decreaseRemainingTimeBySecond(int seconds)
    {
        if(_timerCooldown < seconds)
        {
            _timerCooldown = 0;
            return;
        }
        _timerCooldown -= seconds;
    }


    /*
     * stop timer countdown:
     * true == stop
     * false == continue
    */
    public void stopTime(bool stop)
    {
        Debug.Log("time stop == " + stop);
        _timeStop = stop;
    }

    // Call when time is up
    public void outOfTime()
    {
        //write code down here
        gameObject.GetComponent<OutOfTimePanel>().openOutOfTimePanel();
    }
}
