using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : RodsBase
{

	// Use this for initialization
	List<Vector2> _dirs = new List<Vector2>();
	public bool IsOn = true;
	public bool Starter = true;
	void Start()
	{
		_dirs.Add(new Vector2(-1, 0));
		_dirs.Add(new Vector2(1, 0));
		_dirs.Add(new Vector2(0, 1));
		_dirs.Add(new Vector2(0, -1));
		_dirs.Add(new Vector2(-1, -1));
		_dirs.Add(new Vector2(1, 1));
		_dirs.Add(new Vector2(-1, 1));
		_dirs.Add(new Vector2(1, -1));

	}
	public void SwitchOnChain()
	{
		//foreach (var dir in _dirs)
		//{
		//	Ray r = new Ray(transform.position, new Vector3(dir.x, 0, dir.y));
		//	Debug.DrawRay(r.origin, r.direction, Color.red);
		//}
	}
	// Update is called once per frame
	void Update()
	{

		bool switched = false;
		foreach (var dir in _dirs)
		{
			Ray r = new Ray(transform.position, new Vector3(dir.x, 0, dir.y));

			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.transform.GetComponent<Laser>().IsOn)
				{
					IsOn = true;
					switched = true;
					break;
				}
			}

		}
		if (!switched && !Starter)
			IsOn = false;
		foreach (var dir in _dirs)
		{

			if (IsOn)
			{
				Ray r = new Ray(transform.position, new Vector3(dir.x, 0, dir.y));
				Debug.DrawRay(r.origin, r.direction, Color.red);
			}
			else
			{
				Ray r = new Ray(transform.position, new Vector3(dir.x, 0, dir.y));
				Debug.DrawRay(r.origin, r.direction, Color.white);
			}

		}



	}
}
