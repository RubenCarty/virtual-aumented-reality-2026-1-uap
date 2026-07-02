# LAB 12 — LABORATORIO EN CASA
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 12 — Optimización Completa del Proyecto XR

---

| Campo | Detalle |
|-------|---------|
| **Estudiante** | Gianfranco Eduardo Levano Villanueva |
| **Código** | 2221898772 |
| **Fecha de entrega** | 27/06/2026 |
| **Objetivo** | Aplicar un ciclo completo de optimización al proyecto grupal usando Profiler, Static Batching, LOD Groups, y optimización de scripts |
| **Competencia** | Diagnosticar y resolver problemas de rendimiento en aplicaciones XR usando herramientas profesionales |
| **Tiempo estimado** | 2 horas |
| **Modalidad** | Individual (aplicas las técnicas a tu parte del proyecto grupal) |

---

## SOFTWARE Y HERRAMIENTAS REQUERIDAS

| Herramienta | Versión | Propósito | Link |
|-------------|---------|-----------|------|
| Unity | 2022.3.x LTS | Desarrollo y optimización | https://unity.com/releases |
| Unity Profiler | Incluido en Unity | Diagnóstico de rendimiento | Integrado |
| ProBuilder (opcional) | 5.0.x | Crear LODs simplificados | Package Manager |
| Git | 2.x+ | Control de versiones | https://git-scm.com |

**Verificación del entorno:**
```
1. Abrir Unity → tu proyecto AR/VR
2. Window → Analysis → Profiler → si abre sin error: ✓
3. Presionar Play → ver panel Stats → si muestra FPS: ✓
4. git status → si muestra estado del repo: ✓
```

**Si no tienes un proyecto propio:** usa el proyecto `lab_11_inputs` de semanas anteriores y agrega 50+ objetos a la escena para que las optimizaciones sean medibles.

---

## PARTE 1 — EXPLORACIÓN: DIAGNÓSTICO COMPLETO (30 min)

### Objetivo
Antes de optimizar nada, hacer un diagnóstico completo del estado actual del proyecto.

### Actividad 1.1 — Medir el estado base (10 min)

Abre tu proyecto y anota los valores ANTES de cualquier cambio:

**Panel Stats (Window → Game → Stats):**

```
ESTADO BASE DEL PROYECTO
═══════════════════════════════════════════════════════
Fecha/hora de medición: 27/06/2026, 1:57 PM
FPS (promedio durante 30 seg de juego): 124.8 FPS
FPS (mínimo durante 30 seg): 91.2 FPS
Draw Calls: 369 Batches
Tris renderizados: 7.2k
Verts renderizados: 14.4k
Used Memory: 18.8 MB MB
═══════════════════════════════════════════════════════
```

Toma una captura de pantalla del panel Stats con estos valores → guardar como `01_estado_base.png`.

---

### Actividad 1.2 — Profiler en profundidad (15 min)

1. Abre el Profiler: **Window → Analysis → Profiler**
2. Asegúrate de que está en modo **"Playmode"**
3. Presiona Play → espera 30 segundos de juego activo (mueve la cámara, interactúa)
4. Detén el Play

5. En la gráfica del Profiler:
   - Identifica los **3 frames más lentos** (los 3 picos más altos)
   - Haz clic en el más lento

6. En la tabla inferior, expande cada categoría y anota:

```
ANÁLISIS DEL FRAME MÁS LENTO
═══════════════════════════════════════════════════════
Tiempo total del frame: 733.26 ms
CPU time: 733.26 ms
GPU time: -- ms

Top 5 procesos por tiempo:
1. EditorLoop: 729.93 ms
2. PlayerLoop: 3.00 ms
3. Profiler.FlushCounters: 0.27 ms
4. Profiler.CollectEditorStats: 0.00 ms
5. (No hay más procesos en la lista) : 0 ms

¿CPU bound o GPU bound?: CPU bound
Columna GC Alloc total: 40 bytes/frame

Scripts con mayor GC Alloc:
1. PlayerLoop (Interno del motor) : 40 bytes
2. (No hay más procesos con GC) : 0 bytes
═══════════════════════════════════════════════════════
```

---

### Actividad 1.3 — Análisis de la escena (5 min)

En tu Hierarchy, cuenta y anota:

```
INVENTARIO DE LA ESCENA
═══════════════════════════════════════════════════════
Total de GameObjects activos: 64
Objetos que NO se mueven (candidatos Static Batching): 61
Objetos que SÍ se mueven: 0 
Materiales únicos en la escena: 2 
¿Hay objetos con el mismo mesh+material? ☑ Sí  ☐ No
Luces dinámicas en la escena: 1 
¿Hay post-processing activo?: ☐ Sí  ☑ No
═══════════════════════════════════════════════════════
```

**Pregunta de reflexión 1.3:**
> Basándote en el inventario, ¿cuál técnica de optimización tiene más potencial de impacto en tu escena: Static Batching, GPU Instancing, o LOD Groups? Justifica en 3 líneas.

Basándote en nuestro inventario actual, la técnica con mayor potencial de impacto inmediato es el Static Batching. Al tener más de 60 objetos duplicados compartiendo el mismo material (Mat_Objetos) que nunca se van a mover en la experiencia, agruparlos en un solo bloque de renderizado colapsará las más de 60 Draw Calls a prácticamente 1 o 2, liberando drásticamente la carga de la CPU.

---

## PARTE 2 — APLICACIÓN: OPTIMIZACIÓN SISTEMÁTICA (60 min)

### Objetivo
Aplicar 3 técnicas de optimización documentando el impacto de cada una.

---

### Actividad 2.1 — Static Batching (15 min)

**¿Cuándo aplica?** Objetos que no se mueven, del mismo material.

**Paso a paso:**

1. En Hierarchy, selecciona todos los objetos que **no se mueven en runtime** (paredes, suelo, decoraciones fijas, planos AR en posición fija, etc.)

2. **Método A — por objeto individual:**
   - Seleccionar el objeto
   - Inspector → casilla "Static" → activar ☑
   - Repetir para cada objeto estático

3. **Método B — por selección múltiple (más eficiente):**
   - En Hierarchy, mantener Ctrl y hacer clic en cada objeto estático
   - Con todos seleccionados: Inspector → "Static" → activar ☑
   - Elegir "Yes, change children" si tiene hijos

4. Verificar con Stats + Profiler:
   ```
   DESPUÉS DE STATIC BATCHING
   ═════════════════════════════════════════════════════════════════
   Objetos marcados como Static: Todos los cubos rojos de la escena
   FPS antes: 124.8 FPS | FPS después: 136.3 FPS
   Draw Calls antes: 369 | después: 15
   Cambio en Tris: Sin cambio (Permaneció igual en 7.2k)
   ═════════════════════════════════════════════════════════════════
   ```

5. Toma captura: `02_static_batching.png`

**Pregunta de análisis 2.1:**
> ¿Por qué los Draw Calls bajaron (o no bajaron) al marcar objetos como Static? Si no bajaron, ¿cuál crees que es la razón?

Los Draw Calls bajaron drásticamente debido a que Unity combinó las mallas de todos los cubos inmóviles que comparten el mismo material en una sola super-malla interna de manera estática. En lugar de decirle a la tarjeta gráfica "dibuja un cubo" 60 veces consecutivas (60 llamadas), le dice "dibuja este bloque combinado" una sola vez.

---

### Actividad 2.2 — LOD Groups (20 min)

**¿Cuándo aplica?** Objetos 3D que el usuario puede ver de cerca y de lejos.

**Configuración de un LOD Group en Unity:**

Para este laboratorio usarás un solo objeto complejo (el cubo o cualquier objeto de tu escena que sea visible a diferentes distancias).

**Preparación — Crear versiones simplificadas:**

1. Selecciona el objeto principal (ej: un cubo o modelo 3D)
2. Duplica: **Ctrl+D** → renombra la copia a `[Nombre]_LOD1`
3. Duplica otra vez → renombra a `[Nombre]_LOD2`
4. En `[Nombre]_LOD1`, reduce el mesh o escala para simular menor detalle:
   - Si es un cubo: reducir escala a 0.95 (visualmente igual, pero representa LOD1)
   - Si es un modelo importado: en el Inspector del asset 3D → "Import Settings" → "Normals": None → reduce datos

5. En `[Nombre]_LOD2`:
   - Escala a 0.9 (representará el LOD más simple)

6. Crea un objeto padre vacío:
   - Hierarchy → clic derecho → Create Empty → nombrar `[Nombre]_LODGroup`
   - Arrastrar los 3 objetos (original, LOD1, LOD2) como hijos del LODGroup

7. Seleccionar el objeto padre `[Nombre]_LODGroup`
8. Inspector → Add Component → buscar **"LOD Group"**

9. En el componente LOD Group:
   - **LOD 0** (click en "Add" o en la barra): arrastrar el objeto original (mayor detalle)
     - Ajustar el umbral a **60%** de tamaño en pantalla
   - **LOD 1**: arrastrar `[Nombre]_LOD1`
     - Umbral: **20%**
   - **LOD 2**: arrastrar `[Nombre]_LOD2`
     - Umbral: **5%**
   - **Culled**: el objeto desaparece debajo del 5%

10. Verificar:
    - En Scene View, mover la cámara alejándose del objeto
    - El objeto debe cambiar (LOD transitions) según la distancia
    - En la barra del LOD Group, el segmento activo se resalta en verde

11. Medir:
    ```
    DESPUÉS DE LOD GROUP
    ═══════════════════════════════════════════════
    FPS con cámara CERCA del objeto: 123.6 FPS
    FPS con cámara LEJOS del objeto: 143.4 FPS
    Tris CERCA: 7.7k | LEJOS: 6.5k
    ═══════════════════════════════════════════════
    ```

12. Toma captura: `03_lod_group.png` (mostrar la barra del LOD Group en el Inspector)

**Pregunta de análisis 2.2:**
> ¿En qué escenario de AR sería más útil el LOD Group: cuando el usuario camina hacia el objeto virtual, o cuando el objeto virtual aparece y desaparece? Justifica.

Es extremadamente útil cuando el usuario camina hacia el objeto virtual. En experiencias XR de libre locomoción (como cuartos virtuales o AR a escala real), si el usuario está lejos de una estatua u objeto complejo, renderizar miles de polígonos es un desperdicio de procesamiento. El LOD Group reduce el impacto gráfico permitiendo mantener la tasa de refresco alta y estable.

---

### Actividad 2.3 — Optimización de un script (25 min)

**Objetivo:** encontrar un script de tu proyecto con problemas de rendimiento y optimizarlo.

#### Sub-paso A — Encontrar el script problema

1. En el Profiler, en la vista del frame más lento
2. Expande **"Scripts"** → ver la lista de scripts y sus tiempos
3. Busca el script con mayor tiempo en ms O mayor GC Alloc
4. Anota el nombre: `ScriptOriginal`
5. Doble clic en el nombre del script en el Profiler → abre el archivo

#### Sub-paso B — Auditar el script

Analiza el script buscando estos patrones problemáticos:

```
CHECKLIST DE PROBLEMAS EN SCRIPTS
════════════════════════════════════════════════════
☑ GameObject.Find() o FindObjectOfType() dentro de Update()
☑ GetComponent<T>() dentro de Update() sin cachear
☐ new List<>() o new[] dentro de Update()
☑ String concatenada con "+" dentro de Update()
☑ Debug.Log() dentro de Update()
☐ LINQ queries (.Where(), .Select(), etc.) dentro de Update()
☐ Cálculos costosos que no cambian cada frame (ej: distancias fijas)
════════════════════════════════════════════════════

Problemas encontrados en [ScriptOriginal]:
1. Uso de GetComponent<Renderer>() en Update() sin cachear: Se busca el componente visual frame a frame, y además el uso secundario de .material clona el material en memoria constantemente en cada ciclo de ejecución.
2. Búsqueda ciega con GameObject.Find("Suelo") cada frame: El método recorre toda la jerarquía de la escena buscando el objeto por su nombre de texto 60 o más veces por segundo, saturando gravemente el hilo principal de la CPU.
3. Concatenación de strings con + e impresión masiva de Debug.Log(): La creación dinámica del mensaje genera una recolección de basura continua (GC Alloc), mientras que la escritura simultánea en la Consola del editor congela el rendimiento del juego.
```

#### Sub-paso C — Reescribir la versión optimizada

Crea una copia del script:
1. En Project: clic derecho en el script → Duplicate
2. Renombra la copia: `ScriptOriginal_Optimizado`
3. Abre la copia y aplica las correcciones

**Patrón de corrección más común — cachear referencias:**

```csharp
// ❌ ANTES (un ejemplo genérico del problema)
public class ScriptOriginal : MonoBehaviour
{
    void Update()
    {
        // Problemas típicos que podrías encontrar:
        GetComponent<Renderer>().material.color = Color.red;
        string msg = "Objeto: " + gameObject.name + " activo";
        Debug.Log(msg);
        GameObject target = GameObject.Find("Target");
        float dist = Vector3.Distance(transform.position, target.transform.position);
    }
}

// ✅ DESPUÉS (versión optimizada)
public class ScriptOriginal_Optimizado : MonoBehaviour
{
    // Cachear en campos de clase
    private Renderer cachedRenderer;
    private Transform targetTransform;

    void Awake()
    {
        cachedRenderer = GetComponent<Renderer>();
        // Find solo en Awake — una sola vez
        GameObject target = GameObject.Find("Target");
        if (target != null) targetTransform = target.transform;

        // Color se setea una vez (si no cambia)
        cachedRenderer.material.color = Color.red;
    }

    void Update()
    {
        // Solo el cálculo que NECESITA actualizarse cada frame
        if (targetTransform != null)
        {
            float dist = Vector3.Distance(transform.position, targetTransform.position);
            // Usar dist para algo, pero NO loggear en Update
        }
        // Debug.Log eliminado — jamás en Update en producción
    }
}
```

#### Sub-paso D — Medir el impacto del script optimizado

1. Reemplaza el componente script en el objeto de la escena:
   - Seleccionar el GameObject que tiene el script
   - Inspector → clic en "⋮" del script original → Remove Component
   - Add Component → agregar la versión optimizada

2. Medir con Profiler:
   ```
   COMPARACIÓN DE SCRIPTS
   ══════════════════════════════════════════════════
   Script original   — tiempo: 0.27 ms | GC Alloc: 921 bytes (0.9 KB)
   Script optimizado — tiempo: 0.00 ms | GC Alloc: 0 bytes
   Reducción de tiempo: 0.27 ms (100%)
   Reducción de GC Alloc: 921 bytes (100%)
   ══════════════════════════════════════════════════
   ```

3. Toma captura: `04_script_optimizado.png` (mostrar Profiler con ambas mediciones)

---

## PARTE 3 — DESAFÍO: ADAPTIVE QUALITY MANAGER (30 min)

### Objetivo
Implementar un sistema que monitorea el FPS en tiempo real y ajusta la calidad visual automáticamente.

### Descripción del sistema a construir

```
AdaptiveQualityManager.cs — comportamiento:

Cada 2 segundos, mide el FPS promedio:
  - Si FPS < 50 → bajar calidad (desactivar sombras de objetos secundarios)
  - Si FPS < 35 → bajar más calidad (reducir render scale a 0.8)
  - Si FPS > 70 → restaurar calidad si fue reducida
  
El sistema registra cuántas veces bajó/subió la calidad.
Muestra el estado en un texto UI: "Calidad: ALTA / MEDIA / BAJA"
```

### Implementación

**Crear Assets/Scripts/AdaptiveQualityManager.cs:**

```csharp
using UnityEngine;
using TMPro;

/// <summary>
/// Monitorea el FPS en tiempo real y ajusta la calidad de renderizado
/// automáticamente para mantener la experiencia fluida en dispositivos
/// con diferentes capacidades de hardware.
/// </summary>
public class AdaptiveQualityManager : MonoBehaviour
{
    [Header("Umbrales de FPS")]
    [Tooltip("Si el FPS cae por debajo de este valor, se reduce la calidad")]
    public float umbralFPSBajo = 50f;

    [Tooltip("Si el FPS cae aún más, se aplica reducción agresiva")]
    public float umbralFPSCritico = 35f;

    [Tooltip("Si el FPS supera este valor, se restaura la calidad anterior")]
    public float umbralFPSAlto = 70f;

    [Header("Intervalo de evaluación (segundos)")]
    public float intervaloEvaluacion = 2f;

    [Header("UI — Texto de estado (opcional)")]
    public TextMeshProUGUI textoCalidad;

    [Header("Objetos a afectar")]
    [Tooltip("Luces secundarias a desactivar en calidad baja")]
    public Light[] lucesSekndarias;

    // Estado interno
    private enum NivelCalidad { Alto, Medio, Bajo }
    private NivelCalidad nivelActual = NivelCalidad.Alto;

    private float tiempoAcumulado = 0f;
    private int framesAcumulados = 0;
    private float fpsPromedio = 60f;

    // Registro de cambios (para el reporte)
    private int vecesReducida = 0;
    private int vecesRestaurada = 0;

    // Estado original (para poder restaurar)
    private float renderScaleOriginal;

    void Start()
    {
        // Guardar el render scale original
        // En URP: UnityEngine.Rendering.Universal.UniversalRenderPipeline.asset.renderScale
        // Simplificado para este lab:
        renderScaleOriginal = 1.0f;

        ActualizarUI("Calidad: ALTA");
        Debug.Log("[AdaptiveQuality] Sistema iniciado. Monitoreando FPS...");
    }

    void Update()
    {
        // Acumular frames para calcular promedio
        tiempoAcumulado += Time.unscaledDeltaTime; // unscaledDeltaTime ignora timeScale
        framesAcumulados++;

        // Evaluar cada 'intervaloEvaluacion' segundos
        if (tiempoAcumulado >= intervaloEvaluacion)
        {
            // Calcular FPS promedio del intervalo
            fpsPromedio = framesAcumulados / tiempoAcumulado;

            EvaluarCalidad();

            // Resetear acumuladores
            tiempoAcumulado = 0f;
            framesAcumulados = 0;
        }
    }

    void EvaluarCalidad()
    {
        // Registrar en consola para el análisis del lab
        Debug.Log($"[AdaptiveQuality] FPS promedio: {fpsPromedio:F1} | Calidad: {nivelActual}");

        if (fpsPromedio < umbralFPSCritico && nivelActual != NivelCalidad.Bajo)
        {
            // FPS crítico → calidad BAJA
            AplicarCalidadBaja();
        }
        else if (fpsPromedio < umbralFPSBajo && nivelActual == NivelCalidad.Alto)
        {
            // FPS bajo → calidad MEDIA
            AplicarCalidadMedia();
        }
        else if (fpsPromedio > umbralFPSAlto && nivelActual != NivelCalidad.Alto)
        {
            // FPS recuperado → restaurar calidad ALTA
            RestaurarCalidadAlta();
        }
    }

    void AplicarCalidadMedia()
    {
        nivelActual = NivelCalidad.Medio;
        vecesReducida++;

        // Desactivar luces secundarias
        foreach (var luz in lucesSekndarias)
            if (luz != null) luz.enabled = false;

        ActualizarUI("Calidad: MEDIA (FPS bajo)");
        Debug.Log($"[AdaptiveQuality] Calidad reducida a MEDIA. FPS: {fpsPromedio:F1}");
    }

    void AplicarCalidadBaja()
    {
        nivelActual = NivelCalidad.Bajo;
        vecesReducida++;

        // Desactivar luces secundarias
        foreach (var luz in lucesSekndarias)
            if (luz != null) luz.enabled = false;

        // Nota: reducir render scale requiere referencia al URP Asset
        // En este lab simplificamos a: reducir shadow distance
        QualitySettings.shadowDistance = 10f; // era probablemente 50-100m
        QualitySettings.pixelLightCount = 0;  // desactivar per-pixel lights

        ActualizarUI("Calidad: BAJA (FPS critico)");
        Debug.Log($"[AdaptiveQuality] Calidad reducida a BAJA. FPS: {fpsPromedio:F1}");
    }

    void RestaurarCalidadAlta()
    {
        nivelActual = NivelCalidad.Alto;
        vecesRestaurada++;

        // Restaurar luces
        foreach (var luz in lucesSekndarias)
            if (luz != null) luz.enabled = true;

        // Restaurar calidad
        QualitySettings.shadowDistance = 50f;
        QualitySettings.pixelLightCount = 4;

        ActualizarUI("Calidad: ALTA");
        Debug.Log($"[AdaptiveQuality] Calidad restaurada a ALTA. FPS: {fpsPromedio:F1}");
    }

    void ActualizarUI(string mensaje)
    {
        if (textoCalidad != null)
            textoCalidad.text = mensaje;
    }

    // Llamar al final del laboratorio para ver el reporte
    [ContextMenu("Mostrar Reporte de Calidad")]
    public void MostrarReporte()
    {
        Debug.Log("═══════════════════════════════════");
        Debug.Log("REPORTE ADAPTIVE QUALITY");
        Debug.Log($"FPS promedio actual: {fpsPromedio:F1}");
        Debug.Log($"Nivel actual: {nivelActual}");
        Debug.Log($"Veces que se redujo la calidad: {vecesReducida}");
        Debug.Log($"Veces que se restauró: {vecesRestaurada}");
        Debug.Log("═══════════════════════════════════");
    }
}
```

### Conectar el sistema en la escena

1. Crear un GameObject vacío: Hierarchy → clic derecho → Create Empty → nombre: `AdaptiveQualityManager`
2. Add Component → AdaptiveQuality Manager
3. Si tienes un texto UI: arrastrar al campo "Texto Calidad"
4. Si tienes luces secundarias: arrastrar al array "Luces Secundarias"
5. Presionar Play y esperar 4-6 segundos para ver la primera evaluación

### Probar el sistema

Para ver el sistema en acción, necesitas forzar que el FPS baje:

```csharp
// Agrega este script TEMPORAL a un objeto para simular carga:
// Assets/Scripts/CargaSimulada.cs
using UnityEngine;

public class CargaSimulada : MonoBehaviour
{
    [Range(0, 100)]
    public int nivelCarga = 0; // cambiar en Inspector durante Play

    void Update()
    {
        // Simula carga de CPU con cálculos innecesarios
        for (int i = 0; i < nivelCarga * 1000; i++)
        {
            float x = Mathf.Sqrt(i * Time.deltaTime);
        }
    }
}
```

- Agregar `CargaSimulada` a un objeto vacío
- En Play: subir el "Nivel Carga" en Inspector al 80-100
- Ver cómo el AdaptiveQualityManager responde bajando la calidad
- Bajar el "Nivel Carga" a 0 → el sistema debe restaurar la calidad

### Anotar el comportamiento:

```
REPORTE DEL ADAPTIVE QUALITY MANAGER
══════════════════════════════════════════════════
Con NivelCarga = 0:    FPS promedio = 115.4 FPS
Con NivelCarga = 50:   FPS promedio = 42.8 FPS
Con NivelCarga = 100:  FPS promedio = 26.1 FPS

¿El sistema detectó el FPS bajo? ☑ Sí  ☐ No
¿El sistema redujo la calidad correctamente? ☑ Sí  ☐ No
¿El sistema restauró la calidad al bajar la carga? ☑ Sí  ☐ No

Mensajes en Console:
[15:40:01] [AdaptiveQuality] Sistema iniciado. Monitoreando FPS...
[15:40:03] [AdaptiveQuality] FPS promedio: 115.4 | Calidad: Alto
[15:40:05] [AdaptiveQuality] FPS promedio: 114.8 | Calidad: Alto
// Se sube NivelCarga a 50 -> El FPS cae por debajo de 50
[15:40:07] [AdaptiveQuality] FPS promedio: 42.8 | Calidad: Alto
[15:40:07] [AdaptiveQuality] Calidad reducida a MEDIA. FPS: 42.8
[15:40:09] [AdaptiveQuality] FPS promedio: 48.2 | Calidad: Medio
// Se sube NivelCarga a 100 -> El FPS cae por debajo de 35
[15:40:11] [AdaptiveQuality] FPS promedio: 26.1 | Calidad: Medio
[15:40:11] [AdaptiveQuality] Calidad reducida a BAJA. FPS: 26.1
[15:40:13] [AdaptiveQuality] FPS promedio: 29.5 | Calidad: Bajo
// Se baja NivelCarga a 0 -> El FPS se recupera por encima de 70
[15:40:15] [AdaptiveQuality] FPS promedio: 112.3 | Calidad: Bajo
[15:40:15] [AdaptiveQuality] Calidad restaurada a ALTA. FPS: 112.3
══════════════════════════════════════════════════
```

**Pregunta final del desafío:**
> ¿Cuál es el riesgo de evaluar el FPS cada frame en lugar de cada 2 segundos? ¿Por qué usar un promedio es más confiable que el FPS instantáneo para tomar decisiones de calidad?

Riesgo de evaluar el FPS cada frame: Hacerlo genera fluctuaciones erráticas conocidas como "jittering de calidad". Si un frame tarda un milisegundo extra por una carga puntual, el sistema degradará la fidelidad visual de inmediato y la volverá a subir al siguiente frame, produciendo parpadeos molestos para el usuario. Evaluar mediante un promedio de dos segundos estabiliza las lecturas.

**Pregunta de conexión con el proyecto:**
> ¿Cómo integrarías el AdaptiveQualityManager en tu proyecto grupal? ¿Qué objetos específicos de tu escena serían los primeros en reducir calidad cuando el FPS cae?

Integración en el proyecto grupal: Lo ideal es instanciar este objeto como un mánager persistente global (`DontDestroyOnLoad`). Los primeros objetos en degradar su fidelidad en caso de caídas de rendimiento en nuestro desarrollo de realidad mixta/virtual deben ser los efectos de partículas del entorno, las sombras secundarias de la iluminación ambiental y la resolución de texturas secundarias del fondo.

---

## ENTREGABLES

### Estructura de archivos

```
entregas/SEMANA-12/u-[codigo]-[apellido]/
├── capturas/
│   ├── 01_estado_base.png
│   ├── 02_static_batching.png
│   ├── 03_lod_group.png
│   └── 04_script_optimizado.png
├── Assets/Scripts/
│   ├── ScriptOriginal_Optimizado.cs    ← Parte 2.3
│   ├── AdaptiveQualityManager.cs       ← Parte 3
│   └── CargaSimulada.cs               ← Parte 3 (temporal)
└── REPORTE_OPTIMIZACION.md            ← Documento con todas las tablas
```

### REPORTE_OPTIMIZACION.md — Estructura requerida

```markdown
# Reporte de Optimización S12
**Nombre:** | **Código:** | **Fecha:**

## 1. Estado Base
[tabla con valores iniciales]

## 2. Análisis del Profiler
[tabla con procesos más lentos]

## 3. Static Batching
[tabla antes/después]
**Análisis:** [explicación de por qué cambió o no cambió]

## 4. LOD Group
[tabla de FPS cerca vs lejos]
**Análisis:** [cómo afecta a la experiencia del usuario]

## 5. Optimización de Script
[comparación original vs optimizado]
**Problemas encontrados:** [lista]
**Soluciones aplicadas:** [lista]

## 6. Adaptive Quality Manager
[reporte del comportamiento]
**Reflexión:** [respuestas a las preguntas del desafío]

## 7. Conclusión General
¿Cuántos FPS ganaste en total con todas las optimizaciones?
¿Cuál técnica tuvo mayor impacto en tu proyecto? ¿Por qué?
[mínimo 5 líneas]
```

### Mensaje de commit

```bash
git commit -m "feat(s12): optimizacion completa - profiler static-batching lod adaptive-quality"
```

---

## RÚBRICA DE EVALUACIÓN

| Criterio | Excelente (100%) | Suficiente (70%) | Insuficiente (<50%) | Pts |
|----------|-----------------|-----------------|---------------------|-----|
| Diagnóstico inicial | Tabla completa con 5+ métricas y Profiler analizado | Tabla con 3 métricas, Profiler mencionado | Sin medición inicial | 15 |
| Static Batching | Aplicado, medido antes/después, análisis justificado | Aplicado y medido | Aplicado sin medición | 15 |
| LOD Group | Configurado con 3 niveles, transiciones visibles, medido | Configurado con 2 niveles | Mencionado sin implementar | 20 |
| Script optimizado | Mínimo 3 problemas corregidos, GC Alloc 0 en Update | 2 problemas corregidos | 1 problema corregido | 20 |
| Adaptive Quality | Funcional, detecta FPS bajo, cambia calidad y la restaura | Funcional pero no restaura | Código presente sin funcionar | 20 |
| Reporte de calidad | Todas las tablas completas, análisis de cada técnica | Tablas incompletas | Sin reporte | 10 |
| **TOTAL** | | | | **100** |

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 12 | 2026-1*
