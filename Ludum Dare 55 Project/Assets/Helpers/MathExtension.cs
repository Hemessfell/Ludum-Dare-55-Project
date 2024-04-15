using UnityEngine;

public class MathExtension
{
    public static Vector3 PixelPerfectClamp(Vector3 moveVector)
    {
        Vector3 vectorInPixels = new Vector3(
        Mathf.RoundToInt(moveVector.x * 16f),
        Mathf.RoundToInt(moveVector.y * 16f),
        moveVector.z);

        return vectorInPixels / 16f;
    }

    public static bool IsBetween(float testValue, float bound1, float bound2)
    {
        return (testValue >= Mathf.Min(bound1, bound2) && testValue <= Mathf.Max(bound1, bound2));
    }

    public static void CreateCircle(LineRenderer line, int segments, float xRadius, float yRadius)
    {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        line.positionCount = segments + 1;
        line.useWorldSpace = false;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yRadius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }
}