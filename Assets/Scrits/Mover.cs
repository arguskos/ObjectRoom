using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : RodsBase
{

	public Vector3 Positon;
	public float Speed;

	void Start()
	{
		StartCoroutine(Move());
	}
	IEnumerator Move()
	{
		Vector3 pos = transform.position;
		float time = 0;
		while ( time<1)
		{
			time += Speed;
			transform.position=Vector3.Lerp(pos,Positon,time);
			yield return null;
		}
	}
}
