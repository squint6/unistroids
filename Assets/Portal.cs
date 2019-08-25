using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal otherPortal;
    public List<Collider2D> ignore = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("here i am");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (ignore.Contains(other)) {
            Debug.Log("Ignorng: " + other);
            ignore.Remove(other);
        } else {
            GameObject go = other.gameObject.transform.parent.gameObject;
            Debug.Log("Entered portal " + gameObject + " - " + go);

            var relPos = transform.position - go.transform.position;
            var newPos = relPos + otherPortal.transform.position;
            Debug.Log("Pos: " + go.transform.position + " - " + relPos + " - " + newPos);
            go.transform.position = newPos;
            otherPortal.ignore.Add(other);
        }


    }
}
