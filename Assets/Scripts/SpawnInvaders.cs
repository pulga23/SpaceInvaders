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
    GameObject[] invasores;

    [SerializeField]
    GameObject[] indestrutiveis;

    [SerializeField]
    int nInvasores = 7;

    [SerializeField]
    float xMin = -3f;

    [SerializeField]
    float yMin = -0.5f;

    [SerializeField]
    float xInc = 1f;

    [SerializeField]
    float yInc = 0.5f;

    [SerializeField]
    float probIndestrutivel = 0.15f;

    [SerializeField]
    float force = 1f;

    int i = 0;

    float tempo = 0f;

    void Awake()
    {
        float y = yMin;

        for ( int line = 0; line < invasores.Length; line++)
        {
            
            float x = xMin;

            for (int i = 1; i <= (nInvasores); i++)
            {
                GameObject normalOuIndestrutivel;
                if(Random.value < probIndestrutivel)
                {
                    normalOuIndestrutivel = indestrutiveis[line];
                }
                else
                {
                    normalOuIndestrutivel = invasores[line];
                }
                GameObject newInvader = Instantiate(normalOuIndestrutivel, transform);
                newInvader.transform.position = new Vector3(x, y, 0f);
                x += xInc;
            }
            y += yInc;
        }
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * force); //invasores andam para baixo
    }

    void Update()
    {
        tempo += Time.deltaTime;
       
        if (tempo > 0.5f && i==0) //anda 0.5 para a direita 
        {
            Vector3 posicao = transform.position;
            posicao.x += 0.5f;
            transform.position = posicao;
            i++;           
        }
        else if (tempo > 1f && i == 1) //0.5 esquerda, volta a 0
        {
            Vector3 posicao = transform.position;
            posicao.x -= 0.5f;
            transform.position = posicao;
            i++;
        }
        else if (tempo > 1.5f && i == 2) //0.5 para a esquerda
        {
            Vector3 posicao = transform.position;
            posicao.x -= 0.5f;
            transform.position = posicao;
            i++;
        }
        else if (tempo > 2f && i == 3) //0.5 direita, volta a 0
        {
            Vector3 posicao = transform.position;
            posicao.x += 0.5f;
            transform.position = posicao;
            i = 0;
            tempo = 0f;
        }

        
    }
}
