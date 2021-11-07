using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<CardScriptableObject> cardsInHand;
    public CardDisplayer cardDispayer;

    public void addCardToHand(CardScriptableObject card){
      if(card != null){
        cardsInHand.Add(card);
        cardDispayer.addCardToBeDisplayed(card);
      }
    }

    public CardScriptableObject removeCardFromHand(int index){
      CardScriptableObject card = cardsInHand[index];

      cardsInHand.RemoveAt(index);
      cardDispayer.removeCardFromBeingDisplayed(index);

      return card;
    }

    public CardScriptableObject[] removeAllCardsFromHand(){
      CardScriptableObject[] hand = cardsInHand.ToArray();

      cardsInHand.Clear();
      cardDispayer.removeALLCardsFromBeingDisplayed();

      return hand;
    }

    public bool canPlayCard(int cardIndex, int manaAvailable){
      if(cardsInHand[cardIndex].CardCost <= manaAvailable) return true;
      else return false;
    }

    public CardScriptableObject playCard(int index, int manaAvailable){
      if(canPlayCard(index,manaAvailable)){
        return removeCardFromHand(index);
      }else{
        Debug.Log("That card can't be played");
        return null;
      }
    }
}
