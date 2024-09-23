using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoInactive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AutoDeactivate", 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AutoDeactivate()
    {
        gameObject.SetActive(false);
    }
}
