using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece
{
    public Tile.Piece type;
    public int Life;
    public int Attack;
    public bool Alive = true;
    public float atkLevel;

}

public class Pion : Piece
{
    public Pion()
    {
        type = Tile.Piece.Pion;
        Life = 100;
        Attack = 45;

        atkLevel = 0;
    }
}

public class Tour : Piece
{
    public Tour()
    {
        type = Tile.Piece.Tour;
        Life = 150;
        Attack = 25;

        atkLevel = 0;
    }
}

public class Dame : Piece
{
    public Dame()
    {
        type = Tile.Piece.Dame;
        Life = 50;
        Attack = 65;

        atkLevel = 0;
    }
}

public class Fou : Piece
{
    public Fou()
    {
        type = Tile.Piece.Fou;
        Life = 75;
        Attack = 45;

        atkLevel = 0;
    }
}

public class Cavalier : Piece
{
    public Cavalier()
    {
        type = Tile.Piece.Cavalier;
        Life = 75;
        Attack = 35;

        atkLevel = 0;
    }
}

