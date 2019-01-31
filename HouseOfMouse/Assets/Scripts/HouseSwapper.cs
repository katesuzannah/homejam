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
    }

    IEnumerator Swap()
    {
        yield return new WaitForSeconds(4f);
        if (!warmHouse.activeInHierarchy) { 
            warmHouse.SetActive(true);
            coolHouse.SetActive(false);
        }
    }

  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      StartCoroutine(Swap());
    }
  }
}
