using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boards : MonoBehaviour
{
    public Transform board1;
    public Transform board2;
    public Transform board3;
    public Transform board4;

    public static Transform[] boards;

    void Awake(){
        boards = new Transform[4];
        boards[0] = board1;
        boards[1] = board2;
        boards[2] = board3;
        boards[3] = board4;
    }
}
