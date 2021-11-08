using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewUltBending", menuName = "ScriptableObjects/Properties/UltBending", order = 1)]
//[System.Serializable]
public class UltBending : Property
{
    public int casterUltMod, opponentUltMod;

    public override void triggerProperty(){
      caster.UpgradeUlt(casterUltMod);
      opponent.UpgradeUlt(opponentUltMod);
      Debug.Log("The ChargeBending property went off");
    }
}
