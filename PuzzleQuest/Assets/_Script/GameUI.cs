using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Image Portrait;
    public Text Name;
    public Image Flag;

    public void SetUpOpps(Opponent opps)
    {
        Portrait.sprite = opps.Portrait;
        Name.text = opps.name;
        Flag.sprite = opps.Flag;
    }
}
