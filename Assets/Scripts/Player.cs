using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Deck library, discardPile;

    public int manaMax, manaCurrent, ultMax, ultCurrent;

    public CardScriptableObject[] startingDeck;

    public Hand playerHand;
    public int handSize;
    public Feild playerFeild;
    public UnityEvent turnEnd;
    //public Deck tempFeild;

    public void setUpLibrary(){
      for(int i = 0; i < startingDeck.Length; i++){
        library.AddCardToBottom(startingDeck[i]);
      }
      library.shuffleDeck();
    }

    public void shuffleDiscardPileBackIn(){
      int c = discardPile.Count();
      for(int i = 0; i < c; i++){
        library.AddCardToBottom(discardPile.takeCardOffTop());
      }
      library.shuffleDeck();
    }

    public void DrawForTurn(){
      for(int i = 0; i < handSize; i++){
        if (library.isDeckEmpty()){ shuffleDiscardPileBackIn();}
        playerHand.addCardToHand(library.takeCardOffTop());
      }
    }

    public void RefillMana(){
      manaCurrent = manaMax;
    }

    public void DiscardAtTurnEnd(){
      CardScriptableObject[] discardedHand = playerHand.removeAllCardsFromHand();
      for(int i = 0; i < discardedHand.Length; i++){
        discardPile.AddCardToBottom(discardedHand[i]);
      }
    }

    public void playCard(int index){
      CardScriptableObject cardBeingPlayed = playerHand.playCard(index, manaCurrent);
      manaCurrent = manaCurrent - cardBeingPlayed.CardCost;

      playerFeild.addCardToFeild(cardBeingPlayed);
    }

    public void passTurn(){
      DiscardAtTurnEnd();
      turnEnd.Invoke();
    }
}
