using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalderoScript : MonoBehaviour
{
    [SerializeField] private List<string> ingredientesCorrectos; // Lista de nombres de los ingredientes correctos (la receta como tal)
    private List<string> ingredientesEnCaldero = new List<string>(); // Lista de ingredientes añadidos
    private Animator animator; // Referencia al Animator del caldero
    private PlayerScript player;

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener Animator
    }

    private void OnTriggerEnter(Collider other)
    {
        string nombreIngrediente = other.gameObject.tag; // Obtener el tag del objeto que entra

        if (ingredientesCorrectos.Contains(nombreIngrediente))
        {
            // Si es un ingrediente correcto, lo añadimos y lo destruimos
            ingredientesEnCaldero.Add(nombreIngrediente);
            Destroy(other.gameObject);

            // Verificamos si ya están todos los ingredientes
            if (ingredientesEnCaldero.Count == ingredientesCorrectos.Count)
            {
                Debug.Log("¡Poción Completa!");
                //dejamos de mostrar la receta, ya que ya está completada
                player.recetaVisible = false;
                // esperamos 2 segundos y popeamos una poción

            }
        }
        else
        {
            // Ingrediente incorrecto: animación y expulsión
            Debug.Log("¡Ingrediente incorrecto!");

            //Expulsión con animación
            /*if (animator != null)
            {
                animator.SetTrigger("Error"); // Reproduce la animación de error, en caso de que hayamos puesto una
            }*/

            // Expulsar ingrediente del caldero
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 direccionExpulsion = (other.transform.position - transform.position).normalized;
                rb.AddForce(direccionExpulsion * 5f, ForceMode.Impulse); // Expulsión del objeto
            }
        }
    }
    public void SetIngredientesCorrectos(List<string> nuevosIngredientes)
    {
        ingredientesCorrectos = new List<string>(nuevosIngredientes);
        ingredientesEnCaldero.Clear(); // Reiniciar ingredientes agregados al caldero
        Debug.Log("Nueva lista de ingredientes correctos asignada.");
    }
}
