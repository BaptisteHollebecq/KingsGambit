using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ui Ui;
    public TileManager board;
    public GameObject Piece;

    public Tile.Colors playerColor;
    public bool playerTurn;

    private void Awake()
    {
        Ui.HideGameCanvas();
    }

    private void Update()
    {
        if (playerTurn == false && board.canPlay)
        {

        }
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
        Ui.HidePileFaceCanvas();
        Ui.ShowGameCanvas();
        Piece.SetActive(false);
        StartCoroutine(board.Spawn());
    }

}
