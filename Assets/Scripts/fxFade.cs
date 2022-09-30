using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxFade : MonoBehaviour
{
    private float rotSpd;
    private void Start()
    {
        rotSpd = Random.Range(-30, 30);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotSpd*Time.deltaTime));
        Destroy(gameObject, 1);
    }
}
