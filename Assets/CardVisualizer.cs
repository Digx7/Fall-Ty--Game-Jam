using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardVisualizer : MonoBehaviour
{
    public CardScriptableObject card;

    [SerializeField]
    private TextMeshProUGUI nameText, costText, effectsText, flavorText;

    public void changeCard(CardScriptableObject _card){
      card = _card;
      nameText.text = card.CardName;
      costText.text = card.CardCost.ToString();
      flavorText.text = card.flavorText;
      /*if(card is PerminateScriptableObject){
        effectsText.text = (PerminateScriptableObject)card.perminateText;
      }
      else if(card is ChampionsScriptableObject){
        effectsText.text = (ChampionsScriptableObject)card.championText;
      }
      else if(card is EffectsScriptableObject){
        effectsText.text = (EffectsScriptableObject)card.effectText;
      }*/
    }
}
