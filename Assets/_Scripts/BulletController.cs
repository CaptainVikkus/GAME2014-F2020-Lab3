using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 1.0f;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        _CheckBounds();
    }

    private void _CheckBounds()
    {
        if (transform.position.y > 5.0f)
        {
            //Debug.Log("Moving Bullet" + gameObject.name);
            //Debug.Log("Dummy: " + gameController.GetDummy());
            gameController.ReturnBullet(gameObject);
        }
    }
}
