using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
	public static Selected Instance;

	public Material Mat;
	// Use this for initialization
	public void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position+ GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size);

		Gizmos.color = new Color(0,0,1,0.3f);
		Gizmos.DrawCube(transform.position+ GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size);
	}
}
