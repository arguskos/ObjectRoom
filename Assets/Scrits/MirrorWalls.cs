using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorWalls : LaserDistributer
{

	//public Vector3 Origin;

//	public Vector3 Dir;


	// Use this for initialization
	void Start()
	{

	}

	public override void Toggle()
	{
		//print(_reciever);
		//print("Toogle"+_reciever);
		base.Toggle();
		
	}

	public void SetReflection(Vector3 origin,Vector3 dir)
	{ 
		Origin = origin;
		Dir = dir;

	}
	// Update is called once per frame
	
}
