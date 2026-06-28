# S12 — GUÍA DE TRABAJO DEL ESTUDIANTE
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 12 — Optimización y Rendimiento en XR

---

> **Instrucciones:** Resuelve todas las secciones en orden. Tiempo sugerido: 90 minutos.
> Entrega en el repositorio del curso como archivo `.md` con tu rama `u-codigo-apellido-nombre-gt12`.
> **No está permitido** buscar respuestas en internet para la Sección A y B.

| Campo | Detalle |
|-------|---------|
| **Estudiante** | Salazar Mondragón Jael Santiago |
| **Código** | 2221898131|
| **Fecha** | 27/06/2026 |
| **Semana** | 12 — Optimización y Rendimiento en XR |

---

## SECCIÓN A — PREGUNTAS DE OPCIÓN MÚLTIPLE (20 puntos — 2 pts c/u)

**Pregunta 1** *(básica)*

¿Cuántos FPS mínimos exige Meta para aprobar una app en el Quest Store?

- [ ] a) 30 FPS
- [ ] b) 60 FPS
- [x] c) 72 FPS
- [ ] d) 120 FPS

**Respuesta:** c) 72 FPS

**Explicación:**  
Meta establece un mínimo de 72 FPS para ofrecer una experiencia VR fluida y reducir el riesgo de mareos durante el uso del visor.

---

**Pregunta 2** *(básica)*

¿Cuál es la herramienta principal de Unity para diagnosticar problemas de rendimiento en tiempo real?

- [ ] a) Inspector
- [x] b) Unity Profiler
- [ ] c) Package Manager
- [ ] d) Scene View Stats

**Respuesta:** b) Unity Profiler

**Explicación:**  
Unity Profiler permite monitorear el uso de CPU, GPU, memoria y otros recursos mientras la aplicación se está ejecutando.

---

**Pregunta 3** *(básica)*

¿Qué es un "Draw Call" en el contexto del rendering de Unity?

- [ ] a) Una función de C# que dibuja texto en pantalla
- [x] b) Una instrucción que la CPU envía a la GPU para renderizar un objeto
- [ ] c) Una llamada al sistema operativo para mostrar la ventana de Unity
- [ ] d) El proceso de importar modelos 3D al proyecto

**Respuesta:** b) Una instrucción que la CPU envía a la GPU para renderizar un objeto.

**Explicación:**  
Cada Draw Call representa una orden de renderizado enviada por la CPU. Si existen demasiadas llamadas, el rendimiento de la aplicación puede disminuir.

---

**Pregunta 4** *(básica)*

¿Qué condición debe cumplir un objeto para poder aplicarle Static Batching?

- [ ] a) Debe tener un Rigidbody
- [x] b) Debe estar marcado como "Static" y no moverse en runtime
- [ ] c) Debe tener exactamente el mismo mesh que otro objeto
- [ ] d) Debe estar en la misma capa (Layer) que los otros objetos

**Respuesta:** b) Debe estar marcado como "Static" y no moverse en runtime.

**Explicación:**  
Static Batching está diseñado para objetos que permanecen inmóviles durante la ejecución, permitiendo reducir la cantidad de Draw Calls.

---

**Pregunta 5** *(intermedia)*

Un modelo 3D tiene 50,000 triángulos en LOD 0. Si el usuario está a 30 metros de distancia y el objeto ocupa el 10% de la pantalla, ¿qué debería mostrar un LOD Group bien configurado?

- [ ] a) LOD 0 (50,000 triángulos) porque el objeto está visible
- [x] b) LOD 1 o LOD 2 con menos triángulos, porque el usuario no nota la diferencia a esa distancia
- [ ] c) "Culled" (no renderiza) porque el objeto es pequeño en pantalla
- [ ] d) LOD 0 siempre, independientemente de la distancia

**Respuesta:** b) LOD 1 o LOD 2 con menos triángulos.

**Explicación:**  
Cuando el objeto está lejos, utilizar modelos simplificados mantiene una apariencia similar y reduce la carga gráfica.

---

**Pregunta 6** *(intermedia)*

Un desarrollador tiene 300 árboles idénticos en su escena con el mismo material. ¿Qué técnica produce mayor reducción de Draw Calls?

- [ ] a) Static Batching, porque los árboles no se mueven
- [x] b) GPU Instancing, porque son instancias del mismo mesh con el mismo material
- [ ] c) LOD Groups, porque reduce la cantidad de triángulos
- [ ] d) Occlusion Culling, porque no renderiza los que están ocultos

**Respuesta:** b) GPU Instancing.

**Explicación:**  
GPU Instancing permite dibujar múltiples copias del mismo objeto utilizando una sola llamada de renderizado, mejorando el rendimiento.

---

**Pregunta 7** *(intermedia)*

¿Por qué crear `new List<>()` dentro de `void Update()` es un problema de rendimiento?

- [ ] a) Porque List no se puede crear dentro de métodos de Unity
- [x] b) Porque genera un objeto nuevo en el heap en cada frame, aumentando la presión sobre el Garbage Collector
- [ ] c) Porque Unity no soporta listas genéricas en tiempo de ejecución
- [ ] d) Porque List.Add() es más lento que los arrays simples

**Respuesta:** b) Porque genera un objeto nuevo en el heap en cada frame.

**Explicación:**  
Crear objetos continuamente dentro de Update produce asignaciones de memoria innecesarias que luego deben ser liberadas por el Garbage Collector.

---

**Pregunta 8** *(avanzada)*

En el Unity Profiler, observas que `Camera.Render` toma 45ms y `Scripts Update` toma 2ms por frame. ¿Qué tipo de problema tiene la aplicación?

- [ ] a) CPU bound — los scripts son el cuello de botella
- [x] b) GPU bound — el problema está en el rendering
- [ ] c) Memory bound — hay demasiada memoria usada
- [ ] d) Physics bound — las colisiones son el problema

**Respuesta:** b) GPU bound.

**Explicación:**  
La mayor parte del tiempo se consume durante el renderizado de la cámara, indicando que el cuello de botella está relacionado con la GPU.

---

**Pregunta 9** *(avanzada)*

¿Cuál es la ventaja del formato de textura ASTC sobre una textura sin comprimir (RGBA32) en Android?

- [ ] a) ASTC es más rápido de cargar desde el disco pero ocupa más memoria en GPU
- [x] b) ASTC reduce el tamaño en memoria de GPU hasta en un 75-80%, mejorando el rendimiento
- [ ] c) ASTC solo funciona en dispositivos con Android 10 o superior
- [ ] d) ASTC mejora la calidad visual pero no tiene impacto en rendimiento

**Respuesta:** b) ASTC reduce el tamaño en memoria de GPU.

**Explicación:**  
La compresión ASTC disminuye el consumo de memoria gráfica sin afectar demasiado la calidad visual, favoreciendo el rendimiento en dispositivos móviles.

---

**Pregunta 10** *(avanzada)*

¿Qué es el "GC.Collect" que aparece en el Unity Profiler y por qué causa stutters?

- [ ] a) Un método que recolecta datos de juego para análisis estadístico
- [x] b) El proceso del Garbage Collector que libera memoria de objetos no usados, pausando temporalmente todos los demás procesos
- [ ] c) Una llamada automática que guarda el estado del juego cada cierto tiempo
- [ ] d) El proceso de Unity para compilar los scripts en tiempo de ejecución

**Respuesta:** b) El proceso del Garbage Collector que libera memoria.

**Explicación:**  
Cuando el Garbage Collector se ejecuta, puede detener momentáneamente la aplicación para liberar memoria, generando pequeñas pausas o "stutters" durante la experiencia XR.

---

## SECCIÓN B — COMPLETAR Y RELACIONAR (20 puntos)

### Parte B1 — Completar espacios en blanco (10 pts — 2 pts c/u)

**1.** El valor de tiempo por frame para alcanzar 90 FPS es **11.11** milisegundos. Si algún proceso supera ese valor, la app baja de 90 FPS.

**Explicación:**  
Cada fotograma dispone de aproximadamente 11.11 ms para procesarse. Si ese tiempo se supera, el número de FPS disminuye.

---

**2.** Para aplicar GPU Instancing, el material del objeto debe tener activada la opción **Enable GPU Instancing** en el Inspector del material.

**Explicación:**  
Esta opción permite que la GPU renderice varias copias del mismo objeto utilizando menos Draw Calls.

---

**3.** El comando de Unity para acceder al Profiler es:

**Window** → Analysis → Profiler.

**Explicación:**  
Desde ese menú se abre la herramienta utilizada para analizar el rendimiento de la aplicación en tiempo real.

---

**4.** Cuando un objeto 3D tiene LOD configurado y la cámara se aleja lo suficiente, el sistema lo marca como **Culled**, es decir, deja de renderizarlo completamente.

**Explicación:**  
Cuando el objeto es demasiado pequeño para aportar información visual, Unity deja de dibujarlo para ahorrar recursos.

---

**5.** `GetComponent<Renderer>()` llamado en `void **Awake()**` (método de inicio, una sola vez) es la práctica correcta para cachear la referencia.

**Explicación:**  
Obtener la referencia una única vez evita realizar búsquedas repetitivas durante la ejecución del juego.

---

## Parte B2 — Relacionar columnas (10 pts — 1 pt c/u)

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



### Explicación

- **Static Batching** combina objetos estáticos que comparten material para reducir Draw Calls.
- **GPU Instancing** dibuja muchas copias del mismo objeto con una sola llamada de renderizado.
- **LOD Group** cambia automáticamente el nivel de detalle según la distancia del objeto.
- **Occlusion Culling** evita renderizar objetos ocultos por otros.
- **Baked Lighting** calcula la iluminación antes de ejecutar la aplicación y la almacena en lightmaps.
- **Single Pass Stereo** renderiza ambos ojos en una sola pasada, mejorando el rendimiento en VR.
- **GC Alloc** representa memoria temporal asignada que posteriormente será liberada por el Garbage Collector.
- **MaterialPropertyBlock** permite modificar propiedades de un objeto sin perder batching.
- **Draw Call** es cada instrucción enviada por la CPU a la GPU para renderizar un objeto.
- **Fixed Foveated Rendering** disminuye la resolución en la periferia de la imagen para mejorar el rendimiento en visores VR.

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

**Respuesta:**

| Problema | ¿Por qué afecta el rendimiento? |
|----------|---------------------------------|
| `GameObject.Find()` dentro de `Update()` | Busca el objeto en toda la escena cada frame, consumiendo CPU innecesariamente. |
| `GetComponent<Renderer>()` en cada frame | Realiza una búsqueda repetitiva del componente que podría almacenarse previamente. |
| Uso de `.material` continuamente | Puede crear nuevas instancias del material y aumentar el consumo de memoria. |
| `Debug.Log()` en cada frame | Genera gran cantidad de mensajes en la consola, afectando el rendimiento durante la ejecución. |

**Explicación:**  
El código realiza varias operaciones costosas cada frame que pueden evitarse almacenando referencias y eliminando instrucciones innecesarias dentro de `Update()`.

---

b) Reescribe el código optimizado manteniendo la funcionalidad (el color sigue cambiando con el tiempo). (4 pts)

```csharp
using UnityEngine;

public class ColorAR : MonoBehaviour
{
    private Renderer renderizador;

    void Awake()
    {
        renderizador = GetComponent<Renderer>();
    }

    void Update()
    {
        renderizador.material.color = new Color(
            Mathf.Sin(Time.time),
            0.5f,
            0.5f
        );
    }
}
```

**Explicación:**  
La referencia al componente se obtiene una sola vez en `Awake()`, evitando búsquedas repetitivas y mejorando el rendimiento del script.

---

## Pregunta C2 (8 pts)

a) Explica cuál es más apropiada para una escena AR estática (objetos que no se mueven) y justifica tu respuesta en términos de rendimiento. (4 pts)

**Respuesta:**

Para una escena AR estática es más conveniente utilizar **Baked Lighting**, ya que la iluminación se calcula previamente y se almacena en lightmaps. Esto reduce considerablemente el trabajo que realiza la GPU durante la ejecución y permite obtener una mayor cantidad de FPS.



---

b) ¿En qué escenario específico de AR sería NECESARIO usar iluminación en tiempo real en lugar de baked? (4 pts)

**Respuesta:**

La iluminación en tiempo real sería necesaria en una aplicación donde existan luces dinámicas o elementos que cambien constantemente de posición, por ejemplo una experiencia AR donde el usuario manipula una linterna virtual o mueve objetos que generan sombras en tiempo real.


---

## Pregunta C3 — Mini caso de análisis (14 pts)

### Pregunta C3a (7 pts)

Identifica los 4 problemas principales de rendimiento en orden de gravedad. Para cada uno: nombra el problema, explica por qué es grave y propón la técnica de optimización específica.

| Problema | ¿Por qué es grave? | Técnica de optimización |
|----------|--------------------|-------------------------|
| Texturas 2048×2048 sin comprimir | Consumen demasiada memoria GPU y aumentan los tiempos de renderizado. | Comprimir las texturas utilizando ASTC. |
| 20 luces en tiempo real | Incrementan significativamente el trabajo de la GPU. | Sustituirlas por Baked Lighting cuando sea posible. |
| `FindObjectsOfType()` dentro de `Update()` | Busca todos los objetos de la escena en cada frame, consumiendo mucha CPU. | Cachear referencias o utilizar listas previamente almacenadas. |
| Sombras activadas en todos los objetos | Generan una carga adicional importante durante el renderizado. | Desactivar sombras innecesarias o limitar su uso únicamente a objetos principales. |

**Explicación:**  
Estos problemas afectan tanto a CPU como a GPU, provocando una disminución considerable del rendimiento en dispositivos móviles.

---

### Pregunta C3b (7 pts)

El docente dice: **"Primero midan, después optimicen".** Describe el proceso exacto de 5 pasos que seguirías en Unity para diagnosticar correctamente el problema antes de tocar una sola línea de código o un solo ajuste de material.

**Respuesta:**

1. Ejecutar la aplicación y abrir **Window → Analysis → Profiler**.
2. Analizar el consumo de CPU, GPU, memoria y renderizado durante la ejecución.
3. Identificar cuál módulo presenta el mayor tiempo de procesamiento por frame.
4. Revisar los Draw Calls, cantidad de triángulos y uso de memoria para localizar el origen del problema.
5. Aplicar únicamente las optimizaciones necesarias y volver a medir el rendimiento para comprobar la mejora obtenida.


---

## SECCIÓN D — PREGUNTAS AVANZADAS Y DE CASO (30 puntos)

### Caso profesional (15 pts)

**Contexto:** La empresa *Lima XR Studios* ganó un contrato para desarrollar una app de entrenamiento VR para mineros de la empresa Antamina (Perú). La simulación muestra un túnel minero de 500m de largo con: 2,000 objetos 3D (rocas, equipos, señales de seguridad), 8 tipos de materiales distintos (pero muchos objetos comparten el mismo material), explosiones de partículas dinámicas, física activa para simular caída de rocas, y 15 scripts de lógica de entrenamiento corriendo en Update. El headset objetivo es Meta Quest 2 (GPU: Adreno 650, 6GB RAM).

---

### Pregunta D1 (5 pts)

Diseña una **estrategia de optimización completa** para este proyecto. Organiza tu respuesta en una tabla con: técnica aplicada, por qué aplica a este caso específico, impacto esperado en FPS, y si requiere modificar los assets 3D o solo configuración de Unity.

| Técnica aplicada | ¿Por qué aplica? | Impacto esperado en FPS | ¿Modificar assets o configuración? |
|------------------|------------------|-------------------------|------------------------------------|
| Static Batching | Agrupa los objetos estáticos que comparten material | Reduce los Draw Calls y mejora el rendimiento | Configuración de Unity |
| GPU Instancing | Optimiza la representación de objetos repetidos como rocas y señales | Disminuye la carga de renderizado | Configuración del material |
| LOD Group | Reduce la complejidad de modelos lejanos | Menor cantidad de triángulos procesados | Modificar assets |
| Occlusion Culling | Evita renderizar objetos ocultos dentro del túnel | Reduce trabajo de la GPU | Configuración de Unity |
| Baked Lighting | Sustituye luces en tiempo real por iluminación precalculada | Disminuye el consumo de GPU | Configuración de Unity |

**Explicación:**  
La combinación de estas técnicas permite disminuir la carga tanto de CPU como de GPU, manteniendo una experiencia fluida en Meta Quest 2.

---

### Pregunta D2 (5 pts)

El físico de "caída de rocas" usa Rigidbody en 500 objetos simultáneamente. Propón una solución que mantenga el realismo visual de la simulación sin comprometer el rendimiento.

**Respuesta:**

Se puede mantener la mayoría de las rocas con Rigidbody desactivado y activar únicamente aquellas que realmente deban caer cuando el usuario se acerque o se produzca una explosión. Una vez finalizada la animación, los Rigidbody pueden volver a desactivarse o convertirse nuevamente en objetos estáticos.

---

### Pregunta D3 (5 pts)

¿Cómo implementarías un sistema de LOD automático en runtime para el túnel, donde el nivel de detalle cambia dinámicamente según la posición del usuario y el FPS actual?

**Respuesta:**

Se calcularía continuamente la distancia entre el usuario y cada objeto del túnel. Si el FPS disminuye por debajo del valor objetivo, el sistema reduciría automáticamente el nivel de detalle utilizando LOD más simples o incluso ocultando objetos muy lejanos. Cuando el rendimiento mejore, el sistema restaurará progresivamente los modelos con mayor calidad.

---

## Pregunta de diseño (8 pts)

> **¿Cómo implementarías un sistema de "Adaptive Quality" para tu proyecto XR que automáticamente reduce la calidad visual cuando el FPS cae por debajo de 60, y la restaura cuando el FPS sube? Describe la lógica del script en pseudocódigo o C# real.**

```csharp
void Update()
{
    float fps = 1f / Time.deltaTime;

    if (fps < 60)
    {
        QualitySettings.shadowDistance = 20;
        QualitySettings.lodBias = 0.5f;
    }
    else if (fps > 70)
    {
        QualitySettings.shadowDistance = 60;
        QualitySettings.lodBias = 1.0f;
    }
}
```

**Explicación:**  
El sistema supervisa constantemente el rendimiento y ajusta automáticamente la calidad gráfica para mantener una experiencia más estable.

---

## Pregunta de pensamiento crítico (7 pts)

> **"Un compañero propone: 'Para optimizar nuestra app AR, vamos a reducir la resolución de pantalla del celular al 50% — así el GPU renderiza menos píxeles y ganamos FPS'. ¿Cuál es el riesgo de esta estrategia y en qué contextos XR específicos podría ser aceptable vs. inaceptable?"**

**Respuesta:**

Reducir la resolución puede mejorar el rendimiento porque disminuye la cantidad de píxeles que procesa la GPU. Sin embargo, también reduce la nitidez de la imagen, haciendo que textos, botones y objetos pequeños sean más difíciles de distinguir. Esta estrategia podría ser aceptable en aplicaciones donde predominan modelos grandes y no existe mucho texto en pantalla. En cambio, sería poco recomendable en aplicaciones educativas o de realidad aumentada donde el usuario necesita leer información detallada o identificar elementos pequeños.

---

## RÚBRICA DE AUTOEVALUACIÓN

| Criterio | Cumplido |
|----------|:-------:|
| Respondí las 10 preguntas de opción múltiple | ☑ |
| Completé los 5 espacios en blanco de B1 | ☑ |
| Relacioné todas las 10 columnas de B2 | ☑ |
| En C1 identifiqué mínimo 3 problemas y escribí código optimizado | ☑ |
| En C2 expliqué la diferencia con ejemplo concreto | ☑ |
| En C3 identifiqué 4 problemas con técnicas específicas | ☑ |
| En D1 mi tabla de estrategia tiene mínimo 5 técnicas | ☑ |
| En D2 propuse solución de física que no requiere 500 Rigidbodies activos | ☑ |
| Entregué como `.md` en la rama correcta de GitHub | ☑ |

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 12 | 2026-1*