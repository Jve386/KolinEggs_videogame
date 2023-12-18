using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerAlTocar : MonoBehaviour
{
    private AudioSource audioSource;
    private ContadorHuevos contadorHuevos;

    private void Start()
    {
        // Obtén el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si no hay un AudioSource adjunto directamente al objeto, intenta buscarlo en los hijos
            audioSource = GetComponentInChildren<AudioSource>();
        }

        // Obtén el script ContadorHuevos
        contadorHuevos = FindObjectOfType<ContadorHuevos>();
        if (contadorHuevos == null)
        {
            Debug.LogError("No se encontró el script ContadorHuevos en la escena.");
        }
    }


private void OnMouseDown()
{
    Debug.Log("Huevo tocado");  // Verifica si este mensaje aparece en la consola al tocar un huevo

    // Reproduce el sonido si hay un AudioSource y está activo
    if (audioSource != null && audioSource.isActiveAndEnabled)
    {
        if (audioSource.clip != null)
        {
            Debug.Log("Intentando reproducir sonido: " + audioSource.clip.name);
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("El AudioClip en AudioSource no está asignado.");
        }
    }
    else
    {
        Debug.LogWarning("No se encontró AudioSource activo y habilitado.");
    }

    // Incrementa el contador
    if (contadorHuevos != null)
    {
        contadorHuevos.IncrementarContador();
    }

    // Llama a DesaparecerObjeto después de un breve retraso (ajusta según sea necesario)
    Invoke("DesaparecerObjeto", 0.3f);
}

    private void DesaparecerObjeto()
    {
        // Oculta el objeto al que está adjunto este script
        gameObject.SetActive(false);

        // Llama a ReaparecerObjeto después de 2 segundos
        Invoke("ReaparecerObjeto", 2f);
    }

    private void ReaparecerObjeto()
    {
        // Reactiva el objeto después de 2 segundos
        gameObject.SetActive(true);

        // Reposiciona el objeto de manera aleatoria en un margen de 1 unidad en las coordenadas X, Y y Z
        Vector3 nuevaPosicion = new Vector3(
            transform.position.x + Random.Range(-1f, 1f),
            transform.position.y + Random.Range(-1f, 1f),
            transform.position.z + Random.Range(-1f, 1f)
        );

        // Aplica la nueva posición al objeto
        transform.position = nuevaPosicion;
    }
}