using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    Vector3 direction;

    Transform myTr;

    private void Start()
    {
        myTr = this.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myTr.Translate(direction * Time.deltaTime);
    }
}
