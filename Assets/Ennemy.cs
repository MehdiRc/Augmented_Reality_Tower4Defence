using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour{

    [System.Serializable]
    public class EnemySettings{
        public int boardID;
        public float speed = 1f;
        public float maxHealth;
        public float health;
        public TowerModes.Mode[] weaknesses;
        public TowerModes.Mode[] resistances;

        public EnemySettings(float _speed, float _health){
            speed = _speed;
            maxHealth = _health;
        }
    }
    
    public EnemySettings properties;

    public Image healthbar;

    private Transform target;
    private int wavePointIndex = 0;

    void Start(){
        
        properties.health = properties.maxHealth;
        target = transform.parent.parent.Find("Waypoints").GetChild(0);
    }

    void Update(){
        Vector3 dir = target.position - transform.position;
        transform.Translate((dir.normalized * properties.speed * Time.deltaTime) , Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f){
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint(){
        if (wavePointIndex >= transform.parent.parent.Find("Waypoints").childCount - 1){
            GameMaster.DestroyEnemy(gameObject);
            WaveSpawner.nbEnemiesAlive--;
            GameMaster.life--;
            return;
        } 

        wavePointIndex++;
        target = transform.parent.parent.Find("Waypoints").GetChild(wavePointIndex);
        
    }

    public void TakeDamage(float amount){
        properties.health -= amount;
        healthbar.fillAmount = properties.health/properties.maxHealth;

        if(properties.health <= 0){
            GameMaster.DestroyEnemy(gameObject);
            WaveSpawner.nbEnemiesAlive--;
        }
    }
}
