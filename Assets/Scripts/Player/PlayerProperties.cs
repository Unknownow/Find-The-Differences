using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProperties : MonoBehaviour
{
    public static PlayerProperties instance;

    [SerializeField]
    private int[] _maxLevelInCase;
    [SerializeField]
    private int[] _starsEachCase;
    [SerializeField]
    private int _numberOfCases = 10;


    [SerializeField]
    private int[][] _starsLevelList;
    [SerializeField]
    private int[] _openedLevelList;
    [SerializeField]
    private int _currentCase = 0;
    [SerializeField]
    private int _starsSum = 0;

    private bool _isBackToLevelSelection = false;
    private bool _isFinishCase = false;
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
        _starsLevelList = new int[_numberOfCases][];
        for (int i = 0; i < _numberOfCases; i++)
        {
            _starsLevelList[i] = new int[_maxLevelInCase[i]];
        }
        if (PlayerPrefs.GetInt("First Time") == 0)
        {
            Debug.Log("PlayerProperties.onFirstTime()");
            _openedLevelList[0] = 1;
            firstTimeSetup();
            PlayerPrefs.SetInt("First Time", 1);
        }
        else
        {
            Debug.Log("PlayerProperties.onSecondTime()");
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
        for (int i = 0; i < _numberOfCases; i++)
        {
            stars += (i + 1).ToString();
            for (int j = 0; j < _starsLevelList[i].Length; j++)
            {
                stars += "-0"; 
            }
            if (i < _openedLevelList.Length - 1)
                stars += "|";
        }
        //Debug.Log("Stars: " + stars);
        PlayerPrefs.SetString("Stars", stars);


        string level = "";
        for (int i = 0; i < _numberOfCases; i++)
        {
            level += (i + 1).ToString() + "-" + _openedLevelList[i].ToString();
            if (i < _openedLevelList.Length - 1)
                level += "|";
        }
         
        PlayerPrefs.SetString("Opened Levels", level);

        for(int i = 0; i < _numberOfCases; i++)
        {
            string s = "";
            for(int j = 0; j < _starsLevelList[i].Length; j++)
            {
                s += _starsLevelList[i][j].ToString() + " ";
            }
            //Debug.Log(s);
        }

        PlayerPrefs.SetInt("Stars Sum", 0);
        _starsSum = 0;
        //gameOpenningSetup(); //testing purpose only
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
                _starsLevelList[int.Parse(value[0]) - 1][count] = int.Parse(value[j]);
            }
        }
        _starsSum = PlayerPrefs.GetInt("Stars Sum");

        for (int i = 0; i < _starsEachCase.Length; i++)
        {
            if (_starsSum >= _starsEachCase[i] && _openedLevelList[i] <= 0)
                _openedLevelList[i] = 1;
        }
        saveGameFile();
        
    }

    private void saveGameFile()
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
            for (int j = 0; j < _starsLevelList[i].Length; j++)
            {
                stars += "-" + _starsLevelList[i][j].ToString();
            }
            if (i < _openedLevelList.Length - 1)
                stars += "|";
        }
        //Debug.Log("Stars: " + stars);
        PlayerPrefs.SetString("Stars", stars);
        int sum = 0;
        foreach (int[] i in _starsLevelList)
            foreach (int j in i)
            {
                sum += j;
            }
        PlayerPrefs.SetInt("Stars Sum", sum);
        //Debug.Log("SUM = "+ sum);
        _starsSum = sum;
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
            nextSceneIndex += _maxLevelInCase[i];
        }
        nextSceneIndex += currentLevel;
        if (isNextCase)
            nextSceneIndex += 1;
        return nextSceneIndex;
    }

    public int findNextSceneToLoadInGameplay(int currentCase, int currentLevel)
    {
        int nextSceneIndex = 0;
        if(currentLevel >= _maxLevelInCase[currentCase - 1])
        {
            //Debug.Log("Num of Stars: " + PlayerPrefs.GetInt("Stars Sum"));
            if (currentCase < _numberOfCases && PlayerPrefs.GetInt("Stars Sum") >= _starsEachCase[currentCase])
                _openedLevelList[currentCase] = 1;
            nextSceneIndex = -1;
            _isFinishCase = true;
        }
        else
        {
            for (int i = 0; i < currentCase - 1; i++)
            {
                nextSceneIndex += _maxLevelInCase[i];
            }
            nextSceneIndex += currentLevel + 1;
            if(_openedLevelList[currentCase - 1] <= currentLevel)
                _openedLevelList[currentCase - 1] += 1;
            //Debug.Log("Current case: " + currentCase);
        }
        saveGameFile();
        return nextSceneIndex;
    }

    public bool checkOpenLevel(int currentCase, int currentLevel)
    {
        if(_openedLevelList[currentCase - 1] != 0)
        {
            if (currentLevel <= _openedLevelList[currentCase - 1])
                return true;
        }
        return false;
    }

    public bool checkOpenCase(int caseIndex)
    {
        for (int i = 0; i < _starsEachCase.Length; i++)
        {
            if (_starsSum >= _starsEachCase[i] && _openedLevelList[i] <= 0)
                _openedLevelList[i] = 1;
        }
        saveGameFile();
        if (_openedLevelList[caseIndex - 1] != 0)
            return true;
        return false;
    }

    public void setCaseOpen(int caseIndex)
    {
        _openedLevelList[caseIndex - 1] = 1;
        saveGameFile();
    }

    public void setIsBackToLevelSelection(bool value)
    {
        _isBackToLevelSelection = value;
    }

    public bool getIsBackToLevelSelection()
    {
        return _isBackToLevelSelection;
    }

    public void setIsFinishCase(bool value)
    {
        _isFinishCase = value;
    }

    public bool getIsFinishCase()
    {
        return _isFinishCase;
    }

    public void setLevelStars(int caseIndex, int levelIndex, int numOfStars)
    {
        if(numOfStars > _starsLevelList[caseIndex - 1][levelIndex - 1])
        {
            _starsLevelList[caseIndex - 1][levelIndex - 1] = numOfStars;
        }
        saveGameFile();
    }

    public int getLevelStars(int caseIndex, int levelIndex)
    {
        return _starsLevelList[caseIndex - 1][levelIndex - 1];
    }

    public int getNumberOfCases()
    {
        return _numberOfCases;
    }

    public int getStarsSum()
    {
        return _starsSum;
    }

    public int getStarsThisCase(int caseIndex)
    {
        return _starsEachCase[caseIndex - 1];
    }

    public bool canCenterOnChild()
    {
        if (_currentCase < _numberOfCases)
            return true;
        return false;
    }

}
