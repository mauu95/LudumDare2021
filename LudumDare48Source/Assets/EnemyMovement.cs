using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed;

    private Vector3 target;
    // Start is called before the first frame update
    void Start() {
        Vector2 diff = Random.insideUnitCircle * 10;
        target = transform.position + new Vector3(diff.x, diff.y);
    }

    // Update is called once per frame
    void Update() {
        var direction = (target - transform.position).normalized;
        transform.position = transform.position + direction * Time.deltaTime * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if ((target - transform.position).magnitude < 0.5) {
            Vector2 diff = Random.insideUnitCircle * 10;
            target = transform.position + new Vector3(diff.x, diff.y);
        }
    }

}
