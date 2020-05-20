using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Update is called once per frame
    void Update(){
        transform.rotation = GameMaster.cam.transform.rotation;
    }
}
