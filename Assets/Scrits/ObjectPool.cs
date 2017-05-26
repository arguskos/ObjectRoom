using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {


	public static ObjectPool Instance;

	public GameObject Laser1;
	public GameObject PhysicsLaser;
	public GameObject Mirrots;
	public GameObject Wall;
	private void Awake()
	{
		if( Instance=null)
		{
			Instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
