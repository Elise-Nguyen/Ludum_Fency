using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    public float ShowDuration = 1f;
    public float FadeSpeed = 0.05f;
    public float MoveStep = 0.1f;

    GameObject go;

    public void ShowPickupText (string txt)
    {
        go = Instantiate(Resources.Load("PickupText") as GameObject,
            transform.position,
            Quaternion.identity);
    }
}
