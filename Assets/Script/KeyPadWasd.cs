using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadWasd : KeyPad
{
    //こいつはKeyPadを継承してるので、
    //directionとかを見えないだけでちゃんと持ってる
    public override Vector3 InputDir()
    {
        Vector3 moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) moveVector += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveVector += Vector3.back;
        if (Input.GetKey(KeyCode.D)) moveVector += Vector3.right;
        if (Input.GetKey(KeyCode.A)) moveVector += Vector3.left;

        return moveVector.normalized;
    }

    public override bool InputJump()
    {
        return Input.GetKey(KeyCode.Space);
    }
}
