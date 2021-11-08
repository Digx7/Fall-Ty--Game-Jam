using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayer : MonoBehaviour
{
  public List<GameObject> cardVisuals;
  public List<CardVisualizer> cardVisualizers;

  [SerializeField]
  private GameObject cardBasePreFab;
  [SerializeField]
  private Vector3 cardDisplayStartingPoint;
  [SerializeField]
  private Vector3 cardDisplayOffset;
  [SerializeField]
  private Vector3 cardDisplayScale;

  public void addCardToBeDisplayed(CardScriptableObject card){
    GameObject cardOBJ = Instantiate(cardBasePreFab, this.transform);
    CardVisualizer visuals = cardOBJ.GetComponent<CardVisualizer>();

    cardVisuals.Add(cardOBJ);

    visuals.changeCard(card);
    visuals.setCardClickable(false);
    cardVisualizers.Add(visuals);

    arrageDisplayCards();
  }

  public void addCardToBeDisplayed(CardScriptableObject card, Player owner){
    GameObject cardOBJ = Instantiate(cardBasePreFab, this.transform);
    CardVisualizer visuals = cardOBJ.GetComponent<CardVisualizer>();

    cardVisuals.Add(cardOBJ);

    visuals.changeCard(card);
    visuals.setOwner(owner);
    cardVisualizers.Add(visuals);

    arrageDisplayCards();
  }

  public void arrageDisplayCards(){
    for(int i = 0; i < cardVisuals.Count; i++){
      cardVisuals[i].transform.localPosition = cardDisplayStartingPoint + (i * cardDisplayOffset);
      cardVisuals[i].transform.localScale = cardDisplayScale;
    }
  }

  public void removeCardFromBeingDisplayed(int index){
    Destroy(cardVisuals[index]);
    cardVisuals.RemoveAt(index);
    cardVisualizers.RemoveAt(index);
  }

  public void removeALLCardsFromBeingDisplayed(){
    for(int i = 0; i < cardVisuals.Count; i++){
      Destroy(cardVisuals[i]);
    }
    cardVisuals.Clear();
    cardVisualizers.Clear();
  }
}
