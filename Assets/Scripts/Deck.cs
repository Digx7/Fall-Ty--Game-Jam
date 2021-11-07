using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Queue<CardScriptableObject> CardsInDeck;

    public void Awake(){
      CardsInDeck = new Queue<CardScriptableObject>();
    }

    public void printCardOnTop(){
      CardScriptableObject cardOnTop = CardsInDeck.Peek();

      if(cardOnTop != null)cardOnTop.printCard();
      else Debug.Log("There is no cards on top of this deck");
    }

    public int printDeckCount(){
      return CardsInDeck.Count;
    }

    public int Count(){
      return CardsInDeck.Count;
    }

    public void AddCardToBottom(CardScriptableObject card){
      CardsInDeck.Enqueue(card);
    }

    public CardScriptableObject takeCardOffTop(){
      if(!isDeckEmpty())return CardsInDeck.Dequeue();
      else return null;
    }

    public void shuffleDeck(){
      //CardScriptableObject[] cardsInArray = CardsInDeck.ToArray()
      List<CardScriptableObject> list = new List<CardScriptableObject>(CardsInDeck.ToArray());

      CardsInDeck.Clear();

      for (int i = 0; i < list.Count; i++) {
         CardScriptableObject temp = list[i];
         int randomIndex = Random.Range(i, list.Count);
         list[i] = list[randomIndex];
         list[randomIndex] = temp;
     }

      for(int i = 0; i < list.Count; i++){
        AddCardToBottom(list[i]);
      }
    }

    public bool isDeckEmpty(){
      if(CardsInDeck.Count == 0) return true;
      else return false;
    }
}
