using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI p1Mana;
    public TextMeshProUGUI p2Mana;
    public TextMeshProUGUI p1Ult;
    public TextMeshProUGUI p2Ult;

    public void UpdateP1Mana(int input){
      p1Mana.text = input.ToString();
    }

    public void UpdateP2Mana(int input){
      p2Mana.text = input.ToString();
    }

    public void UpdateP1Ult(int input){
      p1Ult.text = input.ToString();
    }

    public void UpdateP2Ult(int input){
      p2Ult.text = input.ToString();
    }
}
