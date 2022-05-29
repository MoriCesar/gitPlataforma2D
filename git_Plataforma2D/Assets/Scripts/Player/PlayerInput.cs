using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour 
{
	public PlayerController playerController;

	private PlayerAnimation playerAnimation;
	private PlayerAttack playerAttack;

	public bool crouched;

	public bool jumpPressed;
	public bool clearJump;

	private void Awake()
    {
		playerAnimation = GetComponent<PlayerAnimation>();
		playerAttack = GetComponent<PlayerAttack>();
    }

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (UIManager.instance.IsPaused())
			return;

		if (clearJump)
        {
			jumpPressed = false;
        }
		clearJump = false;

		jumpPressed = jumpPressed || Input.GetButtonDown("Jump");

		if (jumpPressed)
        {
			if (crouched)
				playerController.PassThroughPlatform();
        }


		if (Input.GetButtonDown("Fire1"))
        {
			playerAttack.Fire();
        }

		if (Input.GetButtonDown("Fire2"))
        {
			playerAttack.MeleeAttack();
        }

		if (Input.GetAxisRaw("Vertical") < 0)
		{
			if (!playerController.GetGrounded())
			{
				playerAnimation.SetCrouch(false);
				return;
			}

			playerAnimation.SetCrouch(true);

			playerController.DisableControls();
			crouched = true;
        }
		else if (Input.GetAxisRaw("Vertical") > -1)
        {
			if (crouched)
            {
				crouched = false;
				playerController.EnableControls();
			}

			playerAnimation.SetCrouch(false);
        }
	}

	private void FixedUpdate()
    {
		clearJump = true;

		playerController.Move(Input.GetAxisRaw("Horizontal"));
    }
}
