using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    [SerializeField]
    Transform prefab;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Transform spawnedObject = GameObject.Instantiate<Transform>(prefab);
            spawnedObject.position = this.transform.position;
        }
    }

}
