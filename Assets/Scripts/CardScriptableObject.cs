using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "ScriptableObjects/Card", order = 1)]
public class CardScriptableObject : ScriptableObject
{

  public string CardName;

  public int CardCost;

  public string flavorText;

  public Sprite cardImage;

  public void printCard(){
    Debug.Log(CardName + " costs " + CardCost + " to play\n" + flavorText);
  }

}
