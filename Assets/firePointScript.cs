using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class firePointScript : MonoBehaviour
{

    //public GameObject firePoint;
    public float rotationSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        ChangeDirection();
        
       

        //transform.Rotate(0, 50 * Time.deltaTime, 0);
        //float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;

        //timeElapsed += Time.deltaTime;


    }

    private void ChangeDirection()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
