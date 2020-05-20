using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrientationTracker : MonoBehaviour
{

    public Camera cam;
    //public Text rotationText;

    [HideInInspector]
    public float imageAngle = 0;
    [HideInInspector]
    public TowerModes.Orientation imageOrientation = TowerModes.Orientation.SOUTH;

    void Start(){
        
    }

    void Update(){
        var forwardA = cam.transform.rotation * Vector3.forward;
        var forwardB = transform.rotation * Vector3.forward; 

        var angleA = Mathf.Atan2(forwardA.x, forwardA.z)*  Mathf.Rad2Deg;
        var angleB = Mathf.Atan2(forwardB.x, forwardB.z)*  Mathf.Rad2Deg;

        var angleDiff = Mathf.DeltaAngle( angleA, angleB );
        imageAngle = angleDiff;
        //rotationText.text = "Rotation : " + Mathf.Floor(imageAngle).ToString();

        if (imageAngle >= (-45f) && imageAngle <= 45f ){
            imageOrientation = TowerModes.Orientation.SOUTH;
        } else if (imageAngle > 45f && imageAngle <= 135f ) {
            imageOrientation = TowerModes.Orientation.EAST;
        } else if (imageAngle < (-45f) && imageAngle >= (-135f) ) {
            imageOrientation = TowerModes.Orientation.WEST;
        } else if (imageAngle < (-135f) || imageAngle > 135f) {
            imageOrientation = TowerModes.Orientation.NORTH;      
        }
    }
}
