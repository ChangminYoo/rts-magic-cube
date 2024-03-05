using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed = 0f;
    private float resetZ = -2000;
    private Vector3 startPos = Vector3.zero;
    private float dist = 2100f;

	private void Start()
    {
        Init();
    }

    private void Init()
    {
        startPos = transform.position;
        speed = Random.Range(2f, 10f);     
        transform.localScale = new Vector3(Random.Range(1, 5f), 1f, Random.Range(1, 5f));
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime, Space.World);

        if (transform.localPosition.z >= dist)
        {
            transform.localPosition = new Vector3(startPos.x, startPos.y, resetZ);
            Init();
        }
    }
}
