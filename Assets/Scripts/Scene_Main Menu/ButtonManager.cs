using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
/*
 * this class is used to manage all the button in the main menu
*/

public class ButtonManager : MonoBehaviour
{
    private GameObject _levelSelectionPanel; //instance of level selection panel
    private GameObject _backGround; //instance of background (the blur when open other panels)
    private GameObject _backButton; //instance of back button
    private PlayerProperties _playerProperties; //instance of player properties


    //Find all the game object needed.
    private void Awake()
    {

        _playerProperties = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>();
        _levelSelectionPanel = GameObject.FindGameObjectWithTag("Level Selection Panel");
        _backGround = _levelSelectionPanel.transform.GetChild(0).gameObject;
        _backButton = _levelSelectionPanel.transform.GetChild(1).gameObject;            
    }



    private void Start()
    {
        int i = 0;

        //turn off all level selection panel
        while (i < _levelSelectionPanel.transform.childCount)
        {
            _levelSelectionPanel.transform.GetChild(i).gameObject.SetActive(false);
            i++;
        }

        //this will show the level selection panel when use that button on ingame scene
        if (_playerProperties.getIsBackToLevelSelection())
        {
            GameObject.FindGameObjectWithTag("Case Selection Panel").transform.GetChild(_playerProperties.getCurrentCase() - 1).GetComponent<CaseSelectionButton>().onCaseSelectionClick();
            _playerProperties.setBackToLevelSelection(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }   
    }


    //call when use back from level selection
    public void onBackFromLevelSelectionClick()
    {
        _backButton.GetComponent<TweenAlpha>().PlayReverse();
        _backGround.GetComponent<TweenAlpha>().PlayReverse();
        _levelSelectionPanel.transform.GetChild(_playerProperties.getCurrentCase() + 1).GetComponent<TweenAlpha>().PlayReverse();
    }


}
