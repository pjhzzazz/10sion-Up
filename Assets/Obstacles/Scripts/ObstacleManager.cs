using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ObstacleManager : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject[] blueLasers;
    public GameObject[] redLasers;


    void Start()
    {
        
    }

    
    void Update()
    {
    }


    public void ToggleBlueLasers()
    {
        foreach (GameObject laser in blueLasers)
        {
            laser.SetActive(!laser.activeSelf);
        }
    }

    public void ToggleRedLasers()
    {
        foreach (GameObject laser in redLasers)
        {
            laser.SetActive(!laser.activeSelf);
        }
    }


}
