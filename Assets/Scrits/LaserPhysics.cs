using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPhysics : LaserDistributer
{
	private bool _connectedToCenter;
	private bool _switchable=false;
	public bool WasPowered;
	// Use this for initialization
	void Start()
	{
		Origin=transform.position;
		Dir=transform.right;
		///Activated;
	}

	
	public void SetDirection()
	{ 
		Origin=transform.position;
		Dir=transform.right;

	}
	public override void Toggle()
	{
	}

	// Update is called once per frame


	
}
