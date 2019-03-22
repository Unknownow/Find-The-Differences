using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    private int _caseIndex;
    [SerializeField]
    private int _levelIndex;
    [SerializeField]
    private Sprite _openSprite;
    [SerializeField]
    private Sprite _closedSprite;
    [SerializeField]
    private bool isOpen = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Camera.main.pixelWidth >= 720)
            gameObject.GetComponent<UI2DSprite>().width = 180;
        else
            gameObject.GetComponent<UI2DSprite>().width = 90;
    }
    void Start()
    {
        isOpen = false;
        selectSprite();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onLevelSelectionClick()
    {
        if (!isOpen)
            return;
        SceneManager.LoadScene( ( _caseIndex - 1)  * 10 + _levelIndex );
    }

    private void selectSprite()
    {
        Sprite temp = _closedSprite;
        int highestCase = PlayerPrefs.GetInt("Case");
        int highestLevel = PlayerPrefs.GetInt("Level");
        if(_caseIndex == highestCase)
        {
            if (_levelIndex <= highestLevel)
            {
                temp = _openSprite;
                isOpen = true;
            }
                
        }
        else if(_caseIndex < highestCase)
        {
            temp = _openSprite;
            isOpen = true;
        }
        gameObject.GetComponent<UI2DSprite>().sprite2D = temp;
        gameObject.GetComponent<UIButton>().normalSprite2D = temp;
    }
}
