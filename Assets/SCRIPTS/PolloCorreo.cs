using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PolloCorreo : MonoBehaviour
{
    public Mercader[] mercaderes; // 🔹 Lista de mercaderes
    public LayerMask layerAgarrables; // 🔹 Detecta solo objetos en la capa "Agarrables"

    // 🔹 Referencias a la UI de los mercaderes
    public GameObject mensajeUI; // 🔹 Panel de texto en la UI (compartido con los mercaderes)
    public TMP_Text textoMensaje; // 🔹 Texto dentro del panel (compartido con los mercaderes)

    private void Start()
    {
        mensajeUI.SetActive(false); // 🔹 Ocultar el mensaje al inicio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerAgarrables) != 0) // 🔍 Solo detecta objetos de la capa "Agarrables"
        {
            string nombreIngrediente = other.gameObject.tag; // 🔹 Usa el Tag para saber qué tipo de ingrediente es
            bool ingredienteValido = false;

            // 🔍 Buscar si algún mercader ha pedido este ingrediente
            foreach (Mercader mercader in mercaderes)
            {
                if (mercader.haSolicitadoPedido && mercader.objetoNecesario == nombreIngrediente)
                {
                    mercader.RecibirPedido(); // ✅ El mercader recibe el pedido
                    ingredienteValido = true;
                    break; // 🔹 Como ya encontramos el mercader que lo pidió, salimos del bucle
                }
            }

            if (ingredienteValido)
            {
                MostrarMensaje("🐥 PIO PIO!!! El ingrediente ha sido enviado al mercader.");
                Destroy(other.gameObject); // 📦 Transportar el ingrediente al mercader
            }
            else
            {
                MostrarMensaje("🐥 PIO PIO???? Nadie ha pedido esto... Lo dejo aquí.");
            }
        }
    }

    // 🔹 Método para mostrar el mensaje en la misma UI que usan los mercaderes
    void MostrarMensaje(string mensaje)
    {
        mensajeUI.SetActive(true); // 🔹 Mostrar el mensaje
        textoMensaje.text = mensaje; // 🔹 Actualizar el texto

        // 🔹 Ocultar el mensaje después de 3 segundos
        CancelInvoke("OcultarMensaje");
        Invoke("OcultarMensaje", 3f);
    }

    void OcultarMensaje()
    {
        mensajeUI.SetActive(false);
    }
}
