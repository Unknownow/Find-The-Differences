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
    private LevelProperties _thisLevelProp;
    private LivesAndDailyManager _livesManager;
    private LivesChange _livesSprite;
    private bool _isOver = false;
    // Use this for initialization
    void Start () {
        _timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<UILabel>();
        _isOver = false;
        _thisLevelProp = gameObject.GetComponent<LevelProperties>();
        _maxSeconds = _thisLevelProp.getMaxSecondsForThisLevel();
        _secondsIncreasePerClick = _thisLevelProp.getSecondsIncreasePerClick();
        _goldsNeededToBuyTime = _thisLevelProp.getGoldsNeededToBuyTime();
        _livesManager = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<LivesAndDailyManager>();
        _livesSprite = GameObject.FindGameObjectWithTag("Shop Panel").transform.GetChild(4).GetComponent<LivesChange>();
        _livesSprite.hideHeartSprite(true);

        _timerCooldown = _maxSeconds;
        _timeStop = false;
        _timeSpend = 1;
        StartCoroutine(decreaseRemainingTimePerSecond(1));
    }
	
	// Update is called once per frame
	void Update () {
        if (_isOver)
            return;
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

    public void onBuyTimeClick()
    {
        _thisLevelProp.watchAds();
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
        _isOver = true;
        gameObject.GetComponent<OutOfTimePanel>().openOutOfTimePanel();
        _livesManager.decreaseCurrentLives();
        _livesSprite.hideHeartSprite(false);
    }

    public int getSpentTime()
    {
        return _timeSpend;
    }

}
