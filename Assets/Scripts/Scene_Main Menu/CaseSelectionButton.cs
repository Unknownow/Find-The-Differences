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
    private bool _isOpened = false; //use this to confirm this level is whether opened or closed

    private PlayerProperties _playerProperties;


    // find all the gameobject needed
    void Awake()
    {
        _levelSelectionPanel = GameObject.FindGameObjectWithTag("Level Selection Panel");
        _backGround = _levelSelectionPanel.transform.GetChild(0).gameObject;
        _levelPanel = _levelSelectionPanel.transform.GetChild(_caseIndex + 1).gameObject;
        _backButton = _levelSelectionPanel.transform.GetChild(1).gameObject;
        _isOpened = false;
    }


    private void Start()
    {
        _playerProperties = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>();

        //change color of the button if this case is not opened
        if (!GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().checkIfThisCaseOpen(_caseIndex))
        {
            gameObject.GetComponent<UI2DSprite>().color = Color.gray;
            gameObject.GetComponent<UIButton>().enabled = false;
            _isOpened = false;
        }
        else if (!_isOpened && _playerProperties.checkIfThisCaseOpen(_caseIndex))
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
        
    }

    //call when want to open level selection 
    public void onCaseSelectionClick()
    {
        if (!GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().checkIfThisCaseOpen(_caseIndex))
            return;

        _backGround.SetActive(true);
        _levelPanel.SetActive(true);
        _backButton.SetActive(true);
        _backGround.GetComponent<TweenAlpha>().PlayForward();
        _levelPanel.GetComponent<TweenAlpha>().PlayForward();
        _backButton.GetComponent<TweenAlpha>().PlayForward();

        GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().setCurrentCase(_caseIndex);
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
        _playerProperties.setThisCaseOpen(_caseIndex);
        gameObject.GetComponent<TweenColor>().PlayForward();
        gameObject.GetComponent<UIButton>().enabled = true;
        transform.GetChild(0).gameObject.SetActive(false);
        _isOpened = true;
    }
}
