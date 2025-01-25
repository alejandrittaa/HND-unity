using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] GameObject receta1; 
    [SerializeField] GameObject receta2;
    [SerializeField] GameObject receta3;
    //[SerializeField] GameObject receta4;
    private bool entradaEnfermo1 = false;
    private bool entradaEnfermo2 = false;
    private bool entradaEnfermo3 = false;
    public bool recetaVisible;
    //private bool recetaAnteriorTerminada;
    //private bool entradaEnfermo4;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Para registrar que ha entrado a hablar con el enfermo

        if(other.gameObject.CompareTag("Enfermo1"))
        {
            entradaEnfermo1 = true;
        }
        else if(other.gameObject.CompareTag("Enfermo2"))
        {
            entradaEnfermo2 = true;
            recetaVisible = false;
        }
        else if (other.gameObject.CompareTag("Enfermo3"))
        {
            entradaEnfermo3 = true;
            recetaVisible = false;
        }

        //Para comprobar si ha hablado con el enfermo correspondiente y si esta cerca del caldero
        if (entradaEnfermo1 == true && other.gameObject.CompareTag("DetectorProximidadCaldero"))
        {
            //mostramos la receta 1
            receta1.SetActive(true);
            recetaVisible = true;
        }
        else if (entradaEnfermo2 == true && other.gameObject.CompareTag("DetectorProximidadCaldero"))
        {
            //si no hay ninguna otra receta mostrandose, muestra la 2
            if (recetaVisible == false)
            {
                receta2.SetActive(true);
            }
        }
        else if (entradaEnfermo3 == true && other.gameObject.CompareTag("DetectorProximidadCaldero"))
        {
            //si no hay ninguna otra receta mostrandose, muestra la 3
            if (recetaVisible == false)
            {
                receta2.SetActive(true);
            }
        }

    }

}
