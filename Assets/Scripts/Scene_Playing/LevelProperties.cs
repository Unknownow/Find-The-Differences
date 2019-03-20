using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProperties : MonoBehaviour
{
    [SerializeField]
    private int _case = 1;
    [SerializeField]
    private int _level = 1;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCase()
    {
        return _case;
    }

    public int getLevel()
    {
        return _level;
    }

}
