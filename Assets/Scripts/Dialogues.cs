using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogues : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // Referencia al componente de texto TMP
    public AudioSource audioSource1; // Primer componente AudioSource

    // Start is called before the first frame update
    void Start()
    {
        // Comienza el proceso de mostrar diálogos
        StartCoroutine(MostrarDialogosCada3Segundos());
        // Reproduce el audio al iniciar el juego
        ReproducirAudioAlInicio();
    }

    // Método para mostrar los diálogos cada 5 segundos
    private IEnumerator MostrarDialogosCada3Segundos()
    {
        // Muestra el primer diálogo inmediatamente
        MostrarDialogo("Bienvenido al mundo de los Dragones Kolin.");

        yield return new WaitForSeconds(3f); // Espera 1 segundo antes de mostrar el siguiente diálogo

        // Muestra el segundo diálogo
        MostrarDialogo("Soy Dracona, necesito que recojas los huevos ya que Shenron no tiene manos. Ayúdalo, porque es muy patoso.");

        yield return new WaitForSeconds(4.5f); // Espera 2 segundos antes de mostrar el siguiente diálogo

        // Muestra el tercer diálogo
        yield return new WaitForSeconds(6f); // Espera 2 segundos antes de mostrar el siguiente diálogo
        MostrarDialogo("<color=#ADD8E6>I am American but I identify myself as a Mexican. I love Mexico. ¡Vamos amigo!</color>");

        // Espera 5 segundos antes de mostrar un espacio
        yield return new WaitForSeconds(7f);
        MostrarDialogo(" ");
    }

    // Método para mostrar un diálogo en el componente de texto TMP
    private void MostrarDialogo(string texto)
    {
        if (dialogueText != null)
        {
            dialogueText.text = texto;
        }
    }

    // Método para reproducir el audio al inicio
    private void ReproducirAudioAlInicio()
    {
        if (audioSource1 != null && audioSource1.clip != null)
        {
            audioSource1.Play();
        }
        else
        {
            Debug.LogWarning("El AudioSource 1 o el AudioClip no están asignados.");
        }
    }

}


