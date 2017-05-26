using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorWalls : LaserDistributer
{
	public bool IsOn;
	//public Vector3 Origin;
	private IEnergyReciever _reciever;
//	public Vector3 Dir;

	public override void  Connected()
	{
	//	print("Wall Connected");
	}
	public override void  Disconnected()
	{
		if(_reciever!=null)
			_reciever.Disconnected();
	//	print("dsiconnected");
	}
	// Use this for initialization
	void Start()
	{

	}

	public override void Toggle()
	{
		//print(_reciever);
		//print("Toogle"+_reciever);
		if (_reciever != null)

		{
			_reciever.Disconnected();
			_reciever = null;
		}

		base.Toggle();
		
	}

	public void SetReflection(Vector3 origin,Vector3 dir)
	{ 
		IsOn = true;
		Origin = origin;
		Dir = dir;

	}
	// Update is called once per frame
	void Update()
	{
		//Debug.DrawRay(r.origin, r.direction);
		if (IsOn)
		{
			DistribueteLaser();
			// Ray r1 = new Ray(Origin, Dir);
			// // Debug.DrawRay(r1.origin, r1.direction,Color.red);
			// RaycastHit hit;
			// if (Physics.Raycast(r1,out hit))
			// {
			// 	Debug.DrawLine(Origin, hit.point, Color.red);
			// 	//Debug.DrawRay(hit.point, Vector3.Reflect(r1.direction, hit.normal), Color.blue);
			// 	MirrorWalls wall = hit.transform.GetComponent<MirrorWalls>();
			// 	if (wall != null)
			// 	{
			// 		wall.Mirror(hit.point, Vector3.Reflect(r1.direction, hit.normal));

			// 	}
			// 	else if (hit.transform.GetComponent<IEnergyReciever>() != null)
			// 	{
			// 		if (_reciever != hit.transform.GetComponent<IEnergyReciever>())
			// 		{
			// 			if (_reciever != null)
			// 				_reciever.Disconnected();
			// 			_reciever = hit.transform.GetComponent<IEnergyReciever>();
			// 			_reciever.Connected();
			// 		}

			// 	}
			// }
			// else 
			// {
			// 	Debug.DrawRay(r1.origin,r1.direction, Color.red);
				
			// }
			//RaycastHit hit;
			//if (Physics.Raycast(r, out hit))
			//{
			//	var c = (r.origin + r.direction) - 2 * (Vector3.Dot((r.origin + r.direction), hit.normal)) * hit.normal;
			//	Debug.DrawLine(transform.position, hit.point, Color.red);

			//	Debug.DrawLine(hit.point, c, Color.red);
			//}
			//else
			//{
			//	Debug.DrawRay(r.origin, r.direction);

			//}
		}
		IsOn = false;
		if (_reciever!=null)
		{
			_reciever.Disconnected();
		}
	}
	
}
