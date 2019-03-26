using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private GameObject _shopPanel;
    private GameObject _goldNumber;
    private GameObject _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this.gameObject);
        _shopPanel = transform.GetChild(3).gameObject;
        _shopPanel.SetActive(false);
        _goldNumber = transform.GetChild(0).gameObject;
        _gameManager = GameObject.FindGameObjectWithTag("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        _goldNumber.GetComponent<UILabel>().text = PlayerPrefs.GetInt("Gold").ToString();
    }

    public void onShopClick()
    {
        _shopPanel.SetActive(true);
        if(_gameManager != null)
        {
            _gameManager.GetComponent<TimeManager>().stopTime(true);
        }
    }

    public void onBackClick()
    {
        if (_gameManager != null)
        {
            _gameManager.GetComponent<TimeManager>().stopTime(false);
        }

    }

}
