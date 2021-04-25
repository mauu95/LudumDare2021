using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed;
    public GameObject player;
    public float maxDistanceFromPlayer = 100;


    private Rigidbody2D rb;
    private Vector3 target;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        Reset();
    }

    // Update is called once per frame
    void Update() {
        var direction = (target - transform.position).normalized;
        transform.position = transform.position + direction * Time.deltaTime * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if ((target - transform.position).magnitude < 0.5) {
            GoToNewTarget();
        }
        if ((transform.position - player.transform.position).magnitude >= maxDistanceFromPlayer) {
            Reset();
        }
    }

    public void Die() {
        // TODO: spawn meat or stuff for the player to eat
        FindObjectOfType<Shop>().addMoney();
        Reset();
    }

    public void Reset() {
        rb.velocity = Vector3.zero;
        SelfPositionAroundPlayer();
        GoToNewTarget();
    }

    void SelfPositionAroundPlayer() {
        var randomPosition = Random.insideUnitCircle * 50;
        var playerPos = player.transform.position;
        var position = new Vector3(playerPos.x + randomPosition.x, playerPos.y + randomPosition.y);
        if ((position - playerPos).magnitude < 20) {
            var vector = (position - playerPos).normalized * 20;
            position += vector;
        }
        transform.position = position;
        //enemies.Add(Instantiate(enemyPrefab, position, Quaternion.identity, enemyContainer.transform));
    }

    void GoToNewTarget() {
        Vector2 diff = Random.insideUnitCircle * 10;
        target = transform.position + new Vector3(diff.x, diff.y);
    }

    public void Bump(Vector3 velocity) {
        rb.velocity = 3 * velocity;
    }

}
