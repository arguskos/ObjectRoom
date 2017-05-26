using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///


///
public class LaserDistributer : RodsBase,IEnergyReciever {

	// Use this for initialization
	private IEnergyReciever _reciever ;
	
	private IEnergyReciever Reciver {
		get{return _reciever; }
		set{
			//Debug.Log("somebodyChaged Me");
			_reciever=value;
		}

		}
	protected Vector3 Origin;
	protected Vector3 Dir;
	void Start () {
		
	}

	protected void DistribueteLaser()
	{
		Ray r = new Ray(Origin, Dir);

			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				//var c = (r.origin + r.direction) - 2 * (Vector3.Dot((r.origin + r.direction), hit.normal)) * hit.normal;
		
				Debug.DrawLine(Origin, hit.point, Color.red);
				//Debug.DrawRay(hit.point, Vector3.Reflect(r.direction, hit.normal), Color.blue);
				MirrorWalls wall = hit.transform.GetComponent<MirrorWalls>();
				if (wall != null)
				{
					if (Reciver != null)
							Reciver.Disconnected();
						Reciver = hit.transform.GetComponent<IEnergyReciever>();
						Reciver.Connected();
					wall.SetReflection(hit.point, Vector3.Reflect(r.direction, hit.normal));
					
				}
				else if (hit.transform.GetComponent<IEnergyReciever>() != null)
				{
					if (Reciver != hit.transform.GetComponent<IEnergyReciever>())
					{
						if (Reciver != null)
							Reciver.Disconnected();
						
						Reciver = hit.transform.GetComponent<IEnergyReciever>();
						if (Reciver!=null)
						{
							print (Reciver);
							Reciver.Connected();
						}
							print (Reciver);
							
						//print("connect");
					}

				}
			}
			else
			{
				Debug.DrawRay(r.origin, r.direction);
			//	print("disconnect"+_reciever);
				//print(_reciever);
				if (Reciver!=null)

				{
					Reciver.Disconnected();
					Reciver = null;
				}
			}
	}
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Connected()
	{
		print("base Connected");
			}

	public virtual void Disconnected()
	{
		print("disconnected");
	}
}
