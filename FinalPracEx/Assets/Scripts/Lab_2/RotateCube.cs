using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public HUDManager hudManager;
    public float speed = 10f;
    private Vector3 rvec = Vector3.one;

    // Update is called once per frame
    void Update()
    {
        float rotAmount = speed * Time.deltaTime;
        hudManager.rotAngle = transform.rotation.y * 180 / Mathf.PI; ;
        transform.Rotate(rvec, rotAmount);
    }
}
