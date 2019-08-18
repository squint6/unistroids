using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctaWallTrigger : MonoBehaviour
{
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
        Debug.Log("OW Trigger enter. This object =  " + gameObject + ". Other object = " + other.gameObject);
        OctaWall ow = gameObject.GetComponentInParent<OctaWall>();
        Destroy(ow.gameObject);
    }

}
