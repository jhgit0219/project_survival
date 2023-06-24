using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Projectile : SpellObject
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
    }

}
