using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyBonus : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int _livesGain = 0;
    [SerializeField]
    private int _goldsGain = 0;
    [SerializeField]
    private int _hintsGain = 0;

    private LivesAndDailyManager dailyManager;
    void Start()
    {
        dailyManager = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<LivesAndDailyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dailyBonusGain()
    {
        dailyManager.increaseCurrentLives(_livesGain);
        dailyManager.addGold(_goldsGain);
        dailyManager.addHints(_hintsGain);
    }
}
