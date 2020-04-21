using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public abstract class KeyPad : MonoBehaviour
{
    //キー入力のデータの纏まりと、それを更新する抽象メソッドを纏めたクラス
    //なんでわざわざこう言うクラスを作るのかと言うと、
    //後でゲームパッドとかにも対応させやすくする為

    public Vector3 direction { get; private set; }
    public bool jump;

    public abstract Vector3 InputDir();
    public abstract bool InputJump();
    void Update()
    {
        direction = InputDir();
        jump = InputJump();
    }
}
