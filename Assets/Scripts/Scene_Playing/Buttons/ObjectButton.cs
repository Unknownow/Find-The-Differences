using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectButton : MonoBehaviour
{
    [SerializeField]
    private bool _isFound = false;
    public GameObject paralleButton;
    [SerializeField]
    private GameObject _foundPrefab;
    [SerializeField]
    private float _percentAboveObject = 0;
    private LevelManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _isFound = false;
        gameManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void found(bool loop = false)
    {
        if (_isFound)
            return;
        Debug.Log("FOUND!");
        _isFound = true;
        paralleButton.GetComponent<ObjectButton>().found(true);
        Vector3 temp = transform.position;
        temp.y += _percentAboveObject;
        Instantiate(_foundPrefab, temp, Quaternion.identity, transform);
        gameObject.GetComponent<UIButton>().enabled = false;
        if(!loop)
            gameManager.onSelectRightObjectClick();
    }

    public bool isFound()
    {
        return this._isFound;
    }
}
