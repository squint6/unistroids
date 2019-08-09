using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
    public float thrust = 1.0F;
    public float rotationSpeed = 0.3F;
    private Rigidbody2D rb;
    
    private GameObject firePoint;
    public Bullet1 bulletPf;
    public int age;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting....");
        rb = GetComponent<Rigidbody2D>();
        firePoint = rb.transform.GetChild(2).gameObject;
    }

    void FireBullet()
    {
        if (Bullet1.numBullets < Bullet1.maxNumBullets)
        {
            Vector3 v = rb.velocity;
            float r = transform.eulerAngles.z;
            Bullet1 b = Instantiate(bulletPf, firePoint.transform.position, Quaternion.identity);
            b.Init(v,r);
        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("j")) {
            rb.AddForce(transform.up * thrust);
        }

        if (Input.GetKeyDown("l"))
        {
            FireBullet();
        }

        float rot = Input.GetAxis("Horizontal") * rotationSpeed;
        rb.AddTorque(-rot);
       
    }

  

    
}
