using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public GameManager manager;
    public GameUI game;


    public Canvas GameCanvas;
    public Canvas PileFace;
    public Canvas EndTurn;
    public Canvas Selection;

    public Image Piece1;
    public Image Piece2;
    public Image Piece3;

    public Sprite DameBlanc;
    public Sprite FouBlanc;
    public Sprite CavalierBlanc;
    public Sprite TourBlanc;
    public Sprite PionBlanc;

    public Sprite DameNoir;
    public Sprite FouNoir;
    public Sprite CavalierNoir;
    public Sprite TourNoir;
    public Sprite PionNoir;

    public Sprite NullSprite;

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
                    if (manager.playerColor == Tile.Colors.Blanc)
                       sp = DameBlanc;
                    else
                        sp = DameNoir;
                    break;
                }
            case "Fou":
                {
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = FouBlanc;
                    else
                        sp = FouNoir;
                    break;
                }
            case "Cavalier":
                {
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = CavalierBlanc;
                    else
                        sp = CavalierNoir;
                    break;
                }
            case "Tour":
                {
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = TourBlanc;
                    else
                        sp = TourNoir;
                    break;
                }
            case "Pion":
                {
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = PionBlanc;
                    else
                        sp = PionNoir;
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
