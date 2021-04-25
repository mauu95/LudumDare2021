using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyFader : MonoBehaviour {
    public float timeToFade = 5;
    private float elapsedTime = 0;
    private SpriteRenderer[] spriteRenderers;
    private void Start() {
        spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update() {
        elapsedTime += Time.deltaTime;
        foreach (var sr in spriteRenderers) {
            var color = sr.color;
            color.a = 1 - (elapsedTime / timeToFade);
            sr.color = color;
        }
        if (elapsedTime > timeToFade) Destroy(gameObject);
    }
}
