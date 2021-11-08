using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardDraw", menuName = "ScriptableObjects/Properties/CardDraw", order = 1)]
//[System.Serializable]
public class CardDraw : Property
{
    public int drawAmount;

    public override void triggerProperty(){
      caster.DrawCards(drawAmount);
      Debug.Log("The Card Draw property went off");
    }
}
