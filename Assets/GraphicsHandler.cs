using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GraphicsHandler : MonoBehaviour, ITrackableEventHandler {

    private TrackableBehaviour mTrackableBehaviour;

    public Transform model1;
    public Transform model2;
    public Transform model3;
    public Transform model4;

    public List<Renderer> model1Renderer = new List<Renderer>();
    private List<Renderer> model2Renderer = new List<Renderer>();
    private List<Renderer> model3Renderer = new List<Renderer>();
    private List<Renderer> model4Renderer = new List<Renderer>();

    private bool tracked = false;
    private TowerModes.Orientation orientation;



    private void hide(List<Renderer> renderers){
        foreach(var r in renderers) {
            try{
              r.enabled = false;
              }
            catch (MissingReferenceException e){
                Debug.Log(renderers);
            }
{
}
        }
    }
    private void show(List<Renderer> renderers){
        foreach(var r in renderers) {
            try{
            r.enabled = true;
            }
            catch (MissingReferenceException e){
                Debug.Log(renderers.Count);
            }
        }
    }
    public void addRenderer(Renderer r, int id){
        switch (id){
            case 0:
                model1Renderer.Add(r);
                break;
            case 1:
                model2Renderer.Add(r);
                break;
            case 2:
                model3Renderer.Add(r);
                break;
            case 3:
                model4Renderer.Add(r);
                break;
            default:
                break;
        }
    }
    public void removeRenderer(Renderer r, int id){
        switch (id){
            case 0:
                model1Renderer.Remove(r);
                break;
            case 1:
                model2Renderer.Remove(r);
                break;
            case 2:
                model3Renderer.Remove(r);
                break;
            case 3:
                model4Renderer.Remove(r);
                break;
            default:
                break;
        }
    }



    // Use this for initialization
    void Start (){
        
        foreach (Renderer r in model1.GetComponentsInChildren<Renderer>()){
            model1Renderer.Add(r);
        }
        foreach (Renderer r in model2.GetComponentsInChildren<Renderer>()){
            model2Renderer.Add(r);
        }
        foreach (Renderer r in model3.GetComponentsInChildren<Renderer>()){
            model3Renderer.Add(r);
        }
        foreach (Renderer r in model4.GetComponentsInChildren<Renderer>()){
            model4Renderer.Add(r);
        }

        hide(model1Renderer);
        hide(model2Renderer);
        hide(model3Renderer);
        hide(model4Renderer);

        /* model1.gameObject.SetActive(false);
        model2.gameObject.SetActive(false);
        model3.gameObject.SetActive(false);
        model4.gameObject.SetActive(false); */

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }               

    // Update is called once per frame
    void Update (){
        
        if (tracked && model1!=null && model2!=null && model3!=null && model4!=null){

            orientation = transform.GetComponent<OrientationTracker>().imageOrientation;

            switch (orientation){
                case TowerModes.Orientation.SOUTH:
                    hide(model2Renderer);
                    hide(model3Renderer);
                    hide(model4Renderer);
                    show(model1Renderer);
                    break;

                case TowerModes.Orientation.EAST:
                    hide(model1Renderer);
                    hide(model3Renderer);
                    hide(model4Renderer);
                    show(model2Renderer);
                    break;

                case TowerModes.Orientation.WEST:
                    hide(model1Renderer);
                    hide(model2Renderer);
                    hide(model4Renderer);
                    show(model3Renderer);
                    break;

                case TowerModes.Orientation.NORTH:
                    hide(model1Renderer);
                    hide(model2Renderer);
                    hide(model3Renderer);
                    show(model4Renderer);
                    break;

                default:
                    break;
            }
        }
    }

    public void OnTrackableStateChanged(
              TrackableBehaviour.Status previousStatus,
              TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            tracked = true;
        } else {
            tracked = false;
        }
    }

    /* private void OnTrackingFound()
    {
        if (bombTowerPrefab != null){
            Transform myModelTrf = GameObject.Instantiate(bombTowerPrefab) as Transform;

             myModelTrf.parent = mTrackableBehaviour.transform;             
             myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
             myModelTrf.localRotation = Quaternion.identity;
             myModelTrf.localScale = new Vector3(0.4f, 0.4f, 0.4f);

             myModelTrf.gameObject.SetActive(true);
         }
     } */

     /* private void OnTrackingLost(){
        TrackerObject[] trackers = FindObjectsOfType<TrackerObject>()
        foreach(var t in trackers){ t.SetOff();}
        this.gameObject.GetComponent<TrackerObject>().SetOn();
     } */
}
