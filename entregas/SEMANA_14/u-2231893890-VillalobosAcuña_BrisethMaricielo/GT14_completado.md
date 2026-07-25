# S14 — GUÍA DE TRABAJO ESTUDIANTIL
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 14 — Pruebas y Validación de Experiencias XR
---

**Curso:** Realidad Virtual y Aumentada  
**Laboratorio:** Semana 14 
**Estudiante:** Villalobos Acuña Briseth Maricielo **Código:** 2231893890
**Fecha:** 18/07/2026 | **Puntuación total:** ____/20

---
---
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

**Pregunta 1.**
¿Cuál es la diferencia entre "testing" (pruebas) y "debugging" (depuración)?

a) Son sinónimos — ambos términos se refieren a encontrar errores en el código.

**b) El testing detecta la existencia de defectos; el debugging localiza y corrige la causa raíz de defectos ya conocidos.**

c) El testing es manual; el debugging es automático.

d) El testing ocurre antes del desarrollo; el debugging ocurre durante el desarrollo.

---

**Pregunta 2.**
Un desarrollador encuentra que su app AR tiene 30 FPS en el editor Unity pero solo 18 FPS en el dispositivo Android físico. ¿Cuál es el primer paso lógico para diagnosticar esta diferencia?

a) Cambiar el target platform a iOS y ver si mejora.

b) Desactivar ARCore en el proyecto porque consume demasiado.

**c) Conectar el dispositivo Android al Profiler de Unity y capturar datos de CPU/GPU en el dispositivo real.**

d) Reinstalar Unity en el dispositivo Android.

---

**Pregunta 3.**
En Unity Test Runner, ¿cuál es la diferencia entre un test de "Edit Mode" y uno de "Play Mode"?

a) Edit Mode funciona solo en Windows; Play Mode funciona en todas las plataformas.

**b) Edit Mode prueba la lógica de scripts sin iniciar el ciclo de juego de Unity; Play Mode prueba con el ciclo completo (Start, Update, etc.) activo.**

c) Edit Mode es más lento porque requiere compilar; Play Mode es más rápido porque usa caché.

d) No hay diferencia funcional — son alias del mismo tipo de test en Unity.

---

**Pregunta 4.**
¿Cuál de los siguientes es un ejemplo de bug con severidad "cosmética" pero prioridad P1?

a) La app crashea al iniciar — día antes de la presentación final.

b) La detección de planos no funciona en superficies oscuras — se reporta 3 meses antes del lanzamiento.

**c) El logo de la empresa en la pantalla de inicio muestra la versión antigua — demo con el cliente mañana.**

d) El texto de ayuda tiene un error de ortografía — versión 1.0 recién publicada.

---

**Pregunta 5.**
¿Qué es una "prueba de regresión" y cuándo se ejecuta?

a) Es una prueba que verifica que el hardware del dispositivo es compatible con la app; se ejecuta al inicio del proyecto.

**b) Es una prueba que re-ejecuta casos previamente aprobados para verificar que las correcciones de bugs no rompieron funcionalidades existentes; se ejecuta después de cada corrección.**

c) Es una prueba de rendimiento bajo condiciones extremas de carga; se ejecuta antes del lanzamiento.

d) Es una prueba que verifica la accesibilidad del producto; se ejecuta una vez al final del proyecto.

---

**Pregunta 6.**
Un equipo de desarrollo usa la convención de Conventional Commits y escribe el mensaje:
`fix(ar-placement): prevenir NullReferenceException en gestos sin plano — BUG-012`

¿Cuál de los siguientes beneficios NO proporciona directamente el ID de bug en el mensaje de commit?

a) Permite buscar exactamente qué cambio de código corrigió el bug con `git log --grep="BUG-012"`.

b) Permite que GitHub/GitLab cierre automáticamente el issue relacionado al hacer merge.

c) Permite al reviewer del PR verificar que el cambio corresponde a lo descrito en el bug report.

**d) Impide que el mismo bug pueda ser reportado nuevamente por otro tester.**

---

**Pregunta 7.**
¿Por qué el protocolo Think-Aloud es especialmente valioso para pruebas de usabilidad en XR comparado con una app de escritorio convencional?

a) Porque en XR el evaluador no puede ver la pantalla del usuario, entonces necesita escuchar lo que dice.

**b) Porque en XR las interacciones son gestos y movimientos físicos difíciles de registrar solo con clickstream — la verbalización revela en tiempo real dónde el usuario se confunde en el espacio 3D.**

c) Porque en XR el software no tiene logs de error, entonces la voz del usuario es la única fuente de datos.

d) Porque en XR todos los usuarios son principiantes y necesitan ser guiados durante la prueba.

---

**Pregunta 8.**
Un caso de prueba para AR tiene la siguiente precondición: "Superficie plana horizontal, texturizada, iluminación 300-600 lux". Dos testers ejecutan el mismo caso: uno sobre una mesa de madera (PASA), otro sobre un espejo horizontal (FALLA). ¿Cuál es la conclusión correcta?

a) Hay un bug en el código de ARCore que debe reportarse a Google.

b) El caso de prueba está mal diseñado porque los resultados son inconsistentes.

**c) No hay un bug — la diferencia de resultado se explica por la precondición (el espejo no es superficie texturizada). El caso está bien diseñado para superficies texturizadas; se necesita un caso separado para superficies reflectantes.**

d) Los dos testers deben repetir la prueba simultáneamente para determinar cuál resultado es correcto.

---

**Pregunta 9.**
¿Cuál de los siguientes describe mejor el rol de ARCore en relación con las pruebas de rendimiento en Android?

**a) ARCore consume recursos adicionales de CPU para el análisis de la cámara, lo que puede reducir los FPS disponibles para la lógica del juego y los shaders Unity.**

b) ARCore optimiza automáticamente el rendimiento del GPU y garantiza 60 FPS en todos los dispositivos certificados.

c) ARCore solo consume recursos cuando hay planos detectados; si no hay planos, el consumo de CPU es cero.

d) ARCore funciona en el GPU exclusivamente y no afecta el rendimiento de los scripts de Unity que corren en CPU.

---

**Pregunta 10.**
¿Cuál es el propósito de incluir un campo "Reproducibilidad" (ej: "10/10 intentos") en un bug report?

a) Indicar al desarrollador cuántas líneas de código están afectadas por el bug.

**b) Comunicar la probabilidad de que el bug ocurra bajo las mismas condiciones, lo que ayuda a priorizar y a verificar que la corrección fue exitosa.**

c) Limitar al tester a reportar solo bugs que ocurren siempre (10/10) y descartar los intermitentes.

d) Calcular automáticamente la prioridad del bug dividiendo 10 entre el número de intentos fallidos.

---

## SECCIÓN B — COMPRENSIÓN TÉCNICA (20 min)

### B.1 — Completar espacios en blanco

Completa los espacios con el término técnico correcto.

1. En Unity, el framework de pruebas integrado se llama **Unity Test Runner** y se accede desde el menú **Window**  → General → **Test Runner**.

2. El tipo de test que verifica la lógica de un script sin necesitar que Unity esté en Play Mode se llama test de **Edit** Mode.

3. En NUnit (el framework usado por Unity Test Runner), el atributo que marca un método como un test es **`[Test]` (o `[UnityTest]`)**, y el método que se ejecuta antes de cada test individual para preparar el estado inicial se marca con **`[SetUp]`**.

4. La métrica de rendimiento que mide cuántos objetos Unity envía al GPU para renderizar en cada frame se llama **Draw Calls (o Batches)** y en proyectos AR móvil debe mantenerse por debajo de **150** para un rendimiento aceptable.

5. Cuando la causa de bajo FPS está en el GPU (renderizado de malla, shaders) se llama condición **GPU** bound; cuando está en el CPU (scripts, física, IA) se llama condición **CPU** bound.

6. En el ciclo de vida de un bug en un sistema de tracking, después de que el developer corrige el bug y hace commit, el estado del bug cambia de "Corregido" a "**Ready for Test**" (o Listo para Re-testeo) hasta que el tester re-ejecuta el caso de prueba original.

7. El protocolo de pruebas de usabilidad en el que el usuario verbaliza sus pensamientos mientras usa el producto se llama protocolo **Think-Aloud** (o Pensamiento en Voz Alta).

8. Una prueba que re-ejecuta todos los casos de prueba aprobados anteriormente después de una corrección se llama prueba de **regresión**.

---

### B.2 — Emparejar columnas

Empareja cada término (columna izquierda) con su definición correcta (columna derecha).

| # | Término | Match | Definición |
|---|---------|:-----:|------------|
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

1. **F** — Justificación: *ARPlaneManager requiere del ciclo de vida activo de Unity y de subsistemas nativos de tracking de cámara simulados o reales, los cuales solo se ejecutan en Play Mode o cargando escenas en dispositivo.*

2. **V** — Justificación: *Un error crítico (como un crash instantáneo) en una escena obsoleta o deshabilitada a la que el usuario ya no puede acceder por interfaz tendrá prioridad P4 al no afectar el negocio.*

3. **F** — Justificación: *El "Happy Path" representa el camino de ejecución ideal del usuario sin considerar excepciones, errores del sistema o entradas alternativas, por lo que no es una suite completa.*

4. **F** — Justificación: *El tracking visual y de SLAM de ARCore depende de variaciones ópticas de contraste (puntos característicos) para calcular la profundidad, por lo que las superficies perfectamente uniformes son invisibles para sus algoritmos.*

5. **F** — Justificación: *El evaluador debe mantener un rol estrictamente observador y no intervencionista, limitándose a motivar al usuario a verbalizar sin resolverle los problemas.*

6. **V** — Justificación: *Los tests unitarios se ejecutan de manera aislada en memoria en milisegundos, siendo la forma más rápida y de menor costo técnico para validar la lógica del software.*

---

## SECCIÓN C — ANÁLISIS Y APLICACIÓN (25 min)

### C.1 — Diagnóstico de plan de pruebas con deficiencias

Lee el siguiente plan de pruebas creado por un estudiante para su proyecto AR y responde las preguntas.

```
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

a) Identifica **4 deficiencias específicas** en este plan de pruebas. Para cada una, nombra el elemento que falta y explica por qué es importante.

1. **Falta de Pasos de Ejecución (Metodología):** Los casos son meras declaraciones de intenciones sin acciones replicables. Es crucial para que cualquier tester (y no solo el creador) pueda seguir exactamente la misma secuencia de interacciones.
2. **Ausencia de Resultados Esperados Claros y Medibles:** Decir "probar que funcione" o "que se vea bien" es altamente subjetivo. Se requiere definir el criterio técnico exacto que determina el éxito (ej. "el modelo 3D de la planta se renderiza sin errores en el plano detectado").
3. **Falta de Especificación del Entorno de Pruebas (Precondiciones):** No define versión de SO, hardware móvil soportado ni condiciones físicas de luz o superficie indispensables para la estabilidad espacial de la AR.
4. **Falta de Atómica de Casos (Ambigüedad):** Casos como "Probar que no crashee" son globales. Deben desglosarse en pruebas específicas por módulo crítico, pues un crash puede ocurrir por decenas de variables de sistema diferentes.

---

b) Reescribe el **caso de prueba 1** ("Probar que la planta aparezca") en formato profesional con todos los campos necesarios: ID, módulo, prioridad, precondiciones, pasos numerados, resultado esperado y estado inicial.

* **ID:** CP-AR-001
* **Módulo:** Colocación de Objetos en Escena (Instantiation)
* **Prioridad:** Alta (P1)
* **Estado Inicial:** App abierta en la interfaz de escaneo, sin modelos en escena.
* **Precondiciones:**
  1. Dispositivo Android compatible con ARCore con permisos de cámara concedidos.
  2. Área de prueba iluminada (mínimo 300 lux) con superficie horizontal texturizada visible.
* **Pasos numerados:**
  1. Apuntar la cámara del dispositivo móvil hacia la superficie plana y mover el celular en círculos sutiles.
  2. Confirmar la visualización visual de la retícula de plano de ARCore en pantalla.
  3. Realizar un toque rápido (Tap) con el dedo en el centro de la retícula del plano detectado.
* **Resultado esperado:**
  El prefab de la planta se instancia en la posición del tap, escalado a dimensiones realistas de maceta de escritorio (0.15 m de diámetro), alineado con la normal del plano detectado, permaneciendo anclado espacialmente al mover el celular alrededor de él.

---

c) El plan dice "esperamos que todo funcione" — ¿qué problema revela esta frase sobre el enfoque del equipo hacia las pruebas? ¿Qué debería decir en su lugar?

* **Problema:** Revela un **sesgo de confirmación** perjudicial para QA. El diseño de pruebas no busca "validar que el software es perfecto" sino, por el contrario, intentar activamente corromper o estresar el sistema para encontrar sus fallas antes que el cliente final. Tener expectativas optimistas mitiga el rigor evaluativo.
* **Corrección sugerida:** *"Nuestra meta es estresar y validar el sistema bajo escenarios diversos y desfavorables para identificar de forma proactiva problemas de tracking, de caídas de FPS o de oclusiones que pongan en riesgo la experiencia de usuario."*

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

* **Línea exacta:** Línea 18: `Vector3 posicion = hits[0].pose.position;`
* **Excepción:** `ArgumentOutOfRangeException` (o `IndexOutOfRangeException`).
* **Escenario real:** Sucede cuando el usuario hace un toque en un área de la pantalla donde ARCore todavía no ha detectado un plano (la lista `hits` se devuelve vacía con longitud cero, y el código intenta acceder al índice `[0]`).
* **Código corregido:**
```csharp
public void AlTapEnPantalla(Vector2 posicionToque)
{
    hits.Clear(); // Limpiamos la lista para evitar datos de frames anteriores
    if (raycastManager.Raycast(posicionToque, hits, TrackableType.PlaneWithinPolygon))
    {
        if (hits.Count > 0)
        {
            Vector3 posicion = hits[0].pose.position;
            Instantiate(prefabObjeto, posicion, hits[0].pose.rotation);
            contadorObjetos++;
        }
    }
}
```

b) Para el **Bug B**: `Destroy(obj)` aplicado a TODOS los GameObjects de la escena es un problema grave. Explica por qué causaría un comportamiento incorrecto y cómo debería corregirse correctamente (sin destruir la cámara, el ARSession y otros objetos del sistema).

* Causa de comportamiento incorrecto: Destruye componentes de soporte medulares del entorno Unity y de AR Foundation como el AR Session, la AR Camera, el canvas del UI, las luces direccionales de la escena e incluso el script GestorColocacionAR en ejecución, dejando el sistema en un estado de pantalla negra irrecuperable.

* **Código corregido:**

``` csharp
// Añadimos una lista interna para rastrear únicamente las plantas creadas
private List<GameObject> objetosCreados = new List<GameObject>();

public void AlTapEnPantalla(Vector2 posicionToque)
{
    hits.Clear();
    if (raycastManager.Raycast(posicionToque, hits, TrackableType.PlaneWithinPolygon))
    {
        if (hits.Count > 0)
        {
            Vector3 posicion = hits[0].pose.position;
            GameObject nuevoObjeto = Instantiate(prefabObjeto, posicion, hits[0].pose.rotation);
            objetosCreados.Add(nuevoObjeto); // Guardamos la referencia directa
            contadorObjetos++;
        }
    }
}

public void ResetearEscena()
{
    foreach (GameObject obj in objetosCreados)
    {
        if (obj != null)
        {
            Destroy(obj);
        }
    }
    objetosCreados.Clear();
    contadorObjetos = 0;
}

```

c) Para el **Bug C**: El método `CambiarColorAccesibilidad()` puede lanzar una NullReferenceException. ¿Cuándo ocurriría esto? Escribe la versión corregida.

* Escenario de ocurrencia: Cuando la variable de referencia pública colorManager no ha sido asignada y arrastrada desde el Inspector de Unity hacia el componente.

* **Código corregido:**

``` Csharp
public void CambiarColorAccesibilidad()
{
    if (colorManager != null)
    {
        colorManager.SiguienteModo();
    }
    else
    {
        Debug.LogWarning("GestorColocacionAR: La variable 'colorManager' no se encuentra asignada en el Inspector.");
    }
}
```

d) Para el **Bug D**: El método de Unity `Debug.Log()` en Update() tiene un problema de rendimiento específico. ¿Qué es? ¿Cómo se corrige? ¿Cómo clasificarías la severidad de este bug?

* **Problema de rendimiento:** Llamar a Debug.Log() en el bucle Update genera una reserva constante de memoria por conversión de texto que obliga al Garbage Collector de Unity a correr continuamente, además de saturar la escritura en los logs del sistema. En móviles, esto genera un cuello de botella grave de CPU que causa caídas drásticas de FPS.

* Severidad: Media (Rendimiento). No rompe la lógica de manera dura, pero degrada gravemente la usabilidad.

* **Código corregido:**
```charp
private bool avisoMaximoMostrado = false;

void Update()
{
    if (contadorObjetos > 10)
    {
        if (!avisoMaximoMostrado)
        {
            Debug.Log("Máximo de objetos alcanzado");
            avisoMaximoMostrado = true; // Imprime solo una vez cuando se cruza el umbral
        }
    }
    else
    {
        avisoMaximoMostrado = false; // Reinicia si el contador de objetos vuelve a bajar
    }
}
```

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

**a) El tiempo disponible es 6 horas. Selecciona qué bugs corregir, ordénalos por prioridad y justifica cada decisión en 2-3 oraciones. Ten en cuenta el contexto del usuario (colegios rurales, MINEDU) y el tiempo de la presentación.**

| Orden | Bug ID | Severidad | Tiempo | Justificación |
|:---:|---|---|---|---|
| **1** | **BUG-C** | CRÍTICO | 3.0 h | Si la app falla inmediatamente en dispositivos Android modernos al iniciar, no habrá demo. Garantizar el inicio del aplicativo ante el MINEDU es el prerrequisito para mostrar todo lo demás. |
| **2** | **BUG-A** | MAYOR | 1.0 h | El valor visual de la simulación educativa de Machu Picchu es central para capturar la atención pedagógica del Ministerio. Mostrarlo de color negro arruinaría el impacto educativo clave. |
| **3** | **BUG-D** | MAYOR | 0.5 h | Al ser colegios rurales de Cusco, la legibilidad del material inclusivo en quechua es fundamental y será altamente vigilada a nivel pedagógico y de inclusión del MINEDU. |
| **4** | **BUG-E** | COSMÉTICO | 0.25 h| Los errores ortográficos en los íconos de la aplicación proyectan de forma inmediata una falta de rigor académico inaceptable para una presentación ante autoridades del Sector de Educación. |

*   **Total de tiempo consumido:** 4.75 horas.
*   *Nota de mitigación:* El tiempo restante (1.25 horas) se mantiene como buffer de estabilidad general para imprevistos técnicos durante la demo. Los bugs restantes (B, F, G) se manejarán de forma operativa (por ejemplo, asegurándonos de que la mesa de demostración física esté perfectamente nivelada para evitar el BUG-G).

---

**b) Para los bugs que NO corregirás antes de la presentación: ¿cómo los comunicarías al cliente (MINEDU) de manera profesional? Escribe un párrafo de 4-5 oraciones.**

> *"Estimado equipo evaluador del MINEDU, para esta versión demostrativa hemos priorizado la compatibilidad estructural y de rendimiento en múltiples versiones de Android, así como el acceso prioritario al doblaje inclusivo en quechua. Por ello, la presente entrega preliminar requiere que las láminas educativas de interacción se sostengan sobre planos horizontales bien iluminados para un correcto anclaje tridimensional. De manera paralela, funcionalidades ergonómicas de animación en transiciones espaciales y la suite de accesibilidad de alto contraste por daltonismo se encuentran en sus fases de validación técnica, y serán desplegadas de forma nativa en la subsiguiente compilación de producción planificada."*

---

**c) BUG-G dice "sin mensaje de error al usuario". ¿Por qué es importante mostrar mensajes de error claros cuando el tracking falla en AR? Relaciona tu respuesta con los principios de accesibilidad cognitiva vistos en S13.**

En la realidad aumentada, la estabilidad visual depende enteramente del entorno físico del usuario. Si el tracking óptico falla y la app simplemente se congela o desvanece los elementos sin avisar, el usuario experimenta frustración al no comprender si la app falló, si el dispositivo se sobrecalentó o si rompió el software, aumentando drásticamente su carga cognitiva. Desde la perspectiva de la accesibilidad cognitiva, los sistemas deben ser predecibles y dar retroalimentación constante de su estado; alertar al usuario con instrucciones de acción claras (ej. *"Superficie curva detectada: por favor endereza la hoja del libro para continuar"*), le dota de control sobre su entorno interactivo reduciendo la fricción tecnológica.

---

## SECCIÓN D — SÍNTESIS Y REFLEXIÓN (25 min)

### Caso integrador: Sistema XR de Telesalud Rural en Perú

**Contexto:**

El Ministerio de Salud (MINSA) ha financiado el desarrollo de un sistema de VR para capacitación de técnicos de salud rurales en el manejo de emergencias obstétricas en zonas sin acceso a médicos especialistas (Puno, Loreto, Madre de Dios). El sistema funciona con headset VR (HTC Vive Focus 3) y simula el procedimiento de atención de un parto con complicaciones. Los técnicos practican el procedimiento en VR hasta dominarlo antes de atender casos reales.

El equipo entrega la versión beta y tú eres el responsable de validación. Tienes 2 semanas antes del primer despliegue piloto en 15 puestos de salud.

**Tarea (respuesta libre estructurada):**

#### Parte D.1 — Plan de pruebas (10 min):

##### 1. Tipos de Pruebas Críticas en Contexto de Salud Rural
*   **Pruebas de Usabilidad Física / Tolerancia al Mareo (Cinetosis):** Dado que los técnicos pueden utilizar el HTC Vive Focus 3 en sesiones prolongadas de simulación obstétrica, verificar que el framerate constante evite la fatiga ocular y náuseas físicas es prioritario.
*   **Pruebas de Funcionalidad Clínica (Fidelidad del Procedimiento):** Validar de forma exhaustiva que cada secuencia del parto simulado responda con total rigor científico a los protocolos internacionales de emergencias del MINSA.
*   **Pruebas de Tolerancia Offline / Resiliencia de Red:** Probar el comportamiento de la app aislando por completo la conectividad a internet para garantizar que no se congelen las simulaciones de capacitación en zonas andinas o amazónicas sin red celular.

##### 2. Casos de Prueba Estructurados

| ID | Módulo | Precondiciones | Pasos de Prueba | Resultado Esperado |
|---|---|---|---|---|
| **CP-VR-001** | Inicialización / Calibración | Visor encendido; guardián físico de escala de habitación configurado a nivel de suelo real. | 1. Lanzar el software de telesalud.<br>2. Pararse frente a la camilla de parto virtual.<br>3. Observar la altura relativa del usuario respecto al modelo 3D. | El plano de la camilla médica de emergencia se alinea horizontalmente a la altura física de la cadera del técnico (85 cm aprox.), evitando fatiga lumbar excesiva. |
| **CP-VR-002** | Interacción Háptica (Mandos) | Escena de atención activa cargada; mandos calibrados al 100% de batería. | 1. Acercar el mando derecho a la pinza umbilical.<br>2. Presionar y sostener el gatillo (Grip).<br>3. Mover la pinza hacia el cordón del neonato virtual. | Al aproximar la pinza a menos de 5 cm de la zona activa, se resalta la retícula de acople y la pinza se bloquea visualmente (snapping) al soltar el gatillo. |
| **CP-VR-003** | Simulación de Escenario Crítico | Fase de alumbramiento uterino iniciada de forma simulada. | 1. No aplicar el masaje uterino externo durante los primeros 60 segundos posteriores a la salida de placenta.<br>2. Monitorear los indicadores de constantes vitales. | El monitor virtual inicia alarmas sonoras y visuales, el flujo de sangrado se intensifica y la presión de la paciente decae bajo los 90/60 mmHg. |
| **CP-VR-004** | Persistencia y Conectividad | Visor configurado en modo avión (sin señal de internet Wi-Fi/móvil). | 1. Abrir la app.<br>2. Seleccionar el módulo de capacitación de parto.<br>3. Guardar el progreso al terminar la sesión interactiva. | La aplicación carga los recursos locales sin bucles de carga infinitos, almacenando de forma segura los reportes de rendimiento localmente para su sincronización posterior. |
| **CP-VR-005** | Recalibración Rápida | Escena interactiva cargada; usuario desorientado espacialmente por desplazarse físicamente. | 1. Sostener presionado el botón "Home/Menú" del mando derecho por 3 segundos consecutivos. | La escena virtual completa y la camilla se re-centran y alinean de manera instantánea respecto a la nueva dirección física de la cabeza del usuario. |

##### 3. Criterios de Aceptación Mínimos para Despliegue
*   **Cero Desviaciones de Protocolo Clínico:** La secuencia del parto virtual debe concordar al 100% con los estándares médicos autorizados por el MINSA.
*   **Framerate Mínimo Estricto:** Mantener un rendimiento de 75 FPS o superior de forma sostenida en el HTC Vive Focus 3 standalone durante toda la simulación de 30 minutos.
*   **Tolerancia a Apagados de Energía:** La base de datos local no debe corromperse bajo cortes abruptos de alimentación del dispositivo a mitad del proceso de simulación.

##### 4. Protocolo de Decisión ante un Bug Crítico (T - 24 horas)
1. **Evaluación de Daño (Triage):** Si el bug produce mareos (caídas severas de FPS) o rompe la secuencia médica del parto, se clasifica como de impacto humano.
2. **Ciclo de Mitigación de Emergencia:** Se otorga una ventana máxima de 4 horas al equipo técnico para corregir el código.
3. **Decisión Final de Despliegue:** Si la corrección falla o el parche arriesga la estabilidad del resto de las simulaciones, **se pospone formalmente el despliegue piloto**. Desplegar software inestable en salud pública daña irreversiblemente la confianza de los técnicos locales y del MINSA en la tecnología XR.

---

#### Parte D.2 — Pruebas de accesibilidad críticas (5 min):

1. **Limitaciones Ergonómicas por Indumentaria y Rasgos Interculturales:**
   *   *Prueba:* Evaluar el ajuste físico de la montura del HTC Vive Focus 3 con técnicos locales que utilicen de forma cotidiana sombreros de ala ancha, mantas de abrigo, chullos andinos tradicionales, o cabellos recogidos específicos.
   *   *Criterio de Aceptación:* El dispositivo de VR debe permitir un acople óptico hermético sin forzar la remoción de prendas de identidad cultural de los usuarios evaluados.
2. **Brecha de Alfabetización Digital Compleja:**
   *   *Prueba:* Evaluar el tutorial del sistema de interacción espacial con técnicos rurales que no posean experiencia previa en videojuegos o sistemas informáticos 3D complejos.
   *   *Criterio de Aceptación:* El 90% de los técnicos debe lograr el agarre intuitivo de los materiales y la navegación autónoma de menús en menos de 10 minutos de autoevaluación guiada por el propio software.
3. **Factores Climáticos y Altitud (Cuidado del Hardware en Regiones de Helada o Selva Alta):**
   *   *Prueba:* Exponer el sistema de visor en simulación en habitaciones con temperaturas extremas (bajo los 5°C o sobre los 35°C con alta humedad).
   *   *Criterio de Aceptación:* El empañamiento de las lentes internas y el sensor óptico exterior debe mitigarse mediante alertas de software internas o instrucciones específicas de calentamiento de equipo sin alterar el tracking de las manos.

---

#### Parte D.3 — Reflexión sobre perseverancia (10 min):

*   **¿Cómo cambia la definición de "suficientemente probado" cuando el contexto es salud vs. un juego casual?**
    En un videojuego, una física defectuosa o una textura ausente representa simplemente una molestia o una pérdida económica marginal para el estudio. En la simulación de salud pública rural, el software es una herramienta de capacitación crítica para salvar vidas. "Suficientemente probado" aquí exige la confirmación científica de que los patrones de comportamiento virtual asimilados por el profesional de salud son clínicamente correctos e inducen a la memoria motora precisa que ejecutarán en pacientes humanas en la vida real.
*   **¿Qué rol juega la perseverancia en el proceso de pruebas cuando el costo del error es alto?**
    La perseverancia del equipo de QA es el principal blindaje ético del proyecto. Cuando el error puede desencadenar consecuencias mortales en una comunidad remota de Puno o Loreto, el tester no puede cansarse ni ceder ante presiones comerciales o administrativas para acelerar los plazos. Implica mantener un escepticismo técnico incansable, documentando y forzando situaciones límite (edge cases) hasta garantizar que no existan puntos ciegos técnicos.
*   **Describe una situación concreta (real o hipotética) donde abandonar las pruebas antes de tiempo podría tener consecuencias irreversibles en este sistema.**
    Imaginemos que por fatiga, el equipo decide omitir las pruebas de calibración háptica fina del instrumental para la extracción manual de placenta retenida (una causa común de muerte materna en zonas rurales). Al no probar exhaustivamente los sensores, no se detecta un bug que valida de forma "correcta" un tirón brusco del cordón umbilical. Un técnico de salud rural asimila este mal hábito debido a que la simulación en VR le dio un puntaje aprobatorio. Meses después, en un puesto médico aislado en Madre de Dios, atiende un parto real con retención de placenta y aplica de forma instintiva la fuerza física incorrecta aprendida en VR. Esto provoca la ruptura del cordón e inversión uterina, causando una hemorragia masiva incontrolable para el centro rural. La paciente fallece camino al hospital provincial. Haber acelerado u omitido esa fase final de QA en el simulador de VR se traduce directamente en la pérdida irreversible de una vida humana.

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