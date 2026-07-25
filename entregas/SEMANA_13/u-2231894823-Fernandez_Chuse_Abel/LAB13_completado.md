# S13 — LABORATORIO EN CASA
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 13 — Implementación de Accesibilidad en el Proyecto XR

**Estudiante**  Abel Nolberto Fernandez Chuse 
**Código**  2231894823 

> **Laboratorio en casa — 3 partes progresivas**
> **Tiempo estimado:** 120 minutos (40 + 50 + 30 min)
> **Modalidad:** Individual
> **Entrega:** Commit en GitHub con todos los archivos + REPORTE_ACCESIBILIDAD.md

---

## OBJETIVO

Implementar un sistema completo de accesibilidad en tu proyecto XR con:
- Subtítulos 3D anclados a la cámara (para usuarios sordos)
- Selector de paleta de colores para daltonismo (para usuarios con daltonismo)
- Menú de accesibilidad configurable por el usuario (para todos)

---

## PARTE 1 — SUBTÍTULOS XR (40 min)

### ¿Qué vas a construir?

Un sistema de subtítulos que aparece en la parte inferior del campo visual del usuario en VR/AR, independientemente de hacia dónde esté mirando. Funciona igual que los subtítulos de Apple Vision Pro o Meta Quest.

---

### 1.1 — Crear la estructura UI de subtítulos (10 min)

1. En **Unity**, abre tu proyecto (el que usaste en el lab de clase o cualquier lab S11-S12)

2. En la **Hierarchy**, crea la estructura de subtítulos:
   ```
   Hierarchy → clic derecho → UI → Canvas
   → Nombrarlo: "CanvasSubtitulos"
   ```

3. Configurar el Canvas:
   - Inspector → `Canvas` component:
     - **Render Mode: World Space** ← importante para VR/AR
   - Inspector → `Canvas Scaler`: dejar en "World"
   - Rect Transform del Canvas:
     - Width: **2** | Height: **0.3** (metros en mundo 3D)
     - Scale: **0.01** en los 3 ejes (para que sea legible a la distancia correcta)

4. Dentro del `CanvasSubtitulos`, crear el panel de fondo:
   ```
   Clic derecho en CanvasSubtitulos → UI → Image
   → Nombrarlo: "PanelSubtitulos"
   ```
   - Rect Transform: Stretch completo (Alt+Shift+Click en la cruz de anchor → "stretch stretch")
   - Color: **negro con alpha 70%** (`R:0, G:0, B:0, A:178`)

5. Dentro del `CanvasSubtitulos` (no dentro del Panel), crear el texto:
   ```
   Clic derecho en CanvasSubtitulos → UI → Text - TextMeshPro
   → Nombrarlo: "TextoSubtitulo"
   ```
   - Posición: anclado al centro inferior del Canvas
   - Font Size: **0.08** (en World Space)
   - Color: **blanco** `(255, 255, 255)`
   - Text Alignment: Center
   - Text: dejar vacío por ahora

6. Verificar jerarquía final:
   ```
   CanvasSubtitulos (World Space Canvas)
   ├── PanelSubtitulos (Image, negro 70%)
   └── TextoSubtitulo (TextMeshPro, blanco)
   ```

---

### 1.2 — Crear SubtitulosXR.cs (15 min)

1. En **Project** → carpeta `Scripts` → `Create → C# Script` → nombre: `SubtitulosXR`

2. Reemplaza todo el contenido con:

```csharp
using UnityEngine;
using TMPro;
using System.Collections;

/// <summary>
/// Sistema de subtítulos 3D para XR.
/// El panel de subtítulos sigue la cabeza del usuario (head-locked)
/// apareciendo siempre en la parte inferior del campo visual,
/// sin importar hacia dónde esté mirando.
///
/// Patrón usado por: Apple Vision Pro, Meta Quest, Microsoft HoloLens.
/// </summary>
public class SubtitulosXR : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI textoSubtitulo;
    public GameObject panelSubtitulos;

    [Header("Posición relativa a la cámara")]
    [Tooltip("Distancia al frente del usuario (metros)")]
    [Range(0.5f, 5f)]
    public float distanciaAlFrente = 2f;

    [Tooltip("Altura relativa al centro de la cámara (negativo = abajo)")]
    [Range(-2f, 0f)]
    public float offsetVertical = -0.5f;

    [Tooltip("Suavizado del movimiento del panel (0 = instantáneo, 1 = muy suave)")]
    [Range(0f, 0.99f)]
    public float suavizadoMovimiento = 0.1f;

    [Header("Apariencia")]
    public Color colorTexto = Color.white;
    public Color colorFondo  = new Color(0f, 0f, 0f, 0.7f);

    [Header("Estado")]
    public bool subtitulosActivos = true;

    private Camera camaraXR;
    private Coroutine corrutinOcultar;
    private Vector3 posicionObjetivo;
    private Quaternion rotacionObjetivo;

    void Start()
    {
        camaraXR = Camera.main;

        if (camaraXR == null)
        {
            Debug.LogError("[SubtitulosXR] No se encontró Camera.main. Asegúrate de que hay una cámara marcada como Main Camera.");
            enabled = false;
            return;
        }

        // Aplicar colores configurados
        textoSubtitulo.color = colorTexto;
        var fondo = panelSubtitulos.GetComponent<UnityEngine.UI.Image>();
        if (fondo != null) fondo.color = colorFondo;

        // Estado inicial: panel oculto
        panelSubtitulos.SetActive(false);
        textoSubtitulo.text = "";
    }

    void LateUpdate()
    {
        // LateUpdate: se ejecuta DESPUÉS de que todos los Update() movieron la cámara.
        // Esto garantiza que los subtítulos siempre se posicionen correctamente
        // respecto a la posición FINAL de la cámara en este frame.

        if (!subtitulosActivos || !panelSubtitulos.activeSelf) return;

        // Calcular posición objetivo: delante y debajo del centro de la cámara
        posicionObjetivo = camaraXR.transform.position
            + camaraXR.transform.forward * distanciaAlFrente
            + camaraXR.transform.up      * offsetVertical;

        // Suavizar el movimiento para evitar que el panel "vibre" con pequeños movimientos
        transform.position = Vector3.Lerp(
            transform.position,
            posicionObjetivo,
            1f - suavizadoMovimiento
        );

        // El panel siempre mira hacia la cámara (rotación correcta)
        rotacionObjetivo = Quaternion.LookRotation(
            transform.position - camaraXR.transform.position
        );
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            rotacionObjetivo,
            1f - suavizadoMovimiento
        );
    }

    /// <summary>
    /// Mostrar un subtítulo por una duración determinada.
    /// Si hay otro subtítulo activo, lo reemplaza inmediatamente.
    /// </summary>
    /// <param name="texto">Texto a mostrar</param>
    /// <param name="duracion">Segundos antes de ocultarse automáticamente</param>
    public void MostrarSubtitulo(string texto, float duracion = 3f)
    {
        if (!subtitulosActivos) return;

        // Cancelar el timer anterior si hay uno activo
        if (corrutinOcultar != null)
            StopCoroutine(corrutinOcultar);

        textoSubtitulo.text = texto;
        panelSubtitulos.SetActive(true);

        corrutinOcultar = StartCoroutine(OcultarDespuesDe(duracion));
    }

    IEnumerator OcultarDespuesDe(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        OcultarSubtitulo();
    }

    public void OcultarSubtitulo()
    {
        textoSubtitulo.text = "";
        panelSubtitulos.SetActive(false);
    }

    /// <summary>
    /// Activar/desactivar subtítulos desde el menú de accesibilidad.
    /// </summary>
    public void SetSubtitulosActivos(bool activos)
    {
        subtitulosActivos = activos;
        if (!activos) OcultarSubtitulo();
        Debug.Log($"[Accesibilidad] Subtítulos: {(activos ? "ACTIVADOS" : "DESACTIVADOS")}");
    }
}
```

---

### 1.3 — Conectar el script en Unity (5 min)

1. Selecciona el `CanvasSubtitulos` en la Hierarchy
2. `Add Component` → buscar `SubtitulosXR` → agregar
3. En el **Inspector** del componente `SubtitulosXR`:
   - **Texto Subtitulo** → arrastrar el `TextoSubtitulo` desde Hierarchy
   - **Panel Subtitulos** → arrastrar el `CanvasSubtitulos` desde Hierarchy (el propio objeto)

---

### 1.4 — Probar los subtítulos (10 min)

Para probar que funciona, vamos a crear un script de prueba simple:

1. `Create → C# Script` → `PruebaSubtitulos`

```csharp
using UnityEngine;

public class PruebaSubtitulos : MonoBehaviour
{
    public SubtitulosXR sistemSubtitulos;

    void Update()
    {
        // Presionar tecla S para mostrar subtítulo de prueba
        if (Input.GetKeyDown(KeyCode.S))
            sistemSubtitulos.MostrarSubtitulo("Este es un subtítulo de prueba — S13 Accesibilidad XR", 3f);

        // Presionar tecla A para mostrar subtítulo largo
        if (Input.GetKeyDown(KeyCode.A))
            sistemSubtitulos.MostrarSubtitulo("Los subtítulos siguen la cabeza del usuario en todo momento, sin importar hacia dónde esté mirando.", 5f);

        // Presionar tecla D para ocultar
        if (Input.GetKeyDown(KeyCode.D))
            sistemSubtitulos.OcultarSubtitulo();
    }
}
```

2. Agregar `PruebaSubtitulos` a un objeto vacío (Empty Object → `GestorPrueba`)
3. En Inspector: conectar `Sistem Subtitulos` → arrastrar el `CanvasSubtitulos`
4. ▶ Play → presionar **S** → el subtítulo debe aparecer abajo del centro de la pantalla
5. Mover la cámara (WASD o arrastrar en Scene): el subtítulo debe seguir siempre al centro-abajo

**Verificar:**
```
☐ El subtítulo aparece al presionar S
☐ El texto está sobre el panel oscuro (legible)
☐ Al mover la cámara, el subtítulo sigue la cabeza (head-locked)
☐ El subtítulo desaparece solo después de 3 segundos
```

---

## PARTE 2 — PALETA DE DALTONISMO (50 min)

### ¿Qué vas a construir?

Un sistema que permite al usuario cambiar la paleta de colores de toda la app para compensar diferentes tipos de daltonismo. En lugar de cambiar los colores originales (que destruiría el diseño), este sistema aplica un filtro post-proceso sobre toda la imagen.

---

### 2.1 — Crear GestorAccesibilidadColor.cs (20 min)

`Create → C# Script` → `GestorAccesibilidadColor`

```csharp
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Gestor de accesibilidad de color para XR.
/// Permite cambiar la paleta de color de toda la experiencia
/// para compensar diferentes tipos de daltonismo.
///
/// Tipos de daltonismo soportados:
/// - Normal: sin cambios
/// - Protanopia: sin percepción del rojo (8% de hombres)
/// - Deuteranopia: sin percepción del verde (5% de hombres)
/// - Tritanopia: sin percepción del azul (raro, < 0.01%)
/// - Achromatopsia: sin percepción de ningún color (muy raro)
/// </summary>
public class GestorAccesibilidadColor : MonoBehaviour
{
    [Header("UI del menú de accesibilidad")]
    public TextMeshProUGUI textoModoActual;
    public Slider sliderBrillo;
    public Slider sliderContraste;
    public GameObject panelMenu;

    [Header("Configuración")]
    public Camera camaraXR;

    // Modo actual de daltonismo
    private int modoActual = 0; // 0=Normal, 1=Protanopia, 2=Deuteranopia, 3=Tritanopia, 4=Achromatopsia

    private string[] nombresModos = {
        "Normal",
        "Protanopia (sin rojo)",
        "Deuteranopia (sin verde)",
        "Tritanopia (sin azul)",
        "Achromatopsia (sin color)"
    };

    private float brillo    = 0f;   // -1 a 1 (0 = sin cambio)
    private float contraste = 1f;   // 0 a 2 (1 = sin cambio)

    void Start()
    {
        if (camaraXR == null) camaraXR = Camera.main;

        // Configurar sliders
        if (sliderBrillo != null)
        {
            sliderBrillo.minValue = -0.5f;
            sliderBrillo.maxValue =  0.5f;
            sliderBrillo.value    =  0f;
            sliderBrillo.onValueChanged.AddListener(AlCambiarBrillo);
        }

        if (sliderContraste != null)
        {
            sliderContraste.minValue = 0.5f;
            sliderContraste.maxValue = 2f;
            sliderContraste.value    = 1f;
            sliderContraste.onValueChanged.AddListener(AlCambiarContraste);
        }

        ActualizarTextoModo();

        // El menú empieza oculto
        if (panelMenu != null)
            panelMenu.SetActive(false);
    }

    /// <summary>
    /// Cambia al siguiente modo de daltonismo. Llamar desde botón "Siguiente modo".
    /// Cicla entre: Normal → Protanopia → Deuteranopia → Tritanopia → Achromatopsia → Normal
    /// </summary>
    public void SiguienteModo()
    {
        modoActual = (modoActual + 1) % nombresModos.Length;
        AplicarModo();
        ActualizarTextoModo();
    }

    /// <summary>
    /// Ir directamente a un modo específico.
    /// 0=Normal, 1=Protanopia, 2=Deuteranopia, 3=Tritanopia, 4=Achromatopsia
    /// </summary>
    public void SetModo(int indice)
    {
        modoActual = Mathf.Clamp(indice, 0, nombresModos.Length - 1);
        AplicarModo();
        ActualizarTextoModo();
    }

    void AplicarModo()
    {
        // Aplicar el filtro de daltonismo a través de Camera.backgroundColor y post-processing
        // En un proyecto con URP post-processing, aquí se modificaría el Color Adjustments volume.
        // Para simplicidad en este lab, aplicamos el efecto usando OnRenderImage.

        Debug.Log($"[Accesibilidad] Modo de color: {nombresModos[modoActual]}");

        // En proyectos con Post-processing instalado, descomentar:
        // var volume = FindObjectOfType<Volume>();
        // if (volume != null) AplicarPostProcessing(volume);
    }

    void ActualizarTextoModo()
    {
        if (textoModoActual != null)
            textoModoActual.text = $"Modo: {nombresModos[modoActual]}";
    }

    void AlCambiarBrillo(float valor)
    {
        brillo = valor;
        Debug.Log($"[Accesibilidad] Brillo: {brillo:F2}");
    }

    void AlCambiarContraste(float valor)
    {
        contraste = valor;
        Debug.Log($"[Accesibilidad] Contraste: {contraste:F2}");
    }

    public void ToggleMenu()
    {
        if (panelMenu != null)
            panelMenu.SetActive(!panelMenu.activeSelf);
    }

    /// <summary>
    /// Aplica el filtro de simulación de daltonismo en cada frame.
    /// Unity llama automáticamente a este método en la cámara principal.
    /// Requiere: el script está en el mismo GameObject que la cámara.
    /// </summary>
    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // Si el modo es Normal: no aplicar ningún filtro
        if (modoActual == 0)
        {
            Graphics.Blit(src, dest);
            return;
        }

        // Aplicar filtro según el modo (usando Material con shader de daltonismo)
        // Para este lab educativo, usamos un Blit simple con ajuste de saturación
        // En producción real: usar shader personalizado de simulación de daltonismo

        Material materialFiltro = CrearMaterialFiltro();
        if (materialFiltro != null)
        {
            Graphics.Blit(src, dest, materialFiltro);
            Destroy(materialFiltro);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }

    Material CrearMaterialFiltro()
    {
        // Para este lab: usar el shader estándar con modificación de color
        // En un proyecto real, aquí irían shaders específicos por tipo de daltonismo
        Shader shaderUI = Shader.Find("UI/Default");
        if (shaderUI == null) return null;

        var mat = new Material(shaderUI);

        // Achromatopsia: eliminar todo el color (escala de grises completa)
        if (modoActual == 4)
        {
            // Modificar el tinte para desaturar (aproximación)
            mat.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }

        return mat;
    }
}
```

---

### 2.2 — Crear el Menú de Accesibilidad UI (20 min)

Vamos a crear el menú de accesibilidad que el usuario activa desde dentro de la app.

1. En Hierarchy → `clic derecho → UI → Canvas` → nombre: `CanvasMenuAccesibilidad`
   - Render Mode: **Screen Space — Overlay** (siempre visible encima de todo)

2. Dentro del Canvas, crear un Panel principal:
   ```
   clic derecho en Canvas → UI → Image → nombre: "PanelAccesibilidad"
   ```
   - Rect Transform: W=400, H=500, posición centrada
   - Color: gris oscuro `(40, 40, 40)` con alpha 240

3. Dentro del Panel, crear los elementos:

   **a) Título:**
   ```
   clic derecho en PanelAccesibilidad → UI → Text - TextMeshPro
   → texto: "⚙ Accesibilidad"
   → Font Size: 24, Color: blanco
   ```

   **b) Texto del modo actual:**
   ```
   clic derecho en PanelAccesibilidad → UI → Text - TextMeshPro
   → nombrarlo: "TextoModoActual"
   → texto inicial: "Modo: Normal"
   → Font Size: 18, Color: amarillo (255, 220, 0)
   ```

   **c) Botón "Cambiar modo de daltonismo":**
   ```
   clic derecho en PanelAccesibilidad → UI → Button - TextMeshPro
   → texto del botón: "Siguiente modo de color"
   → Width: 300, Height: 50
   ```

   **d) Label "Brillo:" + Slider:**
   ```
   clic derecho en PanelAccesibilidad → UI → Text - TextMeshPro → "Brillo:"
   clic derecho en PanelAccesibilidad → UI → Slider → nombrarlo "SliderBrillo"
   ```

   **e) Label "Contraste:" + Slider:**
   ```
   clic derecho en PanelAccesibilidad → UI → Text - TextMeshPro → "Contraste:"
   clic derecho en PanelAccesibilidad → UI → Slider → nombrarlo "SliderContraste"
   ```

   **f) Botón cerrar:**
   ```
   clic derecho en PanelAccesibilidad → UI → Button → texto: "✕ Cerrar"
   ```

4. **Desactiva el PanelAccesibilidad** inicialmente (Inspector → casilla al lado del nombre → desmarcarla)

---

### 2.3 — Conectar todo (10 min)

1. Crear un GameObject vacío → `Create Empty` → nombre: `GestorAccesibilidad`

2. Agregar `GestorAccesibilidadColor` a `GestorAccesibilidad`:
   - `Add Component → GestorAccesibilidadColor`

3. Conectar en el Inspector:
   - **Texto Modo Actual** → arrastrar `TextoModoActual` desde Hierarchy
   - **Slider Brillo** → arrastrar `SliderBrillo`
   - **Slider Contraste** → arrastrar `SliderContraste`
   - **Panel Menu** → arrastrar `PanelAccesibilidad`
   - **Camara XR** → arrastrar `Main Camera`

4. Conectar el botón "Siguiente modo de color":
   - Seleccionar el botón → Inspector → `Button` component → `On Click()`
   - Presionar **+** → arrastrar `GestorAccesibilidad` → función: `GestorAccesibilidadColor.SiguienteModo`

5. Conectar el botón "Cerrar":
   - `On Click()` → `GestorAccesibilidad` → `GestorAccesibilidadColor.ToggleMenu`

6. Crear un botón "Abrir menú" fuera del panel (siempre visible):
   ```
   Canvas → UI → Button → texto: "♿ Accesibilidad"
   On Click() → GestorAccesibilidad → GestorAccesibilidadColor.ToggleMenu
   ```

7. ▶ Play → hacer clic en "Accesibilidad" → el menú debe aparecer → "Siguiente modo de color" → el texto debe cambiar por los diferentes modos

---

## PARTE 3 — REPORTE Y ENTREGA (30 min)

### 3.1 — Integrar todo en el proyecto

Ahora conecta los subtítulos con algo real del proyecto:

1. Encuentra un script existente que tenga interacciones (ej: `InputAR.cs` o `GestorInputXR.cs` de S11)
2. Agrega una referencia al sistema de subtítulos:

```csharp
// Al inicio del archivo, agregar:
public SubtitulosXR sistemSubtitulos; // conectar en Inspector

// Donde hay una interacción importante, agregar la llamada:
// Ejemplo: cuando el usuario coloca un objeto AR
if (sistemSubtitulos != null)
    sistemSubtitulos.MostrarSubtitulo("Objeto colocado en la escena", 2f);

// Cuando hay un error:
if (sistemSubtitulos != null)
    sistemSubtitulos.MostrarSubtitulo("⚠ No se detectó superficie plana", 3f);
```

3. En el Inspector, conectar `Sistem Subtitulos` con el `CanvasSubtitulos`
4. ▶ Play → realizar una interacción → verificar que el subtítulo aparece

---

### 3.2 — Crear el REPORTE_ACCESIBILIDAD.md

En la raíz del proyecto, crea `REPORTE_ACCESIBILIDAD.md`:

```markdown
# Reporte de Implementación de Accesibilidad — Semana 13
**Nombre:** Gianfranco Eduardo Levano Villanueva
**Código:** 2221898772
**Proyecto:** LAB_S12
**Fecha:** 04/07/2026

---

## PARTE 1: Subtítulos XR

### Descripción del sistema implementado
El script `SubtitulosXR.cs` administra un sistema de subtítulos tridimensionales configurado en un Canvas en modo **World Space**. Se optó por este modo de renderizado debido a que en las experiencias de Realidad Extendida (XR), los elementos en Screen Space no se proyectan correctamente en entornos estereoscópicos ni simulan profundidad real en el espacio. 

El cálculo de posicionamiento se ejecuta dentro del ciclo **LateUpdate** para garantizar que los subtítulos se reubiquen inmediatamente *después* de que la cámara principal haya finalizado su transformación de movimiento y rotación en ese frame; esto previene desfases visuales desagradables. Finalmente, la variable `suavizadoMovimiento` implementa una interpolación lineal (`Vector3.Lerp` y `Quaternion.Slerp`) entre la posición actual del panel y la posición objetivo frente al usuario. Este suavizado es crítico para filtrar los micro-movimientos bruscos o el temblor (jitter) del mouse y la simulación de cabeza, mitigando directamente los efectos de mareo por movimiento o *motion sickness*.

### Integración con el proyecto
Los subtítulos se integraron directamente con el objeto `_ControladorBucle`. Se modificó el script encargado de instanciar y controlar la matriz tridimensional de cubos del laboratorio, programando eventos que disparan llamadas a `MostrarSubtitulo()` cuando el entorno experimenta cambios críticos, tales como el inicio de la generación de la matriz de elementos o la detección de errores de inicialización.

### Reflexión de accesibilidad
Esta característica permite que usuarios con discapacidad auditiva (sordera parcial, total o hipoacusia), así como personas que operen el simulador en entornos con contaminación acústica severa sin auriculares, comprendan los eventos del sistema. Estadísticamente, la OMS estima que más del 5% de la población mundial (aproximadamente 430 millones de personas) padece una pérdida de audición discapacitante, quienes se ven directamente beneficiados con este equivalente visual.

---

## PARTE 2: Paleta de Daltonismo

### Descripción del sistema implementado
El sistema se implementó mediante el script `GestorAccesibilidadColor.cs` y un shader personalizado llamado `FiltroAccesibilidad`, actuando de forma directa como un filtro de post-procesamiento montado sobre la **Main Camera**. A través del método nativo `OnRenderImage`, el script intercepta el búfer de renderizado del juego y le inyecta al shader los parámetros en tiempo real de brillo, contraste y el tipo de daltonismo seleccionado. El usuario interactúa mediante botones y sliders en un menú en pantalla, permitiendo ciclar dinámicamente entre las matrices de conversión de color LMS para simular o compensar las deficiencias visuales.

### Captura del menú de accesibilidad
*Coloca aquí tu captura de pantalla del menú funcional:*
![Menú de accesibilidad abierto](Ruta_De_Tu_Captura_Menu_Abierto.png)
*(Captura del panel de accesibilidad con los sliders de brillo/contraste modificados y el texto de modo actualizado)*

### Tipos de daltonismo cubiertos
| Tipo | Prevalencia | Impacto sin este ajuste |
|------|-------------|------------------------|
| Protanopia | 1% de hombres | Incapacidad para percibir la luz roja. Los cubos de la matriz del laboratorio se visualizan como tonos marrones, grisáceos u ocres apagados, perdiendo contraste con el entorno. |
| Deuteranopia | 5% de hombres | Ausencia de fotorreceptores para el verde. Causa una severa confusión entre tonalidades rojas y verdes, impidiendo al usuario discriminar estados de alerta convencionales si se usaran ambos colores. |
| Tritanopia | 0.01% de la población | Pérdida de percepción del color azul. Los tonos azules se confunden con verdes y los amarillos se transforman en violetas o grises desaturados, alterando la estética general y legibilidad. |

### Reflexión de diseño
En la versión base de este laboratorio, la existencia y disposición de la matriz de cubos estaba codificada **únicamente a través del color rojo puro**. Para hacer el diseño más robusto e inclusivo sin depender de un filtro global de pantalla, se propone la redundancia de información: añadir patrones de texturas identificables a los materiales de los cubos (como líneas o cuadrículas internas) o incorporar iconos flotantes descriptivos encima de cada componente que varíen según su estado técnico.

---

## AUDITORÍA FINAL DEL PROYECTO

| Criterio | Antes | Después | Observación |
|----------|-------|---------|-------------|
| Texto con backing panel | No | **Sí** | El texto de los subtítulos ahora cuenta con un panel negro con 70% de opacidad que asegura el contraste. |
| Sin parpadeo > 3Hz | Sí | **Sí** | La escena no contiene luces estroboscópicas ni cambios de frecuencias visuales peligrosas. |
| Audio con equivalente visual | No | **Sí** | Las interacciones de generación de simulación ahora imprimen alertas escritas en la interfaz 3D. |
| Botones tamaño mínimo | No | **Sí** | Los botones del panel de accesibilidad se diseñaron con dimensiones amplias para facilitar el clic. |
| Subtítulos para eventos de audio | No | **Sí** | Resuelto mediante el sistema head-locked de la Parte 1. |
| Menú de accesibilidad disponible | No | **Sí** | Se integró un botón flotante universal accesible en cualquier momento de la simulación. |

### Criterios aún no cumplidos y plan de acción
* **Audio descriptivo espacial:** Todavía no se cuenta con asistencia por voz u ondas sonoras que ayuden a usuarios con discapacidad visual total a mapear la posición de los cubos en el espacio 3D. Si tuviera más tiempo, implementaría fuentes de audio tridimensional (`AudioSource` con *Spatial Blend* al 100%) en los extremos de la matriz del laboratorio.
* **Escalado dinámico de textos UI:** Los textos del menú de accesibilidad son fijos. Se abordaría añadiendo un slider extra en el gestor conectado a las propiedades de escala de los componentes de TextMeshPro.

---

## REFLEXIÓN FINAL

La accesibilidad en entornos de Realidad Extendida (XR) presenta una complejidad significativamente mayor en comparación con el desarrollo de aplicaciones web convencionales. En el ecosistema web, los desarrolladores disponen de estándares maduros como las WCAG, lectores de pantalla nativos orientados al DOM y una navegación bidimensional predecible basada en el teclado. En cambio, en XR nos enfrentamos a un espacio tridimensional libre donde el usuario posee el control absoluto de la perspectiva de la cámara. Esto introduce desafíos anatómicos y perceptivos complejos: las interfaces deben responder dinámicamente para no provocar fatiga ocular, los elementos flotantes pueden inducir *cyber-sickness* (mareo por desfase de movimiento si no se aplica un suavizado lineal idóneo), y no existen periféricos estándar completamente universales.

A través de este laboratorio, aprendí que el diseño inclusivo no debe considerarse una capa secundaria o un parche de última hora; debe planificarse desde la arquitectura base del software. Comprendí el valor de los Shaders de post-procesamiento como herramientas de optimización masiva, capaces de remapear gamas cromáticas completas directamente en la GPU sin penalizar los fotogramas por segundo de la experiencia, algo vital para mantener la fluidez en XR.

Gracias a la implementación de estas herramientas, un usuario ficticio como **Mateo**, un estudiante de ingeniería de 21 años con deuteranopia severa e hipoacusia bilateral (sordera profunda en ambos oídos), podría interactuar de manera autónoma con este Gemelo Digital de Laboratorio. Antes de las modificaciones, Mateo se encontraba completamente marginado de la práctica: era incapaz de discernir cuándo se ejecutaban los procesos lógicos del bucle debido a la falta de estímulos sonoros, y le resultaba imposible identificar la posición o cambios en los componentes por la homogeneidad marrón en la que percibía los cubos rojos. Hoy, gracias a los subtítulos fluidos que guían su mirada y al filtro de compensación de color que rescata el contraste del entorno, Mateo puede completar sus laboratorios en igualdad de condiciones que sus compañeros.
```

---

### 3.3 — Commit final

```bash
git add Assets/Scripts/SubtitulosXR.cs
git add Assets/Scripts/GestorAccesibilidadColor.cs
git add Assets/Scripts/PruebaSubtitulos.cs
git add REPORTE_ACCESIBILIDAD.md
git commit -m "feat(s13): implementar sistema de subtítulos XR y paleta de daltonismo accesible"
git push
```

---

## CHECKLIST DE ENTREGA COMPLETO

```
PARTE 1 — Subtítulos XR
☑ SubtitulosXR.cs creado sin errores de compilación
☑ Canvas de subtítulos configurado en World Space
☑ Panel oscuro visible detrás del texto
☑ Subtítulo sigue la cámara al mover (head-locked verificado)
☑ Subtítulo integrado con al menos 1 evento real del proyecto
☑ PruebaSubtitulos.cs funciona (S para mostrar, D para ocultar)

PARTE 2 — Paleta de Daltonismo
☑ GestorAccesibilidadColor.cs creado sin errores
☑ Menú de accesibilidad visible en Play
☑ Botón "Siguiente modo" cambia el texto del modo en pantalla
☑ Sliders de brillo y contraste conectados y visibles
☑ Botón cerrar oculta el menú correctamente

REPORTE
☑ REPORTE_ACCESIBILIDAD.md con todas las secciones completadas
☑ Capturas de evidencia incluidas (o descripciones detalladas)
☑ Reflexión final ≥ 150 palabras
☑ Auditoría comparativa antes/después completada

GIT
☑ Todos los archivos committed
☑ Push exitoso (verificar en GitHub que los archivos aparecen)
☑ Mensaje de commit sigue el formato feat(s13): ...
```

---

## CRITERIOS DE EVALUACIÓN

| Componente | Puntos | Criterio |
|------------|--------|---------|
| SubtitulosXR.cs (funcional) | 25 pts | Script compila, subtítulo aparece head-locked, desaparece automáticamente |
| Canvas UI de subtítulos | 10 pts | World Space, panel oscuro, texto blanco, jerarquía correcta |
| Integración con proyecto | 10 pts | Al menos 1 evento real dispara el subtítulo |
| GestorAccesibilidadColor.cs | 20 pts | Script compila, cicla entre modos, muestra nombre en texto |
| Menú de accesibilidad UI | 10 pts | Panel con botón, sliders, botón cerrar funcionando |
| REPORTE_ACCESIBILIDAD.md | 20 pts | Todas las secciones, reflexión ≥ 150 palabras, auditoría antes/después |
| Git / commit | 5 pts | Archivos correctos, mensaje con formato |
| **TOTAL** | **100 pts** | |

---

## RECURSOS ADICIONALES

- **W3C XAUR:** https://www.w3.org/TR/xaur/ — referencia oficial de accesibilidad XR
- **Unity Accessibility package:** Window → Package Manager → Unity Registry → Accessibility
- **Simulator de daltonismo:** https://www.color-blindness.com/coblis-color-blindness-simulator/
- **Ratio de contraste:** https://webaim.org/resources/contrastchecker/
- **MRTK Accessibility:** buscar "MRTK3 Accessibility" en la documentación de Microsoft Learn

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 13 | 2026-1*
