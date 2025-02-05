using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorObjetos : MonoBehaviour
{
    public Transform posicionFlotante; // Punto donde el objeto flotará
    public string objetoDetectado = ""; // Nombre del objeto en el detector
    private GameObject objetoActual = null; // Referencia al objeto detectado

    public LayerMask layerAgarrables; // 🔹 Layer específica para objetos agarrables

    private void OnTriggerEnter(Collider other)
    {
        if (objetoActual == null && ((1 << other.gameObject.layer) & layerAgarrables) != 0)
        {
            objetoActual = other.gameObject; // Guardamos el objeto
            objetoDetectado = objetoActual.name; // Guardamos su nombre
            FijarObjeto(); // Lo colocamos en su sitio flotante
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objetoActual != null && other.gameObject == objetoActual)
        {
            LiberarObjeto(); // Lo liberamos para que vuelva a tener físicas normales
            objetoActual = null;
            objetoDetectado = "";
        }
    }

    void FijarObjeto()
    {
        if (objetoActual != null)
        {
            Rigidbody rb = objetoActual.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero; // Detener cualquier movimiento
                rb.useGravity = false; // Desactivar gravedad para que quede fijo
                rb.constraints = RigidbodyConstraints.FreezeAll; // Congelar completamente
            }

            // Mover el objeto al punto exacto de flotación y resetear su rotación
            objetoActual.transform.position = posicionFlotante.position;
            objetoActual.transform.rotation = Quaternion.identity;
        }
    }

    void LiberarObjeto()
    {
        if (objetoActual != null)
        {
            Rigidbody rb = objetoActual.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = true; // Activar gravedad de nuevo
                rb.constraints = RigidbodyConstraints.None; // Permitir movimiento libre
            }
        }
    }
}
