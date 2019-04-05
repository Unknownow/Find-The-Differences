using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This class is used to manage the shop panel
*/
public class ShopManager : MonoBehaviour
{
    private GameObject _shopPanel;  //Instance of shop panel
    private GameObject _goldNumber; //Instance of gold number on the top
    private GameObject _gameManager;    //Instance of game manager
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

    //call this when want to open shop
    public void onShopClick()
    {
        _shopPanel.SetActive(true);
        if(_gameManager != null)
        {
            _gameManager.GetComponent<TimeManager>().stopTime(true);
        }
    }

    //call this to turn off shop panel
    public void onBackClick()
    {
        if (_gameManager != null)
        {
            _gameManager.GetComponent<TimeManager>().stopTime(false);
        }

    }

}
