using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    ARPlaneManager m_ARPlaneManager;

    public Text buttontext;



    private void Awake()
    {
        m_ARPlaneManager = GetComponent<ARPlaneManager>();
    }

    public void TogglePlaneDetectionAndVisibility()
    {
        m_ARPlaneManager.enabled = !m_ARPlaneManager.enabled;

        if (m_ARPlaneManager.enabled)
        {
            SetAllPlanesActiveOrDeactive(true);
            GetComponent<PortalPlacer>().enabled = true;

            buttontext.text = "Disable";

        }else
        {
            SetAllPlanesActiveOrDeactive(false);
            GetComponent<PortalPlacer>().enabled = false;

            buttontext.text = "Enable";


        }
    }

        

        void SetAllPlanesActiveOrDeactive(bool value)
        {
            foreach(var plane in m_ARPlaneManager.trackables)
            {
                plane.gameObject.SetActive(value);
            }

        }

}
