using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region 伪单例


    public static GameManager Instance;
    private void Awake()
    {

        Instance = this;

    }

    #endregion


    static bool isRote = false;

    static bool isSetFo = true;

    static int roteIndex = 5;

    static int turnNum = 0;

    static int roteSpeed = 0;

    /// <summary>
    /// 陀螺是否还在旋转
    /// </summary>
    public static bool IsRote { get => isRote; set => isRote = value; }

    /// <summary>
    /// 是否可以滑动陀螺
    /// </summary>
    public static bool IsSetFo { get => isSetFo; set => isSetFo = value; }

    /// <summary>
    /// 陀螺剩余旋转次数
    /// </summary>
    public static int RoteIndex { get => roteIndex; set => roteIndex = value; }

   /// <summary>
   /// 旋转圈数
   /// </summary>
    public static int TurnNum { get => turnNum; set => turnNum = value; }

    /// <summary>
    /// 旋转速度
    /// </summary>
    public static int RoteSpeed { get => roteSpeed; set => roteSpeed = value; }

    void Start()
    {
        
    }



    void Update()
    {
        
    }
}
