using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPixel : MonoBehaviour
{
    void Update()
    {
        transform.position = MathExtension.PixelPerfectClamp(transform.position);
    }
}
