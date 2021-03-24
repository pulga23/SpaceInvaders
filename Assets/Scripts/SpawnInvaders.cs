using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInvaders : MonoBehaviour
{
    [SerializeField]
    GameObject invasorA;

    [SerializeField]
    GameObject invasorB;

    [SerializeField]
    GameObject invasorC;

    [SerializeField]
    int nInvasores = 7;

    [SerializeField]
    float xMin = -3f;

    [SerializeField]
    float yMin = -0.5f;

    void Awake()
    {
        float x = xMin;
        float y = yMin;

        for (int i = 1; i <= 2*nInvasores; i++ )
        {
           
            
            GameObject newInvaderA = Instantiate(invasorA, transform);
            newInvaderA.transform.position = new Vector3(x, y, 0f);
          
            GameObject newInvaderB = Instantiate(invasorB, transform);
            newInvaderB.transform.position = new Vector3(x, (y+1f), 0f);

            GameObject newInvaderC = Instantiate(invasorC, transform);
            newInvaderC.transform.position = new Vector3(x, (y+2f), 0f);
            
            x += 1f;
                
             
            if(i==(nInvasores))
            {
                y += 0.5f;
                x = xMin;
            }
            
        }
    }
}
