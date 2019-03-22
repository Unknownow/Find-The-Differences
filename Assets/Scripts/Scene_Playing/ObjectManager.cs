using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {
    [SerializeField]
    private int _maxNumObjects = 5;
    [SerializeField]
    private int _secondsDecreaseWhenChooseWrong = 20;
    private int _chosenObject = 0;
    private UILabel _objectCount;
    private GameObject _hintObject;
    private bool _levelCompleted = false;
    [SerializeField]
    private ObjectProperties[] _object;
	// Use this for initialization
	void Start () {
        _chosenObject = 0;
        _objectCount = GameObject.FindGameObjectWithTag("Object Count").GetComponent<UILabel>();
        _objectCount.text = "Found(0/" + _maxNumObjects.ToString() + ")";
        _object = GameObject.FindObjectsOfType<ObjectProperties>();
        _hintObject = GameObject.FindGameObjectWithTag("Hint");
        _hintObject.SetActive(false);
        _levelCompleted = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (_chosenObject >= _maxNumObjects && !_levelCompleted)
        {
            gameObject.GetComponent<NextLevelPanel>().openNextLevelPanel();
            gameObject.GetComponent<TimeManager>().stopTime(true);
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
        foreach (ObjectProperties i in _object)
        {
            if (!i.isFound())
            {
                Debug.Log(i.transform.position);
                _hintObject.transform.position = i.transform.position;
                _hintObject.SetActive(true);
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

}
