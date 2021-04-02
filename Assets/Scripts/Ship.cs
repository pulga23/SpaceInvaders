using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    GameObject fire;

    [SerializeField]
    Transform nozzle;

    [SerializeField]
    float velocidade = 5f;

    [SerializeField]
    int vidasNave = 3;

    Vector3 bottomLeftWorld, topRightWorld;
    float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        //0.5 é metade do tamanho da nave
        minX = Camera.main.ViewportToWorldPoint(Vector2.zero).x + 0.5f; 

        maxX = Camera.main.ViewportToWorldPoint(Vector2.one).x - 0.5f;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(fire, nozzle.position, nozzle.rotation);
        }

        MoveShip();

    }

    void MoveShip()
    {
        float hMov = Input.GetAxis("Horizontal"); //valor entre -1 e 1 poara esq e dir

        transform.position += hMov * velocidade * Vector3.right * Time.deltaTime; //se hmov zero não há alteração no transform position

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minX, maxX);
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "DisparoDoInvasor")
        {
            Destroy(collision.gameObject);
            vidasNave--;
            if (vidasNave == 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        } 
    }
    
}
