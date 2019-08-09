using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    void OnTriggerEnter2D(Collider2D other)
    {
        // do i really have to go through transform to get parent?
        Destroy(transform.parent.gameObject);
    }
}
