using Pathfinding;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ChunkGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] chunks;
    AstarPath path;
    [SerializeField] private GameObject finalChunk;
    private ChunkManager chunkManager;
    private AstarData data;
    private Transform camPos;


    [SerializeField]
    private int numberOfGenerations, chunkSize;

    private int chunksProb, previousChunkProb;


    private void Start()
    {
        camPos = Camera.main.transform;
        path = AstarPath.active;
        data = path.data;
        chunkManager = FindObjectOfType<ChunkManager>();

        for (int i = 0; i <= numberOfGenerations; i++)
        {
            if (i < numberOfGenerations)
            {
                previousChunkProb = chunksProb;
                while (chunksProb == previousChunkProb)
                {                                 
                    chunksProb = Random.Range(0, chunks.Length);
                }

                GameObject temp;
                if (i == 0)
                    temp = Instantiate(chunks[chunksProb], new Vector3(transform.position.x + ((i + 2) * chunkSize), transform.position.y ), transform.rotation, chunkManager.transform);
                else
                    temp = Instantiate(chunks[chunksProb], new Vector3(transform.position.x + ((i + 2) * chunkSize), transform.position.y), transform.rotation, chunkManager.transform);
                chunkManager.chunks.Add(temp);
            }
            else if (i == numberOfGenerations)
            {
                GameObject finalChunkGO = Instantiate(finalChunk, new Vector3(transform.position.x + ((i + 2) * chunkSize), transform.position.y), transform.rotation, chunkManager.transform);
                chunkManager.chunks.Add(finalChunkGO);
            }
        }

        path.Scan();
    }

    void Update()
    {
       if (transform.position.x < camPos.position.x)
        {
            transform.position = new Vector3(transform.position.x + chunkSize / 2, transform.position.y);
            data.gridGraph.center.x = transform.position.x;
            AstarPath.UpdateGraph();
        }
    }
    
}