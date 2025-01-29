using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private CalderoScript caldero; // Referencia al script del caldero
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
        //PARA COMPROBAR SI HA ENTRADO A CASA DEL ENFERMO

        if(other.gameObject.CompareTag("Enfermo1"))
        {
            Debug.Log("Has visitado al enfermo 1");
            entradaEnfermo1 = true;
            caldero.SetIngredientesCorrectos(new List<string> { "Zanahoria", "Zanahoria", "Zanahoria" });
            Debug.Log("Ingredientes para Enfermo 1 asignados.");
        }
        else if(other.gameObject.CompareTag("Enfermo2"))
        {
            Debug.Log("Has visitado al enfermo 2");
            entradaEnfermo2 = true;
            caldero.SetIngredientesCorrectos(new List<string> { "BayasRojas", "HojaSagrada", "CristalMístico" });
            Debug.Log("Ingredientes para Enfermo 2 asignados.");
        }
        else if (other.gameObject.CompareTag("Enfermo3"))
        {
            Debug.Log("Has visitado al enfermo 3");
            entradaEnfermo3 = true;
            caldero.SetIngredientesCorrectos(new List<string> { "SetaLuminosa", "AguaBendita", "CortezaMilenaria" });
            Debug.Log("Ingredientes para Enfermo 3 asignados.");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //PARA MOSTRAR LA RECETA CORRESPONDIENTE SI ESTÁ AL LADO DEL CALDERO
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
