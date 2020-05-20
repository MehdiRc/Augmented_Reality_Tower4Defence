using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Wave{

    [System.Serializable]
    public class EnemyWave{
        public Transform prefab;
        public float count;
        public float rate;
    }

    [System.Serializable]
    public class BoardWave{
        public EnemyWave[] enemyGroup;
    }

    public BoardWave[] waveBoards = new BoardWave[4];

    public Wave(){
        waveBoards = new BoardWave[4];
    }

}
