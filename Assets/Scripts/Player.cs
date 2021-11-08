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
    public UnityEvent cardPlayed,turnStart,turnEnd;
    public IntEvent manaChanged,ultChanged;
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

    public virtual void Draw(){
      for(int i = 0; i < handSize; i++){
        if (library.isDeckEmpty()){ shuffleDiscardPileBackIn();}
        //playerHand.addCardToHand(library.takeCardOffTop(),playCard(i))
        playerHand.addCardToHand(library.takeCardOffTop(), this);
      }
      //updateCardButtons();
    }

    public void RefillMana(){
      manaCurrent = manaMax;
      manaChanged.Invoke(manaCurrent);
    }

    public void emptyMana(){
      manaCurrent = 0;
      manaChanged.Invoke(manaCurrent);
    }

    public void DiscardAtTurnEnd(){
      CardScriptableObject[] discardedHand = playerHand.removeAllCardsFromHand();
      for(int i = 0; i < discardedHand.Length; i++){
        discardPile.AddCardToBottom(discardedHand[i]);
      }
    }

    public virtual void playCard(int index){
      Debug.Log("Attempting to play a card at index: " + index);

      CardScriptableObject cardBeingPlayed = playerHand.playCard(index, manaCurrent);
      manaCurrent = manaCurrent - cardBeingPlayed.CardCost;
      manaChanged.Invoke(manaCurrent);

      Debug.Log("Adding the card to the feild");
      playerFeild.addCardToFeild(cardBeingPlayed);

      Debug.Log("Updateing the card buttons after being played");
    }

    public void playCard(CardScriptableObject card){
      if(playerHand.isCardInHand(card)){
        playCard(playerHand.findIndexOfCardInHand(card));
      }
    }

    public void BuyCard(CardScriptableObject card){
      library.AddCardToBottom(card);
    }

    public void UpgradeUlt(int input){
      ultCurrent += input;
      ultChanged.Invoke(ultCurrent);
    }

    public void passTurn(){
      emptyMana();
      DiscardAtTurnEnd();
      playerFeild.checkAllCardsForTriggerType(TriggerType.EndStep);
      playerFeild.proccessStack();
      turnEnd.Invoke();
    }
}
