using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {

  public float speed;

  private Rigidbody2D rb;
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

  private void DashToward(Vector3 position){
    Vector3 current = transform.position;
    Vector3 target = position;

    Vector3 direction = target - current;
    rb.velocity = direction.normalized * speed;
  }
}
