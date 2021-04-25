using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed;
    public float rotatioSpeed = 1f;
    public float maxDistanceFromPlayer = 100;


    protected Rigidbody2D rb;
    protected Vector3 target;
    protected GameObject player;
    protected bool isAggred = false;

    // Start is called before the first frame update
    public virtual void Start() {
        rb = GetComponent<Rigidbody2D>();
        player = PlayerMovement.instance.gameObject;
        Reset();
    }

    // Update is called once per frame
    public virtual void Update() {
        var targetPosition = GetTagetPosition();
        var direction = (targetPosition - transform.position).normalized;
        transform.position = transform.position + direction * Time.deltaTime * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = transform.rotation.eulerAngles.z;
        float theAngle = Mathf.LerpAngle(currentAngle, angle, Time.deltaTime * rotatioSpeed);

        transform.rotation = Quaternion.AngleAxis(theAngle, Vector3.forward);

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

    protected void SelfPositionAroundPlayer() {
        var randomPosition = Random.insideUnitCircle * 50;
        var playerPos = player.transform.position;
        var position = new Vector3(playerPos.x + randomPosition.x, playerPos.y + randomPosition.y);
        if ((position - playerPos).magnitude < 20) {
            var vector = (position - playerPos).normalized * 20;
            position += vector;
        }
        if (position.y > 0)
            position.y = -position.y;
        transform.position = position;
    }

    protected Vector3 GetTagetPosition() {
        if (isAggred) {
            return player.transform.position;
        }
        return target;
    }

    protected void GoToNewTarget() {
        if (!isAggred) {
            Vector2 diff = Random.insideUnitCircle * 10;
            target = transform.position + new Vector3(diff.x, diff.y);
            if (target.y > 0) {
                target.y = -target.y;
            }
        }
    }

    public void Bump(Vector3 velocity) {
        rb.velocity = 3 * velocity;
    }

    public void RemoveAggro() {
        if (isAggred) {
            isAggred = false;
            GoToNewTarget();
        }
    }

    public void AddAggro() {
        isAggred = true;
    }

}
