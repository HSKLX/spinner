using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    Rigidbody2D rig;

    public float foK;//旋转速度系数

    public float rigAVK;//旋转阻力系数

    public float minRigAVK;//最小旋转阻力系数

    public float maxSpeed;//最大旋转速度

    float turnAng =0;

    //public float maxFo;//最大旋转力


    public void AddFo(Vector3 fr)
    {
        Debug.Log("fr" + fr);

        //if (fo>maxFo)
        //{
        //    fo = maxFo;
        //}

        fr *= (foK*0.02f);

        //限制最大速度
        rig.AddTorque(fr.z,ForceMode2D.Impulse);
        if (Mathf.Abs(rig.angularVelocity) > maxSpeed)
        {
            if (rig.angularVelocity > 0)
            {
                rig.angularVelocity = maxSpeed;

            }
            else
            {
                rig.angularVelocity = -maxSpeed;

            }

        }

        Debug.Log("rig.angularVelocity" + rig.angularVelocity);

    }


    //public void AddFo(float fo)
    //{
    //    Debug.Log("fo" + fo);

    //    //if (fo>maxFo)
    //    //{
    //    //    fo = maxFo;
    //    //}

    //    fo *= foK;

    //    //限制最大速度
    //    if (Mathf.Abs(rig.angularVelocity + fo)>maxSpeed)
    //    {
    //        if (rig.angularVelocity>0)
    //        {
    //            rig.angularVelocity = maxSpeed;

    //        }
    //        else
    //        {
    //            rig.angularVelocity = -maxSpeed;

    //        }

    //    }
    //    else
    //    {
    //        rig.angularVelocity += fo;

    //    }

    //    Debug.Log("rig.angularVelocity" + rig.angularVelocity);

    //}




    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        //rig.angularVelocity = 360;


    }

    void Update()
    {
        if (GameManager.IsRote)
        {
            //旋转圈数
            turnAng += Mathf.Abs(rig.angularVelocity) * Time.deltaTime;

            GameManager.TurnNum =(int)(turnAng) / 360;

            //旋转速度
            GameManager.RoteSpeed = (int)(Mathf.Abs(rig.angularVelocity) * 60 / 360);


            //旋转阻力
            float roteSpeedDif = 0;
            if (rig.angularVelocity < 0)
            {
                roteSpeedDif = rigAVK * Time.deltaTime * Mathf.Max(minRigAVK, Mathf.Abs(rig.angularVelocity));

            }
            else
            {
                roteSpeedDif = -rigAVK * Time.deltaTime * Mathf.Max(minRigAVK,Mathf.Abs(rig.angularVelocity));
            }
            rig.angularVelocity += roteSpeedDif;


            //旋转速度过小停下
            if (Mathf.Abs(rig.angularVelocity) <= 5)
            {

                rig.angularVelocity = 0;

                GameManager.IsRote = false;

                GameManager.IsSetFo = true;

                GameManager.RoteIndex = 5;

                GameManager.RoteSpeed = 0;

                turnAng = 0;

                GameObject.Find("Canvas").transform.Find("EndPanel").gameObject.SetActive(true);
            }
        }
            
    }
}
