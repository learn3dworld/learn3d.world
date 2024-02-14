using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkyObj : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgroundShapes;

    [SerializeField]
    private double spawnRadius;

    [SerializeField]
    private double spawnFrequency;
    
    // Start is called before the first frame update
    void Start()
    {
        double d_theta_xy = 360 / spawnFrequency;
     
        for (double theta =0; theta < 360; theta += d_theta_xy)
        {
            double x_pos = Math.Cos(theta) * spawnRadius;
            double y_pos = Math.Sin(theta) * spawnRadius;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
