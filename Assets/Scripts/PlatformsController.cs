using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float distance;

    Vector3 _originalPos;
    Vector3 _targetPos;

    private void Awake()
    {
        _originalPos = transform.position;
        _targetPos = _originalPos;
        _targetPos.x += distance;
    }

    private void FixedUpdate()
    {
        float time = Mathf.PingPong(Time.time * speed, 1.0F);
        Vector3 pos = Vector3.Lerp(_originalPos, _targetPos, time);
        transform.position = pos;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
