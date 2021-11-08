using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Deck library, discardPile;

    public int manaMax, manaCurrent, ultMax, ultCurrent, currentLife, maxLife, shopMod;

    public ChampionsScriptableObject playersChampion;
    public CardScriptableObject[] startingDeck;

    public Hand playerHand;
    public int handSize;
    public Feild playerFeild;
    public UnityEvent cardPlayed,turnStart,turnEnd,playerDied;
    public IntEvent manaChanged,ultChanged,healthChanged,shopModChanged;
    //public Deck tempFeild;

    public void setUpLibrary(){
      for(int i = 0; i < startingDeck.Length; i++){
        library.AddCardToBottom(startingDeck[i]);
      }
      library.shuffleDeck();

      healthChanged.Invoke(currentLife);
    }

    public void castChampion(){
      playerFeild.addCardToFeild(playersChampion);
    }

    public void shuffleDiscardPileBackIn(){
      int c = discardPile.Count();
      for(int i = 0; i < c; i++){
        library.AddCardToBottom(discardPile.takeCardOffTop());
      }
      library.shuffleDeck();
    }

    public virtual void Draw(){
      DrawCards(handSize);
      //updateCardButtons();
    }

    public void DrawCards(int numberOfCardsToDraw){
      for(int i = 0; i < numberOfCardsToDraw; i++){
        if (library.isDeckEmpty()){ shuffleDiscardPileBackIn();}
        //playerHand.addCardToHand(library.takeCardOffTop(),playCard(i))
        playerHand.addCardToHand(library.takeCardOffTop(), this);
      }
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

      if(ultCurrent > ultMax) TriggerUlt();
    }

    public void TriggerUlt(){
      ultCurrent = 0;
      Debug.Log("The ultimate has triggered");
      playerFeild.checkAllCardsForTriggerType(TriggerType.UltimateTriggered);
    }

    public void UpdateHealth(int input){
      currentLife += input;
      healthChanged.Invoke(currentLife);
      if(currentLife <= 0)playerDied.Invoke();
    }

    public void UpdateManaMax(int input){
      manaMax += input;
    }

    public void UpdateShopCostMod(int input){
      shopMod += input;
      shopModChanged.Invoke(shopMod);
    }

    public void passTurn(){
      emptyMana();
      DiscardAtTurnEnd();
      playerFeild.checkAllCardsForTriggerType(TriggerType.EndStep);
      playerFeild.proccessStack();
      turnEnd.Invoke();
    }
}
