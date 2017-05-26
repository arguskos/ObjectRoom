	using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrebsList : MonoBehaviour {

	// Use this for initialization
	public static PrebsList Instance;
	public bool UsePhysics;
	public GameObject[] PhysicsPrefbabs;
	public GameObject[] GridPrefabs;
	public GameObject[] SharePrefabs;

	public GameObject[] GetPrefabs()
	{
		if (UsePhysics)
		{
			return PhysicsPrefbabs.Concat(SharePrefabs).ToArray();

		}
		else
		{
			return GridPrefabs.Concat(SharePrefabs).ToArray();

		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
