using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dailyBonus;
    private LivesAndDailyManager dailyManager;
    private int _currentDay = 0;
    // Start is called before the first frame update
    void Start()
    {
        dailyManager = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<LivesAndDailyManager>();
        gameObject.GetComponent<UIPanel>().alpha = 0;
        for(int i = 0; i < dailyManager.getLastestLoginDay() - 1; i++)
        {
            setDayToOpen(dailyBonus[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playDailyAnim()
    {
        dailyBonus[_currentDay - 1].transform.GetChild(1).GetComponent<TweenScale>().PlayForward();
        dailyBonus[_currentDay - 1].transform.GetChild(1).GetComponent<TweenAlpha>().PlayForward();
        dailyBonus[_currentDay - 1].GetComponent<DailyBonus>().dailyBonusGain();
    }

    public void checkDaily(){
        if (dailyManager.checkDaily())
        {
            gameObject.GetComponent<UIPanel>().alpha = 1;
            _currentDay = dailyManager.getCurrentDailyDay();
            gameObject.GetComponent<TweenScale>().PlayForward();
        }
    }

    private void setDayToOpen(Transform daily)
    {
        daily.GetChild(1).GetComponent<UISprite>().alpha = 0;
        daily.GetChild(0).localScale = new Vector3(1, 1, 1);
    }
}
