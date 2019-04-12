using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    private int _maxNumObjects = 5;
    private int _secondsDecreaseWhenChooseWrong = 20;
    private int _bonusGoldForThisLevel = 1;
    private int _chosenObject = 0;
    private int _hintsSpend = 0;
    private int _goldsNeededToBuyHint = 1;
    private bool _levelCompleted = false;
    public UILabel _objectCount;
    public GameObject _hintObject;
    public GameObject _blurBackground;
    public ObjectButton[] _object;
    public LevelProperties _thisLevelProp;
    public StarsCount _starsCount;
    public LivesChange _livesSprite;

    [SerializeField]
    private Sprite _pauseBackground;
    [SerializeField]
    private Sprite _nextLevelBackground;
    [SerializeField]
    private Sprite _timeoutBackground;

    private LivesAndDailyManager _livesManager;

    // Use this for initialization
    void Start () {
        
        _objectCount = GameObject.FindGameObjectWithTag("Object Count").GetComponent<UILabel>();
        _blurBackground = GameObject.FindGameObjectWithTag("Blur Background");
        _object = FindObjectsOfType<ObjectButton>();
        _hintObject = GameObject.FindGameObjectWithTag("Hint");
        _starsCount = gameObject.GetComponent<StarsCount>();
        _livesSprite = GameObject.FindGameObjectWithTag("Shop Panel").transform.GetChild(4).GetComponent<LivesChange>();
        _livesManager = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<LivesAndDailyManager>();

        _thisLevelProp = gameObject.GetComponent<LevelProperties>();
        _maxNumObjects = _thisLevelProp.getMaxNumOfObjects();
        _secondsDecreaseWhenChooseWrong = _thisLevelProp.getSecondsDecreaseWhenChooseWrong();
        _bonusGoldForThisLevel = _thisLevelProp.getBonusGoldForThisLevel();
        _goldsNeededToBuyHint = _thisLevelProp.getGoldsNeededToBuyHint();

        _blurBackground.SetActive(false);
        _objectCount.text = "Found(0/" + _maxNumObjects.ToString() + ")";
        _chosenObject = 0;
        _hintObject.SetActive(false);
        _levelCompleted = false;
        _hintsSpend = 0;
        _livesManager.onCheckingTime();
    }
	
	// Update is called once per frame
	void Update () {
        if (_chosenObject >= _maxNumObjects && !_levelCompleted)
        {
            gameObject.GetComponent<TimeManager>().stopTime(true);
            GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>().setLevelStars(_thisLevelProp.getCase(), _thisLevelProp.getLevel(), _starsCount.getStars());
            gameObject.GetComponent<NextLevelPanel>().openNextLevelPanel();
            _livesSprite.hideHeartSprite(false);
            //Debug.Log("Spent time: " + gameObject.GetComponent<TimeManager>().getSpentTime());
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
        _starsCount.wrongClick();
        gameObject.GetComponent<TimeManager>().decreaseRemainingTimeBySecond(_secondsDecreaseWhenChooseWrong);
    }

    public void onHintClick()
    {
        if (_hintObject.activeSelf)
            return;
        if (PlayerPrefs.GetInt("Gold") < _goldsNeededToBuyHint)
        {
            _thisLevelProp.watchAds();
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + _goldsNeededToBuyHint);
        }   
        if (PlayerPrefs.GetInt("Gold") < _goldsNeededToBuyHint)
            return;
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - _goldsNeededToBuyHint);
        foreach (ObjectButton i in _object)
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


    public void blurBackground(int index)
    {
        _blurBackground.SetActive(true);
        Transform upperPanel = _blurBackground.transform.GetChild(0);
        Transform backGround = _blurBackground.transform.GetChild(1);
        if (index == 0)
        {
            backGround.GetComponent<UI2DSprite>().sprite2D = _pauseBackground;
            upperPanel.GetComponent<UISprite>().spriteName = "Sprite_Upper Panel";
        }
        else if (index == 1)
        {
            backGround.GetComponent<UI2DSprite>().sprite2D = _nextLevelBackground;
            upperPanel.GetComponent<UISprite>().spriteName = "Sprite_Upper Panel";
        }
        else if (index == 2)
        {
            backGround.GetComponent<UI2DSprite>().sprite2D = _timeoutBackground;
            upperPanel.GetComponent<UISprite>().spriteName = "Sprite_Gray Upper Panel";
        }
        backGround.GetComponent<TweenAlpha>().PlayForward();
        upperPanel.GetComponent<UISprite>().alpha = 1;
    }

    public void unblurBackground()
    {
        _blurBackground.SetActive(true);
        Transform upperPanel = _blurBackground.transform.GetChild(0);
        Transform backGround = _blurBackground.transform.GetChild(1);
        backGround.GetComponent<TweenAlpha>().PlayReverse();
        upperPanel.GetComponent<TweenAlpha>().PlayForward();
    }


    public int getSpentHints()
    {
        return _hintsSpend;
    }
    
    public int getBonusGoldForThisLevel()
    {
        return _bonusGoldForThisLevel;
    }

}
