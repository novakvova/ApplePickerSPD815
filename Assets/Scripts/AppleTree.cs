using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject applePrefab;

    public float speed = 1f; //швидк≥сть
    public float leftAndRightEdge = 10f; //меж≥
    public float changeToChangeDirections = 0.1f; //≥мов≥рн≥сть зм≥ни напр€мку
    public float secondBetweenAppleDrops = 1f; //1 раз в секунду кидаЇмо €блуко

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("----Create apple tree----");
        Invoke("DropApple", 2);
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }
    private void FixedUpdate()
    {
        if (Random.value < changeToChangeDirections)
            speed *= -1;
    }
}
