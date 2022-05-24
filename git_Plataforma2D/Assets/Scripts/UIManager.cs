using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour 
{
	public static UIManager instance;

	public GameObject[] lives;

	public GameObject[] keys;

	public Text dialogueText;
	public Animator dialoguePanel;

	private void Awake()
    {
		instance = this;
    }

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SetText(string text)
    {
		CancelInvoke();
		dialogueText.text = text;
		dialoguePanel.gameObject.SetActive(true);
    }

	public void SetTextOut()
    {
		Invoke("TextOut", 1f);
    }
	void TextOut()
    {
		dialoguePanel.Play("Dialogue Exit");
		Invoke("DisableDialoguePanel", 0.5f);
    }

	void DisableDialoguePanel()
    {
		dialoguePanel.gameObject.SetActive(false);
    }

	public void SetLives(int amount)
    {
		for (int i = 0; i < lives.Length; i++)
        {
			lives[i].SetActive(false);
        }

		for (int i = 0; i < amount; i++)
        {
			lives[i].SetActive(true);
        }
    }

	public void SetKeys(int amount)
    {
		for (int i = 0; i < keys.Length; i++)
        {
			keys[i].SetActive(false);
        }
		for (int i = 0; i < amount; i++)
        {
			keys[i].SetActive(true);
        }
    }
}
