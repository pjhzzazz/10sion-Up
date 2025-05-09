using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    public GameObject[] blueLasers;
    public GameObject[] redLasers;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ToggleBlueLasers()
    {
        foreach (GameObject laser in blueLasers)
        {
            laser.SetActive(!laser.activeSelf); //�Ķ��� ������ ����
        }
    }

    public void ToggleRedLasers()
    {
        foreach (GameObject laser in redLasers)
        {
            laser.SetActive(!laser.activeSelf);//������ ������ ����
        }
    }

}
