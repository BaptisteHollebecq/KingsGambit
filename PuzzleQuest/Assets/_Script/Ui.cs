using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public Canvas GameCanvas;
    public Canvas PileFace;


    public void ShowGameCanvas()
    {
        GameCanvas.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void HideGameCanvas()
    {
        GameCanvas.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void ShowPileFaceCanvas()
    {
        PileFace.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void HidePileFaceCanvas()
    {
        PileFace.GetComponent<CanvasGroup>().alpha = 0;
    }
}
