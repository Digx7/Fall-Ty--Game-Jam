using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1, player2;

    public Player playerGoingFirst;

    public void startGame(){
      player1.setUpLibrary();
      player2.setUpLibrary();

      nextTurn(playerGoingFirst);
    }

    public void nextTurn(Player activePlayer){
      activePlayer.DrawForTurn();
      activePlayer.RefillMana();
    }

    public void finishGame(){}
}
