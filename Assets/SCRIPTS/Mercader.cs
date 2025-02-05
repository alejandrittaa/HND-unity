using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Importar TextMeshPro


public class Mercader : MonoBehaviour
{

    public string nombreMercader;
    public string objetoNecesario;
    public float distanciaInteraccion = 3f;
    private bool misionCompletada = false;
    //private Transform jugador;
    private bool HabladoAntes = false;
    

    public GameObject mensajeUI; // Panel de texto en la UI
    public TMP_Text textoMensaje;

    // 🔹 Referencias a los 3 detectores de objetos
    public GameObject detector1;
    public GameObject detector2;
    public GameObject detector3;

    public LayerMask layerAgarrables; // 🔹 Para detectar solo objetos de la capa Agarrables

    void Start()
    {
        mensajeUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensajeUI.SetActive(true);
            MostrarMensaje();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensajeUI.SetActive(false);
        }
    }


    void MostrarMensaje()
    {

        if (!misionCompletada)
        {
            if (JugadorTieneObjeto() && HabladoAntes)
            {
                textoMensaje.text = $"Gracias por traerme {objetoNecesario}, te lo agradezco.";
                misionCompletada = true;
                EliminarObjeto(); // ✅ Eliminamos el objeto solo al completar la misión
            }
            else if (!HabladoAntes)
            {
                textoMensaje.text = $"Hola, coge lo que necesites de mi puesto, pero a cambio, necesito que me traigas {objetoNecesario}.";
                HabladoAntes = true;
            }
            else
            {
                textoMensaje.text = "Todavía no tienes mi " + objetoNecesario + "? Tráemelo por favor, lo necesito.";
            }
        }
    }

    // ✅ Método para solo DETECTAR el objeto sin eliminarlo
    bool JugadorTieneObjeto()
    {
        return (VerificarObjeto(detector1) || VerificarObjeto(detector2) || VerificarObjeto(detector3));
    }


    // ✅ Método para SOLO verificar si hay un objeto en el detector
    bool VerificarObjeto(GameObject detector)
    {
        if (detector != null)
        {
            DetectorObjetos scriptDetector = detector.GetComponent<DetectorObjetos>();
            return scriptDetector != null && scriptDetector.objetoDetectado == objetoNecesario;
        }
        return false;
    }
    bool VerificarYEliminarObjeto(GameObject detector)
    {
        if (detector != null)
        {
            // 💡 Aseguramos que el GameObject tiene el script `DetectorObjetos`
            DetectorObjetos scriptDetector = detector.GetComponent<DetectorObjetos>();

            if (scriptDetector != null && scriptDetector.objetoDetectado == objetoNecesario)
            {
                scriptDetector.objetoDetectado = ""; // Borramos el objeto detectado
                return true;
            }
        }
        return false;
    }

    // ✅ Método para ELIMINAR el objeto tras completar la misión
    void EliminarObjeto()
    {
        VerificarYEliminarObjeto(detector1);
        VerificarYEliminarObjeto(detector2);
        VerificarYEliminarObjeto(detector3);
    }
}
