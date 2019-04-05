using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStars : MonoBehaviour
{
    private GameObject _leftStar;
    private GameObject _rightStar;
    private GameObject _middleStar;
    // Start is called before the first frame update
    void Start()
    {
        _leftStar = transform.GetChild(1).gameObject;
        _rightStar = transform.GetChild(0).gameObject;
        _middleStar = transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeStars(int stars)
    {
        if(stars == 0)
        {
            _leftStar.SetActive(false);
            _rightStar.SetActive(false);
            _middleStar.SetActive(false);
        }
        else if (stars == 1)
        {
            _leftStar.SetActive(false);
            _rightStar.SetActive(false);
            _middleStar.SetActive(true);
        }
        else if (stars == 2)
        {
            _leftStar.SetActive(true);
            _rightStar.SetActive(false);
            _middleStar.SetActive(true);
        }
        else if (stars == 3)
        {
            _leftStar.SetActive(true);
            _rightStar.SetActive(true);
            _middleStar.SetActive(true);
        }
    }
}
