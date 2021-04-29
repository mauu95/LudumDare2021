using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : Movement {
    public enum EnemyState{
        CHILLED,
        SCARED,
        TRIGGERED
    }
    public float speed;
    public float rotatioSpeed = 1f;
    protected Vector3 target;
    protected GameObject player;
    public EnemyState state = EnemyState.CHILLED;

    protected override void Start() {
        base.Start();
        player = Player.instance.gameObject;
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
    }

    protected void SetTaget() {
        if(target==null)
            target = GetRandomTarget();

        switch(state){
            case EnemyState.CHILLED:
                if(Mathf.Abs((transform.position - target).magnitude) < 0.1f)
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
    }

    protected Vector2 GetRandomTarget() {
        Vector2 randPos = Random.insideUnitCircle;
        randPos += randPos.normalized * 20;
        target = transform.position + new Vector3(randPos.x, randPos.y);
        if (target.y > 0) 
            target.y = -target.y;
        return target;
    }

    public void SetState(EnemyState state){
        this.state = state;
    }

    public void SetState(EnemyState state, float time){
        this.state = state;
        StartCoroutine(SetStateIn(EnemyState.CHILLED, time));
    }

    private IEnumerator SetStateIn(EnemyState state, float time){
        yield return new WaitForSeconds(time);
        this.state = state;
    }

}
