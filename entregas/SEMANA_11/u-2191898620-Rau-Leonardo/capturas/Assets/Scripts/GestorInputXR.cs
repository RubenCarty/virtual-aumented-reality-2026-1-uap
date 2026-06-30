using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(ARRaycastManager))]
public class GestorInputXR : MonoBehaviour
{
    [Header("Objeto AR")]
    public GameObject prefabObjeto;

    [Header("UI Feedback")]
    public TextMeshProUGUI textoGesto;
    public TextMeshProUGUI textoEscala;
    public TextMeshProUGUI textoRotacion;

    [Header("Parámetros")]
    public float velocidadRotacion = 0.4f;
    public float umbralDoubleTap   = 0.4f;   // segundos entre taps
    public float umbralHold        = 0.5f;   // segundos para hold
    public float umbralSwipe       = 10f;    // píxeles mínimos para swipe

    // ── Estado interno ─────────────────────────────────────────────────
    private ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject objetoAR;

    private float tiempoUltimoTap = -1f;
    private float tiempoInicioToque = -1f;
    private bool holdDetectado = false;
    private Coroutine corrutinHold;

    private bool pinchActivo = false;
    private float distanciaInicialPinch;
    private float escalaInicialPinch;

    void Awake() => raycastManager = GetComponent<ARRaycastManager>();

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        Touch.onFingerDown += AlBajarDedo;
        Touch.onFingerMove += AlMoverDedo;
        Touch.onFingerUp   += AlSubirDedo;
    }

    void OnDisable()
    {
        Touch.onFingerDown -= AlBajarDedo;
        Touch.onFingerMove -= AlMoverDedo;
        Touch.onFingerUp   -= AlSubirDedo;
        EnhancedTouchSupport.Disable();
    }

    // ── EVENTOS DE DEDO ────────────────────────────────────────────────

    void AlBajarDedo(Finger dedo)
    {
        // CORRECCIÓN: Usamos <= 1 para tolerar retrasos de actualización de frames en el conteo
        if (Touch.activeFingers.Count <= 1)
        {
            // Registrar tiempo de inicio para detectar hold
            tiempoInicioToque = Time.time;
            holdDetectado = false;

            // Iniciar corrutina de hold
            corrutinHold = StartCoroutine(DetectarHold(dedo));
        }
        else if (Touch.activeFingers.Count == 2)
        {
            // Cancelar hold si se agrega segundo dedo
            if (corrutinHold != null) StopCoroutine(corrutinHold);

            // Inicializar pinch
            pinchActivo = true;
            distanciaInicialPinch = Vector2.Distance(
                Touch.activeFingers[0].screenPosition,
                Touch.activeFingers[1].screenPosition);
            if (objetoAR != null)
                escalaInicialPinch = objetoAR.transform.localScale.x;
        }
    }

    void AlMoverDedo(Finger dedo)
    {
        int dedosActivos = Touch.activeFingers.Count;

        if (dedosActivos == 1 && objetoAR != null)
        {
            float deltaX = dedo.currentTouch.delta.x;
            if (Mathf.Abs(deltaX) > umbralSwipe)
            {
                // Cancelar hold si hay movimiento significativo
                if (corrutinHold != null) StopCoroutine(corrutinHold);

                float angulo = -deltaX * velocidadRotacion;
                objetoAR.transform.Rotate(Vector3.up, angulo, Space.World);

                string dir = deltaX > 0 ? "→" : "←";
                MostrarGesto($"SWIPE {dir} | Rot: {objetoAR.transform.eulerAngles.y:F0}°");
                ActualizarUIRotacion(objetoAR.transform.eulerAngles.y);
            }
        }
        else if (dedosActivos == 2 && pinchActivo && objetoAR != null)
        {
            float distanciaActual = Vector2.Distance(
                Touch.activeFingers[0].screenPosition,
                Touch.activeFingers[1].screenPosition);

            float factor = distanciaActual / distanciaInicialPinch;
            float nuevaEscala = Mathf.Clamp(escalaInicialPinch * factor, 0.05f, 3f);
            objetoAR.transform.localScale = Vector3.one * nuevaEscala;

            MostrarGesto($"PINCH | Escala: {nuevaEscala:F2}");
            ActualizarUIEscala(nuevaEscala);
        }
    }

    void AlSubirDedo(Finger dedo)
    {
        // CORRECCIÓN: Evaluamos el levantamiento de forma segura independiente del conteo estricto
        if (Touch.activeFingers.Count <= 1)
        {
            if (corrutinHold != null) StopCoroutine(corrutinHold);

            float duracionToque = Time.time - tiempoInicioToque;

            // Seguridad por si el tiempo de inicio no se guardó bien
            if (tiempoInicioToque < 0) duracionToque = 0.1f;

            // Solo procesar tap si NO fue un hold
            if (!holdDetectado && duracionToque < umbralHold)
            {
                float tiempoDesdeUltimoTap = Time.time - tiempoUltimoTap;

                if (tiempoDesdeUltimoTap < umbralDoubleTap && tiempoUltimoTap > 0)
                {
                    // ── DOBLE TAP ─────────────────────────────────────
                    MostrarGesto("DOBLE TAP — reset");
                    AlDoubleTap();
                    tiempoUltimoTap = -1f; // resetear
                }
                else
                {
                    // ── TAP SIMPLE ────────────────────────────────────
                    tiempoUltimoTap = Time.time;
                    MostrarGesto($"TAP en {dedo.screenPosition}");
                    AlTapSimple(dedo.screenPosition);
                }
            }

            pinchActivo = false;
        }
    }

    // ── ACCIONES DE GESTOS ─────────────────────────────────────────────

    void AlTapSimple(Vector2 posicion)
    {
        hits.Clear();
        if (!raycastManager.Raycast(posicion, hits, TrackableType.PlaneWithinPolygon)) return;

        Pose pose = hits[0].pose;
        if (objetoAR == null)
            objetoAR = Instantiate(prefabObjeto, pose.position, pose.rotation);
        else
            objetoAR.transform.SetPositionAndRotation(pose.position, pose.rotation);

        // Feedback visual: parpadeo verde
        StartCoroutine(ParpadeoColor(Color.green));
    }

    public void AlDoubleTap()
    {
        if (objetoAR == null) return;
        objetoAR.transform.localScale = Vector3.one * 0.1f;
        objetoAR.transform.rotation = Quaternion.identity;
        ActualizarUIEscala(0.1f);
        ActualizarUIRotacion(0f);
        StartCoroutine(ParpadeoColor(Color.white));
    }

    IEnumerator DetectarHold(Finger dedo)
    {
        yield return new WaitForSeconds(umbralHold);

        // Solo si el dedo sigue en pantalla
        if (Touch.activeFingers.Count == 1)
        {
            holdDetectado = true;
            MostrarGesto("HOLD — cambiar color");
            AlHold();
        }
    }

    void AlHold()
    {
        if (objetoAR == null) return;
        Color colorAleatorio = Random.ColorHSV(0f, 1f, 0.6f, 1f, 0.8f, 1f);
        StartCoroutine(TransicionColor(colorAleatorio));
    }

    // ── FEEDBACK VISUAL ────────────────────────────────────────────────

    IEnumerator ParpadeoColor(Color colorDestino)
    {
        if (objetoAR == null) yield break;
        var renderer = objetoAR.GetComponent<Renderer>();
        if (renderer == null) yield break;

        Color colorOriginal = renderer.material.color;
        renderer.material.color = colorDestino;
        yield return new WaitForSeconds(0.15f);
        renderer.material.color = colorOriginal;
    }

    IEnumerator TransicionColor(Color colorDestino)
    {
        if (objetoAR == null) yield break;
        var renderer = objetoAR.GetComponent<Renderer>();
        if (renderer == null) yield break;

        Color inicio = renderer.material.color;
        float t = 0;
        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            renderer.material.color = Color.Lerp(inicio, colorDestino, t);
            yield return null;
        }
    }

    // ── UI ────────────────────────────────────────────────────────────

    void MostrarGesto(string mensaje)
    {
        if (textoGesto != null) textoGesto.text = mensaje;
    }

    void ActualizarUIEscala(float escala)
    {
        if (textoEscala != null) textoEscala.text = $"Escala: {escala:F2}x";
    }

    void ActualizarUIRotacion(float angulo)
    {
        if (textoRotacion != null) textoRotacion.text = $"Rot: {angulo:F0}°";
    }
}