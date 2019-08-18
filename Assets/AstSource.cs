using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstSource : MonoBehaviour {
    public float period = 4.0F;
    public Ast astPf;

    public GameObject[] contents;
    private int nextContentIndex = 0;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("CreateAst", 1.0F, period);

    }

    void CreateAst() {
        Ast ast = Instantiate(astPf, transform.position, Quaternion.identity);
        if (nextContentIndex < contents.Length && Random.value > 0.5) {
            ast.contents = contents[nextContentIndex];
            nextContentIndex++;
        }
        ast.Init(AstSize.Large, transform.position, Ast.RandVel());
    }

    // Update is called once per frame
    void Update() {

    }
}
