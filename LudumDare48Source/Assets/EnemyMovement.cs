using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : Movement {
    public enum EnemyState{
        CHILLED,
        SCARED,
        TRIGGERED
    }
    private float speed;
    public float chilledSpeed = 1f;
    public float scaredSpeed = 1f;
    public float triggeredSpeed = 1f;
    public float rotatioSpeed = 1f;
    protected Vector3 target;
    protected GameObject player;
    public EnemyState state;
    public Transform gfx;
    private bool m_FacingRight = true;

    protected override void Start() {
        base.Start();
        player = Player.instance.gameObject;
        SetState(EnemyState.CHILLED);
        target = GetRandomTarget();
    }

    protected override void Update() {
        base.Update();
        SetTaget();
        Vector3 direction = (target - transform.position).normalized;
        rb.AddForce(direction*speed);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = transform.rotation.eulerAngles.z;
        float theAngle = Mathf.LerpAngle(currentAngle, angle, Time.deltaTime * rotatioSpeed);

        transform.rotation = Quaternion.AngleAxis(theAngle, Vector3.forward);

        float move = direction.x;
        if (move > 0 && !m_FacingRight)
            Flip();
        else if (move < 0 && m_FacingRight)
            Flip();
    }

    protected virtual void OnCollisionEnter2D(Collision2D other) {
        
    }

    protected void SetTaget() {
        if(target==null)
            target = GetRandomTarget();
        
        if (target.y > 0) 
            target.y = -target.y;

        switch(state){
            case EnemyState.CHILLED:
                if(Mathf.Abs((transform.position - target).magnitude) < 1f)
                    target = GetRandomTarget();
                break;
            case EnemyState.TRIGGERED:
                target = player.transform.position;
                break;
            case EnemyState.SCARED:
                target = transform.position + transform.position - player.transform.position;
                break;
            default:
                Debug.LogError("Unhandled Enemy behaviour: " + state);
                break;
        }
        if (target.y > 0) 
            target.y = -target.y;

    }

    protected Vector2 GetRandomTarget() {
        Vector2 randPos = Random.insideUnitCircle;
        randPos += randPos.normalized * 20;
        target = transform.position + new Vector3(randPos.x, randPos.y);
        return target;
    }

    public void SetState(EnemyState state){
        switch(state){
            case EnemyState.CHILLED:
                speed = chilledSpeed;
                break;
            case EnemyState.TRIGGERED:
                speed = triggeredSpeed;
                break;
            case EnemyState.SCARED:
                speed = scaredSpeed;
                break;
            default:
                Debug.LogError("Unhandled Enemy behaviour: " + state);
                break;
        }
        this.state = state;
    }

    public void SetState(EnemyState state, float time){
        SetState(state);
        StartCoroutine(SetStateIn(EnemyState.CHILLED, time));
    }

    private IEnumerator SetStateIn(EnemyState state, float time){
        yield return new WaitForSeconds(time);
        SetState(state);
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        gfx.Rotate(180f, 0f, 0f);
    }

}
