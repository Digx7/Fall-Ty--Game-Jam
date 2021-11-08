using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player1, player2;
    public Store storeR, storeL;

    public Player playerGoingFirst;

    public void startGame(){
      player1.setUpLibrary();
      player2.setUpLibrary();
      storeR.setUpLibrary();
      storeL.setUpLibrary();
      storeR.Draw();
      storeL.Draw();
      player1.castChampion();
      player2.castChampion();

      nextTurn(playerGoingFirst);
    }

    public void nextTurn(Player activePlayer){
      activePlayer.Draw();
      activePlayer.RefillMana();
      storeR.SetActivePlayer(activePlayer);
      storeL.SetActivePlayer(activePlayer);
    }

    public void finishGame(){
      Debug.Log("Game Finished");
    }
}
