using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctaShield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ship") {
            Ship s = other.gameObject.GetComponentInParent<Ship>();
            s.ParkInShield(this);
        }

    }

}
