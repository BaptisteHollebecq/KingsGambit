using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public TileManager Board;

    public void BasicPlay()
    {
        Debug.Log("IA's playing");
        foreach (Tile t in Board.TileArray)
        {
            if (t.X != 0)
            {
                Tile tx = Board.TileArray[t.X - 1, t.Y];
                t.Swap(tx);
                t.TileToDestroy = t.Check();
                tx.TileToDestroy = tx.Check();

                if (t.TileToDestroy != null || tx.TileToDestroy != null)
                {
                    t.Manager.Game.playerTurn = true;
                    if (t.TileToDestroy != null)
                    {
                        StartCoroutine(t.DestroyTile(t.TileToDestroy));
                    }
                    if (tx.TileToDestroy != null)
                    {
                        StartCoroutine(tx.DestroyTile(tx.TileToDestroy));
                    }
                    break;
                }
                else
                {
                    t.Swap(tx);
                }

            }
            if (t.X != Board.column-1)
            {
                Tile tx = Board.TileArray[t.X + 1, t.Y];
                t.Swap(tx);
                t.TileToDestroy = t.Check();
                tx.TileToDestroy = tx.Check();

                if (t.TileToDestroy != null || tx.TileToDestroy != null)
                {
                    t.Manager.Game.playerTurn = true;
                    if (t.TileToDestroy != null)
                    {
                        StartCoroutine(t.DestroyTile(t.TileToDestroy));
                    }
                    if (tx.TileToDestroy != null)
                    {
                        StartCoroutine(tx.DestroyTile(tx.TileToDestroy));
                    }
                    break;
                }
                else
                {
                    t.Swap(tx);
                }

            }
            if (t.Y != 0)
            {
                Tile tx = Board.TileArray[t.X , t.Y - 1];
                t.Swap(tx);
                t.TileToDestroy = t.Check();
                tx.TileToDestroy = tx.Check();

                if (t.TileToDestroy != null || tx.TileToDestroy != null)
                {
                    t.Manager.Game.playerTurn = true;
                    if (t.TileToDestroy != null)
                    {
                        StartCoroutine(t.DestroyTile(t.TileToDestroy));
                    }
                    if (tx.TileToDestroy != null)
                    {
                        StartCoroutine(tx.DestroyTile(tx.TileToDestroy));
                    }
                    break;
                }
                else
                {
                    t.Swap(tx);
                }

            }
            if (t.Y != Board.row-1)
            {
                Tile tx = Board.TileArray[t.X, t.Y + 1];
                t.Swap(tx);
                t.TileToDestroy = t.Check();
                tx.TileToDestroy = tx.Check();

                if (t.TileToDestroy != null || tx.TileToDestroy != null)
                {
                    t.Manager.Game.playerTurn = true;
                    if (t.TileToDestroy != null)
                    {
                        StartCoroutine(t.DestroyTile(t.TileToDestroy));
                    }
                    if (tx.TileToDestroy != null)
                    {
                        StartCoroutine(tx.DestroyTile(tx.TileToDestroy));
                    }
                    break;
                }
                else
                {
                    t.Swap(tx);
                }

            }
        }
    }

}
