using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSwapper : MonoBehaviour
{
    public GameObject warmHouse;
    public GameObject coolHouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swap();
        }
    }

    void Swap()
    {
        if (warmHouse.activeInHierarchy)
        {
            warmHouse.SetActive(false);
            coolHouse.SetActive(true);
        }
        else
        {
            warmHouse.SetActive(true);
            coolHouse.SetActive(false);
        }
    }
}
