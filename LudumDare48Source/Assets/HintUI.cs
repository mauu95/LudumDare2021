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
    }
    public void SetText(string text){
        hintText.text = text;
        anim.Play(0);
    }
}
