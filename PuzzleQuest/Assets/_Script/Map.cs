using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameManager manager;

    public List<GameObject> Buttons = new List<GameObject>();
    public List<GameObject> Opps = new List<GameObject>();

    public int index = 0;

    private void Start()
    {
        foreach (GameObject g in Buttons)
        {
            g.SetActive(false);
        }
        Buttons[index].SetActive(true);
    }

    public void Button()
    {
        manager.opps = Opps[index].GetComponent<Opponent>();
        Buttons[index].SetActive(false);
        Buttons[index + 1].SetActive(true);
        gameObject.SetActive(false);

        manager.Text.gameObject.SetActive(true);
        manager.Text.ShowText(Opps[index].GetComponent<Opponent>().EntryLine, false);
        index++;
    }

}
