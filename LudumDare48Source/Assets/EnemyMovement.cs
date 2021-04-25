using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed;
    public float maxDistanceFromPlayer = 100;


    private Rigidbody2D rb;
    private Vector3 target;
    private GameObject player;
    private bool isAggred = false;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = PlayerMovement.instance.gameObject;
        Reset();
    }

    // Update is called once per frame
    void Update() {
        var targetPosition = GetTagetPosition();
        var direction = (targetPosition - transform.position).normalized;
        transform.position = transform.position + direction * Time.deltaTime * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (!isAggred && (target - transform.position).magnitude < 0.5) {
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
    }

    Vector3 GetTagetPosition() {
        if (isAggred) {
            return player.transform.position;
        }
        return target;
    }

    void GoToNewTarget() {
        if (!isAggred) {
            Vector2 diff = Random.insideUnitCircle * 10;
            target = transform.position + new Vector3(diff.x, diff.y);
        }
    }

    public void Bump(Vector3 velocity) {
        rb.velocity = 3 * velocity;
    }

    public void RemoveAggro() {
        if (isAggred) {
            isAggred = false;
            GoToNewTarget();
            var sr = GetComponent<SpriteRenderer>();
            sr.color = Color.white;
        }
    }

    public void AddAggro() {
        isAggred = true;
        var sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
    }

}
