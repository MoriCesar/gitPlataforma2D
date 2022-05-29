using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour 
{
	public float jumpForce = 550;
	public float iceForce = 5;
	public Transform groundCheck;
	public float groundRadius = 0.1f;
	public LayerMask groundLayer;

	public AudioClip jumpSfx;
	public AudioClip[] footStepsSfx;

	[SerializeField]
	private float walkSpeed;
	public float pushSpeed;
	public float maxSpeed = 10;
	private bool pushing;

	private Rigidbody2D rb;
	private Vector2 newMovement;

	private bool facingRight = true;

	private bool grounded;
	private bool doubleJump;

	private bool onIce;

	private PlayerAnimation playerAnimation;
	private bool canControl = true;

	private PassThroughPlatform platform;
	private AudioManager audioManager;

	private PlayerInput playerInput;

	private void Awake() 
	{
		rb = GetComponent<Rigidbody2D>();
		playerAnimation = GetComponent<PlayerAnimation>();
		audioManager = GetComponent<AudioManager>();
		playerInput = GetComponent<PlayerInput>();
	}

	// Use this for initialization
	void Start () 
	{
		// Teste com 60 frames por segundo
		//Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

		playerAnimation.SetOnGround(grounded);

		if (grounded)
			doubleJump = false;

		//Debug.Log(rb.velocity.y);
	}

	private void FixedUpdate() 
	{
		playerAnimation.SetVSpeed(rb.velocity.y);

		if (!canControl)
        {
			return;
        }
		if (!onIce)
			rb.velocity = newMovement;
		else if (onIce)
        {
			rb.AddForce(new Vector2(newMovement.x * iceForce, 0), ForceMode2D.Force);
			if (Mathf.Abs(rb.velocity.x) >= maxSpeed)
            {
				rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
            }
        }

		if (playerInput.jumpPressed)
        {
			if (!playerInput.crouched)
            {
				if (grounded || (!doubleJump && PlayerSkills.instance.skills.Contains(Skills.DoubleJump)))
                {
					audioManager.PlayAudio(jumpSfx);
					rb.velocity = Vector2.zero;
					rb.AddForce(Vector2.up * jumpForce);

					if (!doubleJump && !grounded)
					{
						doubleJump = true;
					}
				}
            }
			
			

			
        }
	}


	public void Move(float direction)
	{
		float currentSpeed;
		if (pushing)
			currentSpeed = pushSpeed;
		else
			currentSpeed = walkSpeed;

		newMovement = new Vector2(direction * currentSpeed, rb.velocity.y);

		playerAnimation.SetSpeed((int)Mathf.Abs(direction));

		if (facingRight && direction < 0)
		{
			Flip();
		}
		else if(!facingRight && direction > 0)
		{
			Flip();
		}
	}

	public void SetPushing(bool state)
    {
		pushing = state;
    }

	void Flip()
	{
		facingRight = !facingRight;

		transform.Rotate(0, 180, 0);
	}

	public void DisableControls()
    {
		canControl = false;
		//jump = false;
		rb.velocity = Vector2.zero;
    }

	public void EnableControls()
    {
		newMovement = Vector2.zero;
		canControl = true;
    }

	public bool GetGrounded()
    {
		return grounded;
    }

	public void SetOnIce(bool state)
    {
		onIce = state;
		if (onIce)
        {
			rb.drag = 2;
        }
		else
        {
			rb.drag = 0;
        }
    }

	public void SetPlatform(PassThroughPlatform passPlatform)
    {
		platform = passPlatform;
    }

	public void PassThroughPlatform()
    {
		if (platform != null)
        {
			platform.PassingThrough();
        }
    }

	public bool IsOnIce()
    {
		return onIce;
    }

	public void FootSteps()
    {
		audioManager.PlayAudio(footStepsSfx[Random.Range(0, footStepsSfx.Length)]);
    }
}
