using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TouchPoint : MonoBehaviour
{
    private bool isSelected = false;
    [SerializeField] List<GameObject> particleVFXs;
    private Vector3 startPos;

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void Pickup()
    {
        transform.rotation = new Quaternion(0,0,-155,0);
    }
    public void Throw()
    {
        transform.rotation = new Quaternion(0,0,0,0);
        transform.position = startPos;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (transform.CompareTag(other.transform.tag))
        {
            var p = other.transform.GetComponent<Point>();
            if (p != null)
            {
                GameManager.Instance.GetCurLevel().RemoveObject(p.gameObject);
                Destroy(p.gameObject);
                /*GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], p.transform.position, transform.rotation);
                Destroy(explosion, .75f);*/
            }
        }
    }
}
