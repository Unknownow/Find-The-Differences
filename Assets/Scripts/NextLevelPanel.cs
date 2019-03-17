using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPanel : MonoBehaviour {

    private GameObject nextLevelPanel;

	// Use this for initialization
	void Start () {
        nextLevelPanel = GameObject.FindGameObjectWithTag("Next Level Panel");
        nextLevelPanel.SetActive(false);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void levelSelectionButton()
    {
        Debug.Log("Level Selection");
        //change to level selection scene below
    }

    public void openNextLevelPanel()
    {
        nextLevelPanel.SetActive(true);
    }
}
