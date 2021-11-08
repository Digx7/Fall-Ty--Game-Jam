using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoadCard : MonoBehaviour
{
    public CardVisualizer physicalCard;
    public CardScriptableObject cardData;

    public void Start(){
      physicalCard.changeCard(cardData);
    }
}
