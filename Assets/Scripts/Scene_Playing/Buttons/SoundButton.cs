using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    private GameObject _slider;
    private float _currentValue;
    private GameObject _muteSprite;
    // Start is called before the first frame update
    void Start()
    {
        _slider = transform.GetChild(0).gameObject;
        _muteSprite = transform.GetChild(1).gameObject;
        _muteSprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_slider.GetComponent<UISlider>().value > 0)
            _muteSprite.SetActive(false);
        else
            _muteSprite.SetActive(true);
    }

    public void onMuteClick()
    {
        if (_slider.GetComponent<UISlider>().value == 0)
        {
            mute();
            _slider.GetComponent<UISlider>().value = _currentValue;
        }
        else
        {
            mute();
            _currentValue = _slider.GetComponent<UISlider>().value;
            _slider.GetComponent<UISlider>().value = 0;
        }
    }

    private void mute()
    {
        Debug.Log("ButtonSound.mute()");
    }
}
