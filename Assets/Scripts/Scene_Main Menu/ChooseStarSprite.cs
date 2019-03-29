using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseStarSprite : MonoBehaviour
{
    [SerializeField]
    private NGUIAtlas _starAtlas;
    [SerializeField]
    private int _numberOfStars = 0;
    private LevelSelectionButton _parent;
    // Start is called before the first frame update
    void Start()
    {
        _parent = gameObject.GetComponentInParent<LevelSelectionButton>();
        setNumberOfStars(_parent.getStarsOfThisLevel());
    }

    // Update is called once per frame
    void Update()
    {
        setNumberOfStars(_parent.getStarsOfThisLevel());
    }

    public void setNumberOfStars(int num)
    {
        _numberOfStars = num;
        changeSprite();
    }

    private void changeSprite()
    {
        if (_numberOfStars == 0)
        {
            gameObject.GetComponent<UISprite>().enabled = false;
            return;
        }
        gameObject.GetComponent<UISprite>().enabled = true;
        gameObject.GetComponent<UISprite>().spriteName = _numberOfStars.ToString() + " Stars";
    }
}
