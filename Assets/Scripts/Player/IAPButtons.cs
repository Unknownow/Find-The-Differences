using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPButtons : MonoBehaviour
{
    [SerializeField]
    private int _goldAmount; // amount of golds gained when using this button
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //call this on buy button
    public void onBuyGoldButtonClick(int amount = 0)
    {
        if (amount == 0)
            amount = _goldAmount;
        Debug.Log("Buy " + amount + " golds");
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + amount);
    }

    //call this on watching ads
    public void watchAds(int amount = 0)
    {
        Debug.Log("watch ads!");
        if (amount == 0)
            amount = _goldAmount;
        Debug.Log("Buy " + amount + " golds");
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + amount);
    }

}
