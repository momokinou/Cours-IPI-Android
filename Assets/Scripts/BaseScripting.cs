using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScripting : MonoBehaviour
{

    public int monEntier;

    [SerializeField]
    bool monBooleen;

    float monFloatInvisible;
    // Start is called before the first frame update
    void Start()
    {
        HelloWorld();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HelloWorld()
    {
        Debug.Log("Hello World from " + this.gameObject.name);
    }
}
