using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Player
{
    public Player activePlayer;

    public override void Draw(){
      Debug.Log("Store is Drawing");
      for(int i = playerHand.cardsInHand.Count; i < handSize; i++){
        playerHand.addCardToHand(library.takeCardOffTop(),this);
      }
    }

    public override void playCard(int index){
      Debug.Log("Attempting to play a card at index: " + index);

      int priceCanPay = activePlayer.manaCurrent + activePlayer.shopMod;

      CardScriptableObject cardBeingBought = playerHand.playCard(index, priceCanPay);

      int cardPrice = cardBeingBought.CardCost - activePlayer.shopMod;
      activePlayer.manaCurrent = activePlayer.manaCurrent - cardPrice;
      activePlayer.manaChanged.Invoke(activePlayer.manaCurrent);

      Debug.Log("Adding the card to the player's deck");
      activePlayer.BuyCard(cardBeingBought);

      Debug.Log("Updateing the card buttons after being played");

      Draw();
    }

    public void SetActivePlayer(Player player){
      activePlayer = player;
    }
}
