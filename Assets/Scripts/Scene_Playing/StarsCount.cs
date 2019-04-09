using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsCount : MonoBehaviour
{
    private int _wrongClick = 0;
    private int _stars = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void wrongClick()
    {
        _wrongClick += 1;
        if (_wrongClick % 2 == 0)
        {
            decreaseStars();
        }
    }

    public void decreaseStars()
    {
        _stars -= 1;
        if (_stars < 0)
            _stars = 0;
    }

    public int getStars()
    {
        return _stars;
    }
}
