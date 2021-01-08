using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PileFace : MonoBehaviour
{
    public void Black()
    {
        transform.DORotate(new Vector3(4410, 0, 0), .3f);
    }

    public void White()
    {
        transform.DORotate(new Vector3(4230, 0, 0), .3f);
    }
}
