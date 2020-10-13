using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;
    public float maxVelocityX = 3.0f;
    public float drag = 0.98f;
    public float horizontalBounds = 3.10f;
    public Rigidbody2D rb2D;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) // touch found
        {
            var touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (touchPos.x > transform.position.x)
            {
                rb2D.velocity = _Move(1.0f);
            }
            if (touchPos.x < transform.position.x)
            {
                rb2D.velocity = _Move(-1.0f);
            }
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            //moveRight
            rb2D.velocity = _Move(1.0f);
        }
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            //moveLeft
            rb2D.velocity = _Move(-1.0f);
        }

        rb2D.velocity *= drag;
        _CheckBounds();

        //Fire
        if (Time.frameCount % 30 == 0 && gameController.HasBullets())
        {
            gameController.GetBullet(transform.position);
        }
    }
    private Vector2 _Move(float direction)
    {
        //Debug.Log(rb2D.velocity);
        return Vector2.ClampMagnitude(rb2D.velocity + new Vector2(speed * direction, 0.0f), maxVelocityX);
    }

    private void _CheckBounds()
    {
        //check left bound
        if (transform.position.x <= -horizontalBounds)
        {
            transform.position = new Vector3(-horizontalBounds, transform.position.y, transform.position.z);
        }
        //check right bound
        if (transform.position.x >= horizontalBounds)
        {
            transform.position = new Vector3(horizontalBounds, transform.position.y, transform.position.z);
        }

    }
}
