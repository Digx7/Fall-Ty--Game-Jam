using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    public void addCardToHand(CardScriptableObject card, Player owner){
      if(card != null){
        cardsInHand.Add(card);
        cardDispayer.addCardToBeDisplayed(card, owner);

      }
    }

    public CardScriptableObject removeCardFromHand(int index){
      Debug.Log("Card is now leaving the hand");

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
        Debug.Log("This card is being played");

        return removeCardFromHand(index);
      }else{
        Debug.Log("That card can't be played");
        return null;
      }
    }

    public bool isCardInHand(CardScriptableObject card){
      for(int i =0; i < cardsInHand.Count; ++i){
        if(cardsInHand[i] == card) return true;
      }
      return false;
    }

    public int findIndexOfCardInHand(CardScriptableObject card){
      for(int i =0; i < cardsInHand.Count; ++i){
        if(cardsInHand[i] == card) return i;
      }
      return 100;
    }
}
