using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera cam;

    private Vector2 firstPosition;

    [SerializeField] private Line linePrefab;

    public const float RESOLUTION = 0.1f;

    private Line currentLine;
    [SerializeField] private ManaFill mana;
    [SerializeField] private float manaIncreaseValue, timeToIncrease;
    private bool isIncreasing = false, canIncrease;
    private Coroutine coroutine;
    
    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        Vector2 _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);



        if (Input.GetMouseButtonDown(0))
        {
            currentLine = Instantiate(linePrefab, _mousePos, Quaternion.identity);
            if(coroutine != null)
                StopCoroutine(coroutine);
            isIncreasing = false;
            canIncrease = false;
        }

        if (Input.GetMouseButton(0))
        {
            currentLine.SetPostion(_mousePos);
        }
        if(Input.GetMouseButtonUp(0) && !isIncreasing)
        {
            coroutine = StartCoroutine(TimeToIncreaseMana());
        }
        if(canIncrease && mana.manaAmmount < 1)
        {
            mana.IncreaseMana(manaIncreaseValue);
        }
    } 

    private IEnumerator TimeToIncreaseMana()
    {
        isIncreasing = true;
        yield return new WaitForSeconds(timeToIncrease);
        canIncrease = true;
    }
}
