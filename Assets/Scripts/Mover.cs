using System;
using System.Collections;
using UnityEngine;


public class Mover : MonoBehaviour
{
    public event Action DestinationReached;

    private Coroutine _moveCoroutine;

    public void StartMove(Transform target, float speed)
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }

        _moveCoroutine = StartCoroutine(Move(target, speed));
    }

    private IEnumerator Move(Transform target, float speed)
    {
        while (isActiveAndEnabled)
        {
            yield return null;

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            if (Vector3.Distance(target.position, transform.position) == 0)
            {
                DestinationReached?.Invoke();
            }
        }
    }
}
