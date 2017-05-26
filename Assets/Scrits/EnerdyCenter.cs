using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnerdyCenter : MonoBehaviour,IEnergyReciever
{
	public int HitsToWin=3;

	private int _currentHit;
	// Use this for initialization
	void Start () {
		
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

	public void Disconnected()
	{
		print("energy cnenter disconnceted");
		
		_currentHit--;
	}
}
