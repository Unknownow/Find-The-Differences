using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.Detectors;
using System;
using UnityEngine.UI;

public class LivesAndDailyManager : MonoBehaviour
{
    [SerializeField]
    private int _maxLives = 5;

    //public Text text1;
    //public Text text2;
    [SerializeField]
    private int _currentLives;
    [SerializeField]
    private bool _isTimeCheating = false;
    private TimeCheatingDetector _timeCheatDetector;

    // Start is called before the first frame update
    void Start()
    {
        _isTimeCheating = false;
        _timeCheatDetector = gameObject.GetComponent<TimeCheatingDetector>();
        if (!_timeCheatDetector.IsRunning)
            TimeCheatingDetector.StartDetection();
        if (PlayerPrefs.GetString("Time") == "")
        {
            Debug.Log("LivesAndDailyManager - First Time Play");
            resetTime();
        }
        else
        {
            _currentLives = PlayerPrefs.GetInt("Lives");
            onCheckingTime();
        }

        //TimeCheatingDetector.StartDetection();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_timeCheatDetector.IsRunning)
            TimeCheatingDetector.StartDetection();

        //text1.text = _timeCheatDetector.LastResult.ToString();
        //text2.text = _timeCheatDetector.LastError.ToString();

        if (Input.GetKeyDown(KeyCode.O))
        {
            decreaseCurrentLives();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            resetTime();
        }
    }

    public void onDetectedTimeCheat()
    {
        _isTimeCheating = true;
    }


    private void onCheckingTime()
    {
        if (!_timeCheatDetector.IsRunning)
            _timeCheatDetector.ForceCheck();

        if (_isTimeCheating)
            return;
        string temp = PlayerPrefs.GetString("Time");
        string[] time = temp.Split('/');
        int day, month, year;
        day = int.Parse(time[0]);
        month = int.Parse(time[1]);
        year = int.Parse(time[2]);
        DateTime temp2 = new DateTime(year, month, day);
        if (DateTime.Compare(temp2, DateTime.Today) < 0)
        {
            resetTime();
        }
    }

    private void resetTime()
    {
        _currentLives = (_maxLives > _currentLives) ? _maxLives : _currentLives;
        PlayerPrefs.SetInt("Lives", _currentLives);

        DateTime temp = DateTime.Today;
        string time = temp.Day + "/" + temp.Month + "/" + temp.Year;
        PlayerPrefs.SetString("Time", time);
    }

    public int getCurrentLives()
    {
        return _currentLives;
    }

    public void decreaseCurrentLives()
    {
        _currentLives -= 1;
        if (_currentLives <= 0)
            _currentLives = 0;
        PlayerPrefs.SetInt("Lives", _currentLives);
    }

    public void increaseCurrentLives()
    {
        _currentLives += 1;
        PlayerPrefs.SetInt("Lives", _currentLives);
    }

    public bool isPlayable()
    {
        if (_currentLives <= 0)
            return false;
        return true;
    }

}
