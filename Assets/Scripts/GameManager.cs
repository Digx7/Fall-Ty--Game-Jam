using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1, player2;
    public Store store;

    public Player playerGoingFirst;

    public void startGame(){
      player1.setUpLibrary();
      player2.setUpLibrary();
      store.setUpLibrary();
      store.Draw();

      nextTurn(playerGoingFirst);
    }

    public void nextTurn(Player activePlayer){
      activePlayer.Draw();
      activePlayer.RefillMana();
      store.SetActivePlayer(activePlayer);
    }

    public void finishGame(){}
}
