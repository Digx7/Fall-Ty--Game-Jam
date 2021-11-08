using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewManaBending", menuName = "ScriptableObjects/Properties/ManaBending", order = 1)]
//[System.Serializable]
public class ManaBending : Property
{
    public int casterManaMod, opponentManaMod;

    public override void triggerProperty(){
      caster.UpdateManaMax(casterManaMod);
      opponent.UpdateManaMax(opponentManaMod);
      Debug.Log("The Mana Bending property went off");
    }
}
