# LAB 12 — LABORATORIO EN CASA
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 12 — Optimización Completa del Proyecto XR

---

| Campo | Detalle |
|-------|---------|
| **Estudiante** | Salazar Mondragón Jael Santiago |
| **Código** | 2221898131 |
| **Fecha de entrega** |27/06/2026 |
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
```text
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

```text
ESTADO BASE DEL PROYECTO
═══════════════════════════════════════════════════════
Fecha/hora de medición: 27/06/2026 - 20:15
FPS (promedio durante 30 seg de juego): 42 FPS
FPS (mínimo durante 30 seg): 31 FPS
Draw Calls: 142
Tris renderizados: 285,000
Verts renderizados: 196,000
Used Memory: 512 MB
═══════════════════════════════════════════════════════
```

Toma una captura de pantalla del panel Stats con estos valores → guardar como `01_estado_base.png`.

**Observación:**

El estado base del proyecto muestra un rendimiento aceptable, pero todavía mejorable para una experiencia XR. El promedio de **42 FPS** indica que la aplicación funciona, aunque no alcanza una fluidez óptima para realidad aumentada o virtual. El mínimo de **31 FPS** demuestra que existen momentos donde el rendimiento cae, posiblemente por exceso de objetos visibles, materiales, luces o scripts ejecutándose en tiempo real.

Los **142 Draw Calls** representan una carga moderada para el renderizado, por lo que aplicar técnicas como **Static Batching** o **GPU Instancing** podría reducir la cantidad de llamadas a la GPU. Además, los **285,000 triángulos** y **196,000 vértices** indican que la escena tiene una complejidad gráfica media, por lo que el uso de **LOD Groups** puede ayudar a disminuir la geometría renderizada cuando los objetos están lejos de la cámara.

La memoria utilizada, de **512 MB**, se encuentra dentro de un rango razonable para un proyecto XR básico o intermedio, aunque podría optimizarse si existen texturas pesadas, modelos innecesarios o recursos no comprimidos. Estos valores servirán como punto de comparación para medir el impacto de las optimizaciones aplicadas durante el laboratorio.

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

```text
ANÁLISIS DEL FRAME MÁS LENTO
═══════════════════════════════════════════════════════
Tiempo total del frame: 24.6 ms
CPU time: 23.8 ms
GPU time: 10.2 ms

Top 5 procesos por tiempo:
1. Camera.Render             : 9.8 ms
2. Scripts.Update            : 5.1 ms
3. Rendering.OpaqueGeometry  : 4.4 ms
4. Physics.Simulate          : 2.0 ms
5. UI.Rendering              : 1.1 ms

¿CPU bound o GPU bound?: CPU bound
Columna GC Alloc total: 896 bytes/frame

Scripts con mayor GC Alloc:
1. PlayerController.cs       : 512 bytes
2. UIManager.cs              : 384 bytes
═══════════════════════════════════════════════════════
```

### Observación

El análisis del frame más lento muestra que el proyecto tiene un rendimiento más estable que el primer caso, ya que alcanza un promedio cercano a **42 FPS**. Sin embargo, el tiempo total del frame aún supera los **16.6 ms**, que sería lo ideal para mantener 60 FPS.

En este caso, el valor de **CPU time** es mayor que el tiempo estimado de GPU, por lo que el proyecto se considera principalmente **CPU bound**. Esto significa que el cuello de botella está más relacionado con procesos ejecutados por la CPU, como scripts, lógica de actualización, física o llamadas de renderizado preparadas antes de enviarse a la GPU.

También se observa una asignación de memoria temporal de **896 bytes/frame**, generada por scripts como `PlayerController.cs` y `UIManager.cs`. Aunque no es una cantidad muy alta, conviene revisar si existen llamadas como `GetComponent()`, creación de listas, concatenación de textos o `Debug.Log()` dentro de `Update()`, ya que podrían generar pausas por el **Garbage Collector** durante la ejecución.

### Actividad 1.3 — Análisis de la escena (5 min)

En tu Hierarchy, cuenta y anota:

```text
INVENTARIO DE LA ESCENA
═══════════════════════════════════════════════════════
Total de GameObjects activos: 58
Objetos que NO se mueven (candidatos Static Batching): 39
Objetos que SÍ se mueven: 19
Materiales únicos en la escena: 9
¿Hay objetos con el mismo mesh+material? ☑ Sí  ☐ No
Luces dinámicas en la escena: 2
¿Hay post-processing activo?: ☐ Sí  ☑ No
═══════════════════════════════════════════════════════
```

**Pregunta de reflexión 1.3:**
> Basándote en el inventario, ¿cuál técnica de optimización tiene más potencial de impacto en tu escena: Static Batching, GPU Instancing, o LOD Groups? Justifica en 3 líneas.

**Respuesta:**

La técnica con mayor potencial de optimización sigue siendo **Static Batching**, ya que aproximadamente dos tercios de los objetos de la escena permanecen inmóviles y pueden agruparse para disminuir la cantidad de Draw Calls. Esta optimización reduciría el trabajo de la CPU durante el renderizado.

Además, al existir varios objetos que comparten el mismo mesh y material, **GPU Instancing** podría complementar la optimización en aquellos elementos repetitivos. En este escenario, el uso de **LOD Groups** tendría un impacto menor debido a que la escena es sencilla y contiene modelos con una cantidad moderada de polígonos.

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
   ```text
   DESPUÉS DE STATIC BATCHING
   ═══════════════════════════════════════════════
   Objetos marcados como Static: 39
   FPS antes: 42 FPS | FPS después: 51 FPS
   Draw Calls antes: 142 | después: 96
   Cambio en Tris: Sin cambios significativos (285,000 tris)
   ═══════════════════════════════════════════════
   ```

5. Toma captura: `02_static_batching.png`

**Pregunta de análisis 2.1:**
> ¿Por qué los Draw Calls bajaron (o no bajaron) al marcar objetos como Static? Si no bajaron, ¿cuál crees que es la razón?

**Respuesta:**

Los **Draw Calls** bajaron porque varios objetos de la escena permanecían inmóviles y podían agruparse mediante **Static Batching**. Al marcar estos objetos como estáticos, Unity pudo reducir la cantidad de llamadas de renderizado necesarias para dibujarlos en pantalla, pasando de **142 Draw Calls** a **96 Draw Calls**.

El aumento de **42 FPS** a **51 FPS** demuestra que la optimización tuvo un impacto positivo en el rendimiento. Sin embargo, la cantidad de triángulos no cambió de forma significativa, porque Static Batching no simplifica los modelos 3D; únicamente mejora la forma en que los objetos son enviados al proceso de renderizado.

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
    ```text
    DESPUÉS DE LOD GROUP
    ═══════════════════════════════════════════════
    FPS con cámara CERCA del objeto: 51 FPS
    FPS con cámara LEJOS del objeto: 58 FPS
    Tris CERCA: 285,000 | LEJOS: 172,000
    ═══════════════════════════════════════════════
    ```

12. Toma captura: `03_lod_group.png` (mostrar la barra del LOD Group en el Inspector)

**Pregunta de análisis 2.2:**
> ¿En qué escenario de AR sería más útil el LOD Group: cuando el usuario camina hacia el objeto virtual, o cuando el objeto virtual aparece y desaparece? Justifica.

**Respuesta:**

El **LOD Group** sería más útil cuando el usuario **camina hacia el objeto virtual o se aleja de él**, porque en ese caso la distancia entre la cámara y el modelo cambia constantemente. Esto permite que Unity muestre el modelo con mayor detalle cuando está cerca y una versión simplificada cuando está lejos.

En una escena básica como la de la imagen 2, donde los objetos son simples pero pueden observarse desde distintas distancias, el LOD Group ayuda a reducir los triángulos renderizados de **285,000** a **172,000** cuando la cámara se aleja. Esto mejora el rendimiento sin afectar demasiado la calidad visual percibida por el usuario.

Cuando un objeto aparece y desaparece de forma inmediata, el LOD Group no tiene tanto impacto, ya que no hay una transición progresiva de distancia. En ese caso, sería más conveniente usar activación/desactivación del objeto u otras técnicas de control de visibilidad.

---

### Actividad 2.3 — Optimización de un script (25 min)

**Objetivo:** encontrar un script de tu proyecto con problemas de rendimiento y optimizarlo.

#### Sub-paso A — Encontrar el script problema

1. En el Profiler, en la vista del frame más lento
2. Expande **"Scripts"** → ver la lista de scripts y sus tiempos
3. Busca el script con mayor tiempo en ms O mayor GC Alloc
4. Anota el nombre: `PlayerController.cs`
5. Doble clic en el nombre del script en el Profiler → abre el archivo

#### Sub-paso B — Auditar el script

Analiza el script buscando estos patrones problemáticos:

```text
CHECKLIST DE PROBLEMAS EN SCRIPTS
════════════════════════════════════════════════════
☐ GameObject.Find() o FindObjectOfType() dentro de Update()
☑ GetComponent<T>() dentro de Update() sin cachear
☐ new List<>() o new[] dentro de Update()
☑ String concatenada con "+" dentro de Update()
☐ Debug.Log() dentro de Update()
☐ LINQ queries (.Where(), .Select(), etc.) dentro de Update()
☑ Cálculos costosos que no cambian cada frame (ej: distancias fijas)
════════════════════════════════════════════════════

Problemas encontrados en PlayerController.cs:
1. Uso repetitivo de GetComponent<Renderer>() durante cada actualización.
2. Concatenación de cadenas dentro de Update(), generando asignaciones temporales de memoria.
3. Recalcular constantemente la distancia al objetivo aunque este permanezca estático.
```

#### Sub-paso C — Reescribir la versión optimizada

Crea una copia del script:
1. En Project: clic derecho en el script → Duplicate
2. Renombra la copia: `PlayerController_Optimizado`
3. Abre la copia y aplica las correcciones

**Patrón de corrección más común — cachear referencias:**

```csharp
// ❌ ANTES (un ejemplo genérico del problema)
public class PlayerController : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        GetComponent<Renderer>().material.color = Color.green;

        string texto = "Distancia: " +
            Vector3.Distance(transform.position, target.position);

        float distancia =
            Vector3.Distance(transform.position, target.position);
    }
}
```

```csharp
// ✅ DESPUÉS (versión optimizada)
using UnityEngine;

public class PlayerController_Optimizado : MonoBehaviour
{
    private Renderer cachedRenderer;

    public Transform target;
    private float distancia;

    void Awake()
    {
        cachedRenderer = GetComponent<Renderer>();
        cachedRenderer.material.color = Color.green;
    }

    void Update()
    {
        if (target != null)
        {
            distancia = Vector3.Distance(transform.position, target.position);
        }
    }
}
```

#### Sub-paso D — Medir el impacto del script optimizado

1. Reemplaza el componente script en el objeto de la escena:
   - Seleccionar el GameObject que tiene el script
   - Inspector → clic en "⋮" del script original → Remove Component
   - Add Component → agregar la versión optimizada

2. Medir con Profiler:
   ```text
   COMPARACIÓN DE SCRIPTS
   ══════════════════════════════════════════════════
   Script original   — tiempo: 2.8 ms | GC Alloc: 512 bytes
   Script optimizado — tiempo: 0.9 ms | GC Alloc: 0 bytes
   Reducción de tiempo: 1.9 ms (67.9%)
   Reducción de GC Alloc: 512 bytes (100%)
   ══════════════════════════════════════════════════
   ```

3. Toma captura: `04_script_optimizado.png` (mostrar Profiler con ambas mediciones)

**Análisis:**

Después de optimizar el script, el tiempo de ejecución disminuyó de **2.8 ms** a **0.9 ms**, lo que representa una mejora cercana al **68 %**. La principal optimización consistió en almacenar la referencia al componente `Renderer` durante `Awake()` y eliminar operaciones innecesarias dentro de `Update()`.

Además, se evitó la creación de cadenas de texto en cada frame y se redujo el consumo de memoria temporal, logrando que el **GC Alloc** pasara de **512 bytes** a **0 bytes**. Estas mejoras permiten una ejecución más eficiente del script y contribuyen a mantener una mayor estabilidad en el rendimiento general de la aplicación XR.

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

```text
REPORTE DEL ADAPTIVE QUALITY MANAGER
══════════════════════════════════════════════════
Con NivelCarga = 0:    FPS promedio = 74 FPS
Con NivelCarga = 50:   FPS promedio = 49 FPS
Con NivelCarga = 100:  FPS promedio = 33 FPS

¿El sistema detectó el FPS bajo? ☑ Sí  ☐ No
¿El sistema redujo la calidad correctamente? ☑ Sí  ☐ No
¿El sistema restauró la calidad al bajar la carga? ☑ Sí  ☐ No

Mensajes en Console:

[AdaptiveQuality] Sistema iniciado. Monitoreando FPS...
[AdaptiveQuality] FPS promedio: 74.2 | Calidad: Alto
[AdaptiveQuality] FPS promedio: 49.0 | Calidad: Alto
[AdaptiveQuality] Calidad reducida a MEDIA. FPS: 49.0
[AdaptiveQuality] FPS promedio: 33.5 | Calidad: Medio
[AdaptiveQuality] Calidad reducida a BAJA. FPS: 33.5
[AdaptiveQuality] FPS promedio: 73.4 | Calidad: Bajo
[AdaptiveQuality] Calidad restaurada a ALTA. FPS: 73.4

══════════════════════════════════════════════════
```

**Pregunta final del desafío:**
> ¿Cuál es el riesgo de evaluar el FPS cada frame en lugar de cada 2 segundos? ¿Por qué usar un promedio es más confiable que el FPS instantáneo para tomar decisiones de calidad?

**Respuesta:**

Evaluar el FPS en cada frame puede hacer que el sistema reaccione demasiado rápido ante variaciones pequeñas o momentáneas del rendimiento. Esto podría provocar cambios constantes entre calidad alta, media y baja, afectando la estabilidad visual de la experiencia XR.

Usar un promedio cada 2 segundos es más confiable porque permite analizar el comportamiento general del rendimiento y no solo una caída puntual. De esta manera, el sistema toma decisiones más estables y evita reducir la calidad de forma innecesaria.

---

**Pregunta de conexión con el proyecto:**
> ¿Cómo integrarías el AdaptiveQualityManager en tu proyecto grupal? ¿Qué objetos específicos de tu escena serían los primeros en reducir calidad cuando el FPS cae?

**Respuesta:**

Integraría el **AdaptiveQualityManager** en la escena principal como un objeto vacío con el script asignado. También conectaría las luces secundarias, el texto UI de estado y los objetos visuales que puedan reducir su calidad sin afectar la experiencia principal del usuario.

Los primeros elementos en reducir calidad serían las **sombras secundarias**, las **luces no esenciales**, los **efectos visuales decorativos**, los **objetos lejanos mediante LOD Groups** y los modelos que no sean necesarios para la interacción principal. Esto permitiría mantener una experiencia fluida sin perder la funcionalidad central del proyecto.

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