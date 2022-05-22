using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour 
{
    public Sprite checkPointLighted;
    public GameObject lights;

    private bool isActive;

	private SpriteRenderer spriteRenderer;
    private CheckPointController checkPointController;

	private void Awake()
    {
		spriteRenderer = GetComponent<SpriteRenderer>(); ;
    }

    private void Start()
    {
        checkPointController = FindObjectOfType<CheckPointController>();
    }

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (isActive)
            return;

		if (other.CompareTag("Player"))
        {
            checkPointController.SetPos(transform.position);
            spriteRenderer.sprite = checkPointLighted;
            lights.SetActive(true);
            isActive = true;
        }
    }
	
}
