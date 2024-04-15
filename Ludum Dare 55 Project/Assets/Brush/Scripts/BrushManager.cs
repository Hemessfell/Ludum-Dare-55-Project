using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushManager : MonoBehaviour
{
    public enum States { Green, Red, Yellow }
    [SerializeField] private Line line;
    [SerializeField] private GameObject wall;
    [SerializeField] private List<GameObject> wallList = new List<GameObject>();
    [SerializeField] private LayerMask whatIsObstacle;
    [SerializeField] private float greenMana, redMana, yellowMana;
    private Image manaColor;
    private LineRenderer lineRenderer;
    private States myState;

    [SerializeField] private ManaFill mana;
    private void Awake()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
        manaColor = mana.GetComponent<Image>();
    }
    void Start()
    {
        myState = States.Red;
        SwitchState(States.Green);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchState(States.Green);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SwitchState(States.Yellow);
        }
        if (Input.GetKeyDown(KeyCode.E))
            SwitchState(States.Red);

        switch (myState)
        {

            case States.Green:
                if (Input.GetMouseButton(0))
                    SpawnWall();
                if (Input.GetMouseButtonUp(0) && wallList.Count > 0)
                    StartCoroutine(ActiveWall());
                return;

            case States.Red:
                return;
            case States.Yellow:
                return;

        }
    }

    private void SpawnWall()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D _hit;
        _hit = Physics2D.BoxCast(new Vector3(_mousePosition.x, _mousePosition.y, 0), new Vector2(1, 0.625f), 0, Vector2.down, 0.1f, whatIsObstacle);

        if (!_hit)
        {
            Instantiate(wall,new Vector3 (_mousePosition.x, _mousePosition.y,0),Quaternion.identity,transform);
            mana.DecreaseMana(greenMana);
            //Instantiate(wall, new Vector3(Mathf.FloorToInt(mousePosition.x) + 0.5f, Mathf.RoundToInt(mousePosition.y), 0), Quaternion.identity, transform);
            GameObject _temp = Instantiate(wall,new Vector3 (_mousePosition.x, _mousePosition.y,0),Quaternion.identity,transform);
            wallList.Add(_temp);
        }
    }

    private IEnumerator ActiveWall()
    {
            for (int i = 0; i < wallList.Count; i++)
            {

                wallList[i].transform.GetChild(0).gameObject.SetActive(true);
                yield return new WaitForSeconds(0.05f);
            }
            wallList.Clear();
    }

    private void SwitchState(States newState)
    {
        myState = newState;
        if (myState is States.Green)
        {
            lineRenderer.startColor = new Color(0.1779548f, 0.4056604f, 0.2083156f);
            manaColor.color = Color.green;
            lineRenderer.endColor = new Color(0, 0.1415094f, 0.02979144f);
        }

        if (newState is States.Red)
        {
            lineRenderer.startColor = new Color(0.5471698f, 0.09292281f, 0.01290495f);
            manaColor.color = Color.red;
            lineRenderer.endColor = new Color(0.7764707f, 0.3686275f, 0.1058824f);
        }
        else if (newState is States.Yellow)
        {
            lineRenderer.startColor = new Color(0.6313726f, 0.6078432f, 0.4705883f);
            manaColor.color = Color.yellow;
            lineRenderer.endColor = new Color(0.9960785f, 0.9058824f, 0.3803922f);
        }
    }

}
