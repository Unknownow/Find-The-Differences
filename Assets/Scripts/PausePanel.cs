using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour {
    [SerializeField]
    private GameObject pausePanel;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        pausePanel = GameObject.FindGameObjectWithTag("Pause Panel");
        pausePanel.SetActive(false);
        gameManager = gameObject.GetComponent<GameManager>();
	}

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
        }
    }

    //pause function. 
    public void pauseButton()
    {
        pausePanel.SetActive(true);
        pausePanel.transform.GetChild(1).GetComponent<TweenAlpha>().PlayForward();
        gameManager.stopTime(true);
    }


    //resume function
    public void resumeButton()
    {
        gameManager.stopTime(false);
    }
}
