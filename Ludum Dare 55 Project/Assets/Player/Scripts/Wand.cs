using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField] GameObject player;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float magnitude;
    [SerializeField] private float frequency;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationMagnitude;

    private bool isDrawing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isDrawing = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            isDrawing = false;
        }

        if (isDrawing)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Helpers.WorldMousePosition().x, Helpers.WorldMousePosition().y, 0.0f), moveSpeed * 2 * Time.deltaTime);
        }
        else
        {
            float x = Mathf.Cos(Time.time * frequency) * magnitude;
            float y = Mathf.Sin(Time.time * frequency) * magnitude;

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x + player.transform.position.x, y + player.transform.position.y), moveSpeed * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Sin(Time.time * rotationSpeed) * rotationMagnitude);
    }
}