using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private int currentSelectedCase = 0;

    
    // Start is called before the first frame update
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
            Debug.Log(currentSelectedCase);
        }   
    }

    public int currentCase()
    {
        return this.currentSelectedCase;
    }

    public void nextCase(GameObject index)
    {
        currentSelectedCase = Int32.Parse(index.name);
        SceneManager.LoadScene(1);
    }

}
