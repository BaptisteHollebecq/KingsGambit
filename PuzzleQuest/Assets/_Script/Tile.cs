﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tile : MonoBehaviour
{
    public enum Colors
    {
        Blanc,
        Noir
    }

    public enum Piece
    {
        Pion,
        Tour,
        Cavalier,
        Fou,
        Dame
    }

    public Colors TileColor;
    public Piece TilePiece;
    public float powerCharge = 10;
    public bool isSelected;
    public Sprite BaseMat;
    public Sprite SelectedMat;
    public int X;
    public int Y;
    public TileManager Manager;
    public List<Tile> TileToDestroy;

    private SpriteRenderer _sp;



    private void Awake()
    {
        _sp = GetComponent<SpriteRenderer>();

        TileManager.LaunchCheck += CheckAndDestroy;
    }

    private void Start()
    {
        if (Manager.SpawnFinished && Manager.TileArray[X, Y - 1] != null)
        {

            CheckAndDestroy();
        }

    }

    private void OnDestroy()
    {
        TileManager.LaunchCheck -= CheckAndDestroy;

        if (Manager.canCount)
        {
            if (TileColor == Manager.Game.playerColor)
            {
                if (Manager.Game.PM.PlayerP1.type == TilePiece && Manager.Game.PM.PlayerP1.Alive)
                    Manager.Game.PM.PlayerP1.atkLevel += powerCharge;
                if (Manager.Game.PM.PlayerP2.type == TilePiece && Manager.Game.PM.PlayerP2.Alive)
                    Manager.Game.PM.PlayerP2.atkLevel += powerCharge;
                if (Manager.Game.PM.PlayerP3.type == TilePiece && Manager.Game.PM.PlayerP3.Alive)
                    Manager.Game.PM.PlayerP3.atkLevel += powerCharge;

            }
            else
            {
                if (Manager.Game.PM.OppP1.type == TilePiece && Manager.Game.PM.OppP1.Alive)
                    Manager.Game.PM.OppP1.atkLevel += powerCharge;
                if (Manager.Game.PM.OppP2.type == TilePiece && Manager.Game.PM.OppP2.Alive)
                    Manager.Game.PM.OppP2.atkLevel += powerCharge;
                if (Manager.Game.PM.OppP3.type == TilePiece && Manager.Game.PM.OppP3.Alive)
                    Manager.Game.PM.OppP3.atkLevel += powerCharge;
            }
        }
    }

    private void Update()
    {
        if (Y != 0)
        {
            if (Manager.TileArray[X, Y - 1] == null)
            {
                Fall();
            }
        }

    }

    private void OnMouseDown()
    {
        if (Manager.canPlay && Manager.Game.playerTurn)
        {
            if (Manager.SelectedTile == null && !isSelected)
            {
                Select();
            }
            else if (Manager.SelectedTile != null && !isSelected)
            {
                if (isNeighbour(Manager.SelectedTile))
                {
                    Swap(Manager.SelectedTile);

                    TileToDestroy = Check();
                    Manager.SelectedTile.TileToDestroy = Manager.SelectedTile.Check();

                    if (TileToDestroy != null || Manager.SelectedTile.TileToDestroy != null)
                    {
                        if (TileToDestroy != null)
                        {
                            Manager.canPlay = false;
                            Manager.Fill(false);
                            StartCoroutine(DestroyTile(TileToDestroy));
                        }

                        if (Manager.SelectedTile.TileToDestroy != null)
                        {
                            Manager.canPlay = false;
                            Manager.Fill(false);
                            StartCoroutine(Manager.SelectedTile.DestroyTile(Manager.SelectedTile.TileToDestroy));
                        }

                        Manager.SelectedTile.UnSelect();
                        Manager.Game.playerTurn = false;
                    }
                    else
                    {
                        Swap(Manager.SelectedTile);
                        Manager.SelectedTile.UnSelect();
                    }
                }
                else
                {
                    Manager.SelectedTile.UnSelect();
                    Select();
                }
            }
            else if (isSelected)
            {
                UnSelect();
            }

        }
    }

    public void Select()
    {
        isSelected = true;

        _sp.sprite = SelectedMat;
        Manager.SelectedTile = this;
    }

    public void UnSelect()
    {
        isSelected = false;
        _sp.sprite = BaseMat;
        Manager.SelectedTile = null;
    }

    public bool isNeighbour(Tile t)
    {
        if (((t.X == X + 1 || t.X == X - 1) && t.Y == Y) || ((t.Y == Y + 1 || t.Y == Y - 1) && t.X == X))
        {
            return true;
        }

        return false;
    }

    public void Swap(Tile t)
    {
        Vector3 tmp = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        int tmpX = X;
        int tmpY = Y;


        transform.DOLocalMove(new Vector3(t.X * Manager.Offset, t.Y * Manager.Offset, 0), 0.4f);
        Manager.TileArray[X, Y] = t;
        X = t.X;
        Y = t.Y;

        t.transform.DOLocalMove(new Vector3(tmpX * Manager.Offset, tmpY * Manager.Offset, 0), 0.4f);
        Manager.TileArray[t.X, t.Y] = this;
        t.X = tmpX;
        t.Y = tmpY;
    }

    public List<Tile> Check()
    {
        int startX = X;
        int startY = Y;
        int x = X;
        int y = Y;
        List<Tile> tH = new List<Tile>();
        List<Tile> tV = new List<Tile>();

        #region horizontal

        while (x > 0)
        {
            if (Manager.TileArray[x - 1, y] != null && Manager.TileArray[x - 1, y].TileColor == TileColor && Manager.TileArray[x - 1, y].TilePiece == TilePiece)
            {
                x--;
            }
            else
            {
                break;
            }
        }

        tH.Add(Manager.TileArray[x, y]);

        while (x < Manager.row - 1)
        {
            if (Manager.TileArray[x + 1, y] != null && Manager.TileArray[x + 1, y].TileColor == TileColor && Manager.TileArray[x + 1, y].TilePiece == TilePiece)
            {
                x++;
                tH.Add(Manager.TileArray[x, y]);
            }
            else
            {
                break;
            }
        }

        #endregion

        #region vertical

        if (tH.Count < 3)
        {
            tH = new List<Tile>();
        }

        x = startX;
        y = startY;

        while (y > 0)
        {
            if (Manager.TileArray[x, y - 1] != null && Manager.TileArray[x, y - 1].TileColor == TileColor && Manager.TileArray[x, y - 1].TilePiece == TilePiece)
            {
                y--;
            }
            else
            {
                break;
            }
        }

        tV.Add(Manager.TileArray[x, y]);

        while (y < Manager.column - 1)
        {
            if (Manager.TileArray[x, y + 1] != null && Manager.TileArray[x, y + 1].TileColor == TileColor && Manager.TileArray[x, y + 1].TilePiece == TilePiece)
            {
                y++;
                tV.Add(Manager.TileArray[x, y]);
            }
            else
            {
                break;
            }
        }

        if (tV.Count >= 3)
        {
            foreach (Tile t in tV)
            {
                tH.Add(t);
            }
        }

        #endregion

        if (tH.Count >= 3)
        {
            return tH;
        }

        return null;
    }

    public IEnumerator DestroyTile(List<Tile> list)
    {
        yield return new WaitForSeconds(0.4f);
        foreach (Tile t in list)
        {

            if (t != null)
            {
                Destroy(t.gameObject);
                Manager.TileArray[t.X, t.Y] = null;
            }
        }

    }

    public void Fall()
    {
        Manager.TileArray[X, Y] = null;

        while (Y > 0 && Manager.TileArray[X, Y - 1] == null)
        {
            Y--;
        }

        transform.DOLocalMove(new Vector3(X * Manager.Offset, Y * Manager.Offset, 0), 0.4f);
        Manager.TileArray[X, Y] = this;

        if (Y == 0 || Manager.TileArray[X, Y - 1] != null)
        {
            TileToDestroy = Check();

            if (TileToDestroy != null)
            {
                StartCoroutine(DestroyTile(TileToDestroy));
            }
        }

    }

    public void CheckAndDestroy()
    {
        TileToDestroy = Check();

        if (TileToDestroy != null)
        {
            StartCoroutine(DestroyTile(TileToDestroy));
        }
    }
}
