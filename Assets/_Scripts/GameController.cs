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

    private Queue<GameObject> bullets = new Queue<GameObject>();
    private Queue<int> dummy = new Queue<int>();
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
        for (int count = 0; count < maxBullets; count++)
        {
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            bullets.Enqueue(tempBullet);
            dummy.Enqueue(Random.Range(0, 20));
        }
    }
    
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bullets.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;

        return newBullet;
    }

    public void ReturnBullet(GameObject mBullet)
    {
        mBullet.SetActive(false);
        bullets.Enqueue(mBullet);
    }

    public int GetDummy()
    {
        return dummy.Dequeue();
    }

    public void ReturnDummy(int i)
    {
        dummy.Enqueue(i);
        Debug.Log("Dummy: " + i);
    }
}
