using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feild : MonoBehaviour
{
    public List<CardScriptableObject> perminants;

    public List<CardScriptableObject> champions;

    public List<CardScriptableObject> effects;

    public CardDisplayer perminantsDispayer, championsDisplayer, effectsDisplayer;

    public void addCardToFeild(CardScriptableObject card){
      if(card is PerminateScriptableObject) {
        perminants.Add(card as PerminateScriptableObject);
        perminantsDispayer.addCardToBeDisplayed(card);
      }else if(card is ChampionsScriptableObject) {
        champions.Add(card as ChampionsScriptableObject);
        championsDisplayer.addCardToBeDisplayed(card);
      }else if(card is EffectsScriptableObject) {
        effects.Add(card as EffectsScriptableObject);
        effectsDisplayer.addCardToBeDisplayed(card);
      }
    }

    public CardScriptableObject removePerminateFromFeild(int index){
      CardScriptableObject card = perminants[index];

      perminants.RemoveAt(index);
      perminantsDispayer.removeCardFromBeingDisplayed(index);

      return card;
    }

    public CardScriptableObject removeChampionFromFeild(int index){
      CardScriptableObject card = champions[index];

      champions.RemoveAt(index);
      championsDisplayer.removeCardFromBeingDisplayed(index);

      return card;
    }

    public CardScriptableObject removeEffectFromFeild(int index){
      CardScriptableObject card = effects[index];

      effects.RemoveAt(index);
      effectsDisplayer.removeCardFromBeingDisplayed(index);

      return card;
    }

    public CardScriptableObject[] removeAllPerminatsFromFeild(){
      CardScriptableObject[] hand = perminants.ToArray();

      perminants.Clear();
      perminantsDispayer.removeALLCardsFromBeingDisplayed();

      return hand;
    }

    public CardScriptableObject[] removeAllChampionsFromFeild(){
      CardScriptableObject[] hand = champions.ToArray();

      champions.Clear();
      championsDisplayer.removeALLCardsFromBeingDisplayed();

      return hand;
    }

    public CardScriptableObject[] removeAllEffectsFromFeild(){
      CardScriptableObject[] hand = effects.ToArray();

      effects.Clear();
      effectsDisplayer.removeALLCardsFromBeingDisplayed();

      return hand;
    }

    public void removeAllCardsFromFeild(){
      removeAllPerminatsFromFeild();
      removeAllEffectsFromFeild();
      removeAllChampionsFromFeild();
    }
}
