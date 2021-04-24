using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour {
  // Start is called before the first frame update
  public float speed;
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    if (Input.GetButtonDown("Fire1")) {
      Vector3 mousePos = Input.mousePosition;
      mousePos.z = Camera.main.nearClipPlane;
      Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
      Debug.Log(worldPosition.x + "," + worldPosition.y);
    }
  }
}
