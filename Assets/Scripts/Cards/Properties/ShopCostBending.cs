using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShopCostBending", menuName = "ScriptableObjects/Properties/ShopCostBending", order = 1)]
//[System.Serializable]
public class ShopCostBending : Property
{
    public int casterShopCostMod, opponentShopCostMod;

    public override void triggerProperty(){
      caster.UpdateShopCostMod(casterShopCostMod);
      opponent.UpdateShopCostMod(opponentShopCostMod);
    }
}
