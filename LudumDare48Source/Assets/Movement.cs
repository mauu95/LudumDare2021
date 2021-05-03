using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected Rigidbody2D rb;
    public float bumpForce = 1f;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update() {
        if(transform.position.y>0)
            rb.AddForce(Vector2.down * rb.mass * 50);
    }

    public virtual void Bump(Vector3 velocity) {
        rb.AddForce(velocity*bumpForce);
    }

}
