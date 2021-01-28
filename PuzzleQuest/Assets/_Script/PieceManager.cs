using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PieceManager : MonoBehaviour
{
    public GameManager manager;

    [Header("Player")]

    public Piece PlayerP1;
    public Piece PlayerP2;
    public Piece PlayerP3;

    public Image PlayerP1Sprite;
    public Image PlayerP2Sprite;
    public Image PlayerP3Sprite;
    public Text PlayerP1Life;
    public Text PlayerP2Life;
    public Text PlayerP3Life;
    public Image PlayerP1Atk;
    public Image PlayerP2Atk;
    public Image PlayerP3Atk;

    [Header("Opponent")]

    public Piece OppP1;
    public Piece OppP2;
    public Piece OppP3;

    public Image OppP1Sprite;
    public Image OppP2Sprite;
    public Image OppP3Sprite;
    public Text OppP1Life;
    public Text OppP2Life;
    public Text OppP3Life;
    public Image OppP1Atk;
    public Image OppP2Atk;
    public Image OppP3Atk;

    [Header("Sprites")]

    public Sprite PionBlanc;
    public Sprite TourBlanc;
    public Sprite CavalierBlanc;
    public Sprite FouBlanc;
    public Sprite DameBlanc;

    public Sprite PionNoir;
    public Sprite TourNoir;
    public Sprite CavalierNoir;
    public Sprite FouNoir;
    public Sprite DameNoir;


    private void Update()
    {
        PlayerP1Life.text = PlayerP1.Life.ToString();
        PlayerP2Life.text = PlayerP2.Life.ToString();
        PlayerP3Life.text = PlayerP3.Life.ToString();

        OppP1Life.text = OppP1.Life.ToString();
        OppP2Life.text = OppP2.Life.ToString();
        OppP3Life.text = OppP3.Life.ToString();

        PlayerP1Atk.transform.localScale = new Vector3(PlayerP1.atkLevel/100,1,1);
        PlayerP2Atk.transform.localScale = new Vector3(PlayerP2.atkLevel / 100, 1, 1);
        PlayerP3Atk.transform.localScale = new Vector3(PlayerP3.atkLevel / 100, 1, 1);

        OppP1Atk.transform.localScale = new Vector3(OppP1.atkLevel / 100, 1, 1);
        OppP2Atk.transform.localScale = new Vector3(OppP2.atkLevel / 100, 1, 1);
        OppP3Atk.transform.localScale = new Vector3(OppP3.atkLevel / 100, 1, 1);



        if (PlayerP1.atkLevel >= 100)
            Attaque(PlayerP1, 0);
        if (PlayerP2.atkLevel >= 100)
            Attaque(PlayerP2, 0);
        if (PlayerP3.atkLevel >= 100)
            Attaque(PlayerP3, 0);

        if (OppP1.atkLevel >= 100)
            Attaque(OppP1, 1);
        if (OppP2.atkLevel >= 100)
            Attaque(OppP2, 1);
        if (OppP3.atkLevel >= 100)
            Attaque(OppP3, 1);

        if ((PlayerP1.Life == 0 && PlayerP2.Life == 0 && PlayerP3.Life == 0) ||
            (OppP1.Life == 0 && OppP2.Life == 0 && OppP3.Life == 0))
        {
            //FIN DE LA GAME MAIS JE SAIS APS QUOI FAIRE
            // RETOUR MAP MONDE .?????????

            manager.Ui.Hide("Game");
            manager.board.ClearBoard();

            manager.Text.gameObject.SetActive(true);
            manager.Text.ShowText(manager.opps.GetComponent<Opponent>().LoosedLine, true);

        }
    }

    void AtkMove(Image piece, Image p)
    {
        Transform start = piece.gameObject.transform;

        Sequence atkMove = DOTween.Sequence();
        atkMove.Append(piece.transform.DOMove(p.transform.position, 0.1f));
        atkMove.PrependInterval(0.1f);
        atkMove.Append(piece.transform.DOMove(start.position, 0.1f));

        atkMove.Play();
    }

    public void Attaque(Piece piece, int player)
    {
        piece.atkLevel = 0;
        if (player == 0)
        {
            if (OppP1.Life > 0)
            {
                OppP1.Life -= piece.Attack;
                if (OppP1.Life <= 0)
                {
                    OppP1.Life = 0;
                    OppP1.Alive = false;
                }
            }
            else if (OppP2.Life > 0)
            {
                OppP2.Life -= piece.Attack;
                if (OppP2.Life <= 0)
                {
                    OppP2.Life = 0;
                    OppP2.Alive = false;
                }
            }
            else if (OppP3.Life > 0)
            {
                OppP3.Life -= piece.Attack;
                if (OppP3.Life <= 0)
                {
                    OppP3.Life = 0;
                    OppP3.Alive = false;
                }
            }
        }
        else
        {
            if (PlayerP1.Life > 0)
            {
                PlayerP1.Life -= piece.Attack;
                if (PlayerP1.Life <= 0)
                {
                    PlayerP1.Life = 0;
                    PlayerP1.Alive = false;
                }
            }
            else if (PlayerP2.Life > 0)
            {
                PlayerP2.Life -= piece.Attack;
                if (PlayerP2.Life <= 0)
                {
                    PlayerP2.Life = 0;
                    PlayerP2.Alive = false;
                }
            }
            else if (PlayerP3.Life > 0)
            {
                PlayerP3.Life -= piece.Attack;
                if (PlayerP3.Life <= 0)
                {
                    PlayerP3.Life = 0;
                    PlayerP3.Alive = false;
                }
            }
        }
    }

    public void SetUpPlayer(string piece, int number)
    {
        Piece p = null;
        Sprite sp = null;

        switch(piece)
        {
            case "Pion":
                {
                    p = new Pion();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = PionBlanc;
                    else
                        sp = PionNoir;
                    break;
                }
            case "Tour":
                {
                    p = new Tour();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = TourBlanc;
                    else
                        sp = TourNoir;
                    break;
                }
            case "Cavalier":
                {
                    p = new Cavalier();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = CavalierBlanc;
                    else
                        sp = CavalierNoir;
                    break;
                }
            case "Fou":
                {
                    p = new Fou();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = FouBlanc;
                    else
                        sp = FouNoir;
                    break;
                }
            case "Dame":
                {
                    p = new Dame();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = DameBlanc;
                    else
                        sp = DameNoir;
                    break;
                }
        }

        switch (number)
        {
            case 1:
                {
                    PlayerP1 = p;
                    PlayerP1Sprite.sprite = sp;
                    break;
                }
            case 2:
                {
                    PlayerP2 = p;
                    PlayerP2Sprite.sprite = sp;
                    break;
                }
            case 3:
                {
                    PlayerP3 = p;
                    PlayerP3Sprite.sprite = sp;
                    break;
                }
        }

    }


    public void SetUpOpponent(string piece, int number)
    {
        Piece p = null;
        Sprite sp = null;
        switch (piece)
        {
            case "Pion":
                {
                    p = new Pion();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = PionNoir;
                    else
                        sp = PionBlanc;
                    break;
                }
            case "Tour":
                {
                    p = new Tour();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = TourNoir;
                    else
                        sp = TourBlanc;
                    break;
                }
            case "Cavalier":
                {
                    p = new Cavalier();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = CavalierNoir;
                    else
                        sp = CavalierBlanc;
                    break;
                }
            case "Fou":
                {
                    p = new Fou();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = FouNoir;
                    else
                        sp = FouBlanc;
                    break;
                }
            case "Dame":
                {
                    p = new Dame();
                    if (manager.playerColor == Tile.Colors.Blanc)
                        sp = DameNoir;
                    else
                        sp = DameBlanc;
                    break;
                }
        }

        switch (number)
        {
            case 1:
                {
                    OppP1 = p;
                    OppP1Sprite.sprite = sp;
                    break;
                }
            case 2:
                {
                    OppP2 = p;
                    OppP2Sprite.sprite = sp;
                    break;
                }
            case 3:
                {
                    OppP3 = p;
                    OppP3Sprite.sprite = sp;
                    break;
                }
        }

    }
}
