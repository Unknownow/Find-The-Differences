using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
    [SerializeField]
    private GameObject pausePanel;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        pausePanel = GameObject.FindGameObjectWithTag("Pause Panel");
        pausePanel.SetActive(false);
        gameManager = gameObject.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void pause()
    {
        Debug.Log("Pause");
        pausePanel.SetActive(true);
        gameManager.stopTimer(true);
    }

    public void resume()
    {
        Debug.Log("Resume");
    }
}
