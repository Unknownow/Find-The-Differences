using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour {

    [SerializeField]
    private float hitBoxRadius = 2f;
    private float oldRadius; 
    private CircleCollider2D hitBoxCollider;

	// Use this for initialization
	void Start () {
        hitBoxCollider = gameObject.GetComponent<CircleCollider2D>();
        oldRadius = hitBoxRadius;
        hitBoxCollider.radius = hitBoxRadius;
    }
	
	// Update is called once per frame
	void Update () {
	    if(hitBoxRadius != oldRadius)
        {
            oldRadius = hitBoxRadius;
            hitBoxCollider.radius = hitBoxRadius;
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, hitBoxRadius);
    }
}
