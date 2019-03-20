using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour {
    private GameObject _pausePanel;
    private TimeManager _timeManager;

	// Use this for initialization
	void Start () {
        _pausePanel = GameObject.FindGameObjectWithTag("Pause Panel");
        _pausePanel.SetActive(false);
        _timeManager = gameObject.GetComponent<TimeManager>();
	}

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _pausePanel.SetActive(!_pausePanel.activeSelf);
        }
    }

    //pause function. 
    public void pauseButton()
    {
        _pausePanel.SetActive(true);
        _pausePanel.transform.GetChild(1).GetComponent<TweenAlpha>().PlayForward();
        _timeManager.stopTime(true);
    }


    //resume function
    public void resumeButton()
    {
        _timeManager.stopTime(false);
    }
}
