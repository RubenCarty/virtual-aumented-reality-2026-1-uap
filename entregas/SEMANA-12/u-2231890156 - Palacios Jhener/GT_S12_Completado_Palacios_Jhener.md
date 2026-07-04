# S12 — GUÍA DE TRABAJO DEL ESTUDIANTE
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 12 — Optimización y Rendimiento en XR

---

> **Instrucciones:** Resuelve todas las secciones en orden. Tiempo sugerido: 90 minutos.
> Entrega en el repositorio del curso como archivo `.md` con tu rama `u-codigo-apellido-nombre-gt12`.
> **No está permitido** buscar respuestas en internet para la Sección A y B.

| Campo | Detalle |
|-------|---------|
| **Estudiante** |Palacios Vergaray Jhener Erick |
| **Código** | 2231890156 |
| **Fecha** |03/07/2026 |
| **Semana** | 12 — Optimización y Rendimiento en XR |

---

# SECCIÓN A — PREGUNTAS DE OPCIÓN MÚLTIPLE (20 puntos — 2 pts c/u)

## Pregunta 1 *(básica)*

¿Cuántos FPS mínimos exige Meta para aprobar una app en el Quest Store?

- [ ] a) 30 FPS
- [ ] b) 60 FPS
- [x] c) 72 FPS
- [ ] d) 120 FPS

**Respuesta:** c) 72 FPS

**Explicación:**  
Una aplicación de realidad virtual debe mantener al menos **72 FPS** para ofrecer una experiencia estable y cómoda, reduciendo la latencia y disminuyendo la posibilidad de mareos durante su uso.

---

## Pregunta 2 *(básica)*

¿Cuál es la herramienta principal de Unity para diagnosticar problemas de rendimiento en tiempo real?

- [ ] a) Inspector
- [x] b) Unity Profiler
- [ ] c) Package Manager
- [ ] d) Scene View Stats

**Respuesta:** b) Unity Profiler

**Explicación:**  
**Unity Profiler** permite analizar en tiempo real el consumo de CPU, GPU, memoria, físicas, rendering y otros procesos, facilitando la detección de cuellos de botella en la aplicación.

---

## Pregunta 3 *(básica)*

¿Qué es un "Draw Call" en el contexto del rendering de Unity?

- [ ] a) Una función de C# que dibuja texto en pantalla
- [x] b) Una instrucción que la CPU envía a la GPU para renderizar un objeto
- [ ] c) Una llamada al sistema operativo para mostrar la ventana de Unity
- [ ] d) El proceso de importar modelos 3D al proyecto

**Respuesta:** b) Una instrucción que la CPU envía a la GPU para renderizar un objeto

**Explicación:**  
Un **Draw Call** es una orden enviada por la CPU a la GPU para dibujar un objeto en pantalla. Reducir la cantidad de Draw Calls mejora el rendimiento de la aplicación.

---

## Pregunta 4 *(básica)*

¿Qué condición debe cumplir un objeto para poder aplicarle Static Batching?

- [ ] a) Debe tener un Rigidbody
- [x] b) Debe estar marcado como "Static" y no moverse en runtime
- [ ] c) Debe tener exactamente el mismo mesh que otro objeto
- [ ] d) Debe estar en la misma capa (Layer) que los otros objetos

**Respuesta:** b) Debe estar marcado como "Static" y no moverse en runtime

**Explicación:**  
El **Static Batching** solo puede aplicarse a objetos que permanecen inmóviles durante la ejecución. Unity combina estos objetos para reducir la cantidad de Draw Calls.

---

## Pregunta 5 *(intermedia)*

Un modelo 3D tiene 50,000 triángulos en LOD 0. Si el usuario está a 30 metros de distancia y el objeto ocupa el 10% de la pantalla, ¿qué debería mostrar un LOD Group bien configurado?

- [ ] a) LOD 0 (50,000 triángulos) porque el objeto está visible
- [x] b) LOD 1 o LOD 2 con menos triángulos, porque el usuario no nota la diferencia a esa distancia
- [ ] c) "Culled" (no renderiza) porque el objeto es pequeño en pantalla
- [ ] d) LOD 0 siempre, independientemente de la distancia

**Respuesta:** b) LOD 1 o LOD 2 con menos triángulos, porque el usuario no nota la diferencia a esa distancia

**Explicación:**  
El sistema **LOD (Level of Detail)** reduce progresivamente la complejidad del modelo conforme disminuye su tamaño en pantalla, mejorando el rendimiento sin afectar de forma perceptible la calidad visual.

---

## Pregunta 6 *(intermedia)*

Un desarrollador tiene 300 árboles idénticos en su escena con el mismo material. ¿Qué técnica produce mayor reducción de Draw Calls?

- [ ] a) Static Batching, porque los árboles no se mueven
- [x] b) GPU Instancing, porque son instancias del mismo mesh con el mismo material
- [ ] c) LOD Groups, porque reduce la cantidad de triángulos
- [ ] d) Occlusion Culling, porque no renderiza los que están ocultos

**Respuesta:** b) GPU Instancing, porque son instancias del mismo mesh con el mismo material

**Explicación:**  
**GPU Instancing** permite renderizar múltiples copias del mismo modelo utilizando una sola llamada de dibujo, reduciendo considerablemente la carga de la CPU.

---

## Pregunta 7 *(intermedia)*

¿Por qué crear `new List<>()` dentro de `void Update()` es un problema de rendimiento?

- [ ] a) Porque List no se puede crear dentro de métodos de Unity
- [x] b) Porque genera un objeto nuevo en el heap en cada frame, aumentando la presión sobre el Garbage Collector
- [ ] c) Porque Unity no soporta listas genéricas en tiempo de ejecución
- [ ] d) Porque List.Add() es más lento que los arrays simples

**Respuesta:** b) Porque genera un objeto nuevo en el heap en cada frame, aumentando la presión sobre el Garbage Collector

**Explicación:**  
Crear objetos nuevos en cada actualización genera asignaciones de memoria constantes, provocando ejecuciones frecuentes del **Garbage Collector**, lo que puede producir pausas o stutters.

---

## Pregunta 8 *(avanzada)*

En el Unity Profiler, observas que `Camera.Render` toma 45 ms y `Scripts Update` toma 2 ms por frame. ¿Qué tipo de problema tiene la aplicación?

- [ ] a) CPU bound — los scripts son el cuello de botella
- [x] b) GPU bound — el problema está en el rendering
- [ ] c) Memory bound — hay demasiada memoria usada
- [ ] d) Physics bound — las colisiones son el problema

**Respuesta:** b) GPU bound — el problema está en el rendering

**Explicación:**  
El mayor tiempo se concentra en **Camera.Render**, indicando que el cuello de botella se encuentra en el proceso de renderizado realizado por la GPU y no en la ejecución de scripts.

---

## Pregunta 9 *(avanzada)*

¿Cuál es la ventaja del formato de textura ASTC sobre una textura sin comprimir (RGBA32) en Android?

- [ ] a) ASTC es más rápido de cargar desde el disco pero ocupa más memoria en GPU
- [x] b) ASTC reduce el tamaño en memoria de GPU hasta en un 75–80 %, mejorando el rendimiento
- [ ] c) ASTC solo funciona en dispositivos con Android 10 o superior
- [ ] d) ASTC mejora la calidad visual pero no tiene impacto en rendimiento

**Respuesta:** b) ASTC reduce el tamaño en memoria de GPU hasta en un 75–80 %, mejorando el rendimiento

**Explicación:**  
La compresión **ASTC** disminuye significativamente el consumo de memoria de las texturas, permitiendo un mejor rendimiento y un uso más eficiente de la GPU en dispositivos móviles.

---

## Pregunta 10 *(avanzada)*

¿Qué es el "GC.Collect" que aparece en el Unity Profiler y por qué causa stutters?

- [ ] a) Un método que recolecta datos de juego para análisis estadístico
- [x] b) El proceso del Garbage Collector que libera memoria de objetos no usados, pausando temporalmente todos los demás procesos
- [ ] c) Una llamada automática que guarda el estado del juego cada cierto tiempo
- [ ] d) El proceso de Unity para compilar los scripts en tiempo de ejecución

**Respuesta:** b) El proceso del Garbage Collector que libera memoria de objetos no usados, pausando temporalmente todos los demás procesos

**Explicación:**  
Cuando el **Garbage Collector** libera memoria, la ejecución de la aplicación se detiene brevemente para recuperar recursos. Estas pausas generan los llamados **stutters** o pequeños congelamientos perceptibles durante la experiencia XR.

# SECCIÓN B — COMPLETAR Y RELACIONAR (20 puntos)

## Parte B1 — Completar espacios en blanco (10 pts — 2 pts c/u)

### 1.

El valor de tiempo por frame para alcanzar **90 FPS** es **11.11** milisegundos. Si algún proceso supera ese valor, la aplicación no podrá mantener los 90 FPS.

**Respuesta:** **11.11 ms**

**Explicación:**  
Para lograr 90 FPS, cada fotograma debe renderizarse en aproximadamente **11.11 milisegundos** (1000 ms ÷ 90). Si el tiempo por frame supera ese valor, la tasa de imágenes por segundo disminuye.

---

### 2.

Para aplicar **GPU Instancing**, el material del objeto debe tener activada la opción **Enable GPU Instancing** en el Inspector del material.

**Respuesta:** **Enable GPU Instancing**

**Explicación:**  
Esta opción permite que Unity renderice múltiples copias del mismo modelo utilizando una sola llamada de dibujo, reduciendo significativamente la cantidad de Draw Calls.

---

### 3.

El comando de Unity para acceder al Profiler es:

**Window → Analysis → Profiler**

**Respuesta:** **Window**

**Explicación:**  
El Profiler se encuentra dentro del menú **Window**, desde donde es posible acceder a las herramientas de análisis y monitoreo del rendimiento de la aplicación.

---

### 4.

Cuando un objeto 3D tiene LOD configurado y la cámara se aleja lo suficiente, el sistema lo marca como **Culled**, es decir, deja de renderizarlo completamente.

**Respuesta:** **Culled**

**Explicación:**  
El estado **Culled** indica que el objeto ya no se renderiza porque su tamaño en pantalla es demasiado pequeño o está fuera del rango definido en el LOD Group, lo que ayuda a mejorar el rendimiento.

---

### 5.

`GetComponent<Renderer>()` llamado en `void **Start()**` (método de inicio, una sola vez) es la práctica correcta para cachear la referencia.

**Respuesta:** **Start**

**Explicación:**  
Obtener la referencia en **Start()** evita ejecutar `GetComponent()` en cada frame dentro de `Update()`, reduciendo operaciones innecesarias y mejorando el rendimiento.

---

# Parte B2 — Relacionar columnas (10 pts — 1 pt c/u)

| Columna A — Técnica / Concepto | Respuesta | Columna B — Descripción |
|--------------------------------|:--------:|--------------------------|
| 1. Static Batching | **C** | Agrupa objetos estáticos con el mismo material en 1 Draw Call. |
| 2. GPU Instancing | **D** | Renderiza muchas copias del mismo mesh en 1 Draw Call. |
| 3. LOD Group | **B** | Reduce triángulos según la distancia a la cámara. |
| 4. Occlusion Culling | **A** | No renderiza objetos que están detrás de otros. |
| 5. Baked Lighting | **E** | Pre-calcula la iluminación y la guarda en texturas. |
| 6. Single Pass Stereo | **F** | Renderiza ambos ojos en una sola pasada (VR). |
| 7. GC Alloc | **G** | Memoria en heap generada por objetos temporales. |
| 8. MaterialPropertyBlock | **H** | Permite propiedades únicas por instancia sin romper batching. |
| 9. Draw Call | **I** | Instrucción CPU → GPU para renderizar un objeto. |
| 10. Fixed Foveated Rendering | **J** | Menor resolución en los bordes del campo visual en realidad virtual. |

---
# SECCIÓN C — ANÁLISIS Y REFLEXIÓN (30 puntos)

## Pregunta C1 (8 pts)

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

### a) Problemas de rendimiento identificados

1. **Uso de `GameObject.Find()` dentro de `Update()`**  
   Este método busca el objeto por nombre en toda la escena en cada frame. Es una operación costosa, especialmente si hay muchos objetos activos.

2. **Uso de `GetComponent<Renderer>()` en cada frame**  
   Llamar `GetComponent()` constantemente genera trabajo innecesario. Lo correcto es obtener la referencia una sola vez en `Start()` o `Awake()`.

3. **Uso de `.material` dentro de `Update()`**  
   Acceder a `.material` puede crear una instancia nueva del material para ese objeto, aumentando el consumo de memoria.

4. **Uso de `Debug.Log()` dentro de `Update()`**  
   Mostrar mensajes en consola cada frame reduce el rendimiento y puede generar caídas de FPS, sobre todo en dispositivos móviles.

5. **Creación constante de un nuevo `Color`**  
   Aunque no es el problema más grave, se está creando un nuevo valor de color en cada frame. Es aceptable para esta funcionalidad, pero debe mantenerse controlado.

---

### b) Código optimizado

```csharp
using UnityEngine;

public class CuboColorOptimizado : MonoBehaviour
{
    private Renderer cuboRenderer;
    private MaterialPropertyBlock propertyBlock;

    void Start()
    {
        GameObject obj = GameObject.Find("CuboAR");
        cuboRenderer = obj.GetComponent<Renderer>();

        propertyBlock = new MaterialPropertyBlock();
    }

    void Update()
    {
        Color nuevoColor = new Color(Mathf.Sin(Time.time), 0.5f, 0.5f);

        cuboRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_Color", nuevoColor);
        cuboRenderer.SetPropertyBlock(propertyBlock);
    }
}
```

### Explicación del código optimizado

En esta versión, `GameObject.Find()` y `GetComponent<Renderer>()` solo se ejecutan una vez en `Start()`, evitando búsquedas repetitivas en cada frame. Además, se usa `MaterialPropertyBlock` para cambiar el color sin crear nuevas instancias del material. También se elimina `Debug.Log()` dentro de `Update()` para evitar sobrecarga en la consola.

---

## Pregunta C2 (8 pts)

### a) ¿Cuál es más apropiada para una escena AR estática?

Para una escena AR móvil estática, donde los objetos no se mueven, es más apropiado usar **Baked Lighting**.

El **Baked Lighting** calcula previamente la iluminación de la escena y la guarda en texturas llamadas lightmaps. Esto permite que la aplicación no tenga que calcular luces y sombras en tiempo real durante la ejecución. En dispositivos móviles, esto mejora el rendimiento porque reduce la carga de la GPU y permite mantener una mayor estabilidad de FPS.

En una app AR, el rendimiento es muy importante porque una caída de FPS puede provocar retrasos, incomodidad visual o pérdida de fluidez. Por eso, si los objetos 3D permanecen fijos, conviene usar iluminación precalculada.

---

### b) ¿Cuándo sería necesario usar Real-time Lighting?

Sería necesario usar **Real-time Lighting** cuando la iluminación o los objetos cambian durante la ejecución.

Por ejemplo, en una app AR donde el usuario puede mover una lámpara virtual, abrir una puerta que deja pasar luz, activar una linterna o desplazar un objeto que proyecta sombra en tiempo real, no sería suficiente usar Baked Lighting. En esos casos, la luz debe reaccionar dinámicamente a los cambios de la escena.

También sería necesario en experiencias donde el objeto AR debe integrarse visualmente con la iluminación real del entorno, por ejemplo, cuando una mesa virtual debe responder a cambios de luz de una habitación o proyectar sombras dinámicas según la posición del usuario.

---

## Pregunta C3 — Mini caso de análisis (14 pts)

### Situación

Tu equipo desarrolló una experiencia AR con las siguientes características:

- 150 cuadros 3D.
- Cada cuadro usa textura única de 2048×2048 sin comprimir.
- 20 luces en tiempo real.
- Un script `ExhibicionManager.cs` usa `FindObjectsOfType<CuadroAR>()` dentro de `Update()`.
- Se calcula la distancia a la cámara cada frame.
- Hay sombras activadas en todos los objetos.
- El resultado es **8 FPS** en un celular Snapdragon 720G.

---

## Pregunta C3a (7 pts)

### 4 problemas principales de rendimiento en orden de gravedad

| Orden | Problema | ¿Por qué es grave? | Técnica de optimización específica |
|------:|----------|--------------------|------------------------------------|
| 1 | **20 luces en tiempo real** | Las luces dinámicas consumen muchos recursos en móviles, especialmente si iluminan varios objetos al mismo tiempo. Esto aumenta el costo de renderizado y puede saturar la GPU. | Usar **Baked Lighting**, reducir la cantidad de luces activas y dejar solo una luz direccional o luz principal si es necesaria. |
| 2 | **Texturas 2048×2048 sin comprimir** | Cada textura ocupa mucha memoria en GPU. Al tener 150 texturas únicas, el consumo de memoria se vuelve demasiado alto para un celular de gama media. | Comprimir texturas en **ASTC**, reducir resolución a 1024×1024 o 512×512, y usar atlas de texturas cuando sea posible. |
| 3 | **Sombras activadas en todos los objetos** | Las sombras en tiempo real multiplican el costo de renderizado, sobre todo con muchas luces y muchos objetos. | Desactivar sombras en objetos secundarios, usar **baked shadows**, reducir resolución de sombras o usar sombras falsas mediante planos/texturas. |
| 4 | **Uso de `FindObjectsOfType<CuadroAR>()` dentro de `Update()`** | Buscar todos los objetos de un tipo en cada frame es muy costoso para la CPU. Esto genera caídas de rendimiento y trabajo innecesario constante. | Cachear la lista de cuadros en `Start()` o `Awake()`, actualizarla solo cuando se agreguen o eliminen cuadros, y evitar búsquedas en cada frame. |

---

## Pregunta C3b (7 pts)

### Proceso de diagnóstico en Unity antes de optimizar

| Paso | Acción | Descripción |
|-----:|--------|-------------|
| 1 | **Ejecutar la app en el dispositivo real** | Primero se debe probar la experiencia directamente en el celular Snapdragon 720G, porque el rendimiento en la PC no representa el comportamiento real del dispositivo móvil. |
| 2 | **Abrir Unity Profiler** | Desde `Window → Analysis → Profiler`, se debe conectar el Profiler al dispositivo para medir CPU, GPU, memoria, rendering, scripts y físicas en tiempo real. |
| 3 | **Identificar el cuello de botella principal** | Se revisa si el mayor consumo está en `Camera.Render`, `Scripts Update`, `GC Alloc`, `Physics` o memoria. Así se determina si el problema principal es de GPU, CPU, memoria o físicas. |
| 4 | **Analizar módulos específicos** | En el Profiler se revisan los módulos de Rendering, Memory y CPU Usage. También se pueden observar los Draw Calls, SetPass Calls, cantidad de triángulos, texturas cargadas y uso de sombras. |
| 5 | **Registrar una línea base antes de modificar** | Se anotan los FPS, tiempo por frame, uso de memoria, Draw Calls, triángulos, llamadas costosas y procesos más lentos. Con esa línea base se podrá comparar objetivamente si una optimización realmente mejora el rendimiento. |

---

## Conclusión de la Sección C

La optimización en XR no debe hacerse al azar. Primero se debe medir el rendimiento con herramientas como Unity Profiler y luego aplicar técnicas específicas según el problema detectado. En apps AR móviles, los errores más comunes son usar luces dinámicas en exceso, texturas sin comprimir, sombras en tiempo real y búsquedas costosas dentro de `Update()`.

# SECCIÓN D — PREGUNTAS AVANZADAS Y DE CASO (30 puntos)

## Caso profesional (15 pts)

### Pregunta D1 (5 pts)

| Técnica aplicada | Por qué aplica a este caso específico | Impacto esperado en FPS | ¿Requiere modificar assets 3D o solo configuración? |
|---|---|---|---|
| **Static Batching** | El túnel tiene muchos objetos fijos como rocas, señales y equipos que no se moverán durante la simulación. | Alto, porque reduce Draw Calls. | Configuración de Unity. |
| **GPU Instancing** | Hay muchos objetos que comparten los mismos materiales y pueden ser renderizados como copias del mismo mesh. | Alto, especialmente en rocas repetidas. | Configuración de materiales y prefabs. |
| **LOD Group** | El túnel mide 500 m, por lo que los objetos lejanos no necesitan mostrarse con alto detalle. | Alto, porque reduce triángulos renderizados. | Requiere versiones LOD de los modelos 3D. |
| **Occlusion Culling** | En un túnel minero muchos objetos quedan ocultos por paredes, curvas o estructuras. | Medio-alto, porque evita renderizar objetos no visibles. | Configuración de Unity. |
| **Baked Lighting** | La mayor parte del túnel es estática, por lo que no es necesario calcular todas las luces en tiempo real. | Alto, porque reduce carga de GPU. | Configuración de iluminación. |
| **Optimización de partículas** | Las explosiones dinámicas pueden consumir mucho rendimiento si tienen demasiadas partículas. | Medio, mejora estabilidad en escenas con explosiones. | Ajuste de sistemas de partículas. |
| **Optimización de scripts en Update** | Hay 15 scripts ejecutándose en `Update()`, lo que puede generar carga innecesaria en CPU. | Medio-alto, dependiendo de la lógica. | Modificación de código. |
| **Fixed Foveated Rendering** | En Meta Quest 2 se puede reducir la calidad en los bordes del campo visual sin afectar mucho la percepción del usuario. | Medio-alto en VR. | Configuración de XR/Quest. |

---

### Pregunta D2 (5 pts)

Para evitar que 500 rocas usen `Rigidbody` activo al mismo tiempo, se puede implementar un sistema de activación por zonas.

La idea es que solo las rocas cercanas al jugador o ubicadas dentro del evento actual de caída tengan física activa. Las demás rocas permanecerían como objetos estáticos o con `Rigidbody` en modo `isKinematic = true`.

Cuando el usuario se acerque a una zona de riesgo, el sistema activa únicamente un grupo pequeño de rocas, por ejemplo entre 20 y 40. Estas rocas tendrían física real para caer, chocar y rodar. Una vez que el evento termine o las rocas queden detenidas, se desactiva la física nuevamente.

```csharp
using UnityEngine;

public class RocaFisicaControlada : MonoBehaviour
{
    private Rigidbody rb;
    private Transform jugador;
    public float distanciaActivacion = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jugador = Camera.main.transform;

        rb.isKinematic = true;
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= distanciaActivacion)
        {
            rb.isKinematic = false;
        }
        else
        {
            rb.isKinematic = true;
        }
    }
}
```

Con esta solución, se mantiene el realismo visual porque el usuario ve rocas cayendo de forma natural cerca de él, pero se evita que el procesador calcule física para objetos que están lejos o que no forman parte del evento activo.

---

### Pregunta D3 (5 pts)

Para implementar un sistema de **LOD automático en runtime**, se puede crear un controlador que evalúe dos factores:

1. La **distancia del usuario** respecto a cada objeto.
2. El **FPS actual** de la aplicación.

Si el usuario está cerca, se muestra un modelo de mayor calidad. Si está lejos, se muestra un modelo de menor detalle. Además, si los FPS bajan demasiado, el sistema fuerza niveles LOD más bajos para recuperar rendimiento.

```csharp
using UnityEngine;

public class RuntimeLODManager : MonoBehaviour
{
    public LODGroup[] objetosLOD;
    public Transform jugador;

    public float fpsActual;
    private float deltaTime;

    void Update()
    {
        CalcularFPS();

        foreach (LODGroup lod in objetosLOD)
        {
            float distancia = Vector3.Distance(jugador.position, lod.transform.position);

            if (fpsActual < 60)
            {
                lod.ForceLOD(2);
            }
            else if (distancia < 10f)
            {
                lod.ForceLOD(0);
            }
            else if (distancia < 30f)
            {
                lod.ForceLOD(1);
            }
            else
            {
                lod.ForceLOD(2);
            }
        }
    }

    void CalcularFPS()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        fpsActual = 1.0f / deltaTime;
    }
}
```

Este sistema permite que el túnel se adapte dinámicamente. Cuando el usuario está cerca de los objetos, se prioriza la calidad visual. Cuando el usuario se aleja o el rendimiento baja, se reduce el nivel de detalle para mantener la fluidez.

---

## Pregunta de diseño (8 pts)

### Sistema Adaptive Quality

Un sistema de **Adaptive Quality** ajusta automáticamente la calidad visual según el rendimiento. Si los FPS caen por debajo de 60, reduce sombras, distancia de renderizado, calidad de texturas o nivel de detalle. Si los FPS se recuperan, restaura gradualmente la calidad.

```csharp
using UnityEngine;

public class AdaptiveQualityManager : MonoBehaviour
{
    public float fpsActual;
    public float fpsMinimo = 60f;
    public float fpsRecuperacion = 72f;

    private float deltaTime;
    private int nivelCalidad = 2;

    void Update()
    {
        CalcularFPS();

        if (fpsActual < fpsMinimo)
        {
            ReducirCalidad();
        }
        else if (fpsActual > fpsRecuperacion)
        {
            AumentarCalidad();
        }
    }

    void CalcularFPS()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        fpsActual = 1.0f / deltaTime;
    }

    void ReducirCalidad()
    {
        if (nivelCalidad > 0)
        {
            nivelCalidad--;

            QualitySettings.SetQualityLevel(nivelCalidad);
            QualitySettings.shadowDistance = 10f;
            QualitySettings.lodBias = 0.5f;
            XRSettings.eyeTextureResolutionScale = 0.8f;
        }
    }

    void AumentarCalidad()
    {
        if (nivelCalidad < 2)
        {
            nivelCalidad++;

            QualitySettings.SetQualityLevel(nivelCalidad);
            QualitySettings.shadowDistance = 30f;
            QualitySettings.lodBias = 1.0f;
            XRSettings.eyeTextureResolutionScale = 1.0f;
        }
    }
}
```

### Explicación

La lógica del sistema consiste en medir los FPS constantemente. Si el rendimiento baja de 60 FPS, se reduce la calidad visual para evitar cortes, mareos o pérdida de fluidez. Si los FPS suben por encima de 72 FPS, el sistema restaura la calidad de manera gradual.

Este tipo de sistema es útil en XR porque permite mantener la experiencia estable sin depender de que el usuario cambie manualmente la configuración.

---

## Pregunta de pensamiento crítico (7 pts)

Reducir la resolución de pantalla al 50 % puede mejorar el rendimiento porque la GPU procesa menos píxeles. Sin embargo, también tiene riesgos importantes en XR.

El principal riesgo es la **pérdida de claridad visual**. En realidad aumentada o virtual, el usuario necesita leer textos, reconocer objetos, ver detalles del entorno y mantener una imagen estable. Si la resolución baja demasiado, la experiencia puede verse borrosa, poco profesional o incómoda.

### Contextos donde podría ser aceptable

| Contexto XR | Por qué podría aceptarse |
|---|---|
| Escenas con objetos grandes y pocos textos | La reducción de resolución no afecta demasiado la comprensión visual. |
| Momentos de baja importancia visual | Por ejemplo, durante una transición, carga o escena secundaria. |
| Dispositivos de bajo rendimiento | Puede usarse temporalmente para evitar caídas graves de FPS. |
| Experiencias donde la prioridad es la fluidez | En VR, mantener FPS estables puede ser más importante que la calidad máxima. |

### Contextos donde sería inaceptable

| Contexto XR | Por qué no debería aplicarse |
|---|---|
| Aplicaciones con texto pequeño | El usuario no podría leer instrucciones, etiquetas o datos importantes. |
| Entrenamiento técnico o médico | Se requiere alta precisión visual para evitar errores de interpretación. |
| AR con reconocimiento de detalles del entorno | Una imagen borrosa puede afectar la integración entre objetos reales y virtuales. |
| Simulaciones de seguridad minera | El usuario debe identificar señales, riesgos, rutas y objetos críticos con claridad. |

### Conclusión

Reducir la resolución al 50 % puede ser una solución rápida, pero no debe ser la primera estrategia. Antes se deben optimizar modelos 3D, texturas, luces, sombras, Draw Calls, físicas y scripts. En XR, la fluidez es importante, pero la claridad visual también es fundamental para evitar incomodidad, errores y pérdida de realismo.

---


*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 12 | 2026-1*