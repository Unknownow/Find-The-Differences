using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSelectionButton : MonoBehaviour
{
       
    [SerializeField]
    private int _caseIndex; //index of this case
    [SerializeField]
    private int _amountOfGoldsToUnlock = 10; //amount of golds needed to early unlock

    private GameObject _backGround; //blurry background
    private GameObject _levelPanel; //panel show all the button to choose level
    private GameObject _backButton; //instance of back button on the case selection panel
    private GameObject _levelSelectionPanel;  //instance of level selection panel
    private GameObject _upperPanel;
    [SerializeField]
    private bool _isOpened = false; //use this to confirm this level is whether opened or closed
    private int _starsThisCase;

    private Transform _starsCount;
    

    private PlayerProperties _playerProperties;


    // find all the gameobject needed
    void Awake()
    {
        _levelSelectionPanel = GameObject.FindGameObjectWithTag("Level Selection Panel");
        _backGround = _levelSelectionPanel.transform.GetChild(0).gameObject;
        _levelPanel = _levelSelectionPanel.transform.GetChild(_caseIndex + 1).gameObject;
        _backButton = _levelSelectionPanel.transform.GetChild(1).gameObject;
        _upperPanel = _levelSelectionPanel.transform.GetChild(_levelSelectionPanel.transform.childCount - 1).gameObject;
        _starsCount = transform.GetChild(1).GetChild(1);
        _playerProperties = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>();
        _starsThisCase = _playerProperties.getStarsThisCase(_caseIndex);
        _isOpened = false;
    }


    private void Start()
    {
        //change color of the button if this case is not opened
        if (!_playerProperties.checkOpenCase(_caseIndex))
        {
            gameObject.GetComponent<UI2DSprite>().color = Color.gray;
            gameObject.GetComponent<UIButton>().enabled = false;
            _isOpened = false;
        }
        else if (!_isOpened && _playerProperties.checkOpenCase(_caseIndex))
        {
            gameObject.GetComponent<UI2DSprite>().color = Color.white;
            gameObject.GetComponent<UIButton>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(false);
            _isOpened = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!_isOpened)
            _starsCount.GetComponent<UILabel>().text = _playerProperties.getStarsSum() + "/" + _starsThisCase;
        else
            transform.GetChild(1).gameObject.SetActive(false);
    }

    //call when want to open level selection 
    public void onCaseSelectionClick()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player Properties");
        GameObject shop = GameObject.FindGameObjectWithTag("Shop Panel");
        if (!_playerProperties.checkOpenCase(_caseIndex))
            return;
        if (!temp.GetComponent<LivesAndDailyManager>().isPlayable())
        {
            shop.transform.GetChild(4).GetComponent<LivesChange>().onOpenAddLifeAdsClick();
            return;
        }
        _backGround.SetActive(true);
        _levelPanel.SetActive(true);
        _backButton.SetActive(true);
        _upperPanel.SetActive(true);
        _levelPanel.GetComponent<TweenAlpha>().PlayForward();
        _levelSelectionPanel.GetComponent<TweenAlpha>().PlayForward();
        _playerProperties.setCurrentCase(_caseIndex);
    }


    public bool getIsOpened()
    {
        return _isOpened;
    }

    public int getAmountOfGoldsToUnlock()
    {
        return _amountOfGoldsToUnlock;
    }

    //call when want to open this case
    public void openThisCase()
    {
        _playerProperties.setCaseOpen(_caseIndex);
        gameObject.GetComponent<TweenColor>().PlayForward();
        gameObject.GetComponent<UIButton>().defaultColor = Color.white;
        gameObject.GetComponent<UIButton>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
        _isOpened = true; 
    }
    public void changeColorToWhite()
    {
        //Debug.Log("COLOR CHANGED!");
        gameObject.GetComponent<UI2DSprite>().color = Color.white;
    }
}
