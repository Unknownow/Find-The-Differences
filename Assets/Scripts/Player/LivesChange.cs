using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesChange : MonoBehaviour
{
    private LivesAndDailyManager _livesManager;
    private UILabel _livesAmount;
    [SerializeField]
    private GameObject _addLifeAdsButton;
    // Start is called before the first frame update
    void Start()
    {
        _livesManager = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<LivesAndDailyManager>();
        _livesAmount = transform.GetChild(1).GetComponent<UILabel>();
        _addLifeAdsButton = transform.GetChild(2).gameObject;
        _addLifeAdsButton.GetComponent<UIWidget>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _livesAmount.text = _livesManager.getCurrentLives().ToString();
        if (Input.GetKeyDown(KeyCode.B))
        {
            onOpenAddLifeAdsClick();
        }
    }

    public void onLivesAdsClick()
    {
        watchAds();
        _livesManager.increaseCurrentLives();
        onCloseAddLifeAdsClick();
    }

    private void watchAds()
    {
        Debug.Log("LivesChange.watchAds()");
    }

    public void onOpenAddLifeAdsClick()
    {
        _addLifeAdsButton.GetComponent<TweenAlpha>().PlayForward();
    }

    public void onCloseAddLifeAdsClick()
    {
        _addLifeAdsButton.GetComponent<TweenAlpha>().PlayReverse();
    }

    public void hideHeartSprite(bool isHidden)
    {
        if (isHidden)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);
    }
}
