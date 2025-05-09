using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRock : MonoBehaviour
{
    public Rigidbody2D _rigidody2D;
    void Start()
    {
        _rigidody2D.simulated = false;
        Invoke("Rolling", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Rolling()
    {
        _rigidody2D.simulated = true;

    }
}
