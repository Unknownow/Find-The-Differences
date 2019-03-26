using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {
    private int _maxNumObjects = 5;
    private int _secondsDecreaseWhenChooseWrong = 20;
    private int _bonusGoldForThisLevel = 1;
    private int _chosenObject = 0;
    private int _hintsSpend = 0;
    private int _goldsNeededToBuyHint = 1;
    private bool _levelCompleted = false;
    private UILabel _objectCount;
    private GameObject _hintObject;
    private GameObject _blurBackground;
    private ObjectProperties[] _object;
    private LevelProperties thisLevelProp;

    // Use this for initialization
    void Start () {
        
        _objectCount = GameObject.FindGameObjectWithTag("Object Count").GetComponent<UILabel>();
        _blurBackground = GameObject.FindGameObjectWithTag("Blur Background");
        _object = FindObjectsOfType<ObjectProperties>();
        _hintObject = GameObject.FindGameObjectWithTag("Hint");

        thisLevelProp = gameObject.GetComponent<LevelProperties>();
        _maxNumObjects = thisLevelProp.getMaxNumOfObjects();
        _secondsDecreaseWhenChooseWrong = thisLevelProp.getSecondsDecreaseWhenChooseWrong();
        _bonusGoldForThisLevel = thisLevelProp.getBonusGoldForThisLevel();
        _goldsNeededToBuyHint = thisLevelProp.getGoldsNeededToBuyHint();

        _blurBackground.SetActive(false);
        _objectCount.text = "Found(0/" + _maxNumObjects.ToString() + ")";
        _chosenObject = 0;
        _hintObject.SetActive(false);
        _levelCompleted = false;
        _hintsSpend = 0;


    }
	
	// Update is called once per frame
	void Update () {
        if (_chosenObject >= _maxNumObjects && !_levelCompleted)
        {
            gameObject.GetComponent<NextLevelPanel>().openNextLevelPanel();
            gameObject.GetComponent<TimeManager>().stopTime(true);
            Debug.Log("Spent time: " + gameObject.GetComponent<TimeManager>().getSpentTime());
            _levelCompleted = true;
        }
    }

    // called when the right object is selected
    public void onSelectRightObjectClick()
    {
        Debug.Log("choose right!");
        _chosenObject += 1;
        if (_chosenObject > _maxNumObjects)
            return;
        _objectCount.text = "Found(" + _chosenObject.ToString() + "/" + _maxNumObjects.ToString() + ")"; 
    }

    // called when player choose wrong object
    public void onSelectWrongObjectClick()
    {
        Debug.Log("choose wrong!");
        gameObject.GetComponent<TimeManager>().decreaseRemainingTimeBySecond(_secondsDecreaseWhenChooseWrong);
    }

    public void onHintClick()
    {
        if (_hintObject.activeSelf)
            return;
        if (PlayerPrefs.GetInt("Gold") < _goldsNeededToBuyHint)
            thisLevelProp.watchAds(_goldsNeededToBuyHint);
        if (PlayerPrefs.GetInt("Gold") < _goldsNeededToBuyHint)
            return;
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - _goldsNeededToBuyHint);
        foreach (ObjectProperties i in _object)
        {
            if (!i.isFound())
            {
                Debug.Log(i.transform.position);
                _hintObject.transform.position = i.transform.position;
                _hintObject.SetActive(true);
                _hintsSpend += 1;
                StartCoroutine(hintDisable());
                return;
            }
        }
    }

    private IEnumerator hintDisable()
    {
        yield return new WaitForSeconds(5);
        _hintObject.SetActive(false);
    }


    public void blurBackground()
    {
        _blurBackground.SetActive(true);
        _blurBackground.GetComponent<TweenAlpha>().PlayForward();
    }

    public void unblurBackground()
    {
        _blurBackground.SetActive(true);
        _blurBackground.GetComponent<TweenAlpha>().PlayReverse();
    }

    public int getSpentHints()
    {
        return _hintsSpend;
    }
    
    public int getBonusGoldForThisLevel()
    {
        return _bonusGoldForThisLevel;
    }


    public void watchAds()
    {
        Debug.Log("Watching Ads - ObjectManager.watchAds()");
    }
}
