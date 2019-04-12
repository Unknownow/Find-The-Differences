using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEffectController : MonoBehaviour
{
    [SerializeField]
    private float _timeDelay1 = 0;
    [SerializeField]
    private float _timeDelay2 = 0;

    private bool _isPlayed1 = false;
    private bool _isPlayed2 = false;

    private bool _isStart = false;

    public Transform _spriteFindThe;
    public Transform _spriteDifferences;
    public Transform _spriteMagnifyingGlass;
    // Start is called before the first frame update
    void Start()
    {
        _spriteFindThe = transform.GetChild(0);
        _spriteDifferences = transform.GetChild(1);
        _spriteMagnifyingGlass = transform.GetChild(2);
        _spriteFindThe.GetChild(1).GetComponent<UISprite>().alpha = 0;
        _spriteDifferences.GetChild(2).GetComponent<UISprite>().alpha = 0;
        _spriteMagnifyingGlass.GetChild(1).GetComponent<UISprite>().alpha = 0;
        _isPlayed1 = false;
        _isPlayed2 = false;
        _isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            playTitleAnim();
        if (!_isStart)
            return;

        if (_isPlayed1 && _isPlayed2)
            return;

        if (!_isPlayed1 && _timeDelay1 > 0)
            _timeDelay1 -= Time.deltaTime;
        else
        {
            _spriteDifferences.GetComponent<TweenPosition>().PlayForward();
            _isPlayed1 = true;
        }

        if (!_isPlayed2 && _timeDelay2 > 0)
            _timeDelay2 -= Time.deltaTime;
        else
        {
            _spriteMagnifyingGlass.GetComponent<TweenPosition>().PlayForward();
            _isPlayed2 = true;
        }
    }

    public void playTitleAnim()
    {
        _isStart = true;
        _spriteFindThe.GetComponent<TweenPosition>().PlayForward();
    }
}
