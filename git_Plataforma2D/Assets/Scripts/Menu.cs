using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour 
{
	public AudioMixer mixer;

	public GameObject loadPanel;

	private string currentScene;

	// Use this for initialization
	void Start () 
	{
		
	}

	float GetVol(float vol)
    {
		float newVol = 0;
		newVol = 20 * Mathf.Log10(vol);
		if (vol <= 0)
		{
			newVol = -80;
		}

		return newVol;
	}
	
	public void SetMasterVol(float vol)
    {
		
		mixer.SetFloat("MasterVol", GetVol(vol));

    }

	public void SetMusicVol(float vol)
    {
		mixer.SetFloat("MusicVol", GetVol(vol));
    }

	public void SetSFXVol(float vol)
    {
		mixer.SetFloat("SFXVol", GetVol(vol));
    }

	public void LoadScene(string scene)
    {
		loadPanel.SetActive(true);
		currentScene = scene;
		Invoke("Loading", 3f);
    }

	void Loading()
    {
		SceneManager.LoadSceneAsync(currentScene);
    }

	public void Quit()
    {
		Application.Quit();
    }
}
