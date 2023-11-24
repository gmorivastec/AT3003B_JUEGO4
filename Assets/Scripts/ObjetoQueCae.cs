using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoQueCae : MonoBehaviour
{

    [SerializeField]
    private float velocidad = 7.5f;

    // para los valores con decimal tenemos float y double diferencia
    // tamaño y precisión
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(
            0,
            -velocidad * Time.deltaTime,
            0
        );
    }
}
