using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParent : MonoBehaviour
{

    public void DestroyMe(float time)
    {
        Destroy(gameObject, time);
    }
}
