using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class ButtonManager : MonoBehaviour
{
    private GameObject _levelSelectionPanel;
    private GameObject _backGround;
    private GameObject _backButton;
    private PlayerProperties _playerProperties;
    // Start is called before the first frame update
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
        while (i < _levelSelectionPanel.transform.childCount)
        {
            _levelSelectionPanel.transform.GetChild(i).gameObject.SetActive(false);
            i++;
        }
        if (_playerProperties.getIsBackToLevelSelection())
        {
            GameObject.FindGameObjectWithTag("Case Selection Panel").transform.GetChild(_playerProperties.getCurrentCase() - 1).GetComponent<CaseSelection>().onCaseSelectionClick();
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


    public void onBackFromLevelSelectionClick()
    {
        _backButton.GetComponent<TweenAlpha>().PlayReverse();
        _backGround.GetComponent<TweenAlpha>().PlayReverse();
        _levelSelectionPanel.transform.GetChild(_playerProperties.getCurrentCase() + 1).GetComponent<TweenAlpha>().PlayReverse();
    }


}
