using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour{

    public Camera _cam;
    public static Camera cam;

    public Transform _gameBoard;
    public static Transform gameBoard;
    public static GraphicsHandler boardGraphics;
    public static OrientationTracker boardOrientationTracker;
    
    public GameObject _menu;
    public GameObject _gameInfo;
    public GameObject _victoryScreen;
    public static bool onMenu = true;

    public static GameObject menu;
    public static GameObject gameInfo;
    public static GameObject victoryScreen;

    public int _life = 10;
    public static int life;
    public static int maxLife;
    public Text lifeText;

    public void menuStart(){
        onMenu = false;
        menu.SetActive(false);
        gameInfo.SetActive(true);
    }

    void Awake(){
        cam = _cam;
        gameBoard = _gameBoard;
        menu = _menu;
        gameInfo = _gameInfo;
        victoryScreen = _victoryScreen;

        boardGraphics = gameBoard.GetComponent<GraphicsHandler>();
        boardOrientationTracker = gameBoard.GetComponent<OrientationTracker>();
        gameInfo.SetActive(false);
        victoryScreen.SetActive(false);
        life = _life;
        maxLife = _life;
    }

    void Update(){
        lifeText.text = ": " + life;
        if (life <= 0){
            lose();
        }
    }

    public static void win(){
        gameInfo.SetActive(false);
        victoryScreen.SetActive(true);
    }

    public static void lose(){
        WaveSpawner.reset();
        life = maxLife;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void DestroyEnemy(GameObject enemyObj){
        Ennemy enemy = enemyObj.GetComponent<Ennemy>();
        boardGraphics.removeRenderer(enemyObj.GetComponent<Renderer>(), enemy.properties.boardID);
        Destroy(enemyObj);
    }

    public static void DestroyBullet(GameObject bulletObj){
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        boardGraphics.removeRenderer(bulletObj.GetComponent<Renderer>(), bullet.boardID);
        Destroy(bulletObj);
    }
}
