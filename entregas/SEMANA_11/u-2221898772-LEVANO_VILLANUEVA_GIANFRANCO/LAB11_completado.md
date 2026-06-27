# LAB11 — LABORATORIO EN CASA
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 11 — Scripts e Inputs: Sistema de Interacciones XR Avanzado

---

> **Laboratorio en casa — 2 horas**
> **Modalidad:** individual
> **Entrega:** PR en GitHub antes del inicio de la Semana 12
> **Rama:** `u-[codigo]-[apellido]-[nombre]-lab11`

| Campo | Detalle |
|-------|---------|
| **Nombre** | Gianfranco Eduardo Levano Villanueva |
| **Código** | 2221898772 |
| **Fecha inicio** | 20/06/2026 |
| **Fecha entrega** | 27/06/2026 |

---

## INTRODUCCIÓN

En el laboratorio de clase implementaste los 3 gestos básicos con el Input legacy (`Input.touchCount`). En este laboratorio en casa darás el siguiente paso: refactorizar ese sistema al **nuevo Input System** usando `EnhancedTouchSupport`, implementar un **feedback visual por gesto**, y agregar un sistema de **acciones encadenadas** (tap + hold para acción especial).

El resultado será un sistema de inputs XR profesional, listo para ser integrado en tu proyecto grupal.

---

## PARTE 1 — EXPLORACIÓN (30 min)

### Objetivo
Entender el nuevo Input System y `EnhancedTouchSupport` antes de implementar.

### Actividad 1.1 — Instalar y activar el nuevo Input System (10 min)

1. Abre el proyecto `lab_11_inputs` del laboratorio de clase (o crea uno nuevo con la misma configuración AR de la Semana 11).

2. **Window → Package Manager → Unity Registry → Input System:**
   - Buscar: `Input System` (by Unity Technologies)
   - Versión: 1.7.x o superior
   - Instalar → Unity pedirá reiniciar → Aceptar

3. **Edit → Project Settings → Player → Other Settings:**
   - Active Input Handling: cambiar a **"Input System Package (New)"**
   - Unity pedirá reiniciar de nuevo → Aceptar

4. Abre la consola y ejecuta Play sin tocar nada. Verifica que no hay errores de `Input` legacy.

**Pregunta de exploración 1:** ¿Qué error aparecería si intentaras usar `Input.GetMouseButtonDown(0)` después de cambiar a "Input System Package (New)"? Anota tu respuesta aquí:

> Respuesta: Si intentas usar Input.GetMouseButtonDown(0) usando la configuración estricta del nuevo Input System, la consola arrojará un error de tipo InvalidOperationException. El mensaje indicará explícitamente que estás intentando consultar una API de Input Legacy (UnityEngine.Input) mientras los sistemas antiguos están desactivados en los Player Settings.

---

### Actividad 1.2 — Explorar la API de EnhancedTouch (10 min)

Crea un script temporal `ExplorarTouch.cs` y agrega este código:

```csharp
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class ExplorarTouch : MonoBehaviour
{
    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        Touch.onFingerDown += AlTocar;
        Touch.onFingerMove += AlMover;
        Touch.onFingerUp   += AlSoltar;
    }

    void OnDisable()
    {
        Touch.onFingerDown -= AlTocar;
        Touch.onFingerMove -= AlMover;
        Touch.onFingerUp   -= AlSoltar;
        EnhancedTouchSupport.Disable();
    }

    void AlTocar(Finger f) =>
        Debug.Log($"[DOWN] Dedo {f.index} en {f.screenPosition}");

    void AlMover(Finger f) =>
        Debug.Log($"[MOVE] Dedo {f.index} delta: {f.currentTouch.delta}");

    void AlSoltar(Finger f) =>
        Debug.Log($"[UP]   Dedo {f.index} soltado en {f.screenPosition}");
}
```

Agrega este script al XR Origin y presiona Play. Haz clicks en la pantalla del editor y observa la consola.

**Pregunta de exploración 2:** ¿Cuál es la diferencia entre `f.screenPosition` y `f.currentTouch.delta`?

> Respuesta: 
> - f.screenPosition representa la posición absoluta (en píxeles de la pantalla) donde se encuentra el dedo en el fotograma actual (coordenadas bidimensionales de la pantalla).
> - f.currentTouch.delta representa el cambio de posición relativo (el desplazamiento en píxeles) que ha tenido ese dedo en comparación con el fotograma anterior. Es decir, cuánto y en qué dirección se movió.

**Pregunta de exploración 3:** ¿Qué evento de `Touch` corresponde a `TouchPhase.Began` del Input legacy?

> Respuesta: El evento que corresponde directamente a TouchPhase.Began es Touch.onFingerDown. Este evento se dispara exactamente en el fotograma en que el dedo entra en contacto con la pantalla.

Cuando termines la exploración, elimina `ExplorarTouch.cs` del XR Origin (puedes dejar el archivo).

---

### Actividad 1.3 — Leer la documentación oficial (10 min)

Accede a: `https://docs.unity3d.com/Packages/com.unity.inputsystem@1.8/manual/EnhancedTouch.html`

Lee la sección "Enhanced Touch Support" y responde:

**Pregunta de exploración 4:** ¿Qué sucede si llamas `EnhancedTouchSupport.Enable()` más de una vez sin llamar `Disable()` entre medio?

> Respuesta: Si llamas a EnhancedTouchSupport.Enable() de manera consecutiva sin un Disable() intermedio, Unity podría generar un aviso en la consola indicando que el soporte avanzado de toque ya está activo. Internamente, el sistema lleva un contador de referencias o simplemente ignora la llamada subsiguiente, pero es una mala práctica arquitectónica ya que puede causar fugas de eventos si no se desviculan simétricamente en OnDisable.

**Pregunta de exploración 5:** ¿`Touch.activeFingers` y `Touch.activeTouches` son la misma colección? ¿Cuál es la diferencia?

> Respuesta: No son la misma colección. > * Touch.activeFingers hace referencia a los dedos físicos (Finger) que están interactuando actualmente con la pantalla. Conserva un índice persistente por cada dedo.
Touch.activeTouches hace referencia al historial o registros de datos de toque (Touch) activos en el frame actual. Un dedo puede generar múltiples estados de toque acumulados en el buffer si la tasa de refresco del input es mayor a la del render. Para lógicas de gestos directos, activeFingers es más limpio de consultar.

---

## PARTE 2 — APLICACIÓN (60 min)

### Objetivo
Implementar un sistema completo de inputs XR usando el nuevo Input System.

### Descripción del producto a construir

Crearás `GestorInputXR.cs` — un script que reemplaza el `InputAR.cs` del lab de clase con las siguientes mejoras:

| Gesto | Acción | Feedback visual |
|-------|--------|----------------|
| Tap (1 dedo, rápido < 0.3s) | Colocar/mover objeto en plano AR | Objeto parpadea en verde |
| Doble tap (2 taps < 0.4s entre sí) | Resetear escala y rotación del objeto | Objeto vuelve a escala 0.1 |
| Hold tap (1 dedo, > 0.5s) | Cambiar color del objeto aleatoriamente | Color cambia con transición |
| Swipe horizontal (1 dedo) | Rotar objeto en Y | Indicador de rotación en UI |
| Pinch (2 dedos) | Escalar objeto (0.05 a 3.0) | Indicador de escala en UI |

### Implementación

#### 2.1 — Crear el sistema de gestos

**Assets/Scripts/GestorInputXR.cs:**

```csharp
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
        int dedosActivos = Touch.activeFingers.Count;

        if (dedosActivos == 1)
        {
            // Registrar tiempo de inicio para detectar hold
            tiempoInicioToque = Time.time;
            holdDetectado = false;

            // Iniciar corrutina de hold
            corrutinHold = StartCoroutine(DetectarHold(dedo));
        }
        else if (dedosActivos == 2)
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
        int dedosActivos = Touch.activeFingers.Count;

        // Al levantar el último dedo
        if (dedosActivos == 0)
        {
            if (corrutinHold != null) StopCoroutine(corrutinHold);

            float duracionToque = Time.time - tiempoInicioToque;

            // Solo procesar tap si NO fue un hold y el movimiento fue mínimo
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

    void AlDoubleTap()
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
```

---

#### 2.2 — Actualizar la UI (10 min)

1. **Hierarchy → Canvas:**
   - Renombrar el texto existente a `TextGesto`
   - Agregar **UI → Text - TextMeshPro** → nombre: `TextEscala` (abajo derecha)
   - Agregar **UI → Text - TextMeshPro** → nombre: `TextRotacion` (abajo izquierda)

2. **Seleccionar XR Origin:**
   - Eliminar el componente `InputAR` (si existe del lab de clase)
   - **Add Component → Gestor Input XR**
   - Arrastrar: `CuboPrefab` → campo "Prefab Objeto"
   - Arrastrar: `TextGesto` → campo "Texto Gesto"
   - Arrastrar: `TextEscala` → campo "Texto Escala"
   - Arrastrar: `TextRotacion` → campo "Texto Rotacion"

---

#### 2.3 — Probar con XR Device Simulator (10 min)

1. Asegúrate de que el `XR Device Simulator` prefab está en la Hierarchy.
2. **▶️ Play**
3. Click izquierdo en el plano → cubo debe aparecer y parpadear en verde
4. Click izquierdo + mover mouse → cubo debe rotar y el texto mostrar el ángulo
5. Doble click rápido → cubo debe resetear

---

#### 2.4 — Evidencias (5 min)

Tomar capturas de:
1. Inspector del XR Origin mostrando todos los campos del `GestorInputXR` asignados
2. La escena en Play con el texto de gesto visible
3. El cubo con un color diferente (después de hold)

---

## PARTE 3 — DESAFÍO (30 min)

### Objetivo
Extender el sistema de gestos con `InputActionReference` para un gesto VR simulado.

### Descripción

Crea un script adicional `BotonVR.cs` que escuche una `InputAction` de tipo `Button` y ejecute la misma acción de "doble tap" (reset escala/rotación) del script `GestorInputXR`.

**Requisitos:**

**Requisito 1:** crear un `InputActionAsset`:
```
Assets → Create → Input Actions → nombre: "Lab11Actions"
Action Map: "XR Lab"
Action: "ResetObjeto" → tipo Button
Binding: <Keyboard>/r    (para probar en editor con tecla R)
```

**Requisito 2:** crear script `BotonVR.cs`:

```csharp
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
        // TODO: suscribirse al evento performed de accionReset
        // TODO: activar la acción con Enable()
    }

    void OnDisable()
    {
        // TODO: desuscribirse del evento performed
    }

    void AlPresionarReset(InputAction.CallbackContext ctx)
    {
        // TODO: llamar al método de reset del gestor
        // Pista: GestorInputXR no tiene acceso público a AlDoubleTap
        //        → ¿qué cambio necesitarías hacer en GestorInputXR?
        Debug.Log("Botón VR: RESET presionado");
    }
}
```

**Requisito 3:** hacer que `AlDoubleTap()` en `GestorInputXR` sea `public` (cambiar `void AlDoubleTap()` a `public void AlDoubleTap()`).

**Requisito 4:** conectar en la escena:
- Agregar `BotonVR` al XR Origin
- Asignar `accionReset` → la acción "ResetObjeto" del asset
- Asignar `gestorInput` → el componente GestorInputXR del XR Origin

**Requisito 5:** probar en Play:
- Presionar `R` en el teclado
- El cubo debe resetear escala y rotación (mismo comportamiento que doble tap)

**Pregunta de desafío:** ¿Por qué es mejor que `BotonVR` llame a `gestorInput.AlDoubleTap()` en lugar de duplicar la lógica de reset dentro de `BotonVR`?

> Respuesta: Invocar directamente a gestorInput.AlDoubleTap() en lugar de duplicar el código dentro de BotonVR es fundamental por los principios de la arquitectura de software limpia, específicamente el principio DRY (Don't Repeat Yourself) y la Centralización de la Lógica de Negocio.
Si en el futuro el cliente o el docente solicita cambiar el comportamiento del reinicio (por ejemplo, que además de la escala se reproduzca un sonido de interfaz o el objeto parpadee en color azul), solo tendrás que modificar el método original en GestorInputXR.cs. Si duplicaras la lógica en ambos scripts, tendrías que recordar actualizar cada uno de ellos por separado, incrementando de manera drástica el riesgo de generar bugs o comportamientos inconsistentes entre las plataformas táctiles y las de VR simulado.

---

## ENTREGA

### Estructura de archivos a subir

```
entregas/SEMANA-11/u-[codigo]-[apellido]/
├── Assets/
│   ├── Scripts/
│   │   ├── GestorInputXR.cs      ← obligatorio
│   │   └── BotonVR.cs            ← desafío
│   └── Input/
│       └── Lab11Actions.inputactions  ← desafío
├── capturas/
│   ├── 01_inspector.png
│   ├── 02_escena_play.png
│   └── 03_color_hold.png
└── RESPUESTAS.md                 ← respuestas de exploración y desafío
```

### Mensaje de commit

```
feat(s11): implementar GestorInputXR con enhanced touch y feedback visual
```

### Criterio de entrega completa

- [X] `GestorInputXR.cs` funcional con los 5 gestos
- [X] `BotonVR.cs` conectado al InputActionReference
- [X] 3 capturas de evidencia
- [X] `RESPUESTAS.md` con las 6 respuestas de exploración y desafío
- [X] Commit con mensaje correcto en la rama `u-[codigo]-[apellido]-[nombre]-lab11`
- [X] PR creado hacia `main` antes del inicio de la Semana 12

---

## RÚBRICA DE AUTOEVALUACIÓN

| Criterio | Puntos | Logrado |
|----------|--------|---------|
| GestorInputXR.cs sin errores de compilación | 15 | ☐ |
| Usa OnEnable/OnDisable (no Start/OnDestroy) | 10 | ☐ |
| Los 5 gestos funcionan correctamente | 20 | ☐ |
| Feedback visual implementado (parpadeo, transición) | 10 | ☐ |
| UI actualizada con escala y rotación en tiempo real | 10 | ☐ |
| BotonVR.cs implementado y conectado (desafío) | 15 | ☐ |
| Respuestas de exploración justificadas | 10 | ☐ |
| Commit correcto con mensaje feat(s11) | 10 | ☐ |
| **TOTAL** | **100** | |

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 11 | 2026-1*
