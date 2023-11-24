using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Nave : MonoBehaviour
{
    [Serializable]
    public class VidaCambio : UnityEvent<float> {}

    [SerializeField]
    private float _velocidad = 5;

    [SerializeField]
    private float _vida = 100;

    [SerializeField]
    private VidaCambio _eventoVidaCambio;

    [SerializeField]
    private UnityEvent _vidaEnCero;

    // Start is called before the first frame update
    void Start()
    {
        _eventoVidaCambio.Invoke(_vida);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(
            h * _velocidad * Time.deltaTime,
            v * _velocidad * Time.deltaTime,
            0
        );
    }

    void OnTriggerEnter(Collider c)
    {
        print("COLISIONÉ CON: " + c.gameObject.layer);
        switch(c.gameObject.layer)
        {
            case 6:
                // aqui va la lógica!
                _vida -= 10;
                // vida -= 10; (lo mismo que )
                // vida = vida - 10;
                // +=
                // *=
                // /=
                // %=
                _eventoVidaCambio.Invoke(_vida);
                break;
            case 7:
                _vida += 10;
                _eventoVidaCambio.Invoke(_vida);
                break;
            default:
                print("NO FUE NI ENEMIGO NI ITEM!");
                break;
        }
        Destroy(c.gameObject);

        if(_vida <= 0)
        {
            _vidaEnCero.Invoke();
        }
    }
}
