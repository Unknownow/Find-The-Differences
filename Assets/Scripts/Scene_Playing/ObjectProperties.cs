using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    [SerializeField]
    private bool _isFound = false;
    public GameObject paralleButton;
    [SerializeField]
    private GameObject _foundPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _isFound = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void found()
    {
        if (_isFound)
            return;
        Debug.Log("FOUND!");
        _isFound = true;
        paralleButton.GetComponent<ObjectProperties>().found();
        Instantiate(_foundPrefab, transform.position, Quaternion.identity, transform);
        gameObject.GetComponent<UIButton>().enabled = false;
    }

    public bool isFound()
    {
        return this._isFound;
    }
}
