# S12 — GUÍA DE TRABAJO DEL ESTUDIANTE
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 12 — Optimización y Rendimiento en XR

---

> **Instrucciones:** Resuelve todas las secciones en orden. Tiempo sugerido: 90 minutos.
> Entrega en el repositorio del curso como archivo `.md` con tu rama `u-codigo-apellido-nombre-gt12`.
> **No está permitido** buscar respuestas en internet para la Sección A y B.

| Campo | Detalle |
|-------|---------|
| **Estudiante** | Luis Fernando Pretell Calderon |
| **Código** | 2231892186 |
| **Fecha** | 27/06/2026 |
| **Semana** | 12 — Optimización y Rendimiento en XR |

---

## SECCIÓN A — PREGUNTAS DE OPCIÓN MÚLTIPLE (20 puntos — 2 pts c/u)

**Pregunta 1** *(básica)*

¿Cuántos FPS mínimos exige Meta para aprobar una app en el Quest Store?

- a) 30 FPS
- b) 60 FPS
- c) 72 FPS
- d) 120 FPS

**Respuesta:** c) 72 FPS

---

**Pregunta 2** *(básica)*

¿Cuál es la herramienta principal de Unity para diagnosticar problemas de rendimiento en tiempo real?

- a) Inspector
- b) Unity Profiler
- c) Package Manager
- d) Scene View Stats

**Respuesta:** b) Unity Profiler

---

**Pregunta 3** *(básica)*

¿Qué es un "Draw Call" en el contexto del rendering de Unity?

- a) Una función de C# que dibuja texto en pantalla
- b) Una instrucción que la CPU envía a la GPU para renderizar un objeto
- c) Una llamada al sistema operativo para mostrar la ventana de Unity
- d) El proceso de importar modelos 3D al proyecto

**Respuesta:** b) Una instrucción que la CPU envía a la GPU para renderizar un objeto

---

**Pregunta 4** *(básica)*

¿Qué condición debe cumplir un objeto para poder aplicarle Static Batching?

- a) Debe tener un Rigidbody
- b) Debe estar marcado como "Static" y no moverse en runtime
- c) Debe tener exactamente el mismo mesh que otro objeto
- d) Debe estar en la misma capa (Layer) que los otros objetos

**Respuesta:** b) Debe estar marcado como "Static" y no moverse en runtime

---

**Pregunta 5** *(intermedia)*

Un modelo 3D tiene 50,000 triángulos en LOD 0. Si el usuario está a 30 metros de distancia y el objeto ocupa el 10% de la pantalla, ¿qué debería mostrar un LOD Group bien configurado?

- a) LOD 0 (50,000 triángulos) porque el objeto está visible
- b) LOD 1 o LOD 2 con menos triángulos, porque el usuario no nota la diferencia a esa distancia
- c) "Culled" (no renderiza) porque el objeto es pequeño en pantalla
- d) LOD 0 siempre, independientemente de la distancia

**Respuesta:** b) LOD 1 o LOD 2 con menos triángulos, porque el usuario no nota la diferencia a esa distancia

---

**Pregunta 6** *(intermedia)*

Un desarrollador tiene 300 árboles idénticos en su escena con el mismo material. ¿Qué técnica produce mayor reducción de Draw Calls?

- a) Static Batching, porque los árboles no se mueven
- b) GPU Instancing, porque son instancias del mismo mesh con el mismo material
- c) LOD Groups, porque reduce la cantidad de triángulos
- d) Occlusion Culling, porque no renderiza los que están ocultos

**Respuesta:** b) GPU Instancing, porque son instancias del mismo mesh con el mismo material

---

**Pregunta 7** *(intermedia)*

¿Por qué crear `new List<>()` dentro de `void Update()` es un problema de rendimiento?

- a) Porque List no se puede crear dentro de métodos de Unity
- b) Porque genera un objeto nuevo en el heap en cada frame, aumentando la presión sobre el Garbage Collector
- c) Porque Unity no soporta listas genéricas en tiempo de ejecución
- d) Porque List.Add() es más lento que los arrays simples

**Respuesta:** b) Porque genera un objeto nuevo en el heap en cada frame, aumentando la presión sobre el Garbage Collector

---

**Pregunta 8** *(avanzada)*

En el Unity Profiler, observas que `Camera.Render` toma 45ms y `Scripts Update` toma 2ms por frame. ¿Qué tipo de problema tiene la aplicación?

- a) CPU bound — los scripts son el cuello de botella
- b) GPU bound — el problema está en el rendering
- c) Memory bound — hay demasiada memoria usada
- d) Physics bound — las colisiones son el problema

**Respuesta:** b) GPU bound — el problema está en el rendering

---

**Pregunta 9** *(avanzada)*

¿Cuál es la ventaja del formato de textura ASTC sobre una textura sin comprimir (RGBA32) en Android?

- a) ASTC es más rápido de cargar desde el disco pero ocupa más memoria en GPU
- b) ASTC reduce el tamaño en memoria de GPU hasta en un 75-80%, mejorando el rendimiento
- c) ASTC solo funciona en dispositivos con Android 10 o superior
- d) ASTC mejora la calidad visual pero no tiene impacto en rendimiento

**Respuesta:** b) ASTC reduce el tamaño en memoria de GPU hasta en un 75-80%, mejorando el rendimiento

---

**Pregunta 10** *(avanzada)*

¿Qué es el "GC.Collect" que aparece en el Unity Profiler and por qué causa stutters?

- a) Un método que recolecta datos de juego para análisis estadístico
- b) El proceso del Garbage Collector que libera memoria de objetos no usados, pausando temporalmente todos los demás procesos
- c) Una llamada automática que guarda el estado del juego cada cierto tiempo
- d) El proceso de Unity para compilar los scripts en tiempo de ejecución

**Respuesta:** b) El proceso del Garbage Collector que libera memoria de objetos no usados, pausando temporalmente todos los demás procesos

---

## SECCIÓN B — COMPLETAR Y RELACIONAR (20 puntos)

### Parte B1 — Completar espacios en blanco (10 pts — 2 pts c/u)

1. El valor de tiempo por frame para alcanzar 90 FPS es **11.11** milisegundos. Si algún proceso supera ese valor, la app baja de 90 FPS.

2. Para aplicar GPU Instancing, el material del objeto debe tener activada la opción **Enable GPU Instancing** en el Inspector del material.

3. El comando de Unity para acceder al Profiler es: **Window** → Analysis → Profiler.

4. Cuando un objeto 3D tiene LOD configurado y la cámara se aleja lo suficiente, el sistema lo marca como **Culled**, es decir, deja de renderizarlo completamente.

5. `GetComponent<Renderer>()` llamado en `void **Awake**()` o `void **Start**()` (método de inicio, una sola vez) es la práctica correcta para cachear la referencia.

---

### Parte B2 — Relacionar columnas (10 pts — 1 pt c/u)

| Columna A — Técnica / Concepto | Tu respuesta | Columna B — Descripción |
|-------------------------------|-------------|------------------------|
| 1. Static Batching | **C** | A. No renderiza objetos que están detrás de otros |
| 2. GPU Instancing | **D** | B. Reduce triángulos según la distancia a la cámara |
| 3. LOD Group | **B** | C. Agrupa objetos estáticos con el mismo material en 1 Draw Call |
| 4. Occlusion Culling | **A** | D. Renderiza muchas copias del mismo mesh en 1 Draw Call |
| 5. Baked Lighting | **E** | E. Pre-calcula la iluminación y la guarda en texturas |
| 6. Single Pass Stereo | **F** | F. Renderiza ambos ojos en una sola pasada (VR) |
| 7. GC Alloc | **G** | G. Memoria en heap generada por objetos temporales |
| 8. MaterialPropertyBlock | **H** | H. Permite propiedades únicas por instancia sin romper batching |
| 9. Draw Call | **I** | I. Instrucción CPU → GPU para renderizar un objeto |
| 10. Fixed Foveated Rendering | **J** | J. Menor resolución en bordes del campo visual VR |

---

## SECCIÓN C — ANÁLISIS Y REFLEXIÓN (30 puntos)

### Pregunta C1 (8 pts)

Un estudiante tiene este código en su proyecto AR:

```csharp
void Update()
{
    GameObject obj = GameObject.Find("CuboAR");
    obj.GetComponent<Renderer>().material.color = new Color(
        Mathf.Sin(Time.time), 0.5f, 0.5f);
    Debug.Log("Color actualizado: " + obj.name);
}
```

a) Identifica **todos** los problemas de rendimiento en este código (mínimo 3). (4 pts)

1. `GameObject.Find("CuboAR")` en `Update()`: Realiza una búsqueda secuencial por cadena de texto en toda la jerarquía de la escena 60 o más veces por segundo ($O(N)$), lo cual genera un impacto masivo en la CPU.
2. `GetComponent<Renderer>()` en `Update()`: Consultar componentes en cada frame es costoso. Unity debe buscar internamente en la entidad el componente solicitado, desperdiciando ciclos de procesamiento de forma iterativa.
3. Uso de `.material`: Acceder a `.material` crea una copia (instancia) única de dicho material en la memoria RAM/VRAM en cada frame. Esto rompe cualquier intento de batching y genera fugas de memoria severas.
4. `Debug.Log` con concatenación de strings en `Update()`: La concatenación `"Color actualizado: " + obj.name` genera allocations en el Heap (`GC Alloc`), forzando al Garbage Collector a activarse constantemente y provocando tirones (stutters). Además, el logeo continuo en consola ralentiza el hilo principal de la aplicación.

b) Reescribe el código optimizado manteniendo la funcionalidad (el color sigue cambiando con el tiempo). (4 pts)

```csharp
using UnityEngine;

public class ColorOptimizerAR : MonoBehaviour
{
    private Renderer _renderer;
    private MaterialPropertyBlock _propBlock;
    private int _colorPropertyId;

    void Awake()
    {
        // 1. Cacheamos la referencia del Renderer local para evitar GetComponents o Finds en Update
        _renderer = GetComponent<Renderer>();
        
        // 2. Inicializamos el MaterialPropertyBlock para modificar propiedades sin duplicar materiales
        _propBlock = new MaterialPropertyBlock();
        
        // 3. Convertimos el nombre de la propiedad a ID numérico (mucho más rápido que usar strings)
        _colorPropertyId = Shader.PropertyToID("_Color");
    }

    void Update()
    {
        if (_renderer == null) return;

        // 4. Calculamos el color dinámico
        Color nuevoColor = new Color(Mathf.Sin(Time.time), 0.5f, 0.5f);

        // 5. Aplicamos los cambios mediante el PropertyBlock manteniendo el batching/instancing intacto
        _renderer.GetPropertyBlock(_propBlock);
        _propBlock.SetColor(_colorPropertyId, nuevoColor);
        _renderer.SetPropertyBlock(_propBlock);
    }
}
```


---

### Pregunta C2 (8 pts)

Compara **Baked Lighting** y **Real-time Lighting** en el contexto de una app AR móvil:

a) Explica cuál es más apropiada para una escena AR estática (objetos que no se mueven) y justifica tu respuesta en términos de rendimiento. (4 pts)

Para una escena AR estática, Baked Lighting es infinitamente más apropiada. Porque el cálculo de la iluminación, las sombras y los rebotes de luz se realiza previamente dentro del editor de Unity y se guarda en texturas especiales llamadas Lightmaps. En tiempo de ejecución (runtime) en el dispositivo móvil, la GPU no gasta recursos calculando complejas fórmulas matemáticas de iluminación ni mapas de sombras dinámicos por cada frame; simplemente renderiza las texturas precalculadas sobre los objetos. Esto ahorra valiosos ciclos de la GPU, previene el sobrecalentamiento del procesador del celular y reduce drásticamente el consumo de batería, permitiendo mantener una tasa de frames fluida y estable.

b) ¿En qué escenario específico de AR sería NECESARIO usar iluminación en tiempo real en lugar de baked? (4 pts)

Sería estrictamente necesario cuando interactuamos con elementos dinámicos o dependientes del entorno real en tiempo de ejecución. Por ejemplo:
1. Si implementamos un sistema de Estimación de Luz (Light Estimation) mediante ARCore/ARKit, donde la iluminación de los objetos virtuales debe cambiar y acoplarse dinámicamente si el usuario enciende/apaga un foco real en su habitación o si pasa una nube por la ventana.
2. Si el usuario puede manipular, mover o rotar los objetos interactivos por la sala (como un catálogo de muebles virtuales), o si hay personajes animados corriendo por el entorno que proyecten sombras dinámicas sobre el piso virtual de la app de realidad aumentada.


---

### Pregunta C3 — Mini caso de análisis (14 pts)

**Situación:** Tu equipo desarrolló la siguiente experiencia AR para el proyecto grupal: una sala de exhibición virtual con 150 cuadros 3D (cada uno con textura única de 2048×2048 sin comprimir), 20 luces en tiempo real, un script `ExhibicionManager.cs` que en `Update()` busca todos los cuadros con `FindObjectsOfType<CuadroAR>()` y calcula la distancia a la cámara, y sombras activadas en todos los objetos. El resultado: 8 FPS en un celular Snapdragon 720G.

#### Pregunta C3a (7 pts): Identifica los 4 problemas principales de rendimiento en orden de gravedad. Para cada uno: nombra el problema, explica por qué es grave y propón la técnica de optimización específica.

1. **Problema: `FindObjectsOfType<CuadroAR>()` en `Update()`**
   * *Por qué es grave:* Es un cuello de botella crítico para la CPU. Este método recorre absolutamente todos los GameObjects de la escena frame tras frame buscando scripts de tipo `CuadroAR`. Con 150 objetos, el costo de CPU es devastador e impide totalmente que el hilo de juego procese el frame a tiempo.
   * *Técnica de optimización:* **Patrón de Registro/Caching en Inicialización.** En lugar de buscar los objetos en `Update`, cada `CuadroAR` puede auto-registrarse en una lista estática dentro de `ExhibicionManager` durante su `Awake()` o `Start()`. El mánager solo leerá esa lista pre-poblada.

2. **Problema: 20 Luces en Tiempo Real con Sombras Activas en Mobile (Forward Rendering)**
   * *Por qué es grave:* Causa un cuello de botella masivo en la GPU (*GPU Bound*). El pipeline de renderizado *Forward* por defecto de Unity en dispositivos móviles requiere procesar cada objeto por cada luz que le afecte. Con 150 objetos y 20 luces, los Draw Calls y pases de sombras se multiplican exponencialmente, saturando el hardware móvil de forma instantánea.
   * *Técnica de optimización:* **Baked Lightmaps y limitación de luces dinámicas.** Cambiar las luces ambientales del escenario a *Baked* para fusionar la iluminación en texturas fijas. Desactivar por completo las sombras dinámicas secundarias y dejar como máximo 1 o 2 luces dinámicas de tipo *Directional* o *Puntual* sin sombras complejas para los elementos móviles.

3. **Problema: 150 Texturas de 2048x2048 Únicas y Sin Comprimir**
   * *Por qué es grave:* Saturación total de la memoria de video (VRAM) y del ancho de banda de texturas. Una sola textura de 2048x2048 sin comprimir (RGBA de 32 bits) pesa aproximadamente 16 MB. Con 150 cuadros, estamos cargando más de 2.4 GB de texturas directamente a la VRAM, sobrepasando las capacidades físicas del chipset gráfico integrado del Snapdragon 720G.
   * *Técnica de optimización:* **Compresión ASTC y Reducción de Resolución (Texture Trimming).** Configurar las texturas en Unity para usar compresión de hardware nativa de Android (**ASTC 6x6** o **8x8**), lo cual reduce el tamaño en VRAM hasta en un 80%. Adicionalmente, limitar la resolución máxima de importación a 1024x1024 o 512x512, lo cual es más que suficiente para pantallas de celulares.

4. **Problema: Cálculo continuo de distancias a la cámara para 150 objetos en `Update()`**
   * *Por qué es grave:* Causa sobrecarga en los scripts de la CPU. Ejecutar el cálculo matemático (`Vector3.Distance` o magnitudes vectoriales) para 150 elementos en cada frame de forma lineal ralentiza la ejecución, especialmente porque se computa sobre elementos que probablemente estén fuera de la vista del usuario.
   * *Técnica de optimización:* **Corrutinas con Slicing de Tiempo o C# Job System.** Cambiar la lógica del `Update()` a una **Corrutina** que realice la verificación de distancia cada 0.1 o 0.2 segundos (5-10 veces por segundo en vez de 60). De igual forma, se puede usar `Vector3.sqrMagnitude` en lugar de `Vector3.Distance` para evitar el costo computacional de la operación de raíz cuadrada (`Mathf.Sqrt`).

#### Pregunta C3b (7 pts): El docente dice: "Primero midan, después optimicen". Describe el proceso exacto de 5 pasos que seguirías en Unity para diagnosticar correctamente el problema antes de tocar una sola línea de código o un solo ajuste de material.

1. **Paso 1: Configurar un Development Build en el Dispositivo Real**  
   Conectar el dispositivo Snapdragon 720G mediante USB. En Unity, ir a *Build Settings*, seleccionar Android, y marcar las casillas **Development Build**, **Autoconnect Profiler** y **Deep Profiling Support** (este último para ver llamadas detalladas a funciones de scripts). Compilar e instalar la app directamente en el teléfono.

2. **Paso 2: Capturar Datos en Vivo con Unity Profiler**  
   Abrir el Unity Profiler en la computadora (`Window -> Analysis -> Profiler`). En la pestaña superior de selección de objetivo, cambiar "Playmode" por el dispositivo Android conectado. Iniciar la aplicación en el celular y registrar una muestra de comportamiento de al menos 10-15 segundos mientras se experimenta el bajo rendimiento (8 FPS).

3. **Paso 3: Analizar la CPU y Localizar el Cuello de Botella Principal**  
   Hacer clic en el módulo de **CPU Usage**. Cambiar la visualización de "Timeline" a **Hierarchy** y ordenar la tabla por la columna **Total %** o **Time ms**. Buscar las llamadas más pesadas; aquí se verá explícitamente cuánto tiempo se lleva `Camera.Render` (Rendering) vs `PlayerLoop -> UpdateScript` (nuestros scripts), detectando el impacto exacto en milisegundos de la función `FindObjectsOfType`.

4. **Paso 4: Diagnosticar la GPU y los Lotes en el Frame Debugger o Rendering Module**  
   Ir al módulo **Rendering** del Profiler para comprobar la cantidad exacta de *Draw Calls* y *SetPass Calls*. Para un diagnóstico visual preciso, pausar el juego y abrir el **Frame Debugger** (`Window -> Analysis -> Frame Debugger`). Hacer clic en *Enable* para desglosar paso a paso cómo la GPU dibuja el frame actual, identificando cómo las 20 luces dinámicas rompen el loteado (*batching*) y multiplican las pasadas de renderizado.

5. **Paso 5: Inspectar el Uso de Memoria y VRAM**  
   Seleccionar el módulo de **Memory** dentro del Profiler, cambiar el modo a *Detailed* y hacer clic en el botón **Take Sample**. Esto generará un mapa completo de los recursos alojados en el dispositivo. Filtrar la inspección por la categoría *Textures* para confirmar el peso exacto que las 150 imágenes de 2K sin comprimir están ejerciendo sobre la memoria física del celular.

---

## SECCIÓN D — PREGUNTAS AVANZADAS Y DE CASO (30 puntos)

### Caso profesional (15 pts)

**Contexto:** La empresa *Lima XR Studios* ganó un contrato para desarrollar una app de entrenamiento VR para mineros de la empresa Antamina (Perú). La simulación muestra un túnel minero de 500m de largo con: 2,000 objetos 3D (rocas, equipos, señales de seguridad), 8 tipos de materiales distintos (pero muchos objetos comparten el mismo material), explosiones de partículas dinámicas, física activa para simular caída de rocas, y 15 scripts de lógica de entrenamiento corriendo en Update. El headset objetivo es Meta Quest 2 (GPU: Adreno 650, 6GB RAM).

#### Pregunta D1 (5 pts): Diseña una estrategia de optimización completa para este proyecto. Organiza tu respuesta en una tabla con: técnica aplicada, por qué aplica a este caso específico, impacto esperado en FPS, y si requiere modificar los assets 3D o solo configuración de Unity.

| Técnica Aplicada | Por qué aplica a este caso específico (Túnel Antamina) | Impacto esperado en FPS | ¿Requiere modificar Assets o solo Configuración? |
| :--- | :--- | :--- | :--- |
| **Occlusion Culling** | Al ser un túnel largo de 500m, el minero solo ve lo que tiene enfrente. Las paredes del túnel bloquean la vista de los 2,000 objetos distantes o que están en galerías contiguas. | **Masivo.** Evita que la GPU renderice objetos que están físicamente bloqueados por la geometría del túnel. | Solo Configuración de Unity (Bake de Oclusión). |
| **GPU Instancing o Static Batching** | Hay 2,000 objetos pero solo 8 materiales. Esto significa que miles de rocas, señales y soportes comparten idénticas mallas y materiales. | **Alto.** Reduce miles de Draw Calls a solo un par de decenas, descongestionando el hilo de renderizado de la CPU. | Solo Configuración (Marcar objetos estáticos o habilitar Instancing en los 8 materiales). |
| **Compresión ASTC nativa para Android** | El Meta Quest 2 utiliza arquitectura móvil Android. El ancho de banda de memoria es limitado y vital para mantener el rendimiento simétrico en ambos ojos. | **Alto.** Disminuye el peso de texturas en VRAM, previniendo micro-tirones al cargar elementos mientras avanzas. | Solo Configuración (Ajustes de importación de texturas en el inspector). |
| **Single Pass Instanced Stereo Rendering** | Al ser VR, por defecto Unity dibuja la escena dos veces (un pase por cada ojo). Esta técnica combina ambos pases de renderizado en uno solo. | **Crítico.** Reduce a la mitad el procesamiento de Draw Calls en la CPU, factor indispensable para llegar a los 72 FPS obligatorios. | Solo Configuración (Ajustes de XR Plug-in Management). |
| **LOD Groups (Level of Detail) en Activos Críticos** | Las rocas detalladas y equipos mineros complejos no necesitan renderizar miles de polígonos si se encuentran a 40 metros de distancia del minero. | **Medio-Alto.** Disminuye la cantidad de triángulos simultáneos en pantalla que debe calcular la GPU. | **Modifica Assets** (Requiere modelar variantes 3D de baja calidad, LOD1, LOD2, para los assets). |

#### Pregunta D2 (5 pts): El físico de "caída de rocas" usa Rigidbody en 500 objetos simultáneamente. Propón una solución que mantenga el realismo visual de la simulación sin comprometer el rendimiento. (Pista: no todas las rocas necesitan física activa al mismo tiempo.)

**Solución por Pool Dinámico y Desactivación por Triggers:**
Para mantener los 72 FPS en Meta Quest 2, resulta inviable procesar 500 objetos activos simulando gravedad y colisiones simultáneas mediante el motor PhysX. Implementamos la siguiente arquitectura:
1. **Estado Inicial Kinematic / Desactivado:** Las 500 rocas se configuran inicialmente en sus posiciones con el parámetro `Rigidbody.isKinematic = true` o manteniendo el componente `Rigidbody` deshabilitado por completo. En este estado, actúan como mallas estáticas con costo computacional cero para el motor de físicas.
2. **Activación Basada en Triggers o Eventos:** Delimitamos zonas de riesgo mediante *Trigger Colliders* invisibles en el túnel. Cuando el jugador o un camión se aproxima al área donde ocurrirá el desprendimiento, el script del evento activa únicamente un grupo pequeño de rocas (ej. 15 o 20 unidades) cambiando su estado a `isKinematic = false`.
3. **Corte por Inactividad (Sleeping Sleep Loop):** Creamos un script en cada roca activa que monitoree su velocidad vectorial (`rigidbody.velocity.sqrMagnitude`). Tan pronto como la roca toque el suelo y su movimiento caiga por debajo de un umbral mínimo durante 1 segundo, el script la vuelve a configurar a `isKinematic = true`. Esto congela el objeto de nuevo, liberando la CPU de inmediato mientras visualmente la roca permanece en el piso de manera realista.

#### Pregunta D3 (5 pts): "¿Cómo implementarías un sistema de LOD automático en runtime para el túnel, donde el nivel de detalle cambia dinámicamente según la posición del usuario y el FPS actual?"

Implementaría un **Mánager de Rendimiento Reactivo (Dynamic Quality Manager)** combinando la distancia del jugador con el estado de salud de la aplicación (*Frame Rate*):

1. **Uso de LOD Bias Global:** Unity cuenta con una propiedad nativa llamada `QualitySettings.lodBias`, que actúa como un multiplicador global para la distancia de transición de todos los `LODGroups` de la escena. Un valor de `1` usa la distancia configurada, valores menores a `1` fuerzan a los objetos a pasar a modelos de menor poligonaje a distancias mucho más cortas de lo normal.
2. **Monitoreo de Framerate por Ventanas de Tiempo:** Un script centralizado evalúa el tiempo promedio de los últimos 30 frames. Si el rendimiento es óptimo (≥ 72 FPS en Quest 2), mantiene el `lodBias` en `1.0` o `1.2` para ofrecer la máxima fidelidad visual en el túnel.
3. **Degradación Dinámica:** Si los FPS caen por debajo de un umbral crítico (por ejemplo, menos de 68 FPS) durante más de 1.5 segundos (lo que indica sobrecarga en la GPU por partículas o polígonos), el mánager decrementa gradualmente el `QualitySettings.lodBias` a valores como `0.6` o `0.5`. De esta forma, de manera automática en tiempo de ejecución, todos los soportes y rocas del túnel disminuyen su calidad geométrica instantáneamente para recuperar la tasa de refresco y evitar el mareo por movimiento (*motion sickness*) en el usuario. Una vez estabilizado el rendimiento por encima de 72 FPS, el bias se incrementa suavemente de forma paulatina.

---

### Pregunta de diseño (8 pts)

> "¿Cómo implementarías un sistema de 'Adaptive Quality' para tu proyecto XR que automáticamente reduce la calidad visual cuando el FPS cae por debajo de 60, y la restaura cuando el FPS sube? Describe la lógica del script en pseudocódigo o C# real."

A continuación se detalla la implementación en código C# real optimizado para Unity:

```csharp
using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class AdaptiveQualityManager : MonoBehaviour
{
    [Header("FPS Thresholds")]
    [SerializeField] private float fpsLowerThreshold = 60f;
    [SerializeField] private float fpsUpperThreshold = 70f;
    [SerializeField] private float checkInterval = 1.0f;

    [Header("Resolution Scales")]
    [SerializeField] private float minRenderScale = 0.7f;
    [SerializeField] private float maxRenderScale = 1.0f;
    [SerializeField] private float scaleStep = 0.1f;

    private float _currentRenderScale = 1.0f;

    void Start()
    {
        // Iniciamos el ciclo de control mediante una corrutina para no saturar el Update
        StartCoroutine(PerformanceCheckRoutine());
    }

    private IEnumerator PerformanceCheckRoutine()
    {
        while (true)
        {
            // Medimos el rendimiento basado en el delta time del frame anterior
            float currentFps = 1.0f / Time.unscaledDeltaTime;

            if (currentFps < fpsLowerThreshold)
            {
                // Rendimiento deficiente: Reducimos la escala de renderizado de la GPU
                AdjustQuality(-scaleStep);
            }
            else if (currentFps > fpsUpperThreshold)
            {
                // Rendimiento excelente: Intentamos recuperar la calidad visual
                AdjustQuality(scaleStep);
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }

    private void AdjustQuality(float amount)
    {
        float targetScale = Mathf.Clamp(_currentRenderScale + amount, minRenderScale, maxRenderScale);
        
        if (!Mathf.Approximately(targetScale, _currentRenderScale))
        {
            _currentRenderScale = targetScale;
            
            // Aplicamos el cambio directo al viewport de renderizado XR nativo de Unity
            #if ENABLE_VR
            XRSettings.renderViewportScale = _currentRenderScale;
            #endif
            
            Debug.Log($"[AdaptiveQuality] Ajustando escala de renderizado a: {_currentRenderScale * 100}% (FPS actuales)");
        }
    }
}
```
---

### Pregunta de pensamiento crítico (7 pts)

>"Un compañero propone: 'Para optimizar nuestra app AR, vamos a reducir la resolución de pantalla del celular al 50% — así el GPU renderiza menos píxeles y ganamos FPS'. ¿Cuál es el riesgo de esta estrategia y en qué contextos XR específicos podría ser aceptable vs. inaceptable?"

**Análisis de la Estrategia:**

*   **El Riesgo Principal:** El peligro capital es la **pérdida severa de nitidez, legibilidad y el aumento de aliasing (píxeles dentados/serruchados)**. Reducir la resolución de pantalla de manera global al 50% significa renderizar solo una cuarta parte de los píxeles originales ($0.5 \times 0.5 = 0.25$). En dispositivos móviles, esto distorsiona dramáticamente las líneas finas y produce fatiga visual instantánea.

*   **Contextos donde es ACEPTABLE:**
    *   Es aceptable cuando la aplicación se encuentra en un estado crítico de **GPU Bound** debido a shaders de fragmentos sumamente costosos, efectos de post-procesado densos o simulaciones de partículas masivas que no se pueden eliminar por diseño.
    *   Aplica correctamente en experiencias de corte casual o estilizado (por ejemplo, juegos AR con estética *Low-Poly* o caricaturesca), donde el foco principal de la app radica en la interacción dinámica fluida y las formas generales, más allá de los detalles minuciosos o texturas realistas.

*   **Contextos donde es INACEPTABLE:**
    *   **Simuladores de Entrenamiento Crítico e Industrial:** Como el caso del túnel de Antamina o mantenimiento de maquinaria, donde el minero u operario necesita leer con total precisión textos de alertas, interfaces de telemetría (HUD) o letreros de seguridad industrial a la distancia.
    *   **Apps AR con Enfoque en Texto o Precisión Médica:** Guías quirúrgicas o manuales interactivos de ensamblaje técnico donde la confusión en un milímetro de la pantalla debido a la pixelación comprometa el objetivo de aprendizaje o la seguridad del usuario.
    *   **Visualizadores Arquitectónicos o de Retail de Alta Gama:** Donde el cliente evalúa la calidad, material y acabados realistas de un producto antes de comprarlo; un renderizado borroso arruina por completo el valor comercial de la experiencia de Realidad Aumentada.

---

## RÚBRICA DE AUTOEVALUACIÓN

| Criterio | Cumplido |
|----------|---------|
| Respondí las 10 preguntas de opción múltiple | ☐ |
| Completé los 5 espacios en blanco de B1 | ☐ |
| Relacioné todas las 10 columnas de B2 | ☐ |
| En C1 identifiqué mínimo 3 problemas y escribí código optimizado | ☐ |
| En C2 expliqué la diferencia con ejemplo concreto | ☐ |
| En C3 identifiqué 4 problemas con técnicas específicas | ☐ |
| En D1 mi tabla de estrategia tiene mínimo 5 técnicas | ☐ |
| En D2 propuse solución de física que no requiere 500 Rigidbodies activos | ☐ |
| Entregué como `.md` en la rama correcta de GitHub | ☐ |

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 12 | 2026-1*
