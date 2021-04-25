using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;
    public static PlayerMovement instance;

    private void Awake() {
        if (instance) Destroy(gameObject);
        instance = this;
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            DashToward(worldPosition);
        }
    }

    private void DashToward(Vector3 position) {
        Vector3 direction = position - transform.position;
        rb.velocity = direction.normalized * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Bump(Vector2 velocity) {
        rb.velocity = rb.velocity + velocity;
    }

}
