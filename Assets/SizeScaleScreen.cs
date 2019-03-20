using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeScaleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float temp = 1440 / Camera.main.pixelWidth;
        //gameObject.GetComponent<UI2DSprite>().width = (int)(70 * (temp / 2.0 + 0.5));
        gameObject.GetComponent<UI2DSprite>().width = (int)(140 / temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
