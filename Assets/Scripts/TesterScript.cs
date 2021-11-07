using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    public GameManager GameManager;
    public Player player1, player2;

    //public int NumberOfFullTurnsToTest, cardIndexToTryToPlay, TestManaAvailable;

    public void Start(){
      //Debug.Log("Attempting to set up the Library");

      GameManager.startGame();

      player1.playCard(0);
      player1.passTurn();

      player2.playCard(0);
      player2.passTurn();

    }

    /*public void testFullTurn(int numberOfTurns){
      for(int i = 0; i < numberOfTurns; i++){
        //Debug.Log("Starting turn: " + i);
        //Debug.Log("Drawing for turn");
        player.DrawForTurn();
        //Debug.Log("Discarding at end of turn");
        player.DiscardAtTurnEnd();
      }
      //Debug.Log("Test results: Library: " + player.library.CardsInDeck.Count + " | Discard Pile: " + player.discardPile.CardsInDeck.Count);
    }*/
}
