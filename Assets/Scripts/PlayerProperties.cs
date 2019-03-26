using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    [SerializeField]
    private int[] _maxLevelsForEachCase;
    [SerializeField]
    private int[] _openedLevelList;
    [SerializeField]
    private int _numberOfCases = 10;
    [SerializeField]
    private int _currentCase = 0;

    private bool _isBackToLevelSelection = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetString("Opened Levels"));
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        _openedLevelList = new int[_numberOfCases];
        if (PlayerPrefs.GetInt("First Time") == 0)
        {
            Debug.Log("First time play");
            _openedLevelList[0] = 1;
            firstTimeSetup();
            PlayerPrefs.SetInt("First Time", 1);
        }
        else
        {
            Debug.Log("Player Setup");
            playerPropertiesSetup();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Delete all player's preferences");
            PlayerPrefs.DeleteAll();
        }
            
    }

    private void firstTimeSetup()
    {
        string temp = "";
        for(int i = 0; i < _openedLevelList.Length; i++)
        {
            temp += (i + 1).ToString() + "-" + _openedLevelList[i].ToString();
            if (i < _openedLevelList.Length - 1)
                temp += "|";
        }
        PlayerPrefs.SetString("Opened Levels", temp);
    }

    private void playerPropertiesSetup()
    {
        string temp = PlayerPrefs.GetString("Opened Levels");
        string[] listOfOpenedLevels = temp.Split('|');
        foreach(string i in listOfOpenedLevels)
        {
            string[] value = i.Split('-');
            _openedLevelList[int.Parse(value[0]) - 1] = int.Parse(value[1]);
        }
    }

    private void playerPropertiesSave()
    {
        string temp = "";
        for(int i = 0; i < _openedLevelList.Length; i++)
        {
            temp += (i + 1).ToString() + "-" + _openedLevelList[i];
            if (i < _openedLevelList.Length - 1)
                temp += "|";
        }
        PlayerPrefs.SetString("Opened Levels", temp);
    }

    public void setCurrentCase(int caseIndex)
    {
        _currentCase = caseIndex;
    }

    public int getCurrentCase()
    {
        return _currentCase;
    }

    public int findSceneToLoadInMenu(int currentCase, int currentLevel, bool isNextCase)
    {
        int nextSceneIndex = 0;
        for(int i = 0; i < currentCase - 1; i++)
        {
            nextSceneIndex += _maxLevelsForEachCase[i];
        }
        nextSceneIndex += currentLevel;
        if (isNextCase)
            nextSceneIndex += 1;
        return nextSceneIndex;
    }

    public int findNextSceneToLoadInGameplay(int currentCase, int currentLevel)
    {
        int nextSceneIndex = 0;
        if(currentLevel >= _maxLevelsForEachCase[currentCase - 1])
        {
            for (int i = 0; i < currentCase; i++)
                nextSceneIndex += _maxLevelsForEachCase[i];
            nextSceneIndex += 1;
            _openedLevelList[currentCase] += 1;
        }
        else
        {
            for (int i = 0; i < currentCase - 1; i++)
            {
                nextSceneIndex += _maxLevelsForEachCase[i];
            }
            nextSceneIndex += currentLevel + 1;
            _openedLevelList[currentCase - 1] += 1;
        }
        playerPropertiesSave();
        return nextSceneIndex;
    }

    public bool checkIfThisLevelIsOpened(int currentCase, int currentLevel)
    {
        if(_openedLevelList[currentCase - 1] != 0)
        {
            if (currentLevel <= _openedLevelList[currentCase - 1])
                return true;
        }
        return false;
    }

    public void setBackToLevelSelection(bool value)
    {
        _isBackToLevelSelection = value;
    }

    public bool getIsBackToLevelSelection()
    {
        return _isBackToLevelSelection;
    }

    public bool checkIfThisCaseOpen(int caseIndex)
    {
        if (_openedLevelList[caseIndex - 1] != 0)
            return true;
        return false;
    }
}
