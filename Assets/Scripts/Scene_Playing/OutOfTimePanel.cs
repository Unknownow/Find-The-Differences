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


    public void backToMainMenuButton()
    {
        Debug.Log("Main Menu");
        //change to menu scene below
    }

    public void retryButton()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void openOutOfTimePanel()
    {
        _outOfTimePanel.SetActive(true);
    }

    public void levelSelectionButton()
    {
        Debug.Log("Level Selection");
        //change to level selection scene below
    }

}