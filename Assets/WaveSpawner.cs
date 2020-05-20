using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour{

    public static Transform[] boards;

    public Wave[] waves;

    public float timeBetweenWaves = 5f;
    public static float countdown = 10f;

    public Text waveInfo;
    public static int waveIndex = 1;

    public static int nbEnemiesAlive = 0;


    void Update(){
        if(GameMaster.onMenu){
            return;
        }

        boards = new Transform[4] {GameMaster.gameBoard.Find("Board1"),GameMaster.gameBoard.Find("Board2"),GameMaster.gameBoard.Find("Board3"),GameMaster.gameBoard.Find("Board4")};

        
        if (nbEnemiesAlive > 0){
            waveInfo.text = "Enemies left : " + nbEnemiesAlive;
            return;
        }

        if (countdown <= 0f){
            SpawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveInfo.text = "Next wave in : " + Mathf.Floor(countdown).ToString();
        
    }

    void SpawnWave(){

        Wave actualWave = waves[waveIndex-1];

        for (int i = 0; i < actualWave.waveBoards.Length; i++){
            StartCoroutine(SpawnEnemyGroup(actualWave.waveBoards[i], i));
        }   

        waveIndex++;
        if (waveIndex > waves.Length){
            waveIndex=1;
        }
    }

    IEnumerator SpawnEnemyGroup(Wave.BoardWave boardWave, int boardNum){
        for (int i = 0; i < boardWave.enemyGroup.Length; i++){
            for (int j = 0; j < boardWave.enemyGroup[i].count; j++){
                SpawnEnnemy(boardWave.enemyGroup[i].prefab, boardNum);
                yield return new WaitForSeconds(1f/boardWave.enemyGroup[i].rate);
            }        
        }
    }

    void SpawnEnnemy(Transform prefab, int BoardNum){
        
        Transform enemyObj = Instantiate(prefab, Boards.boards[BoardNum].Find("Level").Find("spawnPoint").position, Boards.boards[BoardNum].Find("Level").Find("spawnPoint").rotation);
        enemyObj.transform.parent = Boards.boards[BoardNum].Find("Enemies");

        Ennemy enemy = enemyObj.GetComponent<Ennemy>();
        enemy.properties.boardID = BoardNum;
        enemyObj.GetComponent<Renderer>().enabled = false;
        GameMaster.boardGraphics.addRenderer(enemyObj.GetComponent<Renderer>(), enemy.properties.boardID);
        nbEnemiesAlive++;
        
    }

    public static void reset(){
        waveIndex = 1;
        nbEnemiesAlive = 0;
        countdown = 10f;
    }
}
