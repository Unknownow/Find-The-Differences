using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSpriteManager : MonoBehaviour
{
    private Transform _goldSprite;
    private Transform _goldNeeded;
    private Transform _numOfHintsLeft;
    private LivesAndDailyManager _livesManager;

    // Start is called before the first frame update
    void Start()
    {
        _livesManager = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<LivesAndDailyManager>();
        _goldSprite = transform.GetChild(0);
        _goldNeeded = transform.GetChild(1);
        _numOfHintsLeft = transform.GetChild(2);
        if(_livesManager.getNumOfHints() > 0)
        {
            _numOfHintsLeft.gameObject.SetActive(true);
            _numOfHintsLeft.GetComponent<UILabel>().text = _livesManager.getNumOfHints().ToString();
            _goldSprite.gameObject.SetActive(false);
            _goldNeeded.gameObject.SetActive(false);
        }
        else
        {
            _numOfHintsLeft.gameObject.SetActive(false);
            _goldSprite.gameObject.SetActive(true);
            _goldNeeded.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _numOfHintsLeft.GetComponent<UILabel>().text = _livesManager.getNumOfHints().ToString();
        if (_livesManager.getNumOfHints() > 0)
        {
            _numOfHintsLeft.gameObject.SetActive(true);
            _numOfHintsLeft.GetComponent<UILabel>().text = _livesManager.getNumOfHints().ToString();
            _goldSprite.gameObject.SetActive(false);
            _goldNeeded.gameObject.SetActive(false);
        }
        else
        {
            _numOfHintsLeft.gameObject.SetActive(false);
            _goldSprite.gameObject.SetActive(true);
            _goldNeeded.gameObject.SetActive(true);
        }
    }
}
