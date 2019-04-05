using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour {
    private float _maxSeconds = 120;
    private int _secondsIncreasePerClick = 20;
    private int _goldsNeededToBuyTime = 300;
    private float _timerCooldown;
    private UILabel _timer;
    private bool _timeStop = false;
    private int _timeSpend = 1;
    private LevelProperties thisLevelProp;
    // Use this for initialization
    void Start () {
        _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<UILabel>();

        thisLevelProp = gameObject.GetComponent<LevelProperties>();
        _maxSeconds = thisLevelProp.getMaxSecondsForThisLevel();
        _secondsIncreasePerClick = thisLevelProp.getSecondsIncreasePerClick();
        _goldsNeededToBuyTime = thisLevelProp.getGoldsNeededToBuyTime();


        _timerCooldown = _maxSeconds;
        _timeStop = false;
        _timeSpend = 1;
        StartCoroutine(decreaseRemainingTimePerSecond(1));
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
                _timeSpend += 1;
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

    public void increaseRemainingTimeBySecond()
    {
        if (PlayerPrefs.GetInt("Gold") < _goldsNeededToBuyTime)
        {
            thisLevelProp.watchAds();
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + _goldsNeededToBuyTime);
        }
        if (PlayerPrefs.GetInt("Gold") < _goldsNeededToBuyTime)
            return;
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - _goldsNeededToBuyTime);
        _timerCooldown += _secondsIncreasePerClick;
        Debug.Log("Increase Time (Time Manager)");
    }

    /*
     * stop timer countdown:
     * true == stop
     * false == continue
    */
    public void stopTime(bool stop)
    {
        //Debug.Log("time stop == " + stop);
        _timeStop = stop;
    }

    // Call when time is up
    public void outOfTime()
    {
        //write code down here
        gameObject.GetComponent<OutOfTimePanel>().openOutOfTimePanel();
    }

    public int getSpentTime()
    {
        return _timeSpend;
    }

}
