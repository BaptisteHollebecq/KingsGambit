using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public Canvas GameCanvas;
    public Canvas PileFace;
    public Canvas EndTurn;
    public Canvas Selection;

    public void Show(string name)
    {
        switch (name)
        {
            case "Game":
                {
                    GameCanvas.gameObject.SetActive(true);
                    break;
                }
            case "PileFace":
                {
                    PileFace.gameObject.SetActive(true);
                    break;
                }
            case "EndTurn":
                {
                    EndTurn.gameObject.SetActive(true);
                    break;
                }
            case "Selection":
                {
                    Selection.gameObject.SetActive(true);
                    break;
                }
        }
    }

    public void Hide(string name)
    {

        switch (name)
        {
            case "Game":
                {
                    GameCanvas.gameObject.SetActive(false);
                    break;
                }
            case "PileFace":
                {
                    PileFace.gameObject.SetActive(false);
                    break;
                }
            case "EndTurn":
                {
                    EndTurn.gameObject.SetActive(false);
                    break;
                }
            case "Selection":
                {
                    Selection.gameObject.SetActive(false);
                    break;
                }
        }
    }


}
