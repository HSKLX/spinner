using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    Text roteIndex;

    Text roteSpeed;

    Text turnNum;

    void Start()
    {
        roteIndex = transform.Find("RoteIndex").GetComponent<Text>();
        roteSpeed = transform.Find("RoteSpeed").GetComponent<Text>();
        turnNum = transform.Find("TurnNum").GetComponent<Text>();

    }



    void Update()
    {
        roteIndex.text = "剩余滑动次数：" + GameManager.RoteIndex;

        turnNum.text = "圈数：" + GameManager.TurnNum;

        roteSpeed.text = "旋转速度："+ GameManager.RoteSpeed + "/min";

    }
}
