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

    private OctaShield shield;
    private Rigidbody2D shieldRB;
    private FixedJoint2D shieldFJ;
    private bool startParking = false;
    private bool finishParking = false;


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

    public void ParkInShield(OctaShield shield) {

        shieldRB = shield.GetComponent<Rigidbody2D>();
        this.shield = shield;
        shieldRB.mass = .01F;
        startParking = true;
    }

    public void StartParking () {

        rb.position = shieldRB.position;
        shield.gameObject.transform.Rotate(0,0,180.0F,Space.World);
        startParking = false;
        finishParking = true;
    }

    public void FinishParking() {
        gameObject.AddComponent<FixedJoint2D>();
        shieldFJ = gameObject.GetComponent<FixedJoint2D>();
        shieldFJ.connectedBody = shieldRB;
        finishParking = false;

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

        if (startParking) {
            StartParking();
        } else if (finishParking) {
            FinishParking();
        }
    }




}
