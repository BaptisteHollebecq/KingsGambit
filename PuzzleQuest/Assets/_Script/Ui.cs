using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public Canvas GameCanvas;
    public Canvas PileFace;
    public Canvas EndTurn;
    public Canvas Selection;


    public Image Piece1;
    public Image Piece2;
    public Image Piece3;

    public Sprite Dame;
    public Sprite Fou;
    public Sprite Cavalier;
    public Sprite Tour;
    public Sprite Pion;

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

    public void AddSprite(string name, int img)
    {
        Sprite sp = null;

        switch (name)
        {
            case "Dame":
                {
                    sp = Dame;
                    break;
                }
            case "Fou":
                {
                    sp = Fou;
                    break;
                }
            case "Cavalier":
                {
                    sp = Cavalier;
                    break;
                }
            case "Tour":
                {
                    sp = Tour;
                    break;
                }
            case "Pion":
                {
                    sp = Pion;
                    break;
                }
        }
    
        switch(img)
        {
            case 1:
                {
                    Piece1.sprite = sp;
                    break;
                }
            case 2:
                {
                    Piece2.sprite = sp;
                    break;
                }
            case 3:
                {
                    Piece3.sprite = sp;
                    break;
                }
        }
    }

    public void ClearSelection()
    {
        Piece1.sprite = null;
        Piece2.sprite = null;
        Piece3.sprite = null;
    }
}
