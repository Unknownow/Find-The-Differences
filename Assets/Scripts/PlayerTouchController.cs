using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTouchController : MonoBehaviour {

    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = getClick();
            if (temp == null)
            {
                text.text = "asdasd";
                return;
            }
                
            if (temp != null)
            {
                text.text = "Decrease!    1" + temp.tag + "     xxxx";//temp.transform.CompareTag("Decrease");


                if (temp.transform.CompareTag("Decrease"))
                {
                    Debug.Log("Decrease!");
                    int i = Random.Range(0, 10);
                    text.text = "Decrease! 2" + i.ToString();
                }
                else if (temp.transform.CompareTag("HitBox"))
                {
                    Debug.Log("Hit!");
                    int i = Random.Range(0, 10);
                    text.text = "Found! " + i.ToString();
                }
                
            }
            
        }
	}

    private GameObject getClick()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.forward, Mathf.Infinity, layer);
        if (hit)
        {
            int i = Random.Range(0, 10);
            text.text = "HIT!" + i.ToString();
            return hit.transform.gameObject;
        }
        return null;
    }

}
