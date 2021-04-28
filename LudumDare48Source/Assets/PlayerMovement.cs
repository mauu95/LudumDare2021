using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {

    public float speed;

    protected override void Update() {
        base.Update();
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            DashToward(worldPosition);
        }
    }

    private void DashToward(Vector3 position) {
        Vector3 direction = position - transform.position;

        if(transform.position.y<0)
            rb.velocity = direction.normalized * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Bump(Vector2 velocity) {
        rb.velocity = rb.velocity + velocity;
    }

}
