using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Gust : TimedSpells
{
    [SerializeField] private GameObject GustPrefab;
    //[SerializeField] private float spikeAOE;
    //[SerializeField] private float spikeRadius;

    // Start is called before the first frame update
    void Start()
    {
        //spikeRadius = 10f;
        Cooldown = 1f;
        Speed = 5f;
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

        GameObject gust = Instantiate(GustPrefab, transform.position , transform.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = gust.GetComponent<Rigidbody2D>();

        rb.velocity = transform.up * Speed;

        //rb.transform.localScale = new Vector2(2, 2);

    }
}
