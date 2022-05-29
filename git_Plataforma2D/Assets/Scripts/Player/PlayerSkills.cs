using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skills
{
	DoubleJump, Melee, Gun
}

public class PlayerSkills : MonoBehaviour 
{
	public static PlayerSkills instance;

	public List<Skills> skills;

	private void Awake()
    {
		instance = this;
    }

	/*private void Start()
    {
		if(GameManager.instance != null)
        {
			for (int i = 0; < GameManager.instance, skills.Count; int++)
			{
				skills.Add(GameManager.instance.skills[i]);
            }
        }
    }*/
}
