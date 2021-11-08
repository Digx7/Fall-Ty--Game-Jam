using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feild : MonoBehaviour
{
    public List<CardScriptableObject> perminants;

    public List<CardScriptableObject> champions;

    public List<CardScriptableObject> effects;

    public CardDisplayer perminantsDispayer, championsDisplayer, effectsDisplayer;

    private Stack<Property> propertiesTriggering;

    [SerializeField]
    private Player caster, opponent;

    public void Awake(){
      propertiesTriggering = new Stack<Property>();
      caster = this.gameObject.GetComponentInParent<Player>();
      opponent = findOpponent();
    }

    private Player findOpponent(){
      Player[] players = GameObject.FindObjectsOfType<Player>();
      for(int i = 0; i<players.Length; i++){
        if(players[i].name != "Store" && players[i].GetComponent<Player>() != caster) return players[i].GetComponent<Player>();
      }
      return null;
    }

    public void addCardToFeild(CardScriptableObject card){
      checkCardForTriggerType(card, TriggerType.ETB);
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
      proccessStack();
    }

    public void checkAllCardsForTriggerType(TriggerType type){
      if(perminants.Count > 0){
        for(int i = 0; i < perminants.Count; ++i)
        {
          Debug.Log("There is a perminant on the field");
          checkCardForTriggerType(perminants[i], type);
        }
      }
      if(effects.Count > 0){
        for(int i = 0; i < effects.Count; ++i){
          checkCardForTriggerType(effects[i], type);
        }
      }
      if(champions.Count > 0){
        for(int i = 0; i < champions.Count; ++i){
          checkCardForTriggerType(champions[i], type);
        }
      }
    }

    public void checkCardForTriggerType(CardScriptableObject card, TriggerType type){
      PerminateScriptableObject pCard = getCardAsPerminate(card);
      EffectsScriptableObject eCard = getCardAsEffect(card);
      ChampionsScriptableObject cCard = getCardAsChampion(card);

      if(eCard != null && eCard.triggers.Length > 0){
        for(int i = 0; i < eCard.triggers.Length; i++){
          if(eCard.triggers[i].type == type){
            addPropertyToStack(eCard.triggers[i].property);
          }
        }
      }
      if(pCard != null && pCard.triggers.Length > 0){
        for(int i = 0; i < pCard.triggers.Length; i++){
          if(pCard.triggers[i].type == type){
            Debug.Log("There is a correct trigger on this Perminate");
            addPropertyToStack(pCard.triggers[i].property);
          }
        }
      }
      if(cCard != null && cCard.triggers.Length > 0){
        for(int i = 0; i < cCard.triggers.Length; i++){
          if(cCard.triggers[i].type == type){
            addPropertyToStack(cCard.triggers[i].property);
          }
        }
      }
    }

    private void addPropertyToStack(Property prop){
      prop.caster = caster;
      prop.opponent = opponent;
      propertiesTriggering.Push(prop);
    }

    public void proccessStack(){
      while(propertiesTriggering.Count != 0){
        Property prop = propertiesTriggering.Pop();
        prop.triggerProperty();
      }
      removeAllEffectsFromFeild();
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

    private PerminateScriptableObject getCardAsPerminate(CardScriptableObject card){
      if(card is PerminateScriptableObject) {
        return card as PerminateScriptableObject;
      }
      return null;
    }

    private EffectsScriptableObject getCardAsEffect(CardScriptableObject card){
      if(card is EffectsScriptableObject) {
        return card as EffectsScriptableObject;
      }
      return null;
    }

    private ChampionsScriptableObject getCardAsChampion(CardScriptableObject card){
      if(card is ChampionsScriptableObject) {
        return card as ChampionsScriptableObject;
      }
      return null;
    }
}
