using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower3 : MonoBehaviour{

    

    private Transform[] targets;
    private GameObject[] lines;
    private TowerProperties properties;

    private float[] fireCountdown;
    private Transform firePoint;
    

    // Start is called before the first frame update
    void Start(){

        properties = transform.GetComponent<TowerProperties>();

        targets = new Transform[Boards.boards.Length];
        lines = new GameObject[Boards.boards.Length];
        fireCountdown = new float[Boards.boards.Length];
        firePoint = transform.parent.Find("FirePoint");


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
        } */


        
        InvokeRepeating ("UpdateTarget", 0f, 0.5f);
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

            if (nearestEnemy != null && shortestDistance <= properties.ranges[i]){
                targets[i] = nearestEnemy.transform;
            } else {
                targets[i] = null;
            }
        }
        
        
    }

    // Update is called once per frame
    void Update(){

        for (int i = 0; i < Boards.boards.Length; i++){
            if (targets[i] != null){
                //lines[i].GetComponent<LineRenderer>().SetPosition(1, targets[i].position);
            
                if (fireCountdown[i] <= 0f){
                    Shoot(targets[i], properties.bulletPrefabs[i]);
                    fireCountdown[i] = 1f/properties.fireRates[i];
                }

                fireCountdown[i] -= Time.deltaTime;
            
            } /* else {
                lines[i].GetComponent<LineRenderer>().SetPosition(1, firePoint.position);
            } */
        }

        
    }

    void Shoot(Transform target, GameObject bulletType){
        GameObject bulletGO = (GameObject)Instantiate(bulletType, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null){
            bullet.Seek(target);
        }
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
