using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ui Ui;
    public TileManager board;
    public IA Ia;
    public GameObject Piece;

    public GameObject Dame;
    public GameObject Fou;
    public GameObject Cavalier;
    public GameObject Tour;
    public GameObject Pion;

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
        switch(x)
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
        Ui.Hide("Selection");
        Ui.Show("Game");
        StartCoroutine(board.Spawn());
    }

    public void ButtonDame()
    {
        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(Dame))
            {
                board.SpawnablePiece.Add(Dame);
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
            board.SpawnablePiece.Add(Dame);
            Ui.AddSprite("Dame", 1);
        }
    }
    public void ButtonFou()
    {
        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(Fou))
            {
                board.SpawnablePiece.Add(Fou);
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
            board.SpawnablePiece.Add(Fou);
            Ui.AddSprite("Fou", 1);
        }
    }
    public void ButtonCavalier()
    {
        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(Cavalier))
            {
                board.SpawnablePiece.Add(Cavalier);
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
            board.SpawnablePiece.Add(Cavalier);
            Ui.AddSprite("Cavalier", 1);
        }
    }
    public void ButtonTour()
    {
        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(Tour))
            {
                board.SpawnablePiece.Add(Tour);
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
            board.SpawnablePiece.Add(Tour);
            Ui.AddSprite("Tour", 1);
        }
    }
    public void ButtonPion()
    {
        if (board.SpawnablePiece.Count < 3)
        {
            if (!board.SpawnablePiece.Contains(Pion))
            {
                board.SpawnablePiece.Add(Pion);
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
            board.SpawnablePiece.Add(Pion);
            Ui.AddSprite("Pion", 1);
        }
    }
}
