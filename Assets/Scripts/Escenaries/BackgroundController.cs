using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
 
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }

  

}

