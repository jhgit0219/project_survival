using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spike : SpellObject
{
    // Start is called before the first frame update
    void Start()
    {
        Duration = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        SpellCountdown();
        ShrinkSpike();
    }

    void ShrinkSpike()
    {
        transform.localScale -= new Vector3(Time.deltaTime * 0.1f, Time.deltaTime * 0.1f);
    }
}
