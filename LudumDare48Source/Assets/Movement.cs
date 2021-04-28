using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update() {
        if(transform.position.y>0)
            rb.gravityScale = 1;
        else
            rb.gravityScale = 0;
    }

    public virtual void Bump(Vector3 velocity) {
        rb.velocity = velocity;
    }


}
