using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite cleanFlag;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveFlag()
    {
        GetComponent<Animator>().enabled = false;
        spriteRenderer.sprite = cleanFlag;
    }
}
