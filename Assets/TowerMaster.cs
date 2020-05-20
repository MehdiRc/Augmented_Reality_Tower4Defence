using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaster : MonoBehaviour
{
    [System.Serializable]
    public class Tower{
        public float range;
        public float fireRate;
        public float damage;
        public GameObject bullet;

        public Tower(float _range, float _fireRate, float _damage, GameObject _bullet){
            range = _range;
            fireRate = _fireRate;
            damage = _damage;
            bullet = _bullet;
        }
    }


    [Header("Tower Settings")]

    public Tower _ArrowTower;
    public Tower _BombardTower;
    public Tower _FireTower;
    public Tower _WaterTower;

    public static Tower ArrowTower;
    public static Tower BombardTower;
    public static Tower FireTower;
    public static Tower WaterTower;

    void Awake(){
        ArrowTower = _ArrowTower;
        BombardTower = _BombardTower;
        FireTower = _FireTower;
        WaterTower = _WaterTower;
    }
}
