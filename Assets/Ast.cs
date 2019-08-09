using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AstSize { Large, Medium, Small};

public class Ast : MonoBehaviour
{

    public static float explosionVelocity = 1.0F;
    public AstSize size = AstSize.Large;

    private Vector3 LargeScale = new Vector3(1.0F, 1.0F, 1.0F);
    private Vector3 MediumScale = new Vector3(.75F, .75F, .75F);
    private Vector3 SmallScale = new Vector3(.5F, .5F, .5F);

    private Rigidbody2D rigidBody;

    private Vector3 sizeScale(AstSize size)
    {
        switch (size) {
            case AstSize.Large:
                return LargeScale;
            case AstSize.Medium:
                return MediumScale;
            case AstSize.Small:
                return SmallScale;
            default:
                return SmallScale;
        }
    }

    public void Init(AstSize size, Vector3 position, Vector3 velocity)
    {
        this.size = size;
        transform.position = position;
        transform.localScale = sizeScale(size);
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = velocity;
    }

    public static Vector3 RandVel()
    {
        return new Vector3(Random.value * explosionVelocity - explosionVelocity/2.0F, Random.value * explosionVelocity - explosionVelocity/2.0F, 0);
    }


    private void createChildAst(AstSize size)
    {
        Debug.Log("Creating new ast");
        Vector3 pos = transform.position;
        Vector3 vel = GetComponent<Rigidbody2D>().velocity;
        Ast a = Instantiate(this, pos, Quaternion.identity);
        Vector3 rv = RandVel();
         a.Init(size, pos + LargeScale * 0.0F, vel + rv);
        a.gameObject.tag = "Ast";
        //Rigidbody2D rb = a.GetComponent<Rigidbody2D>();
       // rb.velocity = vel + RandVel();

    }

    public void Collision()
    {
        switch (size)
        {
            case AstSize.Large:
                createChildAst(AstSize.Medium);
                createChildAst(AstSize.Medium);
                Destroy(gameObject);
                //this.size = AstSize.Medium;
                //transform.localScale = sizeScale(this.size);
               // rigidBody.velocity = rigidBody.velocity + RandVel();
                break;
            case AstSize.Medium:
                createChildAst(AstSize.Small);
                createChildAst(AstSize.Small);
                Destroy(gameObject);
                //this.size = AstSize.Small;
                //transform.localScale = sizeScale(this.size);
                break;
            case AstSize.Small:
                Destroy(gameObject);
                break;
        }
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
