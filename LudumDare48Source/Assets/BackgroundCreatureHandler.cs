using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCreatureHandler : MonoBehaviour {
    public float movementSpeed = 0.5f;
    public float maxDistanceFromPlayer = 50;

    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private float customAlphaSeed;
    private Vector3 target;

    // Start is called before the first frame update
    void Start() {
        player = PlayerMovement.instance.gameObject;
        SelfPositionAroundPlayer(true);
        spriteRenderer = GetComponent<SpriteRenderer>();
        customAlphaSeed = Random.value * 20;
    }

    // Update is called once per frame
    void Update() {
        // change alpha 
        var c = spriteRenderer.color;
        c.a = 0.3f + Mathf.Sin(Time.timeSinceLevelLoad + customAlphaSeed) / 10;
        spriteRenderer.color = c;

        // change position
        var direction = (target - transform.position).normalized;
        transform.position = transform.position + direction * Time.deltaTime * movementSpeed;


        if ((target - transform.position).magnitude < 0.5) {
            GoToNewTarget();
        }
        if ((transform.position - player.transform.position).magnitude >= maxDistanceFromPlayer) {
            Reset();
        }
    }

    public void Reset() {
        SelfPositionAroundPlayer(false);
        GoToNewTarget();
    }

    public void SelfPositionAroundPlayer(bool initialSpawn) {
        var randomPosition = Random.insideUnitCircle * 50;
        var playerPos = player.transform.position;
        var position = new Vector3(playerPos.x + randomPosition.x, playerPos.y + randomPosition.y);
        if (!initialSpawn && (position - playerPos).magnitude < 20) {
            var vector = (position - playerPos).normalized * 20;
            position += vector;
        }
        transform.position = position;
    }

    void GoToNewTarget() {
        Vector2 diff = Random.insideUnitCircle * 10;
        target = transform.position + new Vector3(diff.x, diff.y);
    }


}
