using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Object : SpellObject
{
    // Start is called before the first frame update
    void Start()
    {
        Duration = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        SpellCountdown();
        ExpandPool();
    }

    void ExpandPool()
    {
        transform.localScale += new Vector3(Time.deltaTime * 0.1f, Time.deltaTime * 0.1f);
    }
}
