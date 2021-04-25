using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card : MonoBehaviour {
    protected Button button;

    private void Start() {
        button = GetComponent<Button>();
    }
}
