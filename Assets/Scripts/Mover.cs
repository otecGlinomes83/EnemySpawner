using System.Collections;
using UnityEngine;


public class Mover : MonoBehaviour
{
    public void StartMove(Vector3 direction, float speed)
    {
        StartCoroutine(Move(direction, speed));
    }

    private IEnumerator Move(Vector3 direction, float speed)
    {
        while (isActiveAndEnabled)
        {
            yield return null;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
    }
}
