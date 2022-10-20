using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RoteSpinner : MonoBehaviour,IPointerDownHandler,IDragHandler,IEndDragHandler
{
    Transform spinner;

    Vector3 op;

    Vector3 op1;

    Quaternion oq;

    Vector3 nowp1;

    RectTransform rect;

    /// <summary>
    /// 鼠标拖动时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        if (GameManager.IsRote == false)
        {
            Vector2 outPos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect,
                eventData.position, eventData.pressEventCamera, out outPos);

            nowp1 = new Vector3(outPos.x, outPos.y, 0);

            //判断旋转方向
            if (Vector3.Dot(op1, nowp1) >= 0)
            {
                spinner.localRotation = oq * Quaternion.AngleAxis(Vector3.Angle(op, nowp1), Vector3.forward);

            }
            else
            {
                spinner.localRotation = oq * Quaternion.AngleAxis(-Vector3.Angle(op, nowp1), Vector3.forward);

            }
        }
        

    }

    /// <summary>
    /// 鼠标结束拖动时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (GameManager.IsSetFo)
        {
            GameManager.IsRote = true;

            GameManager.RoteIndex -= 1;

            if (GameManager.RoteIndex==0)
            {
                GameManager.IsSetFo = false;
            }

            //获得鼠标移动速度
            float axisX = -Input.GetAxis("Mouse X");
            float axisY = Input.GetAxis("Mouse Y");
            Vector3 mXY = new Vector3(axisX, axisY, 0);

            //旋转力的大小
            Vector3 nowp2 = Quaternion.AngleAxis(90, Vector3.forward) * nowp1.normalized;

            Vector3 fr = nowp2 * (Mathf.Cos(Mathf.Deg2Rad * Vector3.Angle(nowp2, mXY)) * mXY.magnitude);

            float frMag = 0;

            //判断滑动方向
            if (Vector3.Angle(nowp2, mXY) >= 90)
            {
                frMag = fr.magnitude;
            }
            else
            {
                frMag = -fr.magnitude;

            }

            spinner.GetComponent<Spinner>().AddFo(frMag);
        }
  

    }

    /// <summary>
    /// 鼠标点击时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {

        if (GameManager.IsRote == false)
        {
            Vector2 outPos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(rect,
                eventData.position, eventData.pressEventCamera, out outPos);

            op = new Vector3(outPos.x, outPos.y, 0);

            op1 = Quaternion.AngleAxis(90, Vector3.forward) * op;

            oq = spinner.localRotation;
        }
        

    }



    void Start()
    {
        spinner = transform.Find("Spinner");

        rect = transform.Find("Center").GetComponent<RectTransform>();

    }

    void Update()
    {


    }
}
