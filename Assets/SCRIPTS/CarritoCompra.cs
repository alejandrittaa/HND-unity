using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoCompra : MonoBehaviour
{
    public Transform armarioCompra; // 📌 Punto donde reaparecerán los objetos
    public LayerMask layerAgarrables; // 🔹 Layer de los agarrables que pueden meterse en el carrito

    private void OnTriggerEnter(Collider other)
    {
        // ✅ Verificamos que el objeto sea un agarrable
        if (((1 << other.gameObject.layer) & layerAgarrables) != 0)
        {
            MoverAlArmario(other.gameObject);
        }
    }

    void MoverAlArmario(GameObject objeto)
    {
        Debug.Log($"🛒 {objeto.name} añadido al carrito, moviéndolo al armario...");

        // ✅ Desactivamos el objeto temporalmente y lo movemos al armario
        objeto.SetActive(false);
        objeto.transform.position = armarioCompra.position;
        objeto.transform.rotation = Quaternion.identity;

        // ✅ Reactivamos el objeto después de un pequeño retraso para simular el transporte
        StartCoroutine(ReaparecerObjeto(objeto));
    }

    System.Collections.IEnumerator ReaparecerObjeto(GameObject objeto)
    {
        yield return new WaitForSeconds(0.5f); // Pequeña pausa antes de reaparecer
        objeto.SetActive(true);
        Debug.Log($"📦 {objeto.name} ahora está en el armario.");
    }
}
