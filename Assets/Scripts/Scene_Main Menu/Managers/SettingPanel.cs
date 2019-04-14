using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeStage.AntiCheat.ObscuredTypes;


public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    private int _goldsGainOnShare = 50;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<UIPanel>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onBackClick()
    {
        gameObject.GetComponent<TweenAlpha>().PlayReverse();
    }

    public void onOpenSettingClick()
    {
        gameObject.GetComponent<TweenAlpha>().PlayForward();
    }

    public void onFbShareClick()
    {
        watchAds();
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + _goldsGainOnShare);
    }
    public void onInsShareClick()
    {
        watchAds();
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + _goldsGainOnShare);
    }

    private void watchAds()
    {
        Debug.Log("SettingPanel.watchAds()");
    }

}
