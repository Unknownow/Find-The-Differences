using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarlyCaseUnlockButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPanel;
    private CaseSelectionButton parent;
    private PlayerProperties _playerProperties;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.GetComponentInParent<CaseSelectionButton>();
        _shopPanel = GameObject.FindGameObjectWithTag("Shop Panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onEarlyUnlockClick()
    {
        Debug.Log("Earyly Unlock");
        if(PlayerPrefs.GetInt("Gold") < parent.getAmountOfGoldsToUnlock())
        {
            _shopPanel.GetComponent<ShopManager>().onShopClick();
            Transform temp = _shopPanel.transform.GetChild(_shopPanel.transform.childCount - 1);
            temp.GetComponent<TweenAlpha>().PlayForward();
            temp.GetComponent<TweenScale>().PlayForward();
            //Debug.Log("Pop up shop");
        }
        else
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - parent.getAmountOfGoldsToUnlock());
            parent.openThisCase();
            //Debug.Log("Case Opened!");
        }
    }
}
