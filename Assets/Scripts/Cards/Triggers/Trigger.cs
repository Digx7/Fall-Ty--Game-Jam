using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerType{ETB, EndStep, StoreBuy, UltimateTrigger}

[System.Serializable]
public class Trigger
{
  public TriggerType type;

  public Property property;
}
