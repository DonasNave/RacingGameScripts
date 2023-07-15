using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollowScript : MonoBehaviour
{
    public GameObject Car;
    private float carX;
    private float carY;
    private float carZ;

    // Update is called once per frame
    void Update ()
    {
        var eurAngles = Car.transform.eulerAngles;
        carX = eurAngles.x;
        carY = eurAngles.y;
        carZ = eurAngles.z;

        transform.eulerAngles = new Vector3(carX - carX, carY, carZ - carZ);
    }
}
