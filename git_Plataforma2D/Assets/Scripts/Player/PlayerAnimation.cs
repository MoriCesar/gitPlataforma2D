﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private Animator anim;

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void SetSpeed(int speed)
	{
		anim.SetInteger("Speed", speed);
	}

	public void SetVSpeed(float speed)
	{
		anim.SetFloat("vSpeed", speed);
	}

	public void SetOnGround(bool state)
	{
		anim.SetBool("OnGround", state);
	}

	public void SetCrouch(bool state)
	{
		anim.SetBool("Crouched", state);
	}

	public void SetMeleeAttack()
	{
		anim.SetTrigger("Attack");
	}
}