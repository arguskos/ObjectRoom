using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPhysics : LaserDistributer
{
	private bool _connectedToCenter;
	private IEnergyReciever _reciever;
	public bool Activated;
	// Use this for initialization
	void Start()
	{
		Origin=transform.position;
		Dir=transform.right;
		///Activated;
	}

	public override void Toggle()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Activated)
		{
			DistribueteLaser();
		}
	}

	public override  void Connected()
	{
		base.Connected();
		print ("connected") ;
		Activated = true;
	}


}
