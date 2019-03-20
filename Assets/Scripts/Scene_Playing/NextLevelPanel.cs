using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPanel : MonoBehaviour {

    private GameObject _nextLevelPanel;

	// Use this for initialization
	void Start () {
        _nextLevelPanel = GameObject.FindGameObjectWithTag("Next Level Panel");
        _nextLevelPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void backToMainMenuButton()
    {
        Debug.Log("Main Menu");
        //change to menu scene below
    }

    public void nextLevelButton()
    {
        Debug.Log("Next Level");
        LevelProperties levelDetail = gameObject.GetComponent<LevelProperties>();
        int levelIndex = levelDetail.getLevel();
        int caseIndex = levelDetail.getCase();

        if (caseIndex >= PlayerPrefs.GetInt("Case"))
        {
            if(levelIndex >= PlayerPrefs.GetInt("Level"))
            {
                if(levelIndex == 4)
                {
                    PlayerPrefs.SetInt("Level", 1);
                    PlayerPrefs.SetInt("Case", ++caseIndex);
                }
                else
                {
                    PlayerPrefs.SetInt("Level", ++levelIndex );
                }
            }
                
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void levelSelectionButton()
    {
        Debug.Log("Level Selection");
        //change to level selection scene below
    }

    public void openNextLevelPanel()
    {
        _nextLevelPanel.SetActive(true);
    }
}
