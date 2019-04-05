using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesManager : MonoBehaviour
{
    [SerializeField]
    private int _maxLives = 5;
    private int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveLives()
    {
        PlayerPrefs.SetInt("Lives", currentLives);
    }

    public void getLives()
    {
        currentLives = PlayerPrefs.GetInt("Lives");
    }
}
