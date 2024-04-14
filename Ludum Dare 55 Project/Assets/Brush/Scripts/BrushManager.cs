using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BrushManager : MonoBehaviour
{
    public enum States {Green, Red, Yellow}
    [SerializeField] private Line line;
    [SerializeField] private GameObject wall;
    [SerializeField] private LayerMask whatIsObstacle;
    private LineRenderer lineRenderer;
    private States myState;

    private void Awake()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
    }
    void Start()
    {
        myState = States.Green;
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SwitchState(States.Green);
        }
        
        if(Input.GetKeyDown(KeyCode.R))
            SwitchState(States.Red);

        switch (myState)
        {
            
            case States.Green:
                if (Input.GetMouseButton(0))
                    SpawnWall();
                return;

            case States.Red:
                return;
            case States.Yellow:
                return;

        }
    }

    private void SpawnWall()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector3(mousePosition.x, mousePosition.y, 0), Vector2.down,0.1f, whatIsObstacle);
       
        if(!hit)
        {
            Instantiate(wall,new Vector3 (mousePosition.x, mousePosition.y,0),Quaternion.identity,transform);
        }
    }

    private void SwitchState(States newState)
    {
        myState = newState;
        if (myState is States.Green)
        {
            lineRenderer.startColor = new Color(0.1779548f, 0.4056604f,0.2083156f);

            lineRenderer.endColor = new Color(0, 0.1415094f, 0.02979144f);
        }

        if (newState is States.Red)
        {
            lineRenderer.startColor = new Color(140, 24, 3);
            Debug.Log("red");
            lineRenderer.endColor = new Color(198, 94, 27);
        }
        else if (newState is States.Yellow)
        {

        }
    }
}
