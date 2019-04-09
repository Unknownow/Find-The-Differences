using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.Detectors;
using System;

public class PlayerLivesManager : MonoBehaviour
{
    [SerializeField]
    private int _maxLives = 5;
    private int _currentLives;
    private bool _isTimeCheating = false;
    private TimeCheatingDetector timeDetector;

    private int _month;
    private int _day;
    private int _year;

    // Start is called before the first frame update
    void Start()
    {
        timeDetector = gameObject.GetComponent<TimeCheatingDetector>();
        Debug.Log(timeDetector.ForceCheck());
        Debug.Log(DateTime.Today);
        if (_isTimeCheating)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void firstTimeSetup()
    {
        _day = DateTime.Today.Day;
        _month = DateTime.Today.Month;
        _year = DateTime.Today.Year;
        string temp = _day + "/" + _month + "/" + _year;
        PlayerPrefs.SetString("Time", temp);
    }

    public void saveLives()
    {
        PlayerPrefs.SetInt("Lives", _currentLives);
    }

    public void getLives()
    {
        _currentLives = PlayerPrefs.GetInt("Lives");
    }

    public bool isPlayable()
    {
        if (PlayerPrefs.GetInt("Lives") <= 0)
            return false;
        return true;
    }

    public void onTimeCheating()
    {
        _isTimeCheating = true;
    }

    private bool checkResetLives()
    {

    }
}
