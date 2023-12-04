using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
