using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public Canvas GameCanvas;
    public Canvas PileFace;


    public void ShowGameCanvas()
    {
        GameCanvas.gameObject.SetActive(true);
    }

    public void HideGameCanvas()
    {
        GameCanvas.gameObject.SetActive(false);
    }

    public void ShowPileFaceCanvas()
    {
        PileFace.gameObject.SetActive(true);
    }

    public void HidePileFaceCanvas()
    {
        PileFace.gameObject.SetActive(false);
    }
}
