using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float hello;

        hello = UnityEngine.Random.Range(-6f, 6f);
        Debug.Log(hello);

        Vector3 temp = new Vector3(hello, 35, 132);
        transform.position = temp;
        Debug.Log(temp);
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
