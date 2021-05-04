using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintUI : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    private Animator anim;

    public static HintUI instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    private void Start() {
        anim = hintText.GetComponent<Animator>();
        GiveHint("MOVE -> Mouse", 3f);
        GiveHint("Deep is Dark", 6f);
        GiveHint("Deep is Dangerous", 9f);
        GiveHint("Eat some fish easy first", 14f);
        GiveHint("and then...", 17f);
        GiveHint("Go DEEPER & DEEPER", 21f);
    }
    public void SetText(string text){
        hintText.text = text;
        anim.Play(0);
    }

    public void GiveHint(string text, float time){
        StartCoroutine(GiveHintCoroutine(text, time));
    }

    private IEnumerator GiveHintCoroutine(string text, float time){
        yield return new WaitForSeconds(time);
        SetText(text);
    }
}
