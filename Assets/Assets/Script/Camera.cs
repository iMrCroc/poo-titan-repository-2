using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject CameraData;
    public GameObject Player;
    public Transform PlayerTransform;
    public Vector3 Distance;
    private Vector3 Location;
    public float sens;
    public float RotationsSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Location = Player.transform.position;
        CameraData.transform.position = Location + Distance;

    }
}
