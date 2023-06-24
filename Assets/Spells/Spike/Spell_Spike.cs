using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Spike : TimedSpells
{
    [SerializeField] private GameObject SpikePrefab;
    [SerializeField] private float spikeAOE;
    [SerializeField] private float spikeRadius;

    // Start is called before the first frame update
    void Start()
    {
        spikeRadius = 10f;
        Cooldown = 0.5f;
        //Speed = 3f;
        CastSpell();
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    protected override void CastSpell()
    {
        //throw new System.NotImplementedException();

        GameObject spike = Instantiate(SpikePrefab, Random.insideUnitCircle * spikeAOE, transform.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = spike.GetComponent<Rigidbody2D>();

        rb.transform.localScale = new Vector2(2, 2);

    }

}
