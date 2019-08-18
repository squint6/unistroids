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
        if (other.gameObject.tag == "OctaShield") {
            Debug.Log("Hit octa shield. Docking!");
            Ship s = gameObject.GetComponentInParent<Ship>();
            s.ParkInShield(other.gameObject.GetComponentInParent<OctaShield>());
        } else {
            Destroy(transform.parent.gameObject);
        }

    }
}
