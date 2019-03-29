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
    //private MenuManager menuManager;
    private PlayerProperties playerProperties;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Camera.main.pixelWidth >= 720)
            gameObject.GetComponent<UI2DSprite>().width = 180;
        else
            gameObject.GetComponent<UI2DSprite>().width = 90;
        //menuManager = FindObjectOfType<MenuManager>();
        playerProperties = GameObject.FindGameObjectWithTag("Player Properties").GetComponent<PlayerProperties>();
    }
    void Start()
    {
        isOpen = false;
        selectSprite();

    }

    // Update is called once per frame
    void Update()
    {
        if(playerProperties.checkIfThisLevelIsOpened(_caseIndex, _levelIndex))
            selectSprite();
    }

    public void onLevelSelectionClick()
    {

        if (!isOpen)
            return;
        Debug.Log(playerProperties.findSceneToLoadInMenu(_caseIndex, _levelIndex, false));
        SceneManager.LoadScene(playerProperties.findSceneToLoadInMenu(_caseIndex,_levelIndex,false));
    }

    private void selectSprite()
    {
        Sprite temp = _closedSprite;

        if(playerProperties.checkIfThisLevelIsOpened(_caseIndex, _levelIndex))
        {
            isOpen = true;
            temp = _openSprite;
        }
        gameObject.GetComponent<UI2DSprite>().sprite2D = temp;
        gameObject.GetComponent<UIButton>().normalSprite2D = temp;
    }
    
    public int getStarsOfThisLevel()
    {
        return playerProperties.getStarsOfThisLevel(_caseIndex, _levelIndex);
    }
}
