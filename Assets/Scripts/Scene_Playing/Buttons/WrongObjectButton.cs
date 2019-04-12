using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongObjectButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _wrongPrefab;
    [SerializeField]
    private Transform _UIRoot;
    [SerializeField]
    private Camera _gameCamera;
    private LevelManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onWrongClick()
    {
        _gameManager.onSelectWrongObjectClick();
        Vector3 pos = UICamera.currentTouch.pos;
        pos.x -= Camera.main.pixelWidth / 2;
        pos.y -= Camera.main.pixelHeight / 2;
        GameObject wrongMark = Instantiate(_wrongPrefab, pos, Quaternion.identity, _UIRoot);
        wrongMark.GetComponent<TweenPosition>().from = pos;
        wrongMark.GetComponent<TweenPosition>().to = new Vector3(pos.x, pos.y + 50, pos.z);
        wrongMark.GetComponent<TweenAlpha>().PlayForward();
        wrongMark.GetComponent<TweenPosition>().PlayForward();
    }

}
