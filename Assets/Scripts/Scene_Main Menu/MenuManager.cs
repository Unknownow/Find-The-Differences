using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private int _currentCase;
    private GameObject _levelSelectionPanel;
    private GameObject _backGround;
    private GameObject _backButton;

    // Start is called before the first frame update
    private void Awake()
    {
        
        if (PlayerPrefs.GetInt("Case") == 0 && PlayerPrefs.GetInt("Level") == 0)
        {
            PlayerPrefs.SetInt("Case", 1);
            PlayerPrefs.SetInt("Level", 1);
        }
        Debug.Log("Case == " + PlayerPrefs.GetInt("Case") + "\nLevel == " + PlayerPrefs.GetInt("Level"));

        //PlayerPrefs.SetInt("Case", 1);
        //PlayerPrefs.SetInt("Level", 1);
        _levelSelectionPanel = GameObject.FindGameObjectWithTag("Level Selection Panel");
        _backGround = _levelSelectionPanel.transform.GetChild(0).gameObject;
        _backButton = _levelSelectionPanel.transform.GetChild(1).gameObject;
        int i = 0;
        while (i < _levelSelectionPanel.transform.childCount)
        {
            _levelSelectionPanel.transform.GetChild(i).gameObject.SetActive(false);
            i++;
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

    public void setCurrentCase(int caseIndex)
    {
        _currentCase = caseIndex;
    }

    public void onBackFromLevelSelectionClick()
    {
        _backButton.GetComponent<TweenAlpha>().PlayReverse();
        _backGround.GetComponent<TweenAlpha>().PlayReverse();
        _levelSelectionPanel.transform.GetChild(_currentCase + 1).GetComponent<TweenAlpha>().PlayReverse();
    }
}
