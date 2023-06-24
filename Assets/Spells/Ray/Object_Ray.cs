using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Object_Ray : SpellObject
{
    //public GameObject RayCenter;
    // Start is called before the first frame update
    void Start()
    {
        Duration = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        SpellCountdown();
        //RevolveRay();
    }

    private void RevolveRay()
    {
        //transform.RotateAround(RayCenter.transform.localPosition, new Vector3(0,0,1), Time.deltaTime * 100);
    }
}
