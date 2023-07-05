using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] Image[] _buttonImages;
    [SerializeField] Text[] _buttonTexts;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    public void ColorChange(string[] stageColor, int kotae)
    {
        int imageColorIndex = 0;
        int imageColorRansuu = 0;
        for (int i = 0; i < _buttonImages.Length; i++)
        {
            imageColorRansuu = Random.Range(0, stageColor.Length);
            imageColorIndex++;
            //_buttonImages[imageColorIndex].color = 
        }
        
    }
}
