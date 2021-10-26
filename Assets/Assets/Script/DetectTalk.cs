using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DetectTalk : MonoBehaviour
{
    float Die = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Die = gameObject.transform.position.y;
        if (Die < 140)
        {
            Invoke("SceneOneEnd", 5);
        }
    }

    public void SceneOneEnd()
    {
        SceneManager.LoadScene("Two");
    }
}
