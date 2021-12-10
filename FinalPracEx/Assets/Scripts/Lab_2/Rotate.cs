using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 rvec = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        rvec.Set(0, 1, -1);
    }

    // Update is called once per frame
    void Update()
    {
        float rotAmount = speed * Time.deltaTime;
        transform.Rotate(rvec, rotAmount);
    }
}
