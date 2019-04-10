using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorRetry : MonoBehaviour
{
    [SerializeField]
    private bool _isRetry = false;

    private LivesAndDailyManager _livesManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _livesManager = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<LivesAndDailyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isRetry)
        {
            if(!_livesManager.isPlayable())
            {
                gameObject.GetComponent<UISprite>().alpha = 1;
                return;
            }
            gameObject.GetComponent<UISprite>().alpha = 0;
            return;
        }
        if (!_livesManager.isPlayable())
        {
            gameObject.GetComponent<UISprite>().color = Color.gray;
            gameObject.GetComponent<UIButton>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<UISprite>().color = Color.white;
            gameObject.GetComponent<UIButton>().enabled = true;
        }
    }
}
