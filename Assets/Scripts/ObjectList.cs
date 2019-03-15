using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour {
    [SerializeField]
    private int maxNumObjects = 5;
    [SerializeField]
    private int secondsDecreaseWhenChooseWrong = 20;
    private int chosenObject = 0;
    private UILabel objectCount; 
	// Use this for initialization
	void Start () {
        chosenObject = 0;
        objectCount = GameObject.FindGameObjectWithTag("Object Count").GetComponent<UILabel>();
        objectCount.text = "Found(0/" + maxNumObjects.ToString() + ")";
    }
	
	// Update is called once per frame
	void Update () {
        if (chosenObject >= maxNumObjects)
        {
            gameObject.GetComponent<NextLevelPanel>().openNextLevelPanel();
            gameObject.GetComponent<GameManager>().stopTime(true);
        }
            
    }

    // called when the right object is selected
    public void selectRightObject()
    {
        Debug.Log("choose right!");
        chosenObject += 1;
        if (chosenObject > maxNumObjects)
            return;
        objectCount.text = "Found(" + chosenObject.ToString() + "/" + maxNumObjects.ToString() + ")"; 
    }

    // called when player choose wrong object
    public void selectWrongObject()
    {
        Debug.Log("choose wrong!");
        gameObject.GetComponent<GameManager>().decreaseRemainingTimeBySecond(secondsDecreaseWhenChooseWrong);
    }

}
