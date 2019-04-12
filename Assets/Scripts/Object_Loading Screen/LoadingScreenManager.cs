using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField]
    private float _loadingSpeed = .002f;

    public List<EventDelegate> onFinish = new List<EventDelegate>();

    private GameObject _loadingBar;
    // Start is called before the first frame update
    void Start()
    {
        _loadingBar = transform.GetChild(0).gameObject;
        _loadingBar.GetComponent<UISlider>().value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _loadingBar.GetComponent<UISlider>().value += Time.deltaTime * _loadingSpeed;
        if (_loadingBar.GetComponent<UISlider>().value >= 1)
        {
            onFinishCall();
            Destroy(gameObject);
        }
            
    }

    public void onFinishCall()
    {
        EventDelegate.Execute(onFinish);
    }
}
