using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Gust : SpellObject
{
    // Start is called before the first frame update
    void Start()
    {
        Duration = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        SpellCountdown();
        PushGust();
    }

    private void PushGust()
    {
        transform.localScale += new Vector3(Time.deltaTime * 5f, Time.deltaTime * 5f);
    }
}
