using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPanel : MonoBehaviour {

    private GameObject _nextLevelPanel;
    private Transform _endGameText;
    private int _nextScene = 0;

	// Use this for initialization
	void Start () {
        _nextLevelPanel = GameObject.FindGameObjectWithTag("Next Level Panel");
        _endGameText = _nextLevelPanel.transform.GetChild(_nextLevelPanel.transform.childCount - 1);
        _nextLevelPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void onBackToMainMenuClick()
    {
        Debug.Log("Main Menu");
        //change to menu scene below
        SceneManager.LoadScene(0);
    }

    public void onNextLevelClick()
    {
        Debug.Log("Next Level");
        
        SceneManager.LoadScene(_nextScene);
    }

    public void onLevelSelectionClick()
    {
        Debug.Log("Level Selection");
        //change to level selection scene below
        GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().setBackToLevelSelection(true);
        SceneManager.LoadScene(0);
    }

    public void openNextLevelPanel()
    {
        _nextLevelPanel.SetActive(true);
        _endGameText.GetChild(0).GetComponent<UILabel>().text = "Time: " + convertSecondsToMinutes(gameObject.GetComponent<TimeManager>().getSpentTime());
        _endGameText.GetChild(1).GetComponent<UILabel>().text = "Bonus golds: " + gameObject.GetComponent<ObjectManager>().getBonusGoldForThisLevel().ToString();
        _endGameText.GetChild(2).GetComponent<UILabel>().text = "Hints: " + gameObject.GetComponent<ObjectManager>().getSpentHints().ToString();
        gameObject.GetComponent<ObjectManager>().blurBackground();
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + gameObject.GetComponent<ObjectManager>().getBonusGoldForThisLevel());

        _nextLevelPanel.GetComponent<TweenAlpha>().PlayForward();
        _nextLevelPanel.GetComponent<TweenScale>().PlayForward();

        LevelProperties levelDetail = gameObject.GetComponent<LevelProperties>();
        int levelIndex = levelDetail.getLevel();
        int caseIndex = levelDetail.getCase();
        _nextScene = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().findNextSceneToLoadInGameplay(caseIndex, levelIndex);
    }

    public string convertSecondsToMinutes(int seconds)
    {
        float s = seconds % 60;
        float m = 0;
        if (seconds > 59)
        {
            m = Mathf.Floor(seconds / 60) + 1;
            s = 0;
        }
        else
        {
            m = Mathf.Floor(seconds / 60);
        }
        return m.ToString("00") + ":" + s.ToString("00");
    }
}
