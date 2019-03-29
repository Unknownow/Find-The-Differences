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

    private int[][] _starsListForEachLevel;
    private bool _isBackToLevelSelection = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetString("Opened Levels"));
        Debug.Log("Press S to delete all player preferences");
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
        _starsListForEachLevel = new int[_maxLevelsForEachCase.Length][];
        for (int i = 0; i < _maxLevelsForEachCase.Length; i++)
        {
            _starsListForEachLevel[i] = new int[_maxLevelsForEachCase[i]];
        }
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
            gameOpenningSetup();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Delete all player's preferences");
            PlayerPrefs.DeleteAll();
            //playerPropertiesSave();
        }
            
    }

    private void firstTimeSetup()
    {
        string stars = "";
        for (int i = 0; i < _openedLevelList.Length; i++)
        {
            stars += (i + 1).ToString();
            for (int j = 0; j < _starsListForEachLevel[i].Length; j++)
            {
                stars += "-0"; 
            }
            if (i < _openedLevelList.Length - 1)
                stars += "|";
        }
        Debug.Log("Stars: " + stars);
        PlayerPrefs.SetString("Stars", stars);


        string level = "";
        for (int i = 0; i < _openedLevelList.Length; i++)
        {
            level += (i + 1).ToString() + "-" + _openedLevelList[i].ToString();
            if (i < _openedLevelList.Length - 1)
                level += "|";
        }
         
        PlayerPrefs.SetString("Opened Levels", level);

        for(int i = 0; i < _starsListForEachLevel.Length; i++)
        {
            string s = "";
            for(int j = 0; j < _starsListForEachLevel[i].Length; j++)
            {
                s += _starsListForEachLevel[i][j].ToString() + " ";
            }
            Debug.Log(s);
        }
    }

    private void gameOpenningSetup()
    {
        string temp = PlayerPrefs.GetString("Opened Levels");
        string[] listOfOpenedLevels = temp.Split('|');
        foreach(string i in listOfOpenedLevels)
        {
            string[] value = i.Split('-');
            _openedLevelList[int.Parse(value[0]) - 1] = int.Parse(value[1]);
        }


        string star = PlayerPrefs.GetString("Stars");
        string[] listOfStars = star.Split('|');
        foreach(string i in listOfStars)
        {
            string[] value = i.Split('-');
            int count = 0;
            for(int j = 1; j < value.Length; j++, count++)
            {
                _starsListForEachLevel[int.Parse(value[0]) - 1][count] = int.Parse(value[j]);
            }
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


        string stars = "";
        for (int i = 0; i < _openedLevelList.Length; i++)
        {
            stars += (i + 1).ToString();
            for (int j = 0; j < _starsListForEachLevel[i].Length; j++)
            {
                stars += "-" + _starsListForEachLevel[i][j].ToString();
            }
            if (i < _openedLevelList.Length - 1)
                stars += "|";
        }
        Debug.Log("Stars: " + stars);
        PlayerPrefs.SetString("Stars", stars);
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
            _openedLevelList[currentCase] = 1;
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

    public void setThisCaseOpen(int caseIndex)
    {
        _openedLevelList[caseIndex - 1] = 1;
        playerPropertiesSave();
    }


    public void setStarsForThisLevel(int caseIndex, int levelIndex, int numOfStars)
    {
        _starsListForEachLevel[caseIndex - 1][levelIndex - 1] = numOfStars;
        playerPropertiesSave();
    }

    public int getStarsOfThisLevel(int caseIndex, int levelIndex)
    {
        return _starsListForEachLevel[caseIndex - 1][levelIndex - 1];
    }
}
