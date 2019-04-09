﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfTimePanel : MonoBehaviour {

    private GameObject _outOfTimePanel;

    // Use this for initialization
    void Start()
    {
        _outOfTimePanel = GameObject.FindGameObjectWithTag("Out Of Time Panel");
        _outOfTimePanel.SetActive(false);
    }


    public void onBackToMainMenuClick()
    {
        Debug.Log("Main Menu");
        //change to menu scene below
        SceneManager.LoadScene(0);
    }

    public void onRetryClick()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void openOutOfTimePanel()
    {
        _outOfTimePanel.SetActive(true);
        gameObject.GetComponent<ObjectManager>().blurBackground(2);
    }

    public void onLevelSelectionClick()
    {
        Debug.Log("Level Selection");
        //change to level selection scene below
        GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().setIsBackToLevelSelection(true);
        SceneManager.LoadScene(0);
    }

    public void onGetHeartClick()
    {
        Debug.Log("Game Manager/OutOfTimePanel");
        gameObject.GetComponent<LevelProperties>().watchAds();
    }

}