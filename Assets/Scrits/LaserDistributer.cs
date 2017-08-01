using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///


///
public class LaserDistributer : RodsBase
{

    // Use this for initialization

    public bool Powered { get; set; }
    public bool Connected = false;
    public Vector3 Origin;
    public Vector3 Dir;
    public Vector3 Target;
    void Start()
    {
        SwitchOff();
    }
    public virtual void SwitchOff()
    {
        Powered = false;
        Connected = false;
    }
    public void Connect()
    {
        if (Powered)
            return;
        Powered = true;
        Ray r = new Ray(Origin, Dir);
        print(Origin + "  " + Dir);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            print("hit");
            if (hit.transform.GetComponent<LaserDistributer>())
            {
                Connected = true;
                Target = hit.point;
                if (hit.transform.GetComponent<MirrorWalls>())
                    hit.transform.GetComponent<MirrorWalls>().SetReflection(hit.point, Vector3.Reflect(r.direction, hit.normal));
                else if (hit.transform.GetComponent<LaserPhysics>())
                {

                    hit.transform.GetComponent<LaserPhysics>().WasPowered = true;
                }
                hit.transform.GetComponent<LaserDistributer>().Connect();
            }

            else if( hit.transform.GetComponent<EnerdyCenter>())
            {
                Connected = true;
                Target = hit.point;
                hit.transform.GetComponent<EnerdyCenter>().Connected();
            }
            else
            {
                Connected = false;
            }
        }
    }
    // hit.transform.GetComponent<MirrorWalls>().SetReflection(hit.point, Vector3.Reflect(r.direction, hit.normal));

    // protected void DistribueteLaser()
    // {
    //     //if (IsOn)
    //    // {
    //         Ray r = new Ray(Origin, Dir);

    //         RaycastHit hit;
    //         if (Physics.Raycast(r, out hit))
    //         {
    //             //var c = (r.origin + r.direction) - 2 * (Vector3.Dot((r.origin + r.direction), hit.normal)) * hit.normal;

    //             Debug.DrawLine(Origin, hit.point, Color.red);
    //             if (hit.transform.GetComponent<IEnergyReciever>() != null)
    //             {

    //                 if (_reciever != null)
    //                 {
    //                     if (_reciever == hit.transform.GetComponent<IEnergyReciever>())
    //                         return;
    //                     else
    //                     {
    //                         _reciever.Disconnected();

    //                     }
    //                 }
    //                 _reciever = hit.transform.GetComponent<IEnergyReciever>();
    //                 _reciever.Connected();
    //                 // if (hit.transform.GetComponent<LaserDistributer>() != null)
    //                 // {
    //                 //     hit.transform.GetComponent<LaserDistributer>().IsOn = true;
    //                 // }
    //                 if (hit.transform.GetComponent<MirrorWalls>())
    //                 {
    //                     hit.transform.GetComponent<MirrorWalls>().SetReflection(hit.point, Vector3.Reflect(r.direction, hit.normal));
    //                 }

    //             }
    //             else
    //             {
    //                 Debug.DrawRay(r.origin, r.direction);

    //             }
    //         }
    //         else
    //         {
    //             if(_reciever!=null)
    //                 _reciever.Disconnected();
    //         }
    //     //}
    // }
    // Update is called once per frame
    void Update()
    {
        //aprint(Powered);

        if (Connected)
        {
            Debug.DrawLine(Origin, Target, Color.red,0.2f);
        }
        else if (Powered)
        {
            Debug.DrawRay(Origin, Dir);
        }



    }
}

