using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletScript : MonoBehaviour
{
    public GameObject bulletPrefab;        // Prefab of the bullet object
    public Transform firePoint;            // Transform representing the bullet spawn point
    public float bulletSpeed = 10f;        // Speed at which the bullet moves

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Change "Fire1" to the appropriate button or key for shooting
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate a new bullet object
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply velocity to the bullet in the direction of the fire point
        rb.velocity = firePoint.up * bulletSpeed;
    }
}
