using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    
    private Transform target;

    public float speed = 50f;
    public float damage = 1f;
    public int boardID;
    public TowerModes.Mode type;

    private float weakMultiplier = 5f;

    public void Seek(Transform _target){
        target = _target;
    }

    // Update is called once per frame
    void Update(){
        if (target==null){
            GameMaster.DestroyBullet(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget(){
        float effectiveDamage = damage;

        foreach (TowerModes.Mode w in target.GetComponent<Ennemy>().properties.weaknesses){
            if (type == w){
                effectiveDamage *= weakMultiplier;
            }
        }
        foreach (TowerModes.Mode r in target.GetComponent<Ennemy>().properties.resistances){
            if (type == r){
                effectiveDamage = 1f; 
            }
        }

        target.GetComponent<Ennemy>().TakeDamage(effectiveDamage);
        GameMaster.DestroyBullet(gameObject);
    }
}
