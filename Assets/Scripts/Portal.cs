using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour {
    
    public Material[] materials;
    
    void Start()
    {
        foreach (var mat in materials)
        {
            mat.SetInt("stest", (int)CompareFunction.Equal);
        }
    }
    
    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "MainCamera")
        {
            return;
        }

        Vector3 userPosition = Camera.main.transform.position+Camera.main.transform.forward*Camera.main.nearClipPlane;
        Vector3 relativePosition = transform.InverseTransformPoint(userPosition);


        //outside
        //if (transform.position.z > collider.transform.position.z) {
        if(relativePosition.z < 0) {
            foreach(var mat in materials) {
                mat.SetInt("stest",(int)CompareFunction.Equal);
            }
        }

        //inside
        else {
            foreach (var mat in materials) {
                //mat.SetInt("stest", (int)CompareFunction.NotEqual);
                mat.SetInt("stest", (int)CompareFunction.NotEqual);
            }
        }
    }

}
