using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackroundMove : MonoBehaviour
{
    [SerializeField] private float _offcetSpeed;

    private Material _material;
    private Vector2 _offcet;

    private void Awake()
    {
        _material = GetComponent<Image>().material;
        _offcet = new Vector2(_offcetSpeed * Time.deltaTime, 0);
    }

    private void Update()
    {
        _material.mainTextureOffset += _offcet;
    }
}
