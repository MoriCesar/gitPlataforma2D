using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThroughPlatform : MonoBehaviour 
{
	public int ignoreLayer;

	private int myLayer;

	// Use this for initialization
	void Start () 
	{
		myLayer = gameObject.layer;
	}
	
	public void PassingThrough()
    {
		gameObject.layer = ignoreLayer;
		Invoke("SetDefaultLayer", 0.5f);
    }

	void SetDefaultLayer()
    {
		gameObject.layer = myLayer;
    }

	private void OnCollisionEnter2D(Collision2D other)
    {
		PlayerController player = other.gameObject.GetComponent<PlayerController>();
		if (player != null)
        {
			player.SetPlatform(this);
        }
    }
}
