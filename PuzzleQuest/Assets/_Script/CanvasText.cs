using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour
{
    public GameManager manager;
    public Text text;
    public float speed = 0.08f;
    bool map = false;

    public void ShowText(string txt, bool next)
    {
        string s = "";
        foreach(char c in txt)
        {
            s += c;
            text.text = s;
        }
        map = next;
    }

    public void Button()
    {
        if (!map)
        {
            manager.Ui.Show("PileFace");
            manager.Piece.SetActive(true);

            gameObject.SetActive(false);
        }
        else
        {
            manager.map.gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
