using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public GameObject bullet;
    public int maxBullets;

    private Queue<GameObject> bullets;
    private bool hasDeadZone = false;

    void Start()
    {
        hasDeadZone = !((Screen.width == Screen.safeArea.width) && (Screen.height == Screen.safeArea.height));
        _BuildBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDeadZone)
        {
            switch (Input.deviceOrientation)
            {
                case DeviceOrientation.LandscapeLeft:
                    Score.rectTransform.anchoredPosition = new Vector2(200.0f, 50.0f);
                    break;
                case DeviceOrientation.LandscapeRight:
                    Score.rectTransform.anchoredPosition = new Vector2(175.0f, 50.0f);
                    break;
                case DeviceOrientation.Portrait:
                    Score.rectTransform.anchoredPosition = new Vector2(175.0f, 50.0f);
                    break;
                case DeviceOrientation.Unknown:
                    //Debug.Log("Ooops, device orientation unkown");
                    break;
            }
        }
    }

    private void _BuildBulletPool()
    {
        bullets = new Queue<GameObject>();

        for (int count = 0; count < maxBullets; count++)
        {
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            tempBullet.transform.parent = transform;
            bullets.Enqueue(tempBullet);
        }
    }
    
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bullets.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;

        return newBullet;
    }

    public bool HasBullets()
    {
        return bullets.Count > 0;
    }

    public void ReturnBullet(GameObject mBullet)
    {
        mBullet.SetActive(false);
        bullets.Enqueue(mBullet);
    }
}
