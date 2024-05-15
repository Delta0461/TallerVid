using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plataform_Break : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void romper() {
        StartCoroutine(Break());
    }
    IEnumerator Break() {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

}
