using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;
    private int selection;

    // Start is called before the first frame update
    void Start()
    {
        selection = PlayerPrefs.GetInt("character", 0);

        for (int i = 0; i < characters.Length; i++)
        {
            if (i == selection){
                characters[i].SetActive(true);
            } else {
                characters[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
