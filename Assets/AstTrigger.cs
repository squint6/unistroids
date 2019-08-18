using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstTrigger : MonoBehaviour
{
    public Ast astPf;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ast" || other.gameObject.tag == "OctaWall")
        {
            Debug.Log("Not handling trigger!");
            return;
        }
        Ast a = gameObject.GetComponentInParent<Ast>();

        a.Collision();
    }
}
