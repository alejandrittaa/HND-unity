using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Importar TextMeshPro


public class Mercader : MonoBehaviour
{
    public string nombreMercader;
    public string objetoNecesario; // 🔹 Cada mercader tendrá un objeto distinto
    private bool habladoAntes = false;
    private bool pedidoEnviado = false;

    public GameObject mensajeUI; // Panel de UI
    public TMP_Text textoMensaje; // Texto dentro del panel

    public PolloCorreo polloCorreo; // Referencia al pollo del correo
    public bool haSolicitadoPedido = false; // ✅ Controla si ha hecho su petición

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
            Debug.Log("Player detectado");
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
        if (pedidoEnviado) // ✅ Si ya le llegó el pedido, mensaje final
        {
            textoMensaje.text = $"Gracias por la {objetoNecesario}, ya me llegó gracias al pollito. Si necesitas coger algo más de mi puesto, adelante.";
        }
        else if (habladoAntes) // 🛑 Si ya le has hablado pero no has enviado el objeto
        {
            textoMensaje.text = $"Todavía no me has mandado la {objetoNecesario}? Cuando la tengas, acércate al pollo del correo, él se encargará de hacérmela llegar. Gracias.";
        }
        else // 🆕 Primera interacción
        {
            textoMensaje.text = $"Hola, qué tal? Coge lo que quieras de mi puesto, pero por favor, envíame una {objetoNecesario}.";
            habladoAntes = true;
            haSolicitadoPedido = true; // ✅ Marcamos que este mercader ya ha hecho una petición
        }
    }

    // ✅ Método que el Pollo del Correo llamará cuando reciba el objeto correcto
    public void RecibirPedido()
    {
        pedidoEnviado = true;
    }
}
