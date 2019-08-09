using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet1 : MonoBehaviour
{
    public float lifetime = 200.0f;
    public float bulletSpeed = 2.0F;
    public static int maxNumBullets = 6;
    public static int numBullets;

    private float deathTime;

    private float degRad = (float)(2.0 * Math.PI / 360.0);
    private bool eternal = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init(Vector3 shipVel, float shipAngle)
    {
        shipAngle *= degRad;
        float dx = -(float)Math.Sin(shipAngle);
        float dy = (float)Math.Cos(shipAngle);
        Vector3 vv = new Vector3(dx, dy, 0);

        deathTime = Time.time + lifetime;

        eternal = false;
        Rigidbody2D orb = GetComponent<Rigidbody2D>();
        orb.velocity = shipVel + vv * bulletSpeed;
        numBullets++;
    }

    void OnDestroy()
    {
        numBullets--;
    }
    // Update is called once per frame
    void Update()
    {
        if (!eternal && (Time.time > deathTime))
        {
            Destroy(gameObject);
        }
    }

}
