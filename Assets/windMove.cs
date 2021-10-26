using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windMove : MonoBehaviour
{
    GameObject objectToMove;
    Rigidbody rbOfObj;

    public AudioSource wind;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("entered");
            objectToMove = other.gameObject;
            rbOfObj = objectToMove.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("left");
            objectToMove = null;
            rbOfObj = null;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        wind.Play();
        wind.time = Random.Range(0f, wind.clip.length);
        objectToMove = null;
        rbOfObj = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(objectToMove!=null && rbOfObj != null)
        {
            rbOfObj.AddForce(transform.forward * Time.deltaTime * 800);
        }
    }
}
