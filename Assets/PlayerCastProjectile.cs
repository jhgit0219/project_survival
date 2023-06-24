using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bulletPrefab;        // Prefab of the bullet object
    public Transform firePoint;            // Transform representing the bullet spawn point
    public float bulletSpeed = 1f;        // Speed at which the bullet moves
    public float bulletCooldown = 0.5f;
    private float timeElapsed;

    public float spiralRadius = 1f;          // Radius of the spiral path
    public float spiralSpeed = 1f;


    


    // Update is called once per frame

    private void Start()
    {
        Shoot();

    }
    private void Update()
    {
        

        if (timeElapsed > bulletCooldown)
        {
            Shoot();
            //angle = (1+angle) % 360 ;

            timeElapsed = 0f;
        }
        
        timeElapsed += Time.deltaTime;
    }

    

    private void Shoot()
    {
        // Instantiate a new bullet object
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply velocity to the bullet in the direction of the fire point
        rb.velocity = firePoint.up * bulletSpeed;

        // Set the bullet's spiral movement
        BulletScript spiralBullet = bullet.GetComponent<BulletScript>();
        //spiralBullet.SetSpiralParameters(spiralRadius, spiralSpeed);
        
    }
}
