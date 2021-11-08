using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLifeBending", menuName = "ScriptableObjects/Properties/LifeBending", order = 1)]
//[System.Serializable]
public class LifeBending : Property
{
    public int casterLifeMod, opponentLifeMod;

    public override void triggerProperty(){
      caster.UpdateHealth(casterLifeMod);
      opponent.UpdateHealth(opponentLifeMod);
      Debug.Log("The LifeBending property went off");
      Debug.Log("The caster is: " + caster);
      Debug.Log("The opponent is: " + opponent);
    }
}
