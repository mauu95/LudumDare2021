using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject[] cards;
    public void EnableAllCards() {
        foreach(GameObject card in cards){
            card.SetActive(true);
        }
    }
}
