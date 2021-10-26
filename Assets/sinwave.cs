using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinwave : MonoBehaviour
{
    public Vector3 localChange;
    public float speed;
    float increment;
    public float offset;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        increment += speed * Time.deltaTime;
        Vector3 change = new Vector3(Mathf.Sin(increment + offset) * localChange.x, Mathf.Sin(increment + offset) * localChange.y, Mathf.Sin(increment + offset) * localChange.z);
        transform.localPosition = pos + change;
    }
}
