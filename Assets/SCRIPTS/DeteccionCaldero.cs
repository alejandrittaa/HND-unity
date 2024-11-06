using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionCaldero : MonoBehaviour
{
    //especificamos el nombre de la etiqueta que llevar� el objeto correcto.
    [SerializeField] private string TagCorrecta;

    private void OnTriggerEnter(Collider other)
    {
        //comprobamos que la etiqueta del objeto sea la correcta.
        if(other.CompareTag(TagCorrecta))
        {
            Debug.Log("El objeto que ha atrevesado el trigger, es el correcto");
            //aqu� hay que a�adir el c�digo de lo que sucede si es correcto
        }else
        {
            Debug.Log("El objeto que ha atrevesado el trigger, es incorrecto");
            //aqu� hay que a�adir el c�digo de lo que sucede si es incorrecto
        }
    }
}
