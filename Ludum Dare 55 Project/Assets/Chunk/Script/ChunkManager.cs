using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    public List<GameObject> chunks = new List<GameObject>();
    public List<GameObject> activeChunks = new List<GameObject>();

    private Transform cameraTrans;

    [SerializeField]
    private float distance;

    [SerializeField] WagonMovement wagon;


    void Start()
    {
        cameraTrans = Camera.main.transform;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (!chunks.Contains(transform.GetChild(i).gameObject))
                chunks.Add(transform.GetChild(i).gameObject);
        }
    }

    void Update()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            if (chunks[i] != null)
            {
                if ((chunks[i].transform.position - cameraTrans.position).sqrMagnitude > distance * distance)
                {
                    if (chunks[i].activeInHierarchy)
                        chunks[i].SetActive(false);
                }
                else
                {
                    if (!chunks[i].activeInHierarchy)
                        chunks[i].SetActive(true);
                }
            }
        }
    }
}
