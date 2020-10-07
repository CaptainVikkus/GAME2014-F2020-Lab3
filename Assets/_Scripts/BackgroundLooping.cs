using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class BackgroundLooping : MonoBehaviour
{
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        float verticalSpeed = transform.position.y - speed * Time.deltaTime;
        transform.position= new Vector3(0, verticalSpeed, 0);
    }
    private void _Reset()
    {
        transform.position= new Vector3(0, 10, 0);
    }

    private void _CheckBounds()
    {
        //check bottom bounds
        if (transform.position.y < -10.0f)
        {
            _Reset();
        }
    }
}
