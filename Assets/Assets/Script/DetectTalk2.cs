using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetectTalk2 : MonoBehaviour
{
    public AudioClip speak;
    public AudioClip fall;
    private Vector3 ryan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ryan = transform.position;
        if (ryan.y < 100)
        {
            SceneManager.LoadScene("Three");

        }

    }
} 