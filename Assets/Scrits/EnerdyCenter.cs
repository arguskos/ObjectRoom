using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnerdyCenter : MonoBehaviour
{
	public int HitsToWin=3;
	public static EnerdyCenter Instance;

	private int _currentHit;
	// Use this for initialization
	 void Start()
	{
		if ( Instance==null)
		{
			Instance=this;
		}
	}
	

	

	private void Win()
	{
		print("gameOver");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public  void Connected()
	{
		print("energy cnenter connected");
		_currentHit++;
		if (HitsToWin <= _currentHit)
		{
			Win();
		}
	}

	public void SwitchOff()
	{
		print("energy cnenter disconnceted");
		
		_currentHit=0;
	}
}
