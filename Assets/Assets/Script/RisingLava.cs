using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingLava : MonoBehaviour
{
    public float speed;
    private Vector3 height;
    private bool rise = false;
    public GameObject floor;
    MeshRenderer lava;
    // Start is called before the first frame update
    void Start()
    {
        lava = floor.GetComponent<MeshRenderer>();
        height = floor.transform.position;
        if (PlayerPrefs.GetInt("level") < int.Parse(SceneManager.GetActiveScene().name))
        {
            PlayerPrefs.SetInt("level", int.Parse(SceneManager.GetActiveScene().name));
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            rise = true;
        }

        if (collisionInfo.collider.tag == "STOPPER")
        {
            rise = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rise = true;
        }

        if (other.gameObject.tag == "STOPPER")
        {
            rise = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rise==true)
        {
            height = new Vector3( height.x, height.y+ speed * 0.06f * Time.fixedDeltaTime,height.z);
            floor.transform.position = height;
        }
        else
        {
            height = new Vector3(height.x, height.y + 0f * Time.fixedDeltaTime, height.z);
            floor.transform.position = height;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftShift))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.P) && Input.GetKey(KeyCode.RightShift))
        {
            PlayerPrefs.SetInt("level", 1);
        }
    }
}
