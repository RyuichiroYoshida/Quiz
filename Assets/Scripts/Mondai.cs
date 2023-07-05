using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mondai : MonoBehaviour
{
    [SerializeField] Text _mondaiText;
    [SerializeField] ColorChanger _colorChanger;

    bool _isThinking = false;//問題を思考していない。つまり正解したということ

    int _stageCount = 0;
    int _mondaiRansuu = 0;
    float _pushButtonNumber = 3;//配列の範囲が0～2なので、範囲外の3を初期値にした

    void Start()
    {
        
    }

    void Update()
    {

        if (_isThinking == false)//問題を回答していないとき。つまり最初、または正解後
        {
            _mondaiRansuu = Random.Range(0, 3);//出題する問題配列のインデックスを乱数で決める
            QuizMondai(_stageCount, _mondaiRansuu);//問題出題メソッド起動
            _isThinking = true;//問題思考中
        }
        else
        {
            if (_pushButtonNumber != 3)//_pushButtonNumberが初期値(3)ではない。つまりボタンの入力がないことを判定する
            {
                if (_mondaiRansuu == _pushButtonNumber)//_mondaiRansuu(答え) == _pushButtonNumber(入力値)
                {
                    print("正解");
                    _pushButtonNumber = 3;//_pushButtonNumberを初期化
                    _isThinking = false;
                    _stageCount++;//ステージカウントを加算。つまり次の問題へ以降
                }
                else
                {
                    print("間違い");
                    _pushButtonNumber = 3;//_pushButtonNumberを初期化
                }
            }
        }
    }
    /// <summary>問題をランダムで乱数で抽選して、引数で経過ステージを受け取り、問題をラウンドごとに変化させる</summary>
    /// <param name="count">現在のステージ(大門カウント)を受け取り、問題番号 = 答えなので、上で決めた乱数を受け取る</param>
    public void QuizMondai(int count, int mondaiRansuu)
    {
        //問題をここで配列で宣言している
        string[] mondai0 = { "red", "blue", "green" };
        string[] mondai1 = { "white", "black", "gray" };

        //配列を格納する配列をここで宣言する
        string[][] stages = { mondai0, mondai1 };
        //配列の中身説明
        //stages[x][y]
        //[x0 = mondai1] [y0 = red / y1 = blue / y2 = green] 
        //[x1 = mondai2] [y0 = white / y1 = black / y2 = gray]

        //_colorChanger.ColorChange(stages[count], mondaiRansuu);

        print(mondaiRansuu);
        _mondaiText.text = "文字の色が" + stages[count][mondaiRansuu] + "はどれですか？";
        
    }
    /// <summary>ボタンが押されたことを感知</summary>
    /// <param name="buttonNumber">インスペクターでどのボタンが押されたかを引数で入手する</param>
    public void PushButton(int buttonNumber)
    {
        _pushButtonNumber = buttonNumber;//ボタンが押されたとき、_pushButtonNumberという変数に引数を格納して、上のif文で正解 == この数字を判定する
    }
}
