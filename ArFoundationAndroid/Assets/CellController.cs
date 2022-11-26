using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{

    public Material Mat1;
    public Material Mat2;
    private float FlashCounter;
    private bool ToRed;

    private Renderer render;


    // Start is called before the first frame update
    void Start()
    { 
      render = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
    
        if (ToRed)  //flip flops between transparent and red
        {
            FlashCounter += 0.1f;  //increments so it takes 10 ticks to move to second material
            render.material = Mat1;
        }
        else
        {
            FlashCounter += 0.02f;  //increments so it takes 50 ticks to move to first material
            render.material = Mat2;
        }
        if (FlashCounter >= 1)
        {
            FlashCounter = 0;
            if (ToRed)
            {
                ToRed = false;
            }
            else
            {
                ToRed = true;
            }

        }
    }
}
