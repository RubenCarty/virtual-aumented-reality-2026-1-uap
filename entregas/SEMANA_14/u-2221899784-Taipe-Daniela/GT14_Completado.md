# S14 — GUÍA DE TRABAJO ESTUDIANTIL
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 14 — Pruebas y Validación de Experiencias XR

---

> **Instrucciones generales**
> Esta guía contiene 4 secciones con distinto nivel de profundidad.
> **No incluye respuestas** — eso es responsabilidad tuya.
> Trabaja individualmente. Puedes consultar tus apuntes y la documentación oficial.
> **Tiempo estimado:** 90 minutos en total.

---

## SECCIÓN A — COMPRENSIÓN CONCEPTUAL (20 min)
### Preguntas de opción múltiple — una respuesta correcta por pregunta

---
## Pregunta 1.
¿Cuál es la diferencia entre "testing" (pruebas) y "debugging" (depuración)?

- [ ] a) Son sinónimos — ambos términos se refieren a encontrar errores en el código.
- [x] **b) El testing detecta la existencia de defectos; el debugging localiza y corrige la causa raíz de defectos ya conocidos.**
- [ ] c) El testing es manual; el debugging es automático.
- [ ] d) El testing ocurre antes del desarrollo; el debugging ocurre durante el desarrollo.

**Explicación:** El testing sirve para identificar la presencia de errores, mientras que el debugging consiste en analizar el código para encontrar la causa del problema y corregirlo.

---

## Pregunta 2.
Un desarrollador encuentra que su app AR tiene 30 FPS en el editor Unity pero solo 18 FPS en el dispositivo Android físico. ¿Cuál es el primer paso lógico para diagnosticar esta diferencia?

- [ ] a) Cambiar el target platform a iOS y ver si mejora.
- [ ] b) Desactivar ARCore en el proyecto porque consume demasiado.
- [x] **c) Conectar el dispositivo Android al Profiler de Unity y capturar datos de CPU/GPU en el dispositivo real.**
- [ ] d) Reinstalar Unity en el dispositivo Android.

**Explicación:** El rendimiento debe analizarse en el dispositivo real usando el Unity Profiler para identificar qué componente (CPU, GPU o memoria) está causando la baja de FPS.

---

## Pregunta 3.
En Unity Test Runner, ¿cuál es la diferencia entre un test de "Edit Mode" y uno de "Play Mode"?

- [ ] a) Edit Mode funciona solo en Windows; Play Mode funciona en todas las plataformas.
- [x] **b) Edit Mode prueba la lógica de scripts sin iniciar el ciclo de juego de Unity; Play Mode prueba con el ciclo completo (Start, Update, etc.) activo.**
- [ ] c) Edit Mode es más lento porque requiere compilar; Play Mode es más rápido porque usa caché.
- [ ] d) No hay diferencia funcional — son alias del mismo tipo de test en Unity.

**Explicación:** Los tests de Edit Mode verifican únicamente la lógica del código, mientras que los de Play Mode ejecutan el comportamiento completo del juego dentro de Unity.

---

## Pregunta 4.
¿Cuál de los siguientes es un ejemplo de bug con severidad "cosmética" pero prioridad P1?

- [ ] a) La app crashea al iniciar — día antes de la presentación final.
- [ ] b) La detección de planos no funciona en superficies oscuras — se reporta 3 meses antes del lanzamiento.
- [x] **c) El logo de la empresa en la pantalla de inicio muestra la versión antigua — demo con el cliente mañana.**
- [ ] d) El texto de ayuda tiene un error de ortografía — versión 1.0 recién publicada.

**Explicación:** Aunque el error es solo visual (cosmético), tiene prioridad alta porque afecta una demostración importante con el cliente.

---

## Pregunta 5.
¿Qué es una "prueba de regresión" y cuándo se ejecuta?

- [ ] a) Es una prueba que verifica que el hardware del dispositivo es compatible con la app; se ejecuta al inicio del proyecto.
- [x] **b) Es una prueba que re-ejecuta casos previamente aprobados para verificar que las correcciones de bugs no rompieron funcionalidades existentes; se ejecuta después de cada corrección.**
- [ ] c) Es una prueba de rendimiento bajo condiciones extremas de carga; se ejecuta antes del lanzamiento.
- [ ] d) Es una prueba que verifica la accesibilidad del producto; se ejecuta una vez al final del proyecto.

**Explicación:** Después de corregir un error se vuelven a ejecutar pruebas anteriores para asegurar que las demás funciones continúan funcionando correctamente.

---

## Pregunta 6.
Un equipo de desarrollo usa la convención de Conventional Commits y escribe el mensaje:

`fix(ar-placement): prevenir NullReferenceException en gestos sin plano — BUG-012`

¿Cuál de los siguientes beneficios NO proporciona directamente el ID de bug en el mensaje de commit?

- [ ] a) Permite buscar exactamente qué cambio de código corrigió el bug con `git log --grep="BUG-012"`.
- [ ] b) Permite que GitHub/GitLab cierre automáticamente el issue relacionado al hacer merge.
- [ ] c) Permite al reviewer del PR verificar que el cambio corresponde a lo descrito en el bug report.
- [x] **d) Impide que el mismo bug pueda ser reportado nuevamente por otro tester.**

**Explicación:** El identificador del bug facilita el seguimiento del cambio, pero no evita que otros usuarios vuelvan a reportar el mismo problema si este reaparece.

---

## Pregunta 7.
¿Por qué el protocolo Think-Aloud es especialmente valioso para pruebas de usabilidad en XR comparado con una app de escritorio convencional?

- [ ] a) Porque en XR el evaluador no puede ver la pantalla del usuario, entonces necesita escuchar lo que dice.
- [x] **b) Porque en XR las interacciones son gestos y movimientos físicos difíciles de registrar solo con clickstream; la verbalización revela en tiempo real dónde el usuario se confunde en el espacio 3D.**
- [ ] c) Porque en XR el software no tiene logs de error, entonces la voz del usuario es la única fuente de datos.
- [ ] d) Porque en XR todos los usuarios son principiantes y necesitan ser guiados durante la prueba.

**Explicación:** Pensar en voz alta permite conocer qué está entendiendo o dónde tiene dificultades el usuario mientras interactúa en un entorno tridimensional.

---

## Pregunta 8.
Un caso de prueba para AR tiene la siguiente precondición: "Superficie plana horizontal, texturizada, iluminación 300-600 lux". Dos testers ejecutan el mismo caso: uno sobre una mesa de madera (PASA), otro sobre un espejo horizontal (FALLA). ¿Cuál es la conclusión correcta?

- [ ] a) Hay un bug en el código de ARCore que debe reportarse a Google.
- [ ] b) El caso de prueba está mal diseñado porque los resultados son inconsistentes.
- [x] **c) No hay un bug — la diferencia de resultado se explica por la precondición (el espejo no es superficie texturizada). El caso está bien diseñado para superficies texturizadas; se necesita un caso separado para superficies reflectantes.**
- [ ] d) Los dos testers deben repetir la prueba simultáneamente para determinar cuál resultado es correcto.

**Explicación:** El espejo no cumple la condición de ser una superficie texturizada, por lo que el comportamiento esperado es diferente y no representa un error del sistema.

---

## Pregunta 9.
¿Cuál de los siguientes describe mejor el rol de ARCore en relación con las pruebas de rendimiento en Android?

- [x] **a) ARCore consume recursos adicionales de CPU para el análisis de la cámara, lo que puede reducir los FPS disponibles para la lógica del juego y los shaders Unity.**
- [ ] b) ARCore optimiza automáticamente el rendimiento del GPU y garantiza 60 FPS en todos los dispositivos certificados.
- [ ] c) ARCore solo consume recursos cuando hay planos detectados; si no hay planos, el consumo de CPU es cero.
- [ ] d) ARCore funciona en el GPU exclusivamente y no afecta el rendimiento de los scripts de Unity que corren en CPU.

**Explicación:** ARCore utiliza procesamiento adicional para analizar la cámara y detectar el entorno, lo que incrementa el uso de recursos y puede disminuir el rendimiento.

---

## Pregunta 10.
¿Cuál es el propósito de incluir un campo "Reproducibilidad" (ej.: "10/10 intentos") en un bug report?

- [ ] a) Indicar al desarrollador cuántas líneas de código están afectadas por el bug.
- [x] **b) Comunicar la probabilidad de que el bug ocurra bajo las mismas condiciones, lo que ayuda a priorizar y a verificar que la corrección fue exitosa.**
- [ ] c) Limitar al tester a reportar solo bugs que ocurren siempre (10/10) y descartar los intermitentes.
- [ ] d) Calcular automáticamente la prioridad del bug dividiendo 10 entre el número de intentos fallidos.

**Explicación:** La reproducibilidad indica con qué frecuencia ocurre el error bajo las mismas condiciones, facilitando su análisis, priorización y posterior verificación una vez corregido.
---

## SECCIÓN B — COMPRENSIÓN TÉCNICA (20 min)

### B.1 — Completar espacios en blanco

Completa los espacios con el término técnico correcto.

1. En Unity, el framework de pruebas integrado se llama **Unity Test Runner** y se accede desde el menú **Window** → General → **Test Runner**.

2. El tipo de test que verifica la lógica de un script sin necesitar que Unity esté en Play Mode se llama test de **Edit** Mode.

3. En NUnit (el framework usado por Unity Test Runner), el atributo que marca un método como un test es **[Test]**, y el método que se ejecuta antes de cada test individual para preparar el estado inicial se marca con **[SetUp]**.

4. La métrica de rendimiento que mide cuántos objetos Unity envía al GPU para renderizar en cada frame se llama **Draw Calls** y en proyectos AR móvil debe mantenerse por debajo de **100** para un rendimiento aceptable.

5. Cuando la causa de bajo FPS está en el GPU (renderizado de malla, shaders) se llama condición **GPU** bound; cuando está en el CPU (scripts, física, IA) se llama condición **CPU** bound.

6. En el ciclo de vida de un bug en un sistema de tracking, después de que el developer corrige el bug y hace commit, el estado del bug cambia de "Corregido" a "**Pendiente de verificación**" hasta que el tester re-ejecuta el caso de prueba original.

7. El protocolo de pruebas de usabilidad en el que el usuario verbaliza sus pensamientos mientras usa el producto se llama protocolo **Think-Aloud**.

8. Una prueba que re-ejecuta todos los casos de prueba aprobados anteriormente después de una corrección se llama prueba de **Regresión**.

---

### B.2 — Emparejar columnas

Empareja cada término (columna izquierda) con su definición correcta (columna derecha).

| # | Término | | Definición |
|---|---------|---|------------|
| 1 | Severidad | **B** | Impacto técnico de un bug en la funcionalidad del sistema |
| 2 | Prioridad | **A** | Urgencia con la que un bug debe ser corregido, según el contexto de negocio |
| 3 | Caso de prueba | **F** | Unidad atómica de prueba: pasos específicos + entrada + resultado esperado |
| 4 | Plan de pruebas | **E** | Documento que define qué se prueba, cómo, cuándo y quién, con su alcance |
| 5 | Unity Profiler | **C** | Herramienta de Unity que registra datos de CPU, GPU, memoria y audio frame por frame |
| 6 | Precondición | **D** | Condición del sistema que debe ser verdadera antes de ejecutar un caso de prueba |
| 7 | Test de regresión | **H** | Re-ejecución de casos de prueba ya aprobados para detectar nuevos defectos tras cambios |
| 8 | Unit test | **G** | Tipo de test que verifica funciones individuales de forma aislada sin dependencias externas |
| 9 | Think-Aloud | **J** | Protocolo de usabilidad donde el usuario verbaliza sus pensamientos en tiempo real |
| 10 | Integration test | **I** | Confirmación de que el sistema funciona correctamente con todas sus partes integradas |

---

### B.3 — Verdadero o Falso con justificación

Indica V (verdadero) o F (falso) y escribe UNA frase explicando por qué.

1. **F** Un test unitario (Unit Test) en Edit Mode puede probar si ARPlaneManager detecta planos correctamente en tiempo real.  
**Justificación:** Porque ARPlaneManager requiere ejecutarse en Play Mode y en un dispositivo compatible con AR.

2. **F** Es posible tener un bug con severidad CRÍTICA (la app crashea) y prioridad P4 (diferir indefinidamente).  
**Justificación:** Un bug crítico debe corregirse con alta prioridad.

3. **F** En el contexto de pruebas XR, "Happy Path" se refiere a la suite de casos de prueba más completa que verifica todos los escenarios posibles.  
**Justificación:** Happy Path representa únicamente el flujo principal de éxito.

4. **F** ARCore puede detectar planos horizontales en superficies completamente uniformes sin textura visual (como una pared blanca lisa).  
**Justificación:** ARCore necesita características visuales para detectar superficies.

5. **F** El protocolo Think-Aloud requiere que el evaluador intervenga y guíe al usuario cuando este se confunde, para que pueda completar las tareas.  
**Justificación:** El evaluador solo observa y registra, sin intervenir.

6. **V** En la "pirámide de pruebas", los tests unitarios (base de la pirámide) deberían ser los más numerosos porque son los más rápidos y baratos de ejecutar.  
**Justificación:** Son rápidos, económicos y permiten detectar errores tempranamente.

---

## SECCIÓN C — ANÁLISIS Y APLICACIÓN (25 min)

### C.1 — Diagnóstico de plan de pruebas con deficiencias

Lee el siguiente plan de pruebas creado por un estudiante para su proyecto AR y responde las preguntas.

```text
PLAN DE PRUEBAS — Proyecto: CuidaPlanta AR
Autor: Estudiante
Fecha: Semana 14

Casos de prueba:
1. Probar que la planta aparezca.
2. Probar que el water button funcione.
3. Probar que se vea bien.
4. Probar que no crashee.
5. Verificar que el audio esté.

Notas: vamos a probar en mi celular y esperamos que todo funcione.
```

**Preguntas:**

**a) Identifica 4 deficiencias específicas en este plan de pruebas. Para cada una, nombra el elemento que falta y explica por qué es importante.**

1. **Falta un identificador (ID)** para cada caso de prueba; permite organizar y dar seguimiento a las pruebas.
2. **Faltan precondiciones**; aseguran que todos ejecuten la prueba en las mismas condiciones.
3. **Faltan pasos detallados**; permiten repetir la prueba de forma consistente.
4. **Falta el resultado esperado**; permite determinar objetivamente si la prueba pasó o falló.

**b) Reescribe el caso de prueba 1 ("Probar que la planta aparezca") en formato profesional con todos los campos necesarios: ID, módulo, prioridad, precondiciones, pasos numerados, resultado esperado y estado inicial.**

**ID:** TC-001

**Módulo:** Detección de planos AR

**Prioridad:** Alta (P1)

**Precondiciones:**
- Dispositivo compatible con ARCore.
- Aplicación instalada y abierta.
- Superficie plana horizontal y texturizada.
- Iluminación adecuada.

**Estado inicial:**
La aplicación está abierta y esperando detectar una superficie.

**Pasos numerados:**
1. Abrir la aplicación.
2. Apuntar la cámara hacia una superficie plana.
3. Esperar la detección del plano.
4. Tocar la superficie detectada.

**Resultado esperado:**
La planta virtual aparece correctamente sobre la superficie detectada y permanece estable.

**c) El plan dice "esperamos que todo funcione" — ¿qué problema revela esta frase sobre el enfoque del equipo hacia las pruebas? ¿Qué debería decir en su lugar?**

**Respuesta:** La frase refleja un enfoque basado en suposiciones y no en verificación objetiva. Debería decir: **"Se ejecutarán los casos de prueba definidos para verificar que cada funcionalidad cumpla los resultados esperados y registrar cualquier defecto encontrado."**

---

### C.2 — Análisis de código con bugs a identificar

Lee el siguiente código de un gestor de AR y luego responde las preguntas:

```csharp
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GestorColocacionAR : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject prefabObjeto;
    public GestorAccesibilidadColor colorManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private int contadorObjetos = 0;

    // Bug A está en este método
    public void AlTapEnPantalla(Vector2 posicionToque)
    {
        raycastManager.Raycast(posicionToque, hits, TrackableType.PlaneWithinPolygon);
        Vector3 posicion = hits[0].pose.position;
        Instantiate(prefabObjeto, posicion, hits[0].pose.rotation);
        contadorObjetos++;
    }

    // Bug B está en este método
    public void ResetearEscena()
    {
        GameObject[] objetos = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objetos)
        {
            Destroy(obj);
        }
        contadorObjetos = 0;
    }

    // Bug C está en este método
    public void CambiarColorAccesibilidad()
    {
        colorManager.SiguienteModo();
    }

    // Bug D está en este método
    void Update()
    {
        if (contadorObjetos > 10)
        {
            Debug.Log("Máximo de objetos alcanzado");
            Debug.Log("Máximo de objetos alcanzado");
            Debug.Log("Máximo de objetos alcanzado");
        }
    }
}
```

**Preguntas:**

a) Para el **Bug A**: ¿en qué línea exacta está el bug? ¿Qué excepción lanzará? ¿Cuándo ocurrirá en condiciones de uso real? Escribe la versión corregida del método `AlTapEnPantalla`.
public void AlTapEnPantalla(Vector2 posicionToque)
{
    if (raycastManager != null &&
        raycastManager.Raycast(posicionToque, hits, TrackableType.PlaneWithinPolygon) &&
        hits.Count > 0)
    {
        Pose pose = hits[0].pose;
        Instantiate(prefabObjeto, pose.position, pose.rotation);
        contadorObjetos++;
    }
    else
    {
        Debug.Log("No se detectó un plano válido.");
    }
}

b) Para el **Bug B**: `Destroy(obj)` aplicado a TODOS los GameObjects de la escena es un problema grave. Explica por qué causaría un comportamiento incorrecto y cómo debería corregirse correctamente (sin destruir la cámara, el ARSession y otros objetos del sistema).
private List<GameObject> objetosInstanciados = new List<GameObject>();

public void AlTapEnPantalla(Vector2 posicionToque)
{
    if (raycastManager != null &&
        raycastManager.Raycast(posicionToque, hits, TrackableType.PlaneWithinPolygon) &&
        hits.Count > 0)
    {
        Pose pose = hits[0].pose;
        GameObject nuevo = Instantiate(prefabObjeto, pose.position, pose.rotation);
        objetosInstanciados.Add(nuevo);
        contadorObjetos++;
    }
}

public void ResetearEscena()
{
    foreach (GameObject obj in objetosInstanciados)
    {
        if (obj != null)
            Destroy(obj);
    }

    objetosInstanciados.Clear();
    contadorObjetos = 0;
}

c) Para el **Bug C**: El método `CambiarColorAccesibilidad()` puede lanzar una NullReferenceException. ¿Cuándo ocurriría esto? Escribe la versión corregida.
public void CambiarColorAccesibilidad()
{
    if (colorManager != null)
    {
        colorManager.SiguienteModo();
    }
    else
    {
        Debug.LogWarning("GestorAccesibilidadColor no asignado.");
    }
}

d) Para el **Bug D**: El método de Unity `Debug.Log()` en Update() tiene un problema de rendimiento específico. ¿Qué es? ¿Cómo se corrige? ¿Cómo clasificarías la severidad de este bug?
private bool mensajeMostrado = false;

void Update()
{
    if (contadorObjetos > 10)
    {
        if (!mensajeMostrado)
        {
            Debug.Log("Máximo de objetos alcanzado");
            mensajeMostrado = true;
        }
    }
    else
    {
        mensajeMostrado = false;
    }
}

---

### C.3 — Caso de gestión de bugs: Priorización bajo presión

**Contexto:** Eres el QA Lead de un equipo de 3 personas que desarrolla una app de AR educativa para colegios rurales de Cusco. La app superpone modelos 3D de historia inca sobre libros impresos (target de imagen). La presentación al MINEDU es en 48 horas. Tienen capacidad de corrección de aproximadamente 6 horas de trabajo.

**Bugs identificados en la última sesión de pruebas:**

| Bug ID | Descripción | Severidad | Tiempo estimado |
|--------|-------------|-----------|-----------------|
| BUG-A | El modelo 3D de Machu Picchu tiene texturas invertidas (se ve todo negro) | MAYOR | 1 hora |
| BUG-B | Al alejar demasiado la cámara del libro, el modelo AR desaparece bruscamente sin transición | MENOR | 2 horas |
| BUG-C | La app no solicita permiso de cámara en Android 13 (crash al iniciar en Pixel 7) | CRÍTICO | 3 horas |
| BUG-D | Los subtítulos del narrador en quechua no tienen backing panel (ilegibles sobre fondos claros) | MAYOR | 0.5 horas |
| BUG-E | El nombre de la app en el ícono tiene un acento incorrecto ("Ándes" en vez de "Andes") | COSMÉTICO | 0.25 horas |
| BUG-F | No hay modo de accesibilidad visual para daltónicos en el menú de configuración | MAYOR | 4 horas |
| BUG-G | Si el libro está doblado en diagonal, el tracking falla sin mensaje de error al usuario | MENOR | 1.5 horas |

**Preguntas:**

a) El tiempo disponible es 6 horas. Selecciona qué bugs corregir, ordénalos por prioridad y justifica cada decisión en 2-3 oraciones. Ten en cuenta el contexto del usuario (colegios rurales, MINEDU) y el tiempo de la presentación.
1. BUG-G: Sin mensaje de error al usuario
Prioridad: ALTA

Justificación:
Se corrige primero porque afecta directamente la experiencia del usuario. En colegios rurales, los estudiantes pueden no comprender por qué la aplicación deja de responder cuando falla el tracking, por lo que un mensaje claro ayuda a solucionar el problema rápidamente.


2. BUG-A: Error al colocar objetos cuando no se detecta un plano
Prioridad: ALTA

Justificación:
Debe corregirse porque puede provocar que la aplicación falle durante la presentación al intentar colocar objetos AR sin una superficie detectada. Garantizar estabilidad es fundamental para una demostración educativa sin interrupciones.


3. BUG-B: Pérdida de tracking AR
Prioridad: ALTA

Justificación:
Afecta la función principal de realidad aumentada, ya que impide visualizar correctamente los elementos virtuales. Es necesario solucionarlo para asegurar que los estudiantes puedan interactuar con la aplicación.


4. BUG-C: Problema de contraste de colores
Prioridad: MEDIA

Justificación:
Se corrige si existe tiempo disponible porque está relacionado con accesibilidad visual e inclusión. No bloquea la funcionalidad principal, pero mejora la experiencia de usuarios con dificultades visuales.


5. BUG-D: Problema de rendimiento por Debug.Log en Update()
Prioridad: BAJA

Justificación:
No afecta directamente la demostración del proyecto. Puede solucionarse después como una optimización del código para mejorar el rendimiento.


ORDEN FINAL:

1. BUG-G
2. BUG-A
3. BUG-B
4. BUG-C
5. BUG-D

b) Para los bugs que NO corregirás antes de la presentación: ¿cómo los comunicarías al cliente (MINEDU) de manera profesional? Escribe un párrafo de 4-5 oraciones.

Los bugs pendientes fueron identificados durante el proceso de pruebas y se encuentran registrados para futuras mejoras. Debido al tiempo limitado antes de la presentación, se priorizaron los errores que afectan la estabilidad, funcionalidad principal y experiencia del usuario. Los problemas restantes no impiden mostrar las funciones principales de la aplicación durante la demostración. Se continuará trabajando en estas correcciones para entregar una versión más estable, accesible y adecuada para el entorno educativo.

c) BUG-G dice "sin mensaje de error al usuario". ¿Por qué es importante mostrar mensajes de error claros cuando el tracking falla en AR? Relaciona tu respuesta con los principios de accesibilidad cognitiva vistos en S13.

Los mensajes de error claros son importantes porque permiten que el usuario entienda qué sucede cuando falla el tracking y qué acción debe realizar para continuar. Sin estos mensajes, los estudiantes podrían pensar que la aplicación está fallando sin saber cómo solucionarlo.

Desde la accesibilidad cognitiva, los mensajes deben ser simples, visibles y fáciles de interpretar para usuarios con diferentes niveles de experiencia tecnológica. Esto reduce la frustración, mejora la autonomía del estudiante y facilita el aprendizaje mediante la aplicación de realidad aumentada.

---

## SECCIÓN D — SÍNTESIS Y REFLEXIÓN (25 min)

### Caso integrador: Sistema XR de Telesalud Rural en Perú

**Contexto:**

El Ministerio de Salud (MINSA) ha financiado el desarrollo de un sistema de VR para capacitación de técnicos de salud rurales en el manejo de emergencias obstétricas en zonas sin acceso a médicos especialistas (Puno, Loreto, Madre de Dios). El sistema funciona con headset VR (HTC Vive Focus 3) y simula el procedimiento de atención de un parto con complicaciones. Los técnicos practican el procedimiento en VR hasta dominarlo antes de atender casos reales.

El equipo entrega la versión beta y tú eres el responsable de validación. Tienes 2 semanas antes del primer despliegue piloto en 15 puestos de salud.

**Tarea (respuesta libre estructurada):**

**Parte D.1 — Plan de pruebas (10 min):**

Diseña el plan de pruebas para esta app de VR. Incluye:

- **Al menos 3 tipos de prueba diferentes con justificación de por qué son críticos en este contexto**

  **1. Pruebas funcionales:** Verifican que todas las funciones del simulador operen correctamente, incluyendo la interacción con los instrumentos médicos, la secuencia del procedimiento obstétrico y el registro de resultados. Son críticas porque el entrenamiento debe representar fielmente un procedimiento médico real.

  **2. Pruebas de usabilidad:** Evalúan si los técnicos de salud pueden utilizar el sistema de forma sencilla e intuitiva. Son importantes porque muchos usuarios pueden no tener experiencia previa con dispositivos de realidad virtual.

  **3. Pruebas de rendimiento y estabilidad:** Comprueban que la aplicación funcione de manera estable durante sesiones prolongadas, manteniendo una tasa constante de imágenes por segundo (FPS) y evitando bloqueos o cierres inesperados. Esto es esencial para evitar mareos y garantizar un entrenamiento continuo.

- **5 casos de prueba en formato correcto (ID, precondiciones, pasos, resultado esperado)**

| ID | Precondiciones | Pasos | Resultado esperado |
|----|----------------|--------|--------------------|
| CP-01 | Headset encendido y aplicación instalada | Iniciar la simulación | La aplicación inicia correctamente en menos de 10 segundos. |
| CP-02 | Simulación iniciada | Seleccionar un instrumento obstétrico | El sistema reconoce correctamente el instrumento seleccionado. |
| CP-03 | Usuario dentro de la simulación | Completar todas las etapas del procedimiento | El sistema registra correctamente cada paso y muestra la evaluación final. |
| CP-04 | Aplicación funcionando durante 30 minutos | Utilizar continuamente la simulación | No ocurren cierres inesperados ni disminución significativa del rendimiento. |
| CP-05 | Simulación finalizada | Guardar el progreso del usuario | El progreso queda almacenado correctamente para futuras sesiones. |

- **Los criterios de aceptación mínimos para declarar el producto "listo para despliegue"**

  - Todas las funciones principales deben ejecutarse correctamente.
  - No deben existir errores críticos o bloqueantes.
  - La aplicación debe mantener un rendimiento estable durante toda la simulación.
  - El procedimiento obstétrico debe representarse correctamente según el protocolo establecido.
  - El progreso del usuario debe almacenarse sin pérdida de información.
  - Los usuarios deben completar el entrenamiento sin dificultades importantes.

- **Qué sucede si se encuentra un bug crítico 1 día antes del despliegue (protocolo de decisión)**

  Si se detecta un bug crítico un día antes del despliegue, el lanzamiento debe posponerse temporalmente. El equipo de desarrollo debe corregir el error, posteriormente el equipo de pruebas ejecutará pruebas de regresión para verificar que la corrección no genere nuevos problemas y finalmente se validarán nuevamente todas las funciones críticas. Solo cuando el sistema cumpla todos los criterios de aceptación se autorizará el despliegue en los puestos de salud.

---

**Parte D.2 — Pruebas de accesibilidad críticas (5 min):**

Identifica al menos 3 barreras de accesibilidad específicas de ESTE contexto (técnicos rurales, zonas remotas, headset VR) que NO serían relevantes en una app AR urbana convencional. Para cada una, propone cómo probarla y qué criterio de aceptación definiría.

**1. Barrera:** Escasa experiencia de los técnicos rurales con dispositivos de realidad virtual.

- **Cómo probarla:** Realizar pruebas con usuarios sin experiencia previa utilizando únicamente el tutorial del sistema.
- **Criterio de aceptación:** El usuario debe iniciar y completar la simulación sin ayuda externa.

**2. Barrera:** Fatiga visual o mareos ocasionados por el uso prolongado del headset VR.

- **Cómo probarla:** Ejecutar sesiones continuas de aproximadamente 30 minutos y registrar posibles molestias físicas.
- **Criterio de aceptación:** La mayoría de usuarios debe completar la sesión sin síntomas que impidan continuar el entrenamiento.

**3. Barrera:** Conectividad limitada en zonas rurales.

- **Cómo probarla:** Ejecutar toda la aplicación sin conexión a Internet y sincronizar los datos cuando exista conectividad.
- **Criterio de aceptación:** Todas las funciones principales deben funcionar en modo offline y sincronizar correctamente la información cuando la conexión esté disponible.

---

**Parte D.3 — Reflexión sobre perseverancia (10 min):**

El escenario describe un sistema de salud real — si falla en producción, puede haber consecuencias en vidas humanas. Responde:

- **¿Cómo cambia la definición de "suficientemente probado" cuando el contexto es salud vs. un juego casual?**

  En un sistema de salud, "suficientemente probado" significa que todas las funciones críticas han sido verificadas exhaustivamente y que el riesgo de error es mínimo, ya que cualquier fallo puede afectar la capacitación del personal y, posteriormente, la atención de pacientes reales. En un juego casual, un error generalmente solo afecta la experiencia del usuario y no pone en riesgo vidas humanas.

- **¿Qué rol juega la perseverancia en el proceso de pruebas cuando el costo del error es alto?**

  La perseverancia permite repetir las pruebas tantas veces como sea necesario, validar diferentes escenarios, documentar todos los errores encontrados y comprobar que las correcciones realmente solucionen el problema sin introducir nuevos fallos. Cuando el costo del error es alto, no es suficiente probar una sola vez; es necesario garantizar la máxima confiabilidad posible.

- **Describe una situación concreta (real o hipotética) donde abandonar las pruebas antes de tiempo podría tener consecuencias irreversibles en este sistema.**

  Una situación hipotética sería que la simulación enseñe de forma incorrecta el procedimiento para atender una hemorragia posparto y ese error no sea detectado porque el equipo decidió finalizar las pruebas antes de tiempo. Un técnico podría aprender un procedimiento equivocado y aplicarlo posteriormente durante una emergencia real en una zona rural sin acceso inmediato a un médico especialista. Esto podría retrasar la atención adecuada y poner en riesgo la vida de la madre y del recién nacido.

*(Respuesta mínima esperada: 20 líneas combinadas entre D.1 + D.2 + D.3)*

---

## RÚBRICA DE AUTOEVALUACIÓN

Antes de entregar, revisa tu trabajo con esta escala:

| Criterio | 0 — No logrado | 1 — Parcialmente | 2 — Logrado |
|----------|----------------|------------------|-------------|
| Sección A: conceptos claros y sin contradicción | < 6 correctas | 6-8 correctas | 9-10 correctas |
| Sección B.1: términos técnicos precisos | < 4 correctos | 4-6 correctos | 7-8 correctos |
| Sección B.2: todos los emparejamientos correctos | < 6 pares | 6-8 pares | 9-10 pares |
| Sección C.1: 4 deficiencias identificadas y justificadas | 1-2 identificadas | 3 identificadas | 4 identificadas con justificación |
| Sección C.2: bugs identificados con causa y corrección | 1-2 bugs | 3 bugs | 4 bugs con código corregido |
| Sección C.3: priorización justificada con contexto | Lista sin justificación | Parcialmente justificada | Justificación con criterios de impacto |
| Sección D: integración coherente de conocimientos S11-S14 | Solo enumera conceptos | Aplica conceptos aislados | Integra y argumenta con coherencia |

**Puntaje máximo: 14 puntos**

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 14 | 2026-1*
