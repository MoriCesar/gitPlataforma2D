using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CheckPointController : MonoBehaviour 
{
	public Transform player;
	public Animator fade;

	public UnityEvent OnRestart;

	private Vector3 respawnPosition;

	public void SetPos(Vector3 pos)
    {
		respawnPosition = pos;
    }

	public void GameOver()
    {
		Invoke("Restart", 3f);
		fade.Play("Fade");
    }

	public void Restart()
    {
		player.position = respawnPosition;
		OnRestart.Invoke();
    }
}
