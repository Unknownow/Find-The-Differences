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
    private PlayerProperties _playerProperties; //instance of player properties
    private GameObject _caseSelectionPanel;
    private UICenterOnChild _centerOnChild;


    //Find all the game object needed.
    private void Awake()
    {

        _playerProperties = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>();
        _levelSelectionPanel = GameObject.FindGameObjectWithTag("Level Selection Panel");
        _caseSelectionPanel = GameObject.FindGameObjectWithTag("Case Selection Panel");
        _centerOnChild = _caseSelectionPanel.GetComponent<UICenterOnChild>();
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
            _playerProperties.setIsBackToLevelSelection(false);
            return;
        }
  
        if (_playerProperties.getIsFinishCase())
        {
            _centerOnChild.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _caseSelectionPanel.GetComponent<UICenterOnChild>().CenterOn(_caseSelectionPanel.transform.GetChild(4));
        }
        if (_playerProperties.getIsFinishCase())
        {
            onFinishCase();
        }
    }


    //call when use back from level selection
    public void onBackFromLevelSelectionClick()
    {
        _levelSelectionPanel.transform.GetChild(_playerProperties.getCurrentCase() + 1).GetComponent<TweenAlpha>().PlayReverse();
        _levelSelectionPanel.GetComponent<TweenAlpha>().PlayReverse();
    }

    public void onFinishCase()
    {
        //Debug.Log("Case: " + _playerProperties.getCurrentCase());
        _centerOnChild.CenterOn(_caseSelectionPanel.transform.GetChild(_playerProperties.getCurrentCase()));
        if (_centerOnChild.onCenter == null)
        {
            _playerProperties.setIsFinishCase(false);
            _centerOnChild.enabled = false;
        }
    }


}
