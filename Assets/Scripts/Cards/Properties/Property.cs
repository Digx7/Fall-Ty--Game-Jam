using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : ScriptableObject
//[System.Serializable]
//public class Property
{

  public Player caster, opponent;

  public virtual void triggerProperty(){
    Debug.Log("Just the base property went off");
  }
}
