using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement: MonoBehaviour {
  public float speed;

  private Vector3 target;
  // Start is called before the first frame update
  void Start() {
    target = Random.insideUnitCircle * 10;
  }

  // Update is called once per frame
  void Update() {
    var direction = (target - transform.position).normalized;
    transform.position = transform.position + direction * Time.deltaTime * speed;
    if ((target - transform.position).magnitude < 0.5) {
      target = Random.insideUnitCircle * 10;
    }
  }

}
