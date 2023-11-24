using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float _tiempoMinimo;
    
    [SerializeField]
    private float _tiempoMaximo;
    
    [SerializeField]
    private float _xMinima;
    
    [SerializeField]
    private float _xMaxima;

    [SerializeField]
    private GameObject _original;


    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_original, "ORIGINAL NO PUEDE SER NULO EN SPAWNER");
        StartCoroutine(Spawnear());
    }

    IEnumerator Spawnear()
    {
        while(true)
        {
            // fully qualified name de una clase
            // es como si fuera "nombre y apellidos"
            // namespace + nombre de clase
            float tiempoRandom = UnityEngine.Random.Range(_tiempoMinimo, _tiempoMaximo);
            float xRandom = UnityEngine.Random.Range(_xMinima, _xMaxima);

            Instantiate(
                _original,
                new Vector3(
                    xRandom, 
                    gameObject.transform.position.y, 
                    gameObject.transform.position.z
                    ),
                _original.transform.rotation
                ); 

            yield return new WaitForSeconds(tiempoRandom);
        }
    }
}
