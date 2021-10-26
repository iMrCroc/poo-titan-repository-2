using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubeslide : MonoBehaviour
{
    public float speed;
    public float speedz;
    public float speedy;
    private float height;
    private float heightz;
    private float heighty;
    private bool rise = false;
    public bool instant;
    // Start is called before the first frame update
    void Start()
    {
        height = transform.position.x;
        heightz = transform.position.z;
        heighty = transform.position.y;
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "character")
        {
            rise = true;
        }

        else
        {
            rise = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rise==true || instant)
        {
            height += speed*Time.deltaTime;
            heightz += speedz * Time.deltaTime;
            heighty += speedy * Time.deltaTime;
            transform.position = new Vector3(height, heighty, heightz);
        }
        
    }
}
