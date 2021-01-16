using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileManager : MonoBehaviour
{
    public static event System.Action LaunchCheck;

    public GameManager Game;
    public int row;
    public int column;
    public float Offset;

    public List<GameObject> SpawnablePiece;
    public Tile[,] TileArray;
    public bool SpawnFinished = false;

    [HideInInspector] public Tile SelectedTile = null;
    public bool canPlay = false;


    private void Awake()
    {
        TileArray = new Tile[row, column];
    }

    private void Update()
    {

    }

    public void Fill(bool first)
    {
        StartCoroutine(Fillboard(first));
    }

    public IEnumerator Fillboard(bool first)
    {
        Debug.Log("Fill lunched");
        bool x;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            x = true;
            for (int i = 0; i < column; i++)
            {
                if (TileArray[i, column - 1] == null)
                {
                    x = false;
                    //yield return new WaitForSeconds(0.1f);
                    int rand = Random.Range(0, SpawnablePiece.Count);

                    GameObject inst = Instantiate(SpawnablePiece[rand], new Vector3(transform.position.x + (i * Offset), transform.position.y + ((row - 1) * Offset), transform.position.z), Quaternion.identity);

                    inst.GetComponent<Tile>().X = i;
                    inst.GetComponent<Tile>().Y = row - 1;
                    inst.transform.parent = transform;
                    inst.GetComponent<Tile>().Manager = this;

                    TileArray[i, column - 1] = inst.GetComponent<Tile>();
                }

            }
            if (x)
            {
                if (!Game.playerTurn && !first)
                    Game.ShowEndTurnUI();
                else
                    canPlay = true; //attaque de l'enemi
                break;
            }
        }
    }

    public IEnumerator Spawn()
    {
        float posX = transform.position.x;

        for (int i = 0; i < row; i++)
        {
            float posY = transform.position.y;

            for (int j = 0; j < column; j++)
            {

                int rand = Random.Range(0, SpawnablePiece.Count);

                GameObject inst  = Instantiate(SpawnablePiece[rand], new Vector3(posX, posY, transform.position.z), Quaternion.identity);


                inst.GetComponent<Tile>().X = i;
                inst.GetComponent<Tile>().Y = j;
                inst.transform.parent = transform;
                inst.GetComponent<Tile>().Manager = this;

                TileArray[i, j] = inst.GetComponent<Tile>();

                posY += Offset;

                yield return new WaitForSeconds(0.02f);
            }
            posX += Offset;
        }

        SpawnFinished = true;
        LaunchCheck?.Invoke();

        Fill(true);
    }
}
