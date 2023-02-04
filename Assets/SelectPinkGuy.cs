using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPinkGuy : MonoBehaviour
{

    bool isOn;


    [SerializeField] GameObject onStateObj;
    [SerializeField] GameObject offStateObj;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        onStateObj.SetActive(false);
        offStateObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn)
        {
            isOn = false;
            onStateObj.SetActive(false);
            offStateObj.SetActive(true);
        } else
        {
            isOn = true;
            onStateObj.SetActive(true);
            offStateObj.SetActive(false);
        }
    }
}
