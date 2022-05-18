using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
	public PlayerController playerController;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerController.Move(Input.GetAxisRaw("Horizontal"));

		if (Input.GetButtonDown("Jump"))
        {
			playerController.Jump();
        }
	}
}
