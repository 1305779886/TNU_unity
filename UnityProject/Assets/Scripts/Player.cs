using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // private 私人
    // publice 公开
    [Header("速度")][Range(0f,100f)]
    public float speed = 3.5f;      //浮点
    [Header("跳跃"),Range(100,2000)]
    public int jump = 300;          //整数
    [Header("是否在地板上"),Tooltip("用来判定角色是否在地板上。")]
    public bool isGround = false;   //布林 -true、false
    [Header("角色名称")]
    public string _name = "KID";    //字符串
}
