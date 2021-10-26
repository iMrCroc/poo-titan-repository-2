using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float DestroyAfterTime;

    private void Start()
    {
        StartCoroutine(destroyOn());
    }

    IEnumerator destroyOn()
    {
        float end = Time.time + DestroyAfterTime;
        while (Time.time < end)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
