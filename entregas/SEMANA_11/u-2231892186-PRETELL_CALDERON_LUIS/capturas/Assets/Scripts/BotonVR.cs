using UnityEngine;
using UnityEngine.InputSystem;

public class BotonVR : MonoBehaviour
{
    [Header("Acción de Reset")]
    public InputActionReference accionReset;

    [Header("Referencia al gestor")]
    public GestorInputXR gestorInput;

    void OnEnable()
    {
        // Suscribirse al evento performed de accionReset
        if (accionReset != null && accionReset.action != null)
        {
            accionReset.action.performed += AlPresionarReset;
            accionReset.action.Enable(); // Activar la acción
        }
    }

    void OnDisable()
    {
        // Desuscribirse del evento performed para evitar leaks de memoria
        if (accionReset != null && accionReset.action != null)
        {
            accionReset.action.performed -= AlPresionarReset;
            accionReset.action.Disable();
        }
    }

    void AlPresionarReset(InputAction.CallbackContext ctx)
    {
        // Llamar al método público de reset del gestor
        if (gestorInput != null)
        {
            gestorInput.AlDoubleTap();
        }
        Debug.Log("Botón VR: RESET presionado a través de InputAction");
    }
}