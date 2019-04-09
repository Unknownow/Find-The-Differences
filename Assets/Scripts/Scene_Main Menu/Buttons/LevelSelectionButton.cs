﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    private int _caseIndex;
    [SerializeField]
    private int _levelIndex;
    [SerializeField]
    private bool isOpen = false;
    [SerializeField]
    private NGUIAtlas uiAtlas;
    //private MenuManager menuManager;
    [SerializeField]
    private PlayerProperties _playerProperties;
    [SerializeField]
    private bool _isBackButton; 
    // Start is called before the first frame update
    private void Awake()
    {
        _playerProperties = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>();
        if (_isBackButton)
            return;
        if (Camera.main.pixelWidth >= 720)
            gameObject.GetComponent<UISprite>().width = 180;
        else
            gameObject.GetComponent<UISprite>().width = 100;
    }
    void Start()
    {
        if (_isBackButton)
            return;
        isOpen = false;
        selectSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isBackButton)
            return;
        //Debug.Log(_playerProperties.checkOpenLevel(_caseIndex, _levelIndex));
        if (_playerProperties.checkOpenLevel(_caseIndex, _levelIndex))
            selectSprite();
    }

    public void onLevelSelectionClick()
    {

        if (!isOpen)
            return;
        //Debug.Log(_playerProperties.findSceneToLoadInMenu(_caseIndex, _levelIndex, false));
        SceneManager.LoadScene(_playerProperties.findSceneToLoadInMenu(_caseIndex,_levelIndex,false));
    }

    public void onBackFromLevelSelectionClick()
    {
        Transform levelSelectionPanel = transform.parent;
        levelSelectionPanel.GetChild(_playerProperties.getCurrentCase() + 1).GetComponent<TweenAlpha>().PlayReverse();
        levelSelectionPanel.GetComponent<TweenAlpha>().PlayReverse();
    }

    private void selectSprite()
    {
        if(_playerProperties.checkOpenLevel(_caseIndex, _levelIndex))
        {
            isOpen = true;
           
            gameObject.GetComponent<UISprite>().spriteName = "Sprite_Level";
            gameObject.GetComponent<UIButton>().normalSprite = "Sprite_Level";
            return;
        }
        //Debug.Log(_playerProperties.checkOpenLevel(_caseIndex, _levelIndex));
        gameObject.GetComponent<UISprite>().spriteName = "Sprite_Level Closed";
        gameObject.GetComponent<UIButton>().normalSprite = "Sprite_Level Closed";
    }
    
    public int getStarsOfThisLevel()
    {
        return _playerProperties.getLevelStars(_caseIndex, _levelIndex);
    }

    public int getIndex()
    {
        return _levelIndex;
    }

    public bool getIsOpen()
    {
        return isOpen;
    }
}