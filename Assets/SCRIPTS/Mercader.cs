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
    private Transform jugador;
    private bool HabladoAntes = false;
    

    public GameObject mensajeUI; // Panel de texto en la UI
    public TMP_Text textoMensaje;

    // 🔹 Referencias a los 3 detectores de objetos
    public GameObject detector1;
    public GameObject detector2;
    public GameObject detector3;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        mensajeUI.SetActive(false);
    }


    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < distanciaInteraccion)
        {
            MostrarMensaje();
        }
        else
        {
            mensajeUI.SetActive(false);
        }
    }

    void MostrarMensaje()
    {
        mensajeUI.SetActive(true);

        if (!misionCompletada)
        {
            //si el jugador tiene el objeto y ya ha hablado antes con el mercader...
            if (JugadorTieneObjeto() && HabladoAntes == true)
            {
                textoMensaje.text = $"Gracias por traerme {objetoNecesario}, te lo agradezco.";
                misionCompletada = true;
            }
            else //si no ha hablado antes con el mercader...
            {
                textoMensaje.text = $"Hola, coge lo que necesites de mi puesto, pero a cambio, necesito que me traigas {objetoNecesario}.";
                HabladoAntes = true;
            }
        }
        else //si no ha completado la misión...
        {
            textoMensaje.text = "Todavía no tienes mi " + objetoNecesario + "? Traémelo porfavor, lo necesito.";
        }
    }

    bool JugadorTieneObjeto()
    {
        // 🔍 Buscar el objeto en los detectores
        if (VerificarYEliminarObjeto(detector1) || VerificarYEliminarObjeto(detector2) || VerificarYEliminarObjeto(detector3))
        {
            return true;
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
}
