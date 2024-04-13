using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera cam;

    private Vector2 firstPosition;

    [SerializeField] private Line linePrefab;

    public const float RESOLUTION = 0.1f;

    private Line currentLine;
    
    void Start()
    {
        cam = Camera.main;
        firstPosition = transform.position;
    }

    
    void Update()
    {
        Vector2 _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);



        if (Input.GetMouseButtonDown(0))
            currentLine = Instantiate(linePrefab, _mousePos, Quaternion.identity);

        if (Input.GetMouseButton(0))
            currentLine.SetPostion(_mousePos);
    } 
}
