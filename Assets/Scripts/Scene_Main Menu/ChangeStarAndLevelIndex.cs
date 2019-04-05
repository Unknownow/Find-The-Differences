using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeStarAndLevelIndex : MonoBehaviour
{

    [SerializeField]
    private int _numberOfStars = 0;

    private LevelSelectionButton levelSelectionButton;
    private GameObject middleStar;
    private GameObject leftStar;
    private GameObject rightStar;
    // Start is called before the first frame update
    private void Start()
    {
        levelSelectionButton = gameObject.GetComponent<LevelSelectionButton>();
        transform.GetChild(0).GetComponent<UILabel>().text = levelSelectionButton.getIndex().ToString("00");
        if (!levelSelectionButton.getIsOpen())
        {
            transform.GetChild(0).GetComponent<UILabel>().enabled = false;
        }
        if (Camera.main.pixelWidth >= 720)
            transform.GetChild(0).GetComponent<UILabel>().fontSize = 92;
        else
            transform.GetChild(0).GetComponent<UILabel>().fontSize = 50;
        middleStar = transform.GetChild(1).GetChild(1).gameObject;
        leftStar = transform.GetChild(1).GetChild(0).gameObject;
        rightStar = transform.GetChild(1).GetChild(2).gameObject;
        changeStar();
    }

    private void Update()
    {
        if (levelSelectionButton.getIsOpen() && !transform.GetChild(0).GetComponent<UILabel>().enabled)
        {
            transform.GetChild(0).GetComponent<UILabel>().enabled = true;
        }
        changeStar();
    }

    private void changeStar()
    {
        _numberOfStars = levelSelectionButton.getStarsOfThisLevel();
        //Debug.Log("Case: " + levelSelectionButton._caseIndex + " Level: " + levelSelectionButton.getIndex() + "\nStar: " + _numberOfStars);
        if (_numberOfStars == 3)
        {
            middleStar.SetActive(true);
            leftStar.SetActive(true);
            rightStar.SetActive(true);
        }
        else if (_numberOfStars == 2)
        {
            middleStar.SetActive(true);
            leftStar.SetActive(true);
            rightStar.SetActive(false);
        }
        else if (_numberOfStars == 1)
        {
            middleStar.SetActive(true);
            leftStar.SetActive(false);
            rightStar.SetActive(false);
        }
        else if (_numberOfStars == 0)
        {
            middleStar.SetActive(false);
            leftStar.SetActive(false);
            rightStar.SetActive(false);
        }
    }
}
