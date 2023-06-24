using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Pool : TimedSpells
{
    [SerializeField] private GameObject PoolPrefab;
   //[SerializeField] private new float ElapsedTime;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Cooldown = 5f;
        Speed = 3f;
        CastSpell();
    }

    // Update is called once per frame
    void Update()
    {
        Countdown();
    }

    /*protected override void Countdown()
    {
        //throw new System.NotImplementedException();

        C

        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > Cooldown)
        {
            ElapsedTime = 0;
            CastSpell();
        }
    }*/

    protected override void CastSpell()
    {
        // Instantiate a new bullet object
        GameObject pool = Instantiate(PoolPrefab, transform.position, transform.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = pool.GetComponent<Rigidbody2D>();

        // Apply velocity to the bullet in the direction of the fire point
        rb.velocity = rb.velocity * 0;

        // Set the bullet's spiral movement
        //BulletScript spiralBullet = fireball.GetComponent<BulletScript>();
        //spiralBullet.SetSpiralParameters(spiralRadius, spiralSpeed);
    }
}
