using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelSelectionPanel;
    [SerializeField]
    private int _caseIndex;
    // Start is called before the first frame update
    void Start()
    {
        _levelSelectionPanel = GameObject.FindGameObjectWithTag("Level Selection Panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void caseSelectionButton()
    {
        GameObject backGround = _levelSelectionPanel.transform.GetChild(0).gameObject;
        backGround.SetActive(true);
        GameObject levelPanel = _levelSelectionPanel.transform.GetChild(_caseIndex + 1).gameObject;
        levelPanel.SetActive(true);
        GameObject backButton = _levelSelectionPanel.transform.GetChild(1).gameObject;
        backButton.SetActive(true);
        backGround.GetComponent<TweenAlpha>().PlayForward();
        levelPanel.GetComponent<TweenAlpha>().PlayForward();
        backButton.GetComponent<TweenAlpha>().PlayForward();
        GameObject.FindGameObjectWithTag("Menu Manager").GetComponent<MenuManager>().setCurrentCase(_caseIndex);
    }
}
