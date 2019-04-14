using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProperties : MonoBehaviour
{
    [SerializeField]
    private int _case = 1;
    [SerializeField]
    private int _level = 1;

    [SerializeField]
    private int _maxNumOfObjects;

    [SerializeField]
    private int _maxSecondsForThisLevel;
    [SerializeField]
    private int _secondsDecreaseWhenChooseWrong;
    [SerializeField]
    private int _secondsIncreasePerClick;

    [SerializeField]
    private int _goldsNeededToBuyTime;
    [SerializeField]
    private int _goldsNeededToBuyHint;
    [SerializeField]
    private int _bonusGoldEachStar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().setCurrentCase(_case);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCase()
    {
        return _case;
    }

    public int getLevel()
    {
        return _level;
    }

    public int getMaxNumOfObjects()
    {
        return _maxNumOfObjects;
    }

    public int getMaxSecondsForThisLevel()
    {
        return _maxSecondsForThisLevel;
    }

    public int getSecondsDecreaseWhenChooseWrong()
    {
        return _secondsDecreaseWhenChooseWrong;
    }

    public int getSecondsIncreasePerClick()
    {
        return _secondsIncreasePerClick;
    }

    public int getGoldsNeededToBuyTime()
    {
        return _goldsNeededToBuyTime;
    }

    public int getGoldsNeededToBuyHint()
    {
        return _goldsNeededToBuyHint;
    }

    public int getBonusGoldsEachStar()
    {
        return _bonusGoldEachStar;
    }

    public void watchAds()
    {
        Debug.Log("GameManager/LevelProperties\nWatching Ads... ");
        //PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + goldsIncrease);
    }
}
