using UnityEngine;
using System.Collections;

public class BallBounce : MonoBehaviour {

    private Rigidbody2D rigidBody;

    void Awake ()
    {
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
    }

	// Use this for initialization
	void Start ()
    {
        rigidBody.AddForce(new Vector2(1000, 0), ForceMode2D.Force);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
