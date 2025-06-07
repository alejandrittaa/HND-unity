using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enfermo : MonoBehaviour
{
    public string nombreEnfermo;
    public string objetoNecesario; // ?? Cada mercader tendr� un objeto distinto
    private bool habladoAntes = false;
    private bool pocionEntregada = false;

    public GameObject mensajeUI; // Panel de UI
    public TMP_Text textoMensaje; // Texto dentro del panel

    public bool hasolicitadopocion = false; // ? Controla si ha hecho su petici�n

    void Start()
    {
        mensajeUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensajeUI.SetActive(true);
            MensajeEnfermo();
        }

        if(other.CompareTag("Pocion"))
        { 
            pocionEntregada = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensajeUI.SetActive(false);
        }
    }

    void MensajeEnfermo()
    {
        if (pocionEntregada) // ? Si ya le lleg� el pedido, mensaje final
        {
            textoMensaje.text = $"Gracias por la {objetoNecesario}, me encuentro mucho mejor.";
        }
        else if (habladoAntes) // ?? Si ya le has hablado pero no has enviado la pocion
        {
            textoMensaje.text = $"Todav�a no me has hecho la {objetoNecesario}? Cuando la tengas, ac�rcate a mi y d�mela, solt�ndola justo en frente de mi.";
        }
        else // ?? Primera interacci�n
        {
            textoMensaje.text = $"Me encuentro muy mal, me duelen mucho los ojitos, podr�as hacerme una {objetoNecesario}.";
            habladoAntes = true;
            hasolicitadopocion = true; // ? Marcamos que este enfermo ya ha hecho una petici�n
        }
    }
}
