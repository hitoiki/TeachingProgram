using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public KeyPad Key;
    public Rigidbody rb;
    public float movePower;
    public float moveSpeed;
    public float jumppower;
    public float jumpTime;
    private float nowJumpTime;
    public float legLength;
    Vector3 moveDir;

    // Update is called once per frame
    void Start()
    {
        nowJumpTime = jumpTime;
    }

    //物理演算ならこちらで。呼び出される頻度は若干Updateに劣るが、
    //物理演算と同時に呼び出されるので齟齬がない
    void FixedUpdate()
    {
        //物理演算を使うので、AddForceで動かす

        //キーの方向ベクトルの水平方向だけ取り出してセット

        moveDir = RemoveY(Key.direction) * movePower;

        //上昇する力を加えるとともに、nowJumpHeightを減らして、
        //ジャンプの距離を制限する
        if (Key.jump && nowJumpTime > 0)
        {
            moveDir += Vector3.up * jumppower;
            nowJumpTime -= Time.deltaTime;
        }
        else
        {
            //ボタン離したら上昇する力をかけない
            nowJumpTime = 0;
        }
        //接地判定
        if (Physics.BoxCast(rb.transform.position, Vector3.right + Vector3.forward, Vector3.down, Quaternion.identity, legLength))
        {
            //接地したらリセット
            nowJumpTime = jumpTime;
            //if (Key.jump) moveDir += Vector3.up * jumppower * 5f;
        }

        //今まで計算した力を(質量を無視して)加える
        rb.AddForce(moveDir, ForceMode.Acceleration);


        //速度が出すぎないように制限
        if (RemoveY(rb.velocity).magnitude > moveSpeed)
        {
            rb.velocity = RemoveY(rb.velocity).normalized * moveSpeed + Vector3.up * rb.velocity.y;
        }
        //動いている方向に向きを揃える
        if (Key.direction != Vector3.zero) rb.rotation = Quaternion.LookRotation(Vector3.RotateTowards(rb.transform.forward, Key.direction, 0.5f, 0f));
        //もしキー入力がないなら減速
        if (Key.direction == Vector3.zero) rb.velocity = Vector3.up * rb.velocity.y + RemoveY(rb.velocity) * 0.5f;
    }

    //よく使うのでメソッド化
    Vector3 RemoveY(Vector3 vector)
    {
        return Vector3.right * vector.x + Vector3.forward * vector.z;
    }
}
