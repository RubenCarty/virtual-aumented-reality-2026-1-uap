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

**Pregunta 1.**
¿Cuál es la diferencia entre "testing" (pruebas) y "debugging" (depuración)?

a) Son sinónimos — ambos términos se refieren a encontrar errores en el código.

b) El testing detecta la existencia de defectos; el debugging localiza y corrige la causa raíz de defectos ya conocidos.

c) El testing es manual; el debugging es automático.

d) El testing ocurre antes del desarrollo; el debugging ocurre durante el desarrollo.

- Rpta: b)
---

**Pregunta 2.**
Un desarrollador encuentra que su app AR tiene 30 FPS en el editor Unity pero solo 18 FPS en el dispositivo Android físico. ¿Cuál es el primer paso lógico para diagnosticar esta diferencia?

a) Cambiar el target platform a iOS y ver si mejora.

b) Desactivar ARCore en el proyecto porque consume demasiado.

c) Conectar el dispositivo Android al Profiler de Unity y capturar datos de CPU/GPU en el dispositivo real.

d) Reinstalar Unity en el dispositivo Android.

Rpta: c)
---

**Pregunta 3.**
En Unity Test Runner, ¿cuál es la diferencia entre un test de "Edit Mode" y uno de "Play Mode"?

a) Edit Mode funciona solo en Windows; Play Mode funciona en todas las plataformas.

b) Edit Mode prueba la lógica de scripts sin iniciar el ciclo de juego de Unity; Play Mode prueba con el ciclo completo (Start, Update, etc.) activo.

c) Edit Mode es más lento porque requiere compilar; Play Mode es más rápido porque usa caché.

d) No hay diferencia funcional — son alias del mismo tipo de test en Unity.

Rpta: b)
---

**Pregunta 4.**
¿Cuál de los siguientes es un ejemplo de bug con severidad "cosmética" pero prioridad P1?

a) La app crashea al iniciar — día antes de la presentación final.

b) La detección de planos no funciona en superficies oscuras — se reporta 3 meses antes del lanzamiento.

c) El logo de la empresa en la pantalla de inicio muestra la versión antigua — demo con el cliente mañana.

d) El texto de ayuda tiene un error de ortografía — versión 1.0 recién publicada.

Rpta: c)
---

**Pregunta 5.**
¿Qué es una "prueba de regresión" y cuándo se ejecuta?

a) Es una prueba que verifica que el hardware del dispositivo es compatible con la app; se ejecuta al inicio del proyecto.

b) Es una prueba que re-ejecuta casos previamente aprobados para verificar que las correcciones de bugs no rompieron funcionalidades existentes; se ejecuta después de cada corrección.

c) Es una prueba de rendimiento bajo condiciones extremas de carga; se ejecuta antes del lanzamiento.

d) Es una prueba que verifica la accesibilidad del producto; se ejecuta una vez al final del proyecto.

Rpta: b)
---

**Pregunta 6.**
Un equipo de desarrollo usa la convención de Conventional Commits y escribe el mensaje:
`fix(ar-placement): prevenir NullReferenceException en gestos sin plano — BUG-012`

¿Cuál de los siguientes beneficios NO proporciona directamente el ID de bug en el mensaje de commit?

a) Permite buscar exactamente qué cambio de código corrigió el bug con `git log --grep="BUG-012"`.

b) Permite que GitHub/GitLab cierre automáticamente el issue relacionado al hacer merge.

c) Permite al reviewer del PR verificar que el cambio corresponde a lo descrito en el bug report.

d) Impide que el mismo bug pueda ser reportado nuevamente por otro tester.

Rpta: d)
---

**Pregunta 7.**
¿Por qué el protocolo Think-Aloud es especialmente valioso para pruebas de usabilidad en XR comparado con una app de escritorio convencional?

a) Porque en XR el evaluador no puede ver la pantalla del usuario, entonces necesita escuchar lo que dice.

b) Porque en XR las interacciones son gestos y movimientos físicos difíciles de registrar solo con clickstream — la verbalización revela en tiempo real dónde el usuario se confunde en el espacio 3D.

c) Porque en XR el software no tiene logs de error, entonces la voz del usuario es la única fuente de datos.

d) Porque en XR todos los usuarios son principiantes y necesitan ser guiados durante la prueba.

Rpta: b)
---

**Pregunta 8.**
Un caso de prueba para AR tiene la siguiente precondición: "Superficie plana horizontal, texturizada, iluminación 300-600 lux". Dos testers ejecutan el mismo caso: uno sobre una mesa de madera (PASA), otro sobre un espejo horizontal (FALLA). ¿Cuál es la conclusión correcta?

a) Hay un bug en el código de ARCore que debe reportarse a Google.

b) El caso de prueba está mal diseñado porque los resultados son inconsistentes.

c) No hay un bug — la diferencia de resultado se explica por la precondición (el espejo no es superficie texturizada). El caso está bien diseñado para superficies texturizadas; se necesita un caso separado para superficies reflectantes.

d) Los dos testers deben repetir la prueba simultáneamente para determinar cuál resultado es correcto.

Rpta: c)
---

**Pregunta 9.**
¿Cuál de los siguientes describe mejor el rol de ARCore en relación con las pruebas de rendimiento en Android?

a) ARCore consume recursos adicionales de CPU para el análisis de la cámara, lo que puede reducir los FPS disponibles para la lógica del juego y los shaders Unity.

b) ARCore optimiza automáticamente el rendimiento del GPU y garantiza 60 FPS en todos los dispositivos certificados.

c) ARCore solo consume recursos cuando hay planos detectados; si no hay planos, el consumo de CPU es cero.

d) ARCore funciona en el GPU exclusivamente y no afecta el rendimiento de los scripts de Unity que corren en CPU.

Rpta: a)
---

**Pregunta 10.**
¿Cuál es el propósito de incluir un campo "Reproducibilidad" (ej: "10/10 intentos") en un bug report?

a) Indicar al desarrollador cuántas líneas de código están afectadas por el bug.

b) Comunicar la probabilidad de que el bug ocurra bajo las mismas condiciones, lo que ayuda a priorizar y a verificar que la corrección fue exitosa.

c) Limitar al tester a reportar solo bugs que ocurren siempre (10/10) y descartar los intermitentes.

d) Calcular automáticamente la prioridad del bug dividiendo 10 entre el número de intentos fallidos.

Rpta: b)
---

## SECCIÓN B — COMPRENSIÓN TÉCNICA (20 min)

### B.1 — Completar espacios en blanco

Completa los espacios con el término técnico correcto.

1. En Unity, el framework de pruebas integrado se llama _Unity Test Runner_ y se accede desde el menú _window_  → General → _test runner_.

2. El tipo de test que verifica la lógica de un script sin necesitar que Unity esté en Play Mode se llama test de _play_ Mode.

3. En NUnit (el framework usado por Unity Test Runner), el atributo que marca un método como un test es _[Test]_, y el método que se ejecuta antes de cada test individual para preparar el estado inicial se marca con _[SetUp]_.

4. La métrica de rendimiento que mide cuántos objetos Unity envía al GPU para renderizar en cada frame se llama _Batches o mejor conocidos como Draw Calls_ y en proyectos AR móvil debe mantenerse por debajo de _150-200_ para un rendimiento aceptable.

5. Cuando la causa de bajo FPS está en el GPU (renderizado de malla, shaders) se llama condición _GPU_ bound; cuando está en el CPU (scripts, física, IA) se llama condición _CPU_ bound.

6. En el ciclo de vida de un bug en un sistema de tracking, después de que el developer corrige el bug y hace commit, el estado del bug cambia de "Corregido" a "_Listo para pruebas_" hasta que el tester re-ejecuta el caso de prueba original.

7. El protocolo de pruebas de usabilidad en el que el usuario verbaliza sus pensamientos mientras usa el producto se llama protocolo _Think-Aloud_.

8. Una prueba que re-ejecuta todos los casos de prueba aprobados anteriormente después de una corrección se llama prueba de _regresión_.

---

### B.2 — Emparejar columnas

Empareja cada término (columna izquierda) con su definición correcta (columna derecha).

| # | Término | | Definición |
|---|---------|---|------------|
| 1 | Severidad | B | Impacto técnico de un bug en la funcionalidad del sistema |
| 2 | Prioridad | A | Urgencia con la que un bug debe ser corregido, según el contexto de negocio |
| 3 | Caso de prueba | F | Unidad atómica de prueba: pasos específicos + entrada + resultado esperado |
| 4 | Plan de pruebas | E | Documento que define qué se prueba, cómo, cuándo y quién, con su alcance |
| 5 | Unity Profiler | C | Herramienta de Unity que registra datos de CPU, GPU, memoria y audio frame por frame |
| 6 | Precondición | D | Condición del sistema que debe ser verdadera antes de ejecutar un caso de prueba |
| 7 | Test de regresión | H | Re-ejecución de casos de prueba ya aprobados para detectar nuevos defectos tras cambios |
| 8 | Unit test | G | Tipo de test que verifica funciones individuales de forma aislada sin dependencias externas |
| 9 | Think-Aloud | J | Protocolo de usabilidad donde el usuario verbaliza sus pensamientos en tiempo real |
| 10 | Integration test | I | Confirmación de que el sistema funciona correctamente con todas sus partes integradas |

---

### B.3 — Verdadero o Falso con justificación

Indica V (verdadero) o F (falso) y escribe UNA frase explicando por qué.

1. _F_ Un test unitario (Unit Test) en Edit Mode puede probar si ARPlaneManager detecta planos correctamente en tiempo real.

2. _V_ Es posible tener un bug con severidad CRÍTICA (la app crashea) y prioridad P4 (diferir indefinidamente).

3. _F_ En el contexto de pruebas XR, "Happy Path" se refiere a la suite de casos de prueba más completa que verifica todos los escenarios posibles.

4. _F_ ARCore puede detectar planos horizontales en superficies completamente uniformes sin textura visual (como una pared blanca lisa).

5. _F_ El protocolo Think-Aloud requiere que el evaluador intervenga y guíe al usuario cuando este se confunde, para que pueda completar las tareas.

6. _V_ En la "pirámide de pruebas", los tests unitarios (base de la pirámide) deberían ser los más numerosos porque son los más rápidos y baratos de ejecutar.

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

1. Falta de pasos de ejecución

Qué falta: Indicar los pasos exactos que debe seguir el tester.
Por qué importa: Sin una guía clara, cada persona prueba de forma distinta y pueden pasar desapercibidos algunos errores.

2. Resultados esperados poco claros

Qué falta: Definir cómo debe comportarse la aplicación si todo funciona bien.
Por qué importa: Sin un resultado esperado, es difícil saber si la prueba fue exitosa o falló.

3. Falta de una lista de dispositivos de prueba

Qué falta: Especificar qué celulares, sistemas operativos y versiones de AR se usarán.
Por qué importa: La aplicación puede funcionar diferente según el dispositivo.

4. Falta de precondiciones

Qué falta: Indicar las condiciones necesarias antes de iniciar la prueba, como buena iluminación, permisos de cámara y detección del plano.
Por qué importa: Así se evita que la prueba falle por el entorno y no por la aplicación.

b) Reescribe el **caso de prueba 1** ("Probar que la planta aparezca") en formato profesional con todos los campos necesarios: ID, módulo, prioridad, precondiciones, pasos numerados, resultado esperado y estado inicial.


| Campo | Contenido |
|-------|-----------|
| ID del Caso | CP-AR-001 |
| Módulo | Inicialización y Colocación de Objetos (Placement) |
| Prioridad | Alta (P1) |
| Precondiciones | Permiso de cámara concedido a la app. Entorno físico bien iluminado (>300 lux). Superficie plana horizontal texturizada (ej. mesa de madera) detectada por el dispositivo. |
| Estado Inicial | La aplicación se encuentra en la pantalla de escaneo activo con la retícula (indicator) visible sobre el plano. |
| Pasos de Ejecución | Tocar una sola vez la pantalla en el centro de la retícula colocada sobre el plano detectado. Retirar la mano de la pantalla. Mover físicamente el dispositivo ligeramente de izquierda a derecha para evaluar la oclusión espacial. |
| Resultado Esperado | El modelo 3D de la planta se instancia exactamente en la posición de la retícula. La planta debe mantenerse fija sobre el plano sin flotar, parpadear ni deslizarse de su posición original al mover la cámara. |


c) El plan dice "esperamos que todo funcione" — ¿qué problema revela esta frase sobre el enfoque del equipo hacia las pruebas? ¿Qué debería decir en su lugar?

- La frase "esperamos que todo funcione" revela un sesgo de confirmación. Este enfoque asume que las pruebas sirven únicamente para demostrar que el código es correcto, lo cual es el error filosófico más común en QA. Las pruebas deben diseñarse con una mentalidad destructiva: su objetivo es encontrar fallas, no validar que no las hay. > Qué debería decir en su lugar: "El objetivo de este ciclo de pruebas es identificar y documentar de manera sistemática los defectos de software y cuellos de botella de rendimiento en la interacción AR, garantizando la estabilidad de la build de cara a la versión final."

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
- Línea: 19: Vector3 posicion = hits[0].pose.position
- Excepción: ArgumentOutOfRangeException o IndexOutOfRangeException.
- Cuándo ocurrirá: Ocurrirá siempre que el usuario toque la pantalla pero el Raycast no colisione con ningún plano válido (la lista hits estará vacía y tendrá tamaño $0$, por lo que intentar acceder al índice [0] causará el crash).
- Versión corregida:

```csharp
public void AlTapEnPantalla(Vector2 posicionToque)
{
    // Verificamos si el raycast colisionó con algún plano antes de acceder a la lista
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

- Comportamiento incorrecto: Al usar GameObject.FindObjectsOfType<GameObject>(), el script recopilará absolutamente todos los objetos de la escena actual. Esto incluye la cámara principal, la luz direccional, los sistemas de tracking (AR Session, AR Session Origin), e incluso el propio objeto que tiene el script GestorColocacionAR. Destruir todo esto romperá por completo el ciclo de vida de la aplicación y la dejará inservible (pantalla negra o crash).
- Cómo corregirse: Se debe llevar un registro exclusivo de los objetos instanciados o utilizar una etiqueta (Tag) para eliminarlos selectivamente.

```csharp
// Solución correcta: Guardar referencias de los objetos creados
private List<GameObject> objetosInstanciados = new List<GameObject>();

public void AlTapEnPantalla(Vector2 posicionToque)
{
    if (raycastManager.Raycast(posicionToque, hits, TrackableType.PlaneWithinPolygon))
    {
        Vector3 posicion = hits[0].pose.position;
        GameObject nuevoObjeto = Instantiate(prefabObjeto, posicion, hits[0].pose.rotation);
        objetosInstanciados.Add(nuevoObjeto); // Guardamos la referencia
        contadorObjetos++;
    }
}

public void ResetearEscena()
{
    // Destruimos únicamente los objetos creados por el usuario
    foreach (GameObject obj in objetosInstanciados)
    {
        if (obj != null)
        {
            Destroy(obj);
        }
    }
    objetosInstanciados.Clear();
    contadorObjetos = 0;
}
```

c) Para el **Bug C**: El método `CambiarColorAccesibilidad()` puede lanzar una NullReferenceException. ¿Cuándo ocurriría esto? Escribe la versión corregida.

- Cuándo ocurriría: Ocurre si la variable pública colorManager no ha sido asignada manualmente arrastrando el componente correspondiente desde el Inspector de Unity antes de iniciar el juego.
- Versión corregida:

```csharp
public void CambiarColorAccesibilidad()
{
    if (colorManager != null)
    {
        colorManager.SiguienteModo();
    }
    else
    {
        Debug.LogWarning("colorManager no asignado en GestorColocacionAR.");
    }
}
```

d) Para el **Bug D**: El método de Unity `Debug.Log()` en Update() tiene un problema de rendimiento específico. ¿Qué es? ¿Cómo se corrige? ¿Cómo clasificarías la severidad de este bug?

- Problema de rendimiento: Llamar a Debug.Log() dentro de Update() hace que el mensaje se mande a la consola hasta 60 o 120 veces por segundo (una vez por frame) mientras contadorObjetos > 10. Esto genera una enorme cantidad de asignaciones de strings en memoria (basura que el Garbage Collector tendrá que limpiar, causando tirones de FPS) e inunda la consola de logs ralentizando el editor y los builds de desarrollo.
- Cómo se corrige: Controlando el evento para que el mensaje solo se imprima una vez cuando se cruza el límite.

```csharp
private bool limiteNotificado = false;

void Update()
{
    if (contadorObjetos > 10)
    {
        if (!limiteNotificado)
        {
            Debug.Log("Máximo de objetos alcanzado");
            limiteNotificado = true; // Evita que se repita en el próximo frame
        }
    }
    else
    {
        limiteNotificado = false; // Resetea si el contador baja de 10
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

a) El tiempo disponible es 6 horas. Selecciona qué bugs corregir, ordénalos por prioridad y justifica cada decisión en 2-3 oraciones. Ten en cuenta el contexto del usuario (colegios rurales, MINEDU) y el tiempo de la presentación.

| Orden | Bug ID | Justificación | Tiempo |
|-------|--------|---------------|--------|
|1|BUG-C (Crash inicio)|Crítico: Si la app crashea al iniciar en Android 13, no habrá presentación. Resolver esto garantiza que los evaluadores puedan ver el proyecto.|3.0 h|
|2|BUG-A (Machu Picchu negro)|Mayor: Machu Picchu es el modelo estrella de la presentación histórica. Verlo negro daría una pésima impresión técnica y estética ante el ministerio.|1.0 h|
|3|BUG-D (Subtítulos sin backing)|Mayor: Al ser para colegios rurales de Cusco, los textos en quechua son clave para la identidad local y el impacto pedagógico del proyecto del MINEDU.|0.5 h|
|4|BUG-E (Acento en icono)|Cosmético: Toma poquísimo tiempo resolverlo y previene una mala impresión de baja rigurosidad ortográfica ante una entidad educativa nacional.|0.25 h|
|5|BUG-G (Fallo tracking diagonal)|Menor (Parcial): Dedicaremos los 1.25 horas restantes a mitigar el problema del tracking o añadir un pequeño texto informativo que alerte al usuario sobre mantener el libro plano.|1.25 h|
|Total|--------|---------------|6.0 horas|

b) Para los bugs que NO corregirás antes de la presentación: ¿cómo los comunicarías al cliente (MINEDU) de manera profesional? Escribe un párrafo de 4-5 oraciones.

- "Como parte de nuestro compromiso con la transparencia y el estándar de calidad educativa, compartimos que el roadmap de desarrollo contempla un despliegue por fases. Para esta primera demostración técnica, nos hemos enfocado rigurosamente en la estabilidad del sistema, la fidelidad de los modelos históricos y la legibilidad de la lengua originaria quechua. Las funciones complementarias de accesibilidad avanzada para daltonismo y las transiciones cinemáticas de desvanecimiento espacial ya se encuentran completamente diseñadas en nuestro backlog técnico, y serán integradas en la fase final de despliegue de la versión 1.1 en las próximas semanas."

c) BUG-G dice "sin mensaje de error al usuario". ¿Por qué es importante mostrar mensajes de error claros cuando el tracking falla en AR? Relaciona tu respuesta con los principios de accesibilidad cognitiva vistos en S13.

- La Realidad Aumentada requiere que el usuario entienda la relación entre el espacio físico e invisible que la cámara analiza. Cuando el tracking falla sin dar explicaciones, se genera una falla de retroalimentación (feedback loop).
- Desde el punto de vista de la accesibilidad cognitiva, el usuario (especialmente niños en entornos rurales no familiarizados con la tecnología) no sabe si el software se trabó, si su teléfono se malogró o si hizo algo mal. Esto eleva la frustración y la carga cognitiva. Mostrar un mensaje sencillo como "Asegúrate de que el libro esté sobre una mesa plana y no esté doblado" devuelve el control al usuario, le permite corregir su acción físicamente, y reanuda el aprendizaje interactivo sin romper la inmersión de la experiencia.

---

## SECCIÓN D — SÍNTESIS Y REFLEXIÓN (25 min)

### Caso integrador: Sistema XR de Telesalud Rural en Perú

**Contexto:**

El Ministerio de Salud (MINSA) ha financiado el desarrollo de un sistema de VR para capacitación de técnicos de salud rurales en el manejo de emergencias obstétricas en zonas sin acceso a médicos especialistas (Puno, Loreto, Madre de Dios). El sistema funciona con headset VR (HTC Vive Focus 3) y simula el procedimiento de atención de un parto con complicaciones. Los técnicos practican el procedimiento en VR hasta dominarlo antes de atender casos reales.

El equipo entrega la versión beta y tú eres el responsable de validación. Tienes 2 semanas antes del primer despliegue piloto en 15 puestos de salud.

**Tarea (respuesta libre estructurada):**

**Parte D.1 — Plan de pruebas (10 min):**
Diseña el plan de pruebas para esta app de VR. Incluye:
- Al menos 3 tipos de prueba diferentes con justificación de por qué son críticos en este contexto
    - Rendimiento y Mareos (FPS): En VR, si el juego va lento (menos de $90$ FPS), la gente se marea y vomita. Hay que probar que vaya fluido sí o sí.
    - Modo Offline: En la selva o la sierra no hay internet. La app tiene que funcionar al 100% sin conexión a la red.
    - Pruebas de Calor (Estrés Térmico): Los visores se calientan rápido. Si vas a Puno o Loreto con calor/humedad, el visor no puede apagarse a mitad de un parto simulado.
- 5 casos de prueba en formato correcto (ID, precondiciones, pasos, resultado esperado)
    - CP-1 (Inicio): Ponerse el visor y calibrar el piso. Resultado: Que el piso virtual esté donde pisas y no salgas volando.
    - CP-2 (Masaje de útero): Tocar el útero de la paciente virtual con ambas manos. Resultado: Los mandos deben vibrar para que sientas que lo estás haciendo bien.
    - CP-3 (Corte de Wi-Fi): Desconectar el internet a mitad de la simulación. Resultado: La app sigue funcionando normal y guarda tu puntaje en el visor.
    - CP-4 (Prueba de calor): Usar la app por 90 minutos seguidos en un cuarto caliente. Resultado: La app no se traba ni se cierra sola.
    - CP-5 (Costura/Sutura): Agarrar la aguja virtual y coser. Resultado: El sistema debe detectar exactamente dónde cosiste y marcarlo en verde.
- Los criterios de aceptación mínimos para declarar el producto "listo para despliegue"
    - Cero bugs que congelen o cierren la app.
    - El juego corre fluido siempre (mínimo $85$ FPS).
    - La batería aguanta al menos 3 simulaciones seguidas (2 horas).
    - Funciona perfecto sin internet.
- Qué sucede si se encuentra un bug crítico 1 día antes del despliegue (protocolo de decisión)
    - ¿Afecta la parte médica? (Ej: enseña a hacer mal un paso de la cirugía). Se cancela el lanzamiento. Con la salud no se juega.
    - ¿Es técnico pero salvable? Si se puede arreglar en unas horas, se hace un parche rápido, se prueba y se lanza. Si no, se pospone el piloto hasta que esté al 100%.

**Parte D.2 — Pruebas de accesibilidad críticas (5 min):**
Identifica al menos 3 barreras de accesibilidad específicas de ESTE contexto (técnicos rurales, zonas remotas, headset VR) que NO serían relevantes en una app AR urbana convencional. Para cada una, propone cómo probarla y qué criterio de aceptación definiría.

- La barrera del idioma: Muchos técnicos hablan quechua o aimara. Si les llenas la pantalla de textos técnicos en español, se van a confundir.
    - Prueba: Ver si entienden la app usando solo iconos y colores de alerta sencillos.
    - Criterio de aceptación: Que terminen la práctica sin trabarse por no entender una palabra.
- La forma de la cara (Ergonomía): Los visores se diseñan para caras asiáticas o norteamericanas. En los andes, la forma de la cara o la distancia entre los ojos varía.
    - Prueba: Ajustar las lentes del visor para diferentes personas de la zona y ver si les duele la nariz o ven borroso.
    - Criterio de aceptación: Que se lo acomoden bien y vean nítido en menos de 2 minutos.
- Miedo a la tecnología: Alguien que no usa tecnología a diario se puede asustar al ponerse un casco de VR que lo aísla del mundo.
    - Prueba: Medir cuánto tardan en pasar el tutorial básico de "cómo mover las manos en el aire".
    - Criterio de aceptación: Que completen el tutorial solos en menos de 5 minutos.

**Parte D.3 — Reflexión sobre perseverancia (10 min):**
El escenario describe un sistema de salud real — si falla en producción, puede haber consecuencias en vidas humanas. Responde:
- ¿Cómo cambia la definición de "suficientemente probado" cuando el contexto es salud vs. un juego casual?
    - En un juego de celular, un bug da risa o se vuelve meme. Aquí, un bug puede costar una vida. Si el simulador tiene un error de diseño y le enseña a un técnico a presionar donde no debe, el técnico va a repetir ese error con una paciente real en su posta. Por eso, "listo" aquí significa perfección en la parte médica.
- ¿Qué rol juega la perseverancia en el proceso de pruebas cuando el costo del error es alto?
    - Como tester en este proyecto, tienes que ser el más terco del equipo. Tienes que probar la app una y otra vez (incluso aguantándote los mareos de la VR) para encontrar ese bug raro que solo pasa a veces. Si te da flojera y lo dejas pasar, ese bug le va a saltar al técnico en el peor momento
- Describe una situación concreta (real o hipotética) donde abandonar las pruebas antes de tiempo podría tener consecuencias irreversibles en este sistema.
    - Imagina que el equipo no quiso probar cómo reacciona el visor al calor extremo de la selva para "ahorrar tiempo". Un técnico en una posta calurosa de Madre de Dios está entrenando para detener una hemorragia postparto (la emergencia más peligrosa). A los 15 minutos, el visor se sobrecalienta y se apaga a la mitad. El técnico se rinde y no aprende la maniobra. Semanas después, le llega una paciente real desangrándose. Al no haber podido practicar por culpa de ese apagón, el técnico no sabe qué hacer a tiempo y la paciente fallece. Así de real y trágico es el impacto de saltarse una prueba.

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
