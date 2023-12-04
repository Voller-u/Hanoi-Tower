using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plate : MonoBehaviour
{
    public enum STATE
    {
        idle,
        selected,
        moving,
    }
    public STATE state = STATE.idle;
    public int size;
    public Text text_size;
}
