using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;

    public float rotatespeed;

    void LateUpdate()
    {
        transform.position = target.position;

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.RotateAround(target.position, Vector3.up, rotatespeed * Time.deltaTime);
        }
    }



}
