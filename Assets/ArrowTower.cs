using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowTower : MonoBehaviour{

    public GraphicsHandler graphics;

    private Transform[] targets;
    private GameObject[] lines;
    private TowerProperties properties;

    private float[] fireCountdown;
    private Transform firePoint;
    
    public TowerModes.Orientation towerOrientation;
    public TowerModes.Orientation worldOrientation;

    /* public float[] boardRanges;
    public float[] boardFireRates;
    public float[] boardDamages;
    public GameObject[] boardBulletPrefabs; */

    public int shift = 0;

    // Start is called before the first frame update
    void Start(){


        properties = transform.GetComponent<TowerProperties>();
        graphics = GameMaster.boardGraphics;

        targets = new Transform[Boards.boards.Length];
        lines = new GameObject[Boards.boards.Length];
        fireCountdown = new float[Boards.boards.Length];
        firePoint = transform.Find("FirePoint");

       
        
        /* boardRanges = new float[4];
        boardFireRates = new float[4];
        boardDamages = new float[4];
        boardBulletPrefabs = new GameObject[4]; */

        /* for (int i = 0; i < lines.Length; i++){
            lines[i] = new GameObject();
            lines[i].transform.position = transform.position;
            lines[i].AddComponent<LineRenderer>();
            LineRenderer lr = lines[i].GetComponent<LineRenderer>();
            lr.startColor = Color.red;
            lr.endColor = Color.red;
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            lr.SetPosition(0, firePoint.position);
            lr.SetPosition(1, firePoint.position);  
        }  */


        
        InvokeRepeating ("UpdateTarget", 1f, 0.5f);
    }

    void UpdateTarget (){

        for (int i = 0; i < Boards.boards.Length; i++){

            Transform[] enemies = Array.FindAll(Boards.boards[i].Find("Enemies").GetComponentsInChildren<Transform>(), child => child != Boards.boards[i].Find("Enemies") && child.tag == "enemyTag");

            float shortestDistance = Mathf.Infinity;
            Transform nearestEnemy = null;

            foreach (Transform enemy in enemies){
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance){
                    shortestDistance = distanceToEnemy;
                    nearestEnemy  = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= properties.ranges[(i+shift)%4]){
                targets[i] = nearestEnemy.transform;
            } else {
                targets[i] = null;
            }
        }
        
        
    }

    // Update is called once per frame
    void Update(){

        towerOrientation = transform.parent.GetComponent<OrientationTracker>().imageOrientation;
        worldOrientation = GameMaster.boardOrientationTracker.imageOrientation;

        adaptPropertiesToWorld();

        for (int i = 0; i < Boards.boards.Length; i++){
            if (targets[i] != null && properties.bulletPrefabs[(i+shift)%4] != null){
                /* lines[i].GetComponent<LineRenderer>().SetPosition(1, targets[i].position); */
            
                if (fireCountdown[i] <= 0f){
                    Shoot(targets[i], properties.bulletPrefabs[(i+shift)%4], i);
                    fireCountdown[i] = 1f/properties.fireRates[(i+shift)%4];
                }

                fireCountdown[i] -= Time.deltaTime;
            
            } else {
                /* lines[i].GetComponent<LineRenderer>().SetPosition(1, firePoint.position); */
            } 
        }

        
    }

    void adaptPropertiesToWorld(){
        //same orientation
        if (towerOrientation == worldOrientation){
            //assignPropertiesToWorld(0);
            shift = 0;
        //shift of 1
        } else if((towerOrientation == TowerModes.Orientation.SOUTH && worldOrientation == TowerModes.Orientation.EAST) ||
                  (towerOrientation == TowerModes.Orientation.EAST  && worldOrientation == TowerModes.Orientation.NORTH) ||
                  (towerOrientation == TowerModes.Orientation.WEST  && worldOrientation == TowerModes.Orientation.SOUTH) ||
                  (towerOrientation == TowerModes.Orientation.NORTH && worldOrientation == TowerModes.Orientation.WEST)){
            //assignPropertiesToWorld(1);
            shift = 3;
        //shift of 2
        } else if((towerOrientation == TowerModes.Orientation.SOUTH && worldOrientation == TowerModes.Orientation.NORTH) ||
                  (towerOrientation == TowerModes.Orientation.EAST  && worldOrientation == TowerModes.Orientation.WEST) ||
                  (towerOrientation == TowerModes.Orientation.WEST  && worldOrientation == TowerModes.Orientation.EAST) ||
                  (towerOrientation == TowerModes.Orientation.NORTH && worldOrientation == TowerModes.Orientation.SOUTH)){
            //assignPropertiesToWorld(2);
            shift = 2;
        //shift of 3
        } else if((towerOrientation == TowerModes.Orientation.SOUTH && worldOrientation == TowerModes.Orientation.WEST) ||
                  (towerOrientation == TowerModes.Orientation.EAST  && worldOrientation == TowerModes.Orientation.SOUTH) ||
                  (towerOrientation == TowerModes.Orientation.WEST  && worldOrientation == TowerModes.Orientation.NORTH) ||
                  (towerOrientation == TowerModes.Orientation.NORTH && worldOrientation == TowerModes.Orientation.EAST)){
            //assignPropertiesToWorld(3);
            shift = 1;
        }
    }

   /*  void assignPropertiesToWorld(int shift){
        for (int i = 0; i < 4; i++){
            boardRanges[i] = properties.ranges[(i+shift)%4];
            boardFireRates[i] = properties.fireRates[(i+shift)%4];
            boardDamages[i] = properties.damages[(i+shift)%4];
            boardBulletPrefabs[i] = properties.bulletPrefabs[(i+shift)%4];
        }
    } */

    void Shoot(Transform target, GameObject bulletType, int boardNum){
        GameObject bulletGO = (GameObject)Instantiate(bulletType, firePoint.position, firePoint.rotation);
        bulletGO.transform.parent = WaveSpawner.boards[boardNum].Find("Projectiles");
      
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null){
            bullet.boardID = boardNum;
            bullet.Seek(target);
        }
        bulletGO.transform.GetComponent<Renderer>().enabled = false;
        graphics.addRenderer(bulletGO.transform.GetComponent<Renderer>(), boardNum);
    }

    void OnDrawGizmosSelected(){
        if (properties != null){
            for (int i = 0; i < Boards.boards.Length; i++){
                switch (properties.modes[i]){
                    case TowerModes.Mode.Arrow:
                        Gizmos.color = Color.green;
                        break;
                    case TowerModes.Mode.Bombard:
                        Gizmos.color = Color.black;
                        break;
                    case TowerModes.Mode.Fire:
                        Gizmos.color = Color.red;
                        break;
                    case TowerModes.Mode.Water:
                        Gizmos.color = Color.blue;
                        break; 
                    default:
                        break;
                }
            Gizmos.DrawWireSphere(transform.position, properties.ranges[i]);
            }  
        }
        
    }
}
