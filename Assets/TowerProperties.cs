using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProperties : MonoBehaviour{

    public TowerModes.Mode faceSouth;
    public TowerModes.Mode faceEast;
    public TowerModes.Mode faceWest;
    public TowerModes.Mode faceNorth;

    [HideInInspector]
    public TowerModes.Mode[] modes;

    public float[] ranges;
    public float[] fireRates;
    public float[] damages;
    public GameObject[] bulletPrefabs;

    void Start(){
        modes = new TowerModes.Mode[4];
        modes[0] = faceSouth;
        modes[1] = faceWest;
        modes[2] = faceNorth;
        modes[3] = faceEast;

        ranges = new float[4];
        fireRates = new float[4];
        damages = new float[4];
        bulletPrefabs = new GameObject[4];

        for (int i = 0; i < modes.Length; i++){
            switch (modes[i]){
                case TowerModes.Mode.Arrow:
                    ranges[i] = TowerMaster.ArrowTower.range;
                    fireRates[i] =TowerMaster.ArrowTower.fireRate;
                    damages[i] = TowerMaster.ArrowTower.damage;
                    bulletPrefabs[i] = TowerMaster.ArrowTower.bullet;
                    break;
                case TowerModes.Mode.Bombard:
                    ranges[i] = TowerMaster.BombardTower.range;
                    fireRates[i] =TowerMaster.BombardTower.fireRate;
                    damages[i] = TowerMaster.BombardTower.damage;
                    bulletPrefabs[i] = TowerMaster.BombardTower.bullet;
                    break;
                case TowerModes.Mode.Fire:
                    ranges[i] = TowerMaster.FireTower.range;
                    fireRates[i] =TowerMaster.FireTower.fireRate;
                    damages[i] = TowerMaster.FireTower.damage;
                    bulletPrefabs[i] = TowerMaster.FireTower.bullet;
                    break;
                case TowerModes.Mode.Water:
                    ranges[i] = TowerMaster.WaterTower.range;
                    fireRates[i] =TowerMaster.WaterTower.fireRate;
                    damages[i] = TowerMaster.WaterTower.damage;
                    bulletPrefabs[i] = TowerMaster.WaterTower.bullet;
                    break;
                default:
                    break;
            }
        }
    }

}
