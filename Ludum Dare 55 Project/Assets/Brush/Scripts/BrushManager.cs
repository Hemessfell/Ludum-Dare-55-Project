using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BrushManager : MonoBehaviour
{
    [SerializeField] private Line line;
    [SerializeField] private GameObject wall, lightining,fire;
    private List<GameObject> wallList = new List<GameObject>();
    private List<GameObject> fireList = new List<GameObject>();
    private List<RaycastHit2D> enemyList = new List<RaycastHit2D>();
    [SerializeField] private LayerMask whatIsObstacle, whatIsEnemy,whereToFire;
    [SerializeField] private float greenMana, redMana, yellowMana, radius;
    public enum States { Green, Red, Yellow }
    private Image manaColor;
    private LineRenderer lineRenderer;
    public States myState { get; private set; }

    [SerializeField] private ManaFill mana;

    private bool isPaiting;
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
        if (Input.GetKeyDown(KeyCode.Q) && !isPaiting)
        {
            SwitchState(States.Green);
        }

        if (Input.GetKeyDown(KeyCode.W) && !isPaiting)
        {
            SwitchState(States.Yellow);
        }
        if (Input.GetKeyDown(KeyCode.E) && !isPaiting)
        {
            SwitchState(States.Red);
        }

        switch (myState)
        {

            case States.Green:
                if (Input.GetMouseButton(0))
                    SpawnWall();

                if (Input.GetMouseButtonUp(0))
                    StartCoroutine(ActiveWall());
                return;

            case States.Red:
                if(Input.GetMouseButton(0))
                    SpawnFire();

                if(Input.GetMouseButtonUp(0))
                    StartCoroutine(ActivateFire());

                return;
            case States.Yellow:
                if (Input.GetMouseButton(0))
                    MarkEnemy();

                if (Input.GetMouseButtonUp(0))
                    StartCoroutine(CastLightning());
                return;

        }
    }
    private void SwitchState(States newState)
    {
        myState = newState;
        if (myState is States.Green)
        {
            lineRenderer.startColor = new Color(0.1779548f, 0.4056604f, 0.2083156f);
            manaColor.color = new Color(0.1779548f, 0.4056604f, 0.2083156f);
            lineRenderer.endColor = new Color(0, 0.1415094f, 0.02979144f);
        }

        if (newState is States.Red)
        {
            lineRenderer.startColor = new Color(0.5471698f, 0.09292281f, 0.01290495f);
            manaColor.color = new Color(0.7764707f, 0.3686275f, 0.1058824f);
            lineRenderer.endColor = new Color(0.7764707f, 0.3686275f, 0.1058824f);
        }
        else if (newState is States.Yellow)
        {
            lineRenderer.startColor = new Color(0.6313726f, 0.6078432f, 0.4705883f);
            manaColor.color = Color.yellow;
            lineRenderer.endColor = new Color(0.9960785f, 0.9058824f, 0.3803922f);
        }
    }

    #region Green Brush

    private void SpawnWall()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D _hit;
        _hit = Physics2D.BoxCast(new Vector3(_mousePosition.x, _mousePosition.y, 0), new Vector2(1, 0.625f), 0, Vector2.down, 0.1f, whatIsObstacle);
        isPaiting = true;
        if (!_hit && !mana.reachedZero)
        {
            mana.DecreaseMana(greenMana);
            GameObject _temp = Instantiate(wall,new Vector3 (_mousePosition.x, _mousePosition.y,0),Quaternion.identity,transform);
            wallList.Add(_temp);
        }
    }

    private IEnumerator ActiveWall()
    {
        isPaiting = false;
        for (int i = 0; i < wallList.Count; i++)
        {
            wallList[i].transform.GetChild(0).gameObject.SetActive(true);
            wallList[i].transform.GetChild(1).gameObject.transform.DOScale(new Vector3(0, 0, 0), 1);
            AstarPath.UpdateGraph();
            yield return new WaitForSeconds(0.05f);
        }
        wallList.Clear();
    }

    #endregion

    #region RedBrush

    private void SpawnFire()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D _hit;
        _hit = Physics2D.CircleCast(new Vector3(_mousePosition.x, _mousePosition.y, 0), 0.3f, Vector2.down, 0.1f, whereToFire);
        isPaiting = true;
        if (!_hit && !mana.reachedZero)
        {
            mana.DecreaseMana(redMana);
            GameObject _temp = Instantiate(fire, new Vector3(_mousePosition.x, _mousePosition.y, 0), Quaternion.identity, transform);
            fireList.Add(_temp);
        }
    }

    private IEnumerator ActivateFire()
    {
        for (int i = 0; i < fireList.Count; i++)
        {
            fireList[i].transform.GetChild(0).gameObject.SetActive(true);
            fireList[i].transform.GetChild(1).gameObject.transform.DOScale(new Vector3(0, 0, 0), 1);
            yield return new WaitForSeconds(0.05f);
        }
        fireList.Clear();
        isPaiting = false;
    }

    #endregion

    #region YellowBrush
    private void MarkEnemy()
    {
        Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D _hit;
        _hit = Physics2D.CircleCast(new Vector3(_mousePosition.x, _mousePosition.y, 0), radius, Vector2.down, 0.1f, whatIsEnemy);
        isPaiting = true;
        if (_hit.collider && !mana.reachedZero && !_hit.collider.transform.GetChild(0).gameObject.activeInHierarchy)
        {
            _hit.collider.transform.GetChild(0).gameObject.SetActive(true);
            mana.DecreaseMana(yellowMana);
            enemyList.Add(_hit);
        }

    }
    private IEnumerator CastLightning()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i].transform.GetChild(1).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
        enemyList.Clear();
        isPaiting = false;
    }
    #endregion

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

