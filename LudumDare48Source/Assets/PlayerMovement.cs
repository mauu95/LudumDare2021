using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement {

    public float speed;
    public float stunTime = 1f;
    private bool isStunned;

    protected override void Update() {
        base.Update();
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
            DashToward(worldPosition);
        }
    }

    private void DashToward(Vector3 position) {
        Vector3 direction = position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(transform.position.y<0 && !isStunned)
            rb.velocity = direction.normalized * speed;
    }

    public override void Bump(Vector3 velocity){
        StartCoroutine(Stun(stunTime));
        rb.AddForce(velocity*bumpForce);
    }

    private IEnumerator Stun(float time){
        isStunned = true;
        yield return new WaitForSeconds(time);
        isStunned = false;
    }

}
