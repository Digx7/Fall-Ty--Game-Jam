using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CardVisualizer : MonoBehaviour
{
    public CardScriptableObject card;

    [SerializeField]
    private TextMeshProUGUI nameText, costText, effectsText, flavorText;
    //public GameObject cardButtonOBJ;
    public Button cardButton;

    public SpriteRenderer cardImageRenderer, cardBoarderRenderer;

    public Player ownerOfCard;
    [SerializeField]
    private Canvas cardCanvas;

    [SerializeField]
    private Camera gameCamera;

    public void Start(){
       gameCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
       //cardButton = cardButtonOBJ.GetComponent<Button>();
       cardCanvas.worldCamera = gameCamera;

       //cardButton.onClick.AddListener(() => testAction());
    }

    public void setOwner(Player owner){
      ownerOfCard = owner;
    }

    public void changeCard(CardScriptableObject _card){
      card = _card;
      nameText.text = card.CardName;
      costText.text = card.CardCost.ToString();
      flavorText.text = card.flavorText;
      cardImageRenderer.sprite = card.cardImage;
      cardBoarderRenderer.sprite = card.cardBoarder;
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

    public void setCardClickable(bool input){
      cardButton.interactable = input;
    }

    public void onCardClicked(){
      ownerOfCard.playCard(card);
    }

    private void testAction(){
      Debug.Log("This Card Was clicked");
    }
}
