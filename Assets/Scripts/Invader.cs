using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField]
    GameObject fire = null;

    [SerializeField]
    float cadencia = 1.5f;

    [SerializeField]
    int vidasInvasoresBoss=10;

    float tempoQuePassou = 0f;

    
    [SerializeField]
    float deltaDisparos=1f; // variação da cadencia de disparos

    
    

    void Update()
    {
        float[] tempoDisparo = {(cadencia - deltaDisparos), (cadencia + deltaDisparos)};

        if (tag == "Destrutivel")
        {
            tempoQuePassou += Time.deltaTime;
            if (tempoQuePassou >= tempoDisparo[Random.Range(0,2)])
            {
                Instantiate(fire, transform.position, transform.rotation);
                tempoQuePassou = 0f;
                
            }
        }

        
        //GetComponent<Rigidbody2D>.velocity = 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Destrutivel")
        {
            if (collision.gameObject.tag == "DisparoDaNave")
            {
                Destroy(gameObject); //destruir o game object (invasor)
                Destroy(collision.gameObject); //destruir o que colidiu comigo (tiro)
            }
        }
        else if(tag == "Indestrutivel")
        {
            vidasInvasoresBoss--;
            if(vidasInvasoresBoss==0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);

        }
        
    }



}
