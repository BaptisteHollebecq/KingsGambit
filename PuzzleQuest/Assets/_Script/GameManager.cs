using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ui Ui;
    public TileManager board;
    public IA Ia;
    public GameObject Piece;

    public Opponent opps;

    public GameObject DameBlanc;
    public GameObject FouBlanc;
    public GameObject CavalierBlanc;
    public GameObject TourBlanc;
    public GameObject PionBlanc;

    public GameObject DameNoir;
    public GameObject FouNoir;
    public GameObject CavalierNoir;
    public GameObject TourNoir;
    public GameObject PionNoir;

    public Tile.Colors playerColor;
    public bool playerTurn;

    public bool Iaturn = false;

    private void Awake()
    {
        Ui.Hide("Game");
        Ui.Hide("EndTurn");
        Ui.Hide("Selection");
    }

    private void Update()
    {
        if (playerTurn == false && board.canPlay && Iaturn == false)
        {
            Iaturn = true;
            StartCoroutine(WaitIa());
        }
    }

    IEnumerator WaitIa()
    {
        yield return new WaitForSeconds(1.5f);
        Ia.BasicPlay();
        Iaturn = false;
    }

    public void ShowEndTurnUI()
    {
        Ui.Show("EndTurn");
    }

    public void EndTurn()
    {
        board.canPlay = true;
        Ui.Hide("EndTurn");
    }

    public void GetColor()
    {
        int x = Random.Range(0, 2);
        switch (x)
        {
            case 0:
                {
                    playerColor = Tile.Colors.Blanc;
                    Piece.GetComponent<PileFace>().White();
                    playerTurn = true;
                    break;
                }
            case 1:
                {
                    playerColor = Tile.Colors.Noir;
                    Piece.GetComponent<PileFace>().Black();
                    playerTurn = false;
                    break;
                }
        }
        StartCoroutine(Wait(1.5f));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Ui.Hide("PileFace");
        board.SpawnablePiece.Clear();
        Ui.ClearSelection();
        Ui.Show("Selection");
        Piece.SetActive(false);
    }

    public void ButtonStart()
    {
        // ajouter a la list les piece de l'ennemi
        if (playerColor == Tile.Colors.Blanc)
        {
            board.SpawnablePiece.Add(opps.PieceNoir1);
            board.SpawnablePiece.Add(opps.PieceNoir2);
            board.SpawnablePiece.Add(opps.PieceNoir3);
        }
        else
        {
            board.SpawnablePiece.Add(opps.PieceBlanche1);
            board.SpawnablePiece.Add(opps.PieceBlanche2);
            board.SpawnablePiece.Add(opps.PieceBlanche3);
        }


        Ui.game.SetUpOpps(opps);

        Ui.Hide("Selection");
        Ui.Show("Game");
        StartCoroutine(board.Spawn());
    }

    public void ButtonDame()
    {
        GameObject piece;
        if (playerColor == Tile.Colors.Blanc)
            piece = DameBlanc;
        else
            piece = DameNoir;

        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(piece))
            {

                board.SpawnablePiece.Add(piece);

                if (Ui.Piece1.sprite == null)
                    Ui.AddSprite("Dame", 1);
                else if (Ui.Piece2.sprite == null)
                    Ui.AddSprite("Dame", 2);
                else if (Ui.Piece3.sprite == null)
                    Ui.AddSprite("Dame", 3);
            }
        }
        else
        {
            board.SpawnablePiece.Clear();
            Ui.ClearSelection();
            board.SpawnablePiece.Add(piece);
            Ui.AddSprite("Dame", 1);
        }
    }
    public void ButtonFou()
    {
        GameObject piece;
        if (playerColor == Tile.Colors.Blanc)
            piece = FouBlanc;
        else
            piece = FouNoir;

        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(piece))
            {

                board.SpawnablePiece.Add(piece);

                if (Ui.Piece1.sprite == null)
                    Ui.AddSprite("Fou", 1);
                else if (Ui.Piece2.sprite == null)
                    Ui.AddSprite("Fou", 2);
                else if (Ui.Piece3.sprite == null)
                    Ui.AddSprite("Fou", 3);
            }
        }
        else
        {
            board.SpawnablePiece.Clear();
            Ui.ClearSelection();
            board.SpawnablePiece.Add(piece);
            Ui.AddSprite("Fou", 1);
        }
    }
    public void ButtonCavalier()
    {
        GameObject piece;
        if (playerColor == Tile.Colors.Blanc)
            piece = CavalierBlanc;
        else
            piece = CavalierNoir;

        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(piece))
            {

                board.SpawnablePiece.Add(piece);

                if (Ui.Piece1.sprite == null)
                    Ui.AddSprite("Cavalier", 1);
                else if (Ui.Piece2.sprite == null)
                    Ui.AddSprite("Cavalier", 2);
                else if (Ui.Piece3.sprite == null)
                    Ui.AddSprite("Cavalier", 3);
            }
        }
        else
        {
            board.SpawnablePiece.Clear();
            Ui.ClearSelection();
            board.SpawnablePiece.Add(piece);
            Ui.AddSprite("Cavalier", 1);
        }
    }
    public void ButtonTour()
    {
        GameObject piece;
        if (playerColor == Tile.Colors.Blanc)
            piece = TourBlanc;
        else
            piece = TourNoir;

        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(piece))
            {

                board.SpawnablePiece.Add(piece);

                if (Ui.Piece1.sprite == null)
                    Ui.AddSprite("Tour", 1);
                else if (Ui.Piece2.sprite == null)
                    Ui.AddSprite("Tour", 2);
                else if (Ui.Piece3.sprite == null)
                    Ui.AddSprite("Tour", 3);
            }
        }
        else
        {
            board.SpawnablePiece.Clear();
            Ui.ClearSelection();
            board.SpawnablePiece.Add(piece);
            Ui.AddSprite("Tour", 1);
        }
    }
    public void ButtonPion()
    {
        GameObject piece;
        if (playerColor == Tile.Colors.Blanc)
            piece = PionBlanc;
        else
            piece = PionNoir;

        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(piece))
            {

                board.SpawnablePiece.Add(piece);

                if (Ui.Piece1.sprite == null)
                    Ui.AddSprite("Pion", 1);
                else if (Ui.Piece2.sprite == null)
                    Ui.AddSprite("Pion", 2);
                else if (Ui.Piece3.sprite == null)
                    Ui.AddSprite("Pion", 3);
            }
        }
        else
        {
            board.SpawnablePiece.Clear();
            Ui.ClearSelection();
            board.SpawnablePiece.Add(piece);
            Ui.AddSprite("Pion", 1);
        }
    }
}
