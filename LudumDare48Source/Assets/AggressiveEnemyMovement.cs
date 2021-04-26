using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveEnemyMovement : EnemyMovement {
    private bool m_FacingRight = true;

    public override void Update() {
        // movement
        var targetPosition = GetTagetPosition();
        var direction = (targetPosition - transform.position).normalized;
        transform.position = transform.position + direction * Time.deltaTime * speed;

        // rotation
        if (direction.x > 0 && !m_FacingRight) {
            Flip();
        } else if (direction.x < 0 && m_FacingRight) {
            Flip();
        }

        // check if it reached destination
        if (!isAggred && (base.target - transform.position).magnitude < 0.5) {
            GoToNewTarget();
        }

        // check if it got too far from player
        if ((transform.position - player.transform.position).magnitude >= maxDistanceFromPlayer) {
            ResetPosition();
        }
    }

    public override void Bump(Vector3 velocity) {
        rb.velocity = 5 * velocity;
    }


    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && !base.isAggred) {
            MobManager.instance.AddAggroTo(gameObject);
        }
    }

}
