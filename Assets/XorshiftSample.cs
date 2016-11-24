using UnityEngine;
using XJ.Unity3D.Random;

public class XorshiftSample : MonoBehaviour
{
    Xorshift xorshift;

    protected virtual void Start()
    {
        xorshift = new Xorshift(0);
    }

    protected virtual void Update()
    {
        Debug.Log(xorshift.Range(0f, 5f));

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = xorshift.OnUnitSphere();
        cube.transform.localScale *= 0.1f;
    }
}