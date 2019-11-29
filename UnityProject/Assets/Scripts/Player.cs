using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位區域
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
    [Header("元件")]
    public Rigidbody2D r2d;
    public Animator ani;
    [Header("音效區域")]
    public AudioSource and;
    public AudioClip soundDiamond;
    #endregion
    
    private void Move()
    {
        float h= Input.GetAxisRaw("Horizontal");  //輸入.取得軸向("水平")左右與AD
        r2d.AddForce(new Vector2(speed*h, 0));
        ani.SetBool("奔跑开关", h != 0);          //動畫元件，設定布林值

        if (Input.GetKeyDown(KeyCode.A ) || Input.GetKeyDown(KeyCode.LeftArrow)) //如果 按下“A”或者“←”按鍵=(0,180,0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) //如果 按下“D”或者“→”按鍵=(0,0,0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void Jump()
    {
        //如果按下空白鍵 並且在地板上 等於 勾選
        if (Input.GetKeyDown(KeyCode.UpArrow)&& isGround==true)
        {
            //在地板上=取消
            isGround = false;
            //剛體.推力（往上）
            r2d.AddForce(new Vector2(0, jump));

            ani.SetTrigger("跳跃触发"); //動畫元件，設定触发器（“参数”）
        }
    }
    private void Dead()
    {

    }

    //事件：在特定時間點以指定次數執行
    //更新事件：一秒執行約60次（60FPS）

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果 碰撞.物件.名稱 等於“地板”
        if(collision.gameObject.name=="地板")
        {
            isGround = true;
        }
    }
}
