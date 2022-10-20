using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndPanel : MonoBehaviour
{



    void Start()
    {
        transform.Find("ExitBtn").GetComponent<Button>().onClick.AddListener(OnExitBtnClick);
    }

    private void OnEnable()
    {
        transform.Find("MessageImage/Text").GetComponent<Text>().text = "你转了"+GameManager.TurnNum+"圈！";
    }

    void OnExitBtnClick()
    {
        gameObject.SetActive(false);

        GameManager.TurnNum = 0;
    }


    void Update()
    {
        
    }
}
