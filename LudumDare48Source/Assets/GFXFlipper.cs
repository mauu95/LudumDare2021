using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFXFlipper : MonoBehaviour
{
    Rigidbody2D rigBody;
    private bool m_FacingRight = true;

    private void Start() {
        if(rigBody == null)
            rigBody = GetComponent<Rigidbody2D>();
        if(rigBody == null)
            rigBody = GetComponentInParent<Rigidbody2D>();
    }

    private void Update() {
        float move = rigBody.velocity.x;
        if (move > 0 && !m_FacingRight)
            Flip();
        else if (move < 0 && m_FacingRight)
            Flip();
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(180f, 0f, 0f);
    }
}
