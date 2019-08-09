using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initialzing...");
        Ast[] asts = FindObjectsOfType<Ast>();
        foreach (Ast ast in asts)
        {
            Debug.Log("Initializing ast: ", ast);
            Rigidbody2D rigidBody = ast.GetComponent<Rigidbody2D>();
            rigidBody.velocity = Ast.RandVel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
