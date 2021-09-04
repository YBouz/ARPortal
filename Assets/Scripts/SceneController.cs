using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void loadPolyscape()
    {
        SceneManager.LoadScene(1);
    }

    public void loadUnderwater()
    {
        SceneManager.LoadScene(2);
    }
    
    public void loadDreamscape()
    {
        SceneManager.LoadScene(3);
    }

    public void loadInfinity()
    {
        SceneManager.LoadScene(4);
    }

    public void loadStayHome()
    {
        SceneManager.LoadScene(5);
    }
}
