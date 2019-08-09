using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AstSize { Large, Medium, Small};

public class Ast : MonoBehaviour
{

    public static float explosionVelocity = 3.0F;
    public AstSize size = AstSize.Large;

    private Vector3 LargeScale = new Vector3(1.0F, 1.0F, 1.0F);
    private Vector3 MediumScale = new Vector3(.75F, .75F, .75F);
    private Vector3 SmallScale = new Vector3(.5F, .5F, .5F);

    private Rigidbody2D rigidBody;
	
	public GameObject contents;

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


    private Ast createChildAst(AstSize size, GameObject contents)
    {
        Debug.Log("Creating new ast");
        Vector3 pos = transform.position;
        Vector3 vel = GetComponent<Rigidbody2D>().velocity;
        Ast a = Instantiate(this, pos, Quaternion.identity);
        Vector3 rv = RandVel();
         a.Init(size, pos + LargeScale * 0.0F, vel + rv);
        a.gameObject.tag = "Ast";
		a.contents = contents;
		return a;

    }

    public void Collision()
    {
        switch (size)
        {
            case AstSize.Large:
                createChildAst(AstSize.Medium, null);
                createChildAst(AstSize.Medium, this.contents);
                Destroy(gameObject);
                break;
            case AstSize.Medium:
                createChildAst(AstSize.Small, null);
                Ast a = createChildAst(AstSize.Small, this.contents);
                Destroy(gameObject);
                break;
            case AstSize.Small:
			if (this.contents) {
			    this.contents.transform.position = transform.position;
				Rigidbody2D rb = GetComponent<Rigidbody2D>();
				Rigidbody2D contRb = contents.GetComponent<Rigidbody2D>();
				contRb.velocity = rb.velocity;
			}
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
