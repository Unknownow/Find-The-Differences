using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPButtons : MonoBehaviour
{
    [SerializeField]
    private int _goldAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void watchAds()
    {
        Debug.Log("Watching ads...");
    }

    public void onBuyGoldButtonClick(int amount = -1)
    {
        if (amount == -1)
            amount = _goldAmount;
        Debug.Log("Buy " + amount + " golds");
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + amount);
    }
}
