using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSource : MonoBehaviour    
{
    public float period = 4.0F;
    public Ast astPf;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateAst", 1.0F, period);

    }

    void CreateAst()
    {
        Debug.Log("In CreateAst");
        Ast ast = Instantiate(astPf, transform.position, Quaternion.identity);
        ast.Init(AstSize.Large, transform.position, Ast.RandVel());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
