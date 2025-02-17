using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest : MonoBehaviour
{
    [UnityTest]
    public IEnumerator Object_MovesForward()
    {
        GameObject obj = new GameObject();
        obj.transform.position = Vector3.zero;

        float speed = 5f;
        obj.transform.position += Vector3.forward * speed * Time.deltaTime;

        yield return null;  // Wait a frame

        Assert.Greater(obj.transform.position.z, 0, "Object should move forward.");
    }
}
