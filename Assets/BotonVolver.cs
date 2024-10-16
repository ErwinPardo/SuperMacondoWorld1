using UnityEngine;
using UnityEngine.UI;  // Necesario para interactuar con componentes de UI
using UnityEngine.Playables;  // Para usar señales en el Timeline

public class BotonVolver : MonoBehaviour
{
    private Button boton;  // Variable para almacenar el componente Button

    // Start se ejecuta una vez antes de que el Update comience a ejecutarse
    private void Start()
    {
        // Obtiene el componente Button al inicio
        boton = GetComponent<Button>();
        gameObject.SetActive(false);
        // Desactiva el botón inicialmente
        boton.enabled = false;
    }

    // Esta función se puede usar para alternar el estado del botón
    public void ToggleButton()
    {
        // Alterna la propiedad "enabled" del botón para activarlo/desactivarlo
        boton.enabled = !boton.enabled;
    }
}