using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Android.Types;
using UnityEngine;

public class Spell_Ray : TimedSpells
{
    [SerializeField] private GameObject RayPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Cooldown = .1f;
        Duration = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
        gameObject.transform.Rotate(new Vector3(0,0,10*Time.deltaTime));

    }

    protected override void CastSpell()
    {
        Vector2 currentPosition = gameObject.transform.position;

        GameObject Ray = Instantiate(RayPrefab, (Random.insideUnitCircle.normalized +  currentPosition), transform.rotation);
        
        Ray.transform.parent = gameObject.transform;

     }


}
