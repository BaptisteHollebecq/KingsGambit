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
    public GameObject Blue;
    public GameObject Red;
    public GameObject Green;
    public GameObject Yellow;
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
        bool check = true;
        foreach(Tile t in TileArray)
        {
            if (t == null)
            {
                check = false;
                break;
            }
        }
        if (check == true)
        {
            canPlay = true;
        }
        else
            canPlay = false;

    }

    private IEnumerator Fill()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < column; i++)
            {
                if (TileArray[i, column - 1] == null)
                {
                    //yield return new WaitForSeconds(0.1f);

                    int rand = Random.Range(0, 4);
                    GameObject inst = null;

                    switch (rand)
                    {
                        case 0:
                            {
                                inst = Instantiate(Blue, new Vector3(transform.position.x + i, transform.position.y + row - 1, transform.position.z), Quaternion.identity);
                                break;
                            }
                        case 1:
                            {
                                inst = Instantiate(Red, new Vector3(transform.position.x + i, transform.position.y + row - 1, transform.position.z), Quaternion.identity);
                                break;
                            }
                        case 2:
                            {
                                inst = Instantiate(Green, new Vector3(transform.position.x + i, transform.position.y + row - 1, transform.position.z), Quaternion.identity);
                                break;
                            }
                        case 3:
                            {
                                inst = Instantiate(Yellow, new Vector3(transform.position.x + i, transform.position.y + row - 1, transform.position.z), Quaternion.identity);
                                break;
                            }
                    }

                    inst.GetComponent<Tile>().X = i;
                    inst.GetComponent<Tile>().Y = row - 1;
                    inst.transform.parent = transform;
                    inst.GetComponent<Tile>().Manager = this;

                    TileArray[i, column - 1] = inst.GetComponent<Tile>();
                }
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

                int rand = Random.Range(0, 4);
                GameObject inst = null;

                switch (rand)
                {
                    case 0:
                        {
                            inst = Instantiate(Blue, new Vector3(posX, posY, transform.position.z), Quaternion.identity);
                            break;
                        }
                    case 1:
                        {
                            inst = Instantiate(Red, new Vector3(posX, posY, transform.position.z), Quaternion.identity);
                            break;
                        }
                    case 2:
                        {
                            inst = Instantiate(Green, new Vector3(posX, posY, transform.position.z), Quaternion.identity);
                            break;
                        }
                    case 3:
                        {
                            inst = Instantiate(Yellow, new Vector3(posX, posY, transform.position.z), Quaternion.identity);
                            break;
                        }
                }

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

        StartCoroutine(Fill());

        SpawnFinished = true;
        LaunchCheck?.Invoke();
    }
}
