using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour 
{
	public float fireRate;
	public Rigidbody2D bulletPrefab;
	public Transform shotSpawn;
	public Vector2 shotImpulse;

	private Animator anim;

	private void Awake()
    {
		anim = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating("SetFire", fireRate, fireRate);
	}
	
	void SetFire()
    {
		anim.SetTrigger("Fire");
    }

	void Fire()
    {
		Rigidbody2D newBullet = Instantiate(bulletPrefab, shotSpawn.position, transform.rotation);
		newBullet.AddForce(shotImpulse, ForceMode2D.Impulse);
		//Destroy(newBullet.gameObject, 5f);
    }
}
