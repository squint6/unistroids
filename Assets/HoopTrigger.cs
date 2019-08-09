using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Trigger enter. This object =  " + gameObject + ". Other object = " + other.gameObject);
		Debug.Log("Trigger enter. This object Tag =  " + gameObject.tag + ". Other object Tag = " + other.gameObject.tag);
		if (other.gameObject.tag == "BouncyBall") {
			Destroy(other.gameObject);
		}


	}
}
