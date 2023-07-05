using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mondai : MonoBehaviour
{
    [SerializeField] Text _mondaiText;
    [SerializeField] ColorChanger _colorChanger;

    bool _isThinking = false;//�����v�l���Ă��Ȃ��B�܂萳�������Ƃ�������

    int _stageCount = 0;
    int _mondaiRansuu = 0;
    float _pushButtonNumber = 3;//�z��͈̔͂�0�`2�Ȃ̂ŁA�͈͊O��3�������l�ɂ���

    void Start()
    {
        
    }

    void Update()
    {

        if (_isThinking == false)//�����񓚂��Ă��Ȃ��Ƃ��B�܂�ŏ��A�܂��͐�����
        {
            _mondaiRansuu = Random.Range(0, 3);//�o�肷����z��̃C���f�b�N�X�𗐐��Ō��߂�
            QuizMondai(_stageCount, _mondaiRansuu);//���o�胁�\�b�h�N��
            _isThinking = true;//���v�l��
        }
        else
        {
            if (_pushButtonNumber != 3)//_pushButtonNumber�������l(3)�ł͂Ȃ��B�܂�{�^���̓��͂��Ȃ����Ƃ𔻒肷��
            {
                if (_mondaiRansuu == _pushButtonNumber)//_mondaiRansuu(����) == _pushButtonNumber(���͒l)
                {
                    print("����");
                    _pushButtonNumber = 3;//_pushButtonNumber��������
                    _isThinking = false;
                    _stageCount++;//�X�e�[�W�J�E���g�����Z�B�܂莟�̖��ֈȍ~
                }
                else
                {
                    print("�ԈႢ");
                    _pushButtonNumber = 3;//_pushButtonNumber��������
                }
            }
        }
    }
    /// <summary>���������_���ŗ����Œ��I���āA�����Ōo�߃X�e�[�W���󂯎��A�������E���h���Ƃɕω�������</summary>
    /// <param name="count">���݂̃X�e�[�W(���J�E���g)���󂯎��A���ԍ� = �����Ȃ̂ŁA��Ō��߂��������󂯎��</param>
    public void QuizMondai(int count, int mondaiRansuu)
    {
        //���������Ŕz��Ő錾���Ă���
        string[] mondai0 = { "red", "blue", "green" };
        string[] mondai1 = { "white", "black", "gray" };

        //�z����i�[����z��������Ő錾����
        string[][] stages = { mondai0, mondai1 };
        //�z��̒��g����
        //stages[x][y]
        //[x0 = mondai1] [y0 = red / y1 = blue / y2 = green] 
        //[x1 = mondai2] [y0 = white / y1 = black / y2 = gray]

        //_colorChanger.ColorChange(stages[count], mondaiRansuu);

        print(mondaiRansuu);
        _mondaiText.text = "�����̐F��" + stages[count][mondaiRansuu] + "�͂ǂ�ł����H";
        
    }
    /// <summary>�{�^���������ꂽ���Ƃ����m</summary>
    /// <param name="buttonNumber">�C���X�y�N�^�[�łǂ̃{�^���������ꂽ���������œ��肷��</param>
    public void PushButton(int buttonNumber)
    {
        _pushButtonNumber = buttonNumber;//�{�^���������ꂽ�Ƃ��A_pushButtonNumber�Ƃ����ϐ��Ɉ������i�[���āA���if���Ő��� == ���̐����𔻒肷��
    }
}
