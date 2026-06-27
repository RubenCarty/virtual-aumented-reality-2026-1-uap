# S11 — GUÍA DE TRABAJO ESTUDIANTE
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 11 — Scripts e Inputs en XR

---

> **Instrucciones generales:**
> - Resuelve TODAS las secciones en orden.
> - No está permitido buscar respuestas en internet para la Sección I y II — usa solo lo visto en clase.
> - Para la Sección III y IV puedes consultar la documentación de Unity.
> - Entrega como archivo `.md` con tu código en bloques de código fenced (```csharp).
> - Tiempo sugerido: 90 minutos.

| Campo | Detalle |
|-------|---------|
| **Estudiante** | Gianfranco Eduardo Levano Villanueva |
| **Código** | 2221898772 |
| **Fecha** | 20/06/2026 |
| **Semana** | 11 — Scripts e Inputs en XR |

---

## SECCIÓN I — COMPRENSIÓN CONCEPTUAL (25 puntos)
### 10 preguntas de opción múltiple — una sola respuesta correcta

---

**Pregunta 1** (2.5 pts)

¿Cuál de las siguientes afirmaciones describe correctamente la diferencia entre el Input System legacy de Unity y el nuevo Input System?

- a) El legacy es más rápido porque no usa reflection; el nuevo es más lento pero más flexible.
- b) El legacy usa `Input.GetKey()` y está atado a dispositivos específicos; el nuevo usa Actions y Bindings desacoplados del dispositivo.
- c) El nuevo Input System reemplaza completamente a `ARRaycastManager` para detectar toques en AR.
- d) Ambos sistemas son equivalentes; la diferencia es solo de sintaxis.

**Respuesta:** b

---

**Pregunta 2** (2.5 pts)

En un proyecto AR para Android, un estudiante escribe:

```csharp
void Update()
{
    if (Input.GetMouseButtonDown(0))
        ColocarObjeto(Input.mousePosition);
}
```

¿Qué problema tiene este código al compilar para Android?

- a) Ningún problema — `GetMouseButtonDown` funciona en Android porque Unity mapea los toques a clicks de ratón.
- b) Solo funciona si el dispositivo tiene un ratón Bluetooth conectado al Android.
- c) En el editor funciona, pero en Android táctil el toque no se registra como click de ratón con el nuevo Input System activo.
- d) El problema es que `mousePosition` no existe en Unity 2022.

**Respuesta:** c

---

**Pregunta 3** (2.5 pts)

¿Por qué se recomienda declarar `List<ARRaycastHit> hits` como campo de clase (fuera del método `Update`) en lugar de crearlo dentro de `Update()`?

- a) Porque `List<ARRaycastHit>` no puede crearse dentro de métodos — es una limitación de C#.
- b) Para reducir la creación de objetos en heap en cada frame y evitar pausas del Garbage Collector.
- c) Porque `ARRaycastManager.Raycast` requiere que la lista sea un campo de clase para poder escribir en ella.
- d) Solo por estilo de código — no hay diferencia de rendimiento.

**Respuesta:** b

---

**Pregunta 4** (2.5 pts)

¿Cuándo se dispara el callback `performed` de una `InputAction`?

- a) En cada frame mientras el botón está presionado (equivalente a `GetKey`).
- b) Solo cuando la acción supera el umbral de activación (ej: botón presionado, trigger > 0.5f).
- c) Solo cuando la acción se cancela (botón soltado).
- d) En cada frame, independientemente del estado del botón.

**Respuesta:** b

---

**Pregunta 5** (2.5 pts)

Un desarrollador escribe este código:

```csharp
void Start()
{
    EnhancedTouchSupport.Enable();
    Touch.onFingerDown += AlTocar;
}
void OnDestroy()
{
    Touch.onFingerDown -= AlTocar;
    EnhancedTouchSupport.Disable();
}
```

Al desactivar y reactivar el GameObject en runtime, el touch deja de funcionar. ¿Cuál es el error?

- a) `EnhancedTouchSupport.Enable()` solo puede llamarse una vez en toda la vida de la app.
- b) `Start()` no se llama al reactivar un GameObject — debería usarse `OnEnable()`/`OnDisable()`.
- c) `Touch.onFingerDown` no existe; el evento correcto es `Touch.onTouchBegin`.
- d) El problema es que `OnDestroy()` no se llama antes de que el objeto se desactive.

**Respuesta:** b

---

**Pregunta 6** (2.5 pts)

¿Cuál es la principal ventaja de usar `InputActionReference` en un campo público del script?

- a) Es el único tipo que puede leer valores `Vector2` de controllers VR.
- b) Permite asignar el binding desde el Inspector sin hardcodear el nombre del botón en el código.
- c) Compila más rápido que usar el string del nombre de la acción.
- d) Permite usar acciones de múltiples `InputActionAsset` simultáneamente.

**Respuesta:** b

---

**Pregunta 7** (2.5 pts)

Para leer el valor del joystick de un controller VR (entrada analógica continua), ¿qué enfoque es más correcto?

- a) Suscribirse al evento `performed` y leer el valor en el callback.
- b) Llamar `ReadValue<Vector2>()` en `Update()` para leer el valor cada frame.
- c) Usar `Input.GetAxis("Horizontal")` del Input System legacy.
- d) Suscribirse a `performed` y `canceled` y calcular la diferencia.

**Respuesta:** b

---

**Pregunta 8** (2.5 pts)

En `XRGrabInteractable`, ¿cuándo se dispara el evento `activated`?

- a) Cuando el controller apunta hacia el objeto interactable.
- b) Cuando el usuario presiona el trigger del controller mientras el objeto ya está siendo agarrado.
- c) Cuando el objeto es instanciado en la escena.
- d) Cuando el objeto entra en el campo de visión del usuario.

**Respuesta:** b

---

**Pregunta 9** (2.5 pts)

¿Para qué sirve el XR Device Simulator en Unity?

- a) Para compilar la app directamente en el dispositivo XR sin usar Build Settings.
- b) Para probar interacciones XR con teclado y ratón en el editor, sin necesidad del hardware físico.
- c) Para simular el rendimiento del dispositivo XR en el editor.
- d) Para reemplazar ARCore en dispositivos que no soportan AR.

**Respuesta:** b

---

**Pregunta 10** (2.5 pts)

¿Cuál de estas opciones describe correctamente el ciclo `performed → canceled` de una InputAction de tipo `Button`?

- a) `performed` al presionar, `canceled` al soltar.
- b) `performed` al soltar, `canceled` al presionar.
- c) `performed` en cada frame que el botón está presionado.
- d) `performed` y `canceled` se disparan siempre en el mismo frame.

**Respuesta:** a

---

## SECCIÓN II — COMPLETAR Y RELACIONAR (25 puntos)

### Parte A — Completa el código (15 pts)

El siguiente script gestiona inputs de controller VR. Rellena los espacios en blanco `[___]` con el código correcto. Cada espacio vale 1 punto.

```csharp
using UnityEngine;
using UnityEngine.[1___];         // namespace del Input System

public class ControladorVR : MonoBehaviour
{
    public InputAction[2___] accionTrigger;    // tipo de referencia a usar
    public InputActionReference accionGrip;

    void [3___]()                 // método correcto de Unity para suscribirse
    {
        accionTrigger.action.[4___] += AlPresionarTrigger;   // evento correcto
        accionGrip.action.performed  += AlAgarrar;
        accionTrigger.action.[5___]();    // activar la acción
        accionGrip.action.Enable();
    }

    void [6___]()                 // método correcto de Unity para desuscribirse
    {
        accionTrigger.action.performed -= AlPresionarTrigger;
        accionGrip.action.[7___]   -= AlAgarrar;   // evento correcto para desuscribir
    }

    void AlPresionarTrigger(InputAction.[8___] ctx)  // tipo del parámetro del callback
    {
        float presion = ctx.[9___]<float>();   // método para leer el valor
        Debug.Log($"Trigger: {presion:[10___]}");   // formato con 2 decimales
    }

    void AlAgarrar(InputAction.CallbackContext ctx)
    {
        float val = ctx.ReadValue<float>();
        bool agarrando = val [11___] 0.5f;   // comparación para detectar agarre
        Debug.Log($"Grip: {agarrando}");
    }

    void Update()
    {
        // Para entradas continuas: leer en Update, NO usar evento performed
        Vector2 joystick = accionGrip.action.[12___]<Vector2>();  // método correcto
    }
}
```

Espacios a completar:

| # | Respuesta |
|---|-----------|
| 1 | InputSystem |
| 2 | Reference |
| 3 | OnEnable |
| 4 | performed |
| 5 | Enable |
| 6 | OnDisable |
| 7 | performed |
| 8 | CallbackContext |
| 9 | ReadValue |
| 10 | F2 o 0.00 |
| 11 | >= |
| 12 | ReadValue |

---

### Parte B — Relacionar columnas (10 pts — 1 pt c/u)

**Columna A (Concepto)** — **Columna B (Descripción)**

| Columna A | Tu respuesta | Columna B |
|-----------|-------------|-----------|
| 1. `TouchPhase.Began` | C | A. Evento que se dispara cuando el controller apunta a un interactable |
| 2. `InputActionReference` | D | B. Lee el valor de una acción en cada frame (para entradas continuas) |
| 3. `EnhancedTouchSupport.Enable()` | E | C. Solo el primer frame en que el dedo toca la pantalla |
| 4. `ReadValue<T>()` en Update | B | D. Campo público que une el script con una acción del Input Actions Asset |
| 5. `hoverEntered` | A | E. Activa el API avanzado de toques multi-dedo del nuevo Input System |
| 6. `performed` | F | F. Callback que se dispara cuando se activa una InputAction |
| 7. `XR Device Simulator` | H | G. Limpiar la lista en vez de crear una nueva con `new` |
| 8. `hits.Clear()` | G | H. Herramienta para probar XR con teclado y ratón en el editor |
| 9. `cancelado` / `canceled` | I | I. Callback que se dispara cuando se desactiva/suelta una InputAction |
| 10. `selectEntered` | J | J. Evento de XRGrabInteractable cuando el usuario agarra el objeto |

---

## SECCIÓN III — ANÁLISIS Y APLICACIÓN (25 puntos)

### Caso 1 — Diagnóstico de código defectuoso (12 pts)

El siguiente script tiene **4 errores** que impiden que funcione correctamente en Android AR. Identifica cada error, explica por qué es un error y escribe la corrección.

```csharp
// Script: GestorInputAR_Defectuoso.cs
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GestorInputAR_Defectuoso : MonoBehaviour
{
    private ARRaycastManager arRM;

    void Start()
    {
        arRM = GetComponent<ARRaycastManager>();
        UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport.Enable();       // Línea A
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += AlTocar;       // Línea B
    }

    void OnDestroy()  // Línea C
    {
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= AlTocar;
        UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport.Disable();
    }

    void AlTocar(UnityEngine.InputSystem.EnhancedTouch.Finger dedo)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();   // Línea D
        if (arRM.Raycast(dedo.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Debug.Log($"Plano AR en: {hits[0].pose.position}");
        }
    }
}
```

Completa la tabla:

| Error | Línea | ¿Por qué es error? | Corrección |
|-------|-------|-------------------|------------|
| 1 | Líneas A y B | Activar el soporte táctil y suscribirse a eventos en Start() provoca fallas si el objeto se desactiva y reactiva en runtime, ya que Start() se ejecuta una sola vez. | Mover estas inicializaciones y suscripciones al método OnEnable(). |
| 2 | Línea C | Desuscribirse en OnDestroy() mantiene la suscripción activa e ineficiente si el objeto solo está deshabilitado pero no destruido. Además, debe emparejarse con el ciclo de vida correcto. | Cambiar el método OnDestroy() por OnDisable() para liberar la suscripción de forma segura. |
| 3 | Línea D | Instanciar una nueva List<ARRaycastHit> dentro de un callback de interacción genera Garbage Collection (GC Alloc) masivo en cada frame de toque, provocando micro-tirones (stuttering). | Declarar la lista como un campo privado de la clase y reutilizarla llamando a hits.Clear() antes de usarla. |
| 4 | Línea A (Contextual) | GetComponent<ARRaycastManager>() fallará (será null) si este script no se encuentra alojado estrictamente en el mismo GameObject que posee el XR Origin (o AR Session Origin). | Utilizar FindAnyObjectByType<ARRaycastManager>() o declarar el campo como [SerializeField] para asignarlo desde el Inspector. |

---

### Caso 2 — Diseño de arquitectura de inputs (13 pts)

Una startup limeña desarrolla **"GuíaMuseo AR"** — una app AR para el Museo Larco de Lima donde los visitantes apuntan su celular a las piezas arqueológicas y aparece información interactiva en AR. Los inputs requeridos son:

- **Tap simple** sobre la pieza → mostrar panel de información
- **Doble tap** sobre el panel → expandir/colapsar detalles
- **Swipe vertical** sobre el panel → navegar entre secciones (Historia / Materiales / Época)
- **Pinch** sobre el panel → zoom in/out del panel AR
- **Long press** (2 segundos) sobre la pieza → guardar en favoritos

El jefe de producto dice: "En 6 meses vamos a agregar soporte para Meta Quest 3 con controllers — no quiero que tengan que reescribir todos los scripts de input."

**Tarea:**

**a)** Diseña el Input Actions Asset (nombre del asset, nombre del Action Map, nombre y tipo de cada Action) que cumpla los requisitos. Usa el siguiente formato de tabla:

| Asset name | Action Map | Action | Tipo |
|------------|-----------|--------|------|
| MuseoInputActions | Interacciones | SeleccionarPieza|Button |
| MuseoInputActions | Interacciones | AlternarDetalles | Button |
| MuseoInputActions | Interacciones | NavegarSecciones | Value |
| MuseoInputActions | Interacciones | ZoomPanel | Value |
| MuseoInputActions | Interacciones | FavoritoPieza | Button |

**b)** Escribe el esqueleto del script `InputMuseoAR.cs` que use `InputActionReference` para las 5 acciones. El esqueleto debe incluir: declaración de campos, `OnEnable()` con suscripciones y Enable, `OnDisable()` con desuscripciones, y los 5 métodos de callback con `Debug.Log()`.

```csharp
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMuseoAR : MonoBehaviour
{
    [Header("Action References")]
    [SerializeField] private InputActionReference actionSeleccionarPieza;
    [SerializeField] private InputActionReference actionAlternarDetalles;
    [SerializeField] private InputActionReference actionNavegarSecciones;
    [SerializeField] private InputActionReference actionZoomPanel;
    [SerializeField] private InputActionReference actionFavoritoPieza;

    private void OnEnable()
    {
        // Suscribir eventos y habilitar acciones
        actionSeleccionarPieza.action.performed += OnSeleccionarPieza;
        actionAlternarDetalles.action.performed += OnAlternarDetalles;
        actionNavegarSecciones.action.performed += OnNavegarSecciones;
        actionZoomPanel.action.performed += OnZoomPanel;
        actionFavoritoPieza.action.performed += OnFavoritoPieza;

        actionSeleccionarPieza.action.Enable();
        actionAlternarDetalles.action.Enable();
        actionNavegarSecciones.action.Enable();
        actionZoomPanel.action.Enable();
        actionFavoritoPieza.action.Enable();
    }

    private void OnDisable()
    {
        // Desuscribir de forma segura
        if (actionSeleccionarPieza != null) actionSeleccionarPieza.action.performed -= OnSeleccionarPieza;
        if (actionAlternarDetalles != null) actionAlternarDetalles.action.performed -= OnAlternarDetalles;
        if (actionNavegarSecciones != null) actionNavegarSecciones.action.performed -= OnNavegarSecciones;
        if (actionZoomPanel != null) actionZoomPanel.action.performed -= OnZoomPanel;
        if (actionFavoritoPieza != null) actionFavoritoPieza.action.performed -= OnFavoritoPieza;
    }

    private void OnSeleccionarPieza(InputAction.CallbackContext ctx)
    {
        Debug.Log("Acción ejecutada: Tap simple detectado para mostrar panel.");
    }

    private void OnAlternarDetalles(InputAction.CallbackContext ctx)
    {
        Debug.Log("Acción ejecutada: Doble tap detectado para expandir/colapsar detalles.");
    }

    private void OnNavegarSecciones(InputAction.CallbackContext ctx)
    {
        Vector2 delta = ctx.ReadValue<Vector2>();
        Debug.Log($"Acción ejecutada: Swipe vertical en progreso con Delta Y: {delta.y}");
    }

    private void OnZoomPanel(InputAction.CallbackContext ctx)
    {
        float value = ctx.ReadValue<float>();
        Debug.Log($"Acción ejecutada: Pinch detectado con valor de magnitud: {value}");
    }

    private void OnFavoritoPieza(InputAction.CallbackContext ctx)
    {
        Debug.Log("Acción ejecutada: Long press de 2 segundos completado. Guardado en favoritos.");
    }
}
```

**c)** Responde en 3 líneas: ¿qué cambiarías en el código para agregar soporte a Meta Quest 3 en 6 meses?
> No se cambiaría ni una sola línea de código en los scripts interactivos. El desacoplamiento del nuevo Input System permite que únicamente abras el Input Actions Asset, añadas un nuevo Control Scheme para XR Controllers, y asignes los nuevos Bindings de Meta Quest 3 directamente a las acciones existentes.


---

## SECCIÓN IV — CASO AVANZADO (25 puntos)

### Reto: Sistema de Input Multi-Modal para XR

**Contexto:** el equipo de VR de tu grupo de proyecto necesita un sistema de inputs que funcione en dos modos:

- **Modo AR (Android):** usa toques táctiles
- **Modo VR (Quest):** usa controllers

El mismo script debe funcionar en ambos modos. Al iniciar, el sistema detecta automáticamente si está en AR o VR y configura los inputs correspondientes.

**Tarea:** implementa `GestorInputMultiModal.cs` con los siguientes requisitos:

**Requisito 1:** detectar el modo de ejecución:
```csharp
// Si tiene ARSession → modo AR; si tiene XRRig con controllers → modo VR
private enum ModoXR { AR, VR }
private ModoXR modoActual;
```

**Requisito 2:** en modo AR:
- Tap → `AccionSeleccionar(posicion2D)`
- Pinch → `AccionEscalar(factor)`
- Swipe horizontal → `AccionRotar(angulo)`

**Requisito 3:** en modo VR:
- Trigger → `AccionSeleccionar(posicion3D del controller)`
- Grip → `AccionEscalar()` (agarrar para escalar)
- Joystick X → `AccionRotar(angulo)`

**Requisito 4:** las tres acciones (`AccionSeleccionar`, `AccionEscalar`, `AccionRotar`) deben estar definidas como métodos que reciben parámetros — el código de lógica NO debe estar duplicado entre el modo AR y VR.

**Requisito 5:** `InputActionReference` para las acciones VR, `EnhancedTouchSupport` para las acciones AR.

**Entrega:**
1. Código completo de `GestorInputMultiModal.cs`

```csharp
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class GestorInputMultiModal : MonoBehaviour
{
    private enum ModoXR { AR, VR }
    [SerializeField] private ModoXR modoActual;

    [Header("Referencias de Acciones VR")]
    [SerializeField] private InputActionReference seleccionarVRAction;
    [SerializeField] private InputActionReference escalarVRAction;
    [SerializeField] private InputActionReference rotarVRAction;

    [Header("Referencias de Controladores VR")]
    [SerializeField] private Transform controllerTransform;

    private void OnEnable()
    {
        DetectarModo();

        if (modoActual == ModoXR.AR)
        {
            EnhancedTouchSupport.Enable();
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += OnTouchAR;
        }
        else
        {
            seleccionarVRAction.action.performed += OnSelectVR;
            seleccionarVRAction.action.Enable();
            escalarVRAction.action.Enable();
            rotarVRAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (modoActual == ModoXR.AR)
        {
            UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= OnTouchAR;
            EnhancedTouchSupport.Disable();
        }
        else
        {
            if (seleccionarVRAction != null) seleccionarVRAction.action.performed -= OnSelectVR;
        }
    }

    private void DetectarModo()
    {
        // Validación: Si existe un objeto ARSession activo, asume entorno móvil AR Foundation
        if (GameObject.FindAnyObjectByType<UnityEngine.XR.ARFoundation.ARSession>() != null)
        {
            modoActual = ModoXR.AR;
        }
        else
        {
            modoActual = ModoXR.VR;
        }
    }

    private void Update()
    {
        if (modoActual == ModoXR.AR)
        {
            ProcesarEntradasContinuasAR();
        }
        else
        {
            ProcesarEntradasContinuasVR();
        }
    }

    // --- MANEJADORES AR ---
    private void OnTouchAR(Finger finger)
    {
        AccionSeleccionar(finger.screenPosition);
    }

    private void ProcesarEntradasContinuasAR()
    {
        var touches = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;

        // Simulación de Pinch con 2 dedos
        if (touches.Count == 2)
        {
            Vector2 prevPos0 = touches[0].screenPosition - touches[0].delta;
            Vector2 prevPos1 = touches[1].screenPosition - touches[1].delta;
            float prevDist = Vector2.Distance(prevPos0, prevPos1);
            float currentDist = Vector2.Distance(touches[0].screenPosition, touches[1].screenPosition);
            
            float factorPinch = currentDist - prevDist;
            AccionEscalar(factorPinch * 0.01f);
        }
        // Swipe con 1 dedo para rotar
        else if (touches.Count == 1 && touches[0].phase == UnityEngine.InputSystem.TouchPhase.Moved)
        {
            float deltaX = touches[0].delta.x;
            AccionRotar(deltaX * 0.2f);
        }
    }

    // --- MANEJADORES VR ---
    private void OnSelectVR(InputAction.CallbackContext ctx)
    {
        Vector3 posController = (controllerTransform != null) ? controllerTransform.position : Vector3.zero;
        AccionSeleccionar(posController);
    }

    private void ProcesarEntradasContinuasVR()
    {
        // Agarrar con Grip continuo para simular escala
        float gripVal = escalarVRAction.action.ReadValue<float>();
        if (gripVal > 0.1f)
        {
            AccionEscalar(gripVal * Time.deltaTime);
        }

        // Joystick X para rotar de manera continua
        Vector2 joystickVal = rotarVRAction.action.ReadValue<Vector2>();
        if (Mathf.Abs(joystickVal.x) > 0.1f)
        {
            AccionRotar(joystickVal.x * 50f * Time.deltaTime);
        }
    }

    // --- LÓGICA DE NEGOCIO REUTILIZABLE (Sin Duplicación) ---
    private void AccionSeleccionar(Vector3 posicionUbicacion)
    {
        Debug.Log($"[LÓGICA CENTRALIZADA] Selección efectuada en la posición/coordenada: {posicionUbicacion}");
        // La lógica de negocio real del proyecto se ejecuta aquí de manera uniforme.
    }

    private void AccionEscalar(float deltaEscala)
    {
        Debug.Log($"[LÓGICA CENTRALIZADA] Escala modificada por un delta/factor de: {deltaEscala}");
    }

    private void AccionRotar(float deltaAngulo)
    {
        Debug.Log($"[LÓGICA CENTRALIZADA] Rotación aplicada con un ángulo/dirección de: {deltaAngulo}");
    }
}
```

2. Explicación en comentarios de por qué el diseño evita duplicación de lógica
>El diseño evita la duplicación de código separando de forma estricta la captura de la señal de hardware de la ejecución de la regla de negocio. El script actúa como un traductor/adaptador multinivel: los métodos dedicados de AR (pantalla táctil) y de VR (mando físico) procesan los datos crudos específicos de su entorno, pero ambos invocan los mismos métodos finales unificados (AccionSeleccionar, AccionEscalar, y AccionRotar). Esto garantiza que si en el futuro se altera el algoritmo de rotación, renderizado o selección, solo se deba actualizar un único punto lógico del código sin importar la plataforma elegida.

3. Tabla de decisiones: ¿qué clase de problema resuelve este patrón en proyectos reales?

|Clase de Problema que Resuelve | Descripción e Impacto en Producción |
|---|-----------|
| Fragmentación de Plataformas | Elimina la necesidad de bifurcar el proyecto o mantener múltiples ramas/escenas paralelas separadas para Android AR y dispositivos VR independientes como Meta Quest. |
| Altos Costos de Mantenimiento | Evita errores de sincronización de código de negocio. Si una regla cambia, no hay riesgo de actualizarla en los scripts de VR y olvidar aplicarla en los componentes móviles de AR. |
| Simulación Eficiente en Editor | Permite pruebas ágiles en el Unity Editor en modo AR (usando emuladores de toques o el mouse) compartiendo la estructura interactiva idéntica que usará el hardware nativo. |


> **Criterio de evaluación:**
> - Código compila sin errores: 10 pts
> - Detección correcta del modo: 5 pts
> - No duplicación de lógica de negocio: 5 pts
> - Uso correcto de OnEnable/OnDisable: 5 pts

---

## RÚBRICA DE AUTOEVALUACIÓN

Antes de entregar, verifica:

| Criterio | Cumplido |
|----------|---------|
| Respondí todas las preguntas de la Sección I | ☐ |
| Completé todos los espacios de la Sección II-A | ☐ |
| Relacioné todos los items de la Sección II-B | ☐ |
| Identifiqué los 4 errores del Caso 1 con correcciones | ☐ |
| El Input Actions Asset del Caso 2 tiene tipos correctos (Button/Value) | ☐ |
| El código de la Sección IV compila (lo verifiqué en Unity) | ☐ |
| Usé `OnEnable`/`OnDisable` (no `Start`/`OnDestroy`) para los eventos | ☐ |
| El archivo está en formato `.md` con código en bloques ` ```csharp ` | ☐ |

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 11 | 2026-1*
