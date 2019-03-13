using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour {
    [SerializeField]
    private int maxNumObjects = 5;
    [SerializeField]
    private int secondsDecreaseWhenChooseWrong = 20;
    private GameManager gameManager;
    private int chosenObject = 0;
    private UILabel objectCount; 
	// Use this for initialization
	void Start () {
        chosenObject = 0;
        objectCount = GameObject.FindGameObjectWithTag("Object Count").GetComponent<UILabel>();
        gameManager = gameObject.GetComponent<GameManager>();
        objectCount.text = "Found(0/" + maxNumObjects.ToString() + ")";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void selectRightObject()
    {
        Debug.Log("choose right!");
        chosenObject += 1;
        if (chosenObject > maxNumObjects)
            return;
        objectCount.text = "Found(" + chosenObject.ToString() + "/" + maxNumObjects.ToString() + ")"; 
    }

    public void selectWrongObject()
    {
        Debug.Log("choose wrong!");
        gameManager.decreaseTimer(secondsDecreaseWhenChooseWrong);
    }
}
