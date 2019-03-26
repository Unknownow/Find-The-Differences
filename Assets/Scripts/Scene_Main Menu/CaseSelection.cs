using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelSelectionPanel;
    [SerializeField]
    private int _caseIndex;
    [SerializeField]
    private int _amountOfGoldsToUnlock = 10;
    private GameObject _backGround;
    private GameObject _levelPanel;
    private GameObject _backButton;
    private bool _isOpened = false;
    // Start is called before the first frame update
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
        if (!GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().checkIfThisCaseOpen(_caseIndex))
        {
            gameObject.GetComponent<UI2DSprite>().color = Color.gray;
            gameObject.GetComponent<UIButton>().enabled = false;
            _isOpened = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!_isOpened && GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().checkIfThisCaseOpen(_caseIndex))
        {
            gameObject.GetComponent<UI2DSprite>().color = Color.white;
            gameObject.GetComponent<UIButton>().enabled = true;
            _isOpened = true;
        }
    }

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

    public void onEarlyUnlockClick()
    {
        Debug.Log("Early Unlock Click - CaseSelection");
    }
}
