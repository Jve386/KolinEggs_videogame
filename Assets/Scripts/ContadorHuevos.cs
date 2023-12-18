using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContadorHuevos : MonoBehaviour
{
    private int contador = 0;
    private TextMeshProUGUI textMeshPro;
    public AudioClip[] clipsDeAudio; // Array que contiene los clips de audio
    private AudioSource audioSource;

    private void Start()
    {
        // Obtén el componente TextMeshProUGUI
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro == null)
        {
            Debug.LogError("No se encontró TextMeshProUGUI en el objeto.");
        }

        // Obtén el componente AudioSource directamente (sin buscar en los hijos)
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay un AudioSource adjunto directamente al objeto, muestra un error
            Debug.LogError("No se encontró AudioSource en el objeto.");
        }

        ActualizarTexto();
    }

    public void IncrementarContador()
    {
        // Incrementa el contador al tocar un huevo
        contador += 10;
        ActualizarTexto();

        // Verifica si el contador es un múltiplo de 50
        if (contador % 50 == 0 && clipsDeAudio.Length > 0)
        {
            ReproducirAudioAleatorio();
        }
    }

    private void ActualizarTexto()
    {
        // Actualiza el texto en el componente TextMeshProUGUI
        if (textMeshPro != null)
        {
            textMeshPro.text = ": " + contador;
        }
    }

    private void ReproducirAudioAleatorio()
{
    if (audioSource != null && clipsDeAudio.Length > 0)
    {
        int indiceAleatorio = Random.Range(0, clipsDeAudio.Length);
        audioSource.clip = clipsDeAudio[indiceAleatorio];
        audioSource.Play();
    }
    else
    {
        Debug.LogWarning("No se encontró AudioSource activo y habilitado o no hay clips de audio asignados.");
    }
}
}