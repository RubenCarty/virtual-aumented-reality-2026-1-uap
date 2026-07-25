# S14 — GUÍA DE TRABAJO ESTUDIANTIL
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 14 — Pruebas y Validación de Experiencias XR
**Estudiante:** Palacios Vergaray Jhener Erick **Código:** 2231890156
# SECCIÓN A — COMPRENSIÓN CONCEPTUAL

## Pregunta 1

¿Cuál es la diferencia entre "testing" (pruebas) y "debugging" (depuración)?

- [ ] a) Son sinónimos — ambos términos se refieren a encontrar errores en el código.
- [x] b) El testing detecta la existencia de defectos; el debugging localiza y corrige la causa raíz de defectos ya conocidos.
- [ ] c) El testing es manual; el debugging es automático.
- [ ] d) El testing ocurre antes del desarrollo; el debugging ocurre durante el desarrollo.

**Respuesta:** b) El testing detecta la existencia de defectos; el debugging localiza y corrige la causa raíz de defectos ya conocidos.

**Explicación:**  
El **testing** permite comprobar si una aplicación funciona como se espera y detectar errores. El **debugging** comienza después de identificar un fallo y consiste en encontrar su causa dentro del código para corregirla.

---

## Pregunta 2

Un desarrollador encuentra que su app AR tiene 30 FPS en el editor Unity pero solo 18 FPS en el dispositivo Android físico. ¿Cuál es el primer paso lógico para diagnosticar esta diferencia?

- [ ] a) Cambiar el target platform a iOS y ver si mejora.
- [ ] b) Desactivar ARCore en el proyecto porque consume demasiado.
- [x] c) Conectar el dispositivo Android al Profiler de Unity y capturar datos de CPU/GPU en el dispositivo real.
- [ ] d) Reinstalar Unity en el dispositivo Android.

**Respuesta:** c) Conectar el dispositivo Android al Profiler de Unity y capturar datos de CPU/GPU en el dispositivo real.

**Explicación:**  
El rendimiento del editor no representa exactamente el funcionamiento del celular. Por eso, se debe medir directamente en el dispositivo para identificar si el problema está relacionado con CPU, GPU, memoria, renderizado o procesos de ARCore.

---

## Pregunta 3

En Unity Test Runner, ¿cuál es la diferencia entre un test de "Edit Mode" y uno de "Play Mode"?

- [ ] a) Edit Mode funciona solo en Windows; Play Mode funciona en todas las plataformas.
- [x] b) Edit Mode prueba la lógica de scripts sin iniciar el ciclo de juego de Unity; Play Mode prueba con el ciclo completo (`Start`, `Update`, etc.) activo.
- [ ] c) Edit Mode es más lento porque requiere compilar; Play Mode es más rápido porque usa caché.
- [ ] d) No hay diferencia funcional — son alias del mismo tipo de test en Unity.

**Respuesta:** b) Edit Mode prueba la lógica de scripts sin iniciar el ciclo de juego de Unity; Play Mode prueba con el ciclo completo activo.

**Explicación:**  
Los tests de **Edit Mode** se utilizan para revisar funciones y clases sin ejecutar la escena. En cambio, los tests de **Play Mode** permiten evaluar comportamientos que dependen del ciclo de vida de Unity, las corrutinas, físicas y objetos activos.

---

## Pregunta 4

¿Cuál de los siguientes es un ejemplo de bug con severidad "cosmética" pero prioridad P1?

- [ ] a) La app crashea al iniciar — día antes de la presentación final.
- [ ] b) La detección de planos no funciona en superficies oscuras — se reporta 3 meses antes del lanzamiento.
- [x] c) El logo de la empresa en la pantalla de inicio muestra la versión antigua — demo con el cliente mañana.
- [ ] d) El texto de ayuda tiene un error de ortografía — versión 1.0 recién publicada.

**Respuesta:** c) El logo de la empresa en la pantalla de inicio muestra la versión antigua — demo con el cliente mañana.

**Explicación:**  
El error es cosmético porque no impide el funcionamiento de la aplicación. Sin embargo, tiene prioridad alta porque la demostración con el cliente es al día siguiente y el logo afecta directamente la imagen de la empresa.

---

## Pregunta 5

¿Qué es una "prueba de regresión" y cuándo se ejecuta?

- [ ] a) Es una prueba que verifica que el hardware del dispositivo es compatible con la app; se ejecuta al inicio del proyecto.
- [x] b) Es una prueba que re-ejecuta casos previamente aprobados para verificar que las correcciones de bugs no rompieron funcionalidades existentes; se ejecuta después de cada corrección.
- [ ] c) Es una prueba de rendimiento bajo condiciones extremas de carga; se ejecuta antes del lanzamiento.
- [ ] d) Es una prueba que verifica la accesibilidad del producto; se ejecuta una vez al final del proyecto.

**Respuesta:** b) Es una prueba que re-ejecuta casos previamente aprobados para verificar que las correcciones no rompieron funcionalidades existentes.

**Explicación:**  
Después de corregir un error, pueden aparecer fallos en otras partes del sistema. La prueba de regresión vuelve a ejecutar casos que anteriormente funcionaban para comprobar que los cambios no hayan generado nuevos defectos.

---

## Pregunta 6

Un equipo de desarrollo usa la convención de Conventional Commits y escribe el mensaje:

```text
fix(ar-placement): prevenir NullReferenceException en gestos sin plano — BUG-012
```

¿Cuál de los siguientes beneficios **NO** proporciona directamente el ID de bug en el mensaje de commit?

- [ ] a) Permite buscar exactamente qué cambio de código corrigió el bug con `git log --grep="BUG-012"`.
- [ ] b) Permite que GitHub/GitLab cierre automáticamente el issue relacionado al hacer merge.
- [ ] c) Permite al reviewer del PR verificar que el cambio corresponde a lo descrito en el bug report.
- [x] d) Impide que el mismo bug pueda ser reportado nuevamente por otro tester.

**Respuesta:** d) Impide que el mismo bug pueda ser reportado nuevamente por otro tester.

**Explicación:**  
Incluir el ID mejora la trazabilidad entre el bug, el commit y la revisión de código. Sin embargo, no evita que otro tester reporte el mismo problema, ya que podrían existir reportes duplicados.

---

## Pregunta 7

¿Por qué el protocolo Think-Aloud es especialmente valioso para pruebas de usabilidad en XR comparado con una app de escritorio convencional?

- [ ] a) Porque en XR el evaluador no puede ver la pantalla del usuario, entonces necesita escuchar lo que dice.
- [x] b) Porque en XR las interacciones son gestos y movimientos físicos difíciles de registrar solo con clickstream — la verbalización revela en tiempo real dónde el usuario se confunde en el espacio 3D.
- [ ] c) Porque en XR el software no tiene logs de error, entonces la voz del usuario es la única fuente de datos.
- [ ] d) Porque en XR todos los usuarios son principiantes y necesitan ser guiados durante la prueba.

**Respuesta:** b) Porque las interacciones XR incluyen gestos y movimientos físicos difíciles de registrar únicamente con datos de clics.

**Explicación:**  
Cuando el usuario expresa lo que piensa mientras interactúa, el evaluador puede identificar confusiones relacionadas con la posición de objetos, controles, gestos, profundidad y navegación en espacios tridimensionales.

---

## Pregunta 8

Un caso de prueba para AR tiene la siguiente precondición: "Superficie plana horizontal, texturizada, iluminación 300-600 lux". Dos testers ejecutan el mismo caso: uno sobre una mesa de madera (PASA), otro sobre un espejo horizontal (FALLA). ¿Cuál es la conclusión correcta?

- [ ] a) Hay un bug en el código de ARCore que debe reportarse a Google.
- [ ] b) El caso de prueba está mal diseñado porque los resultados son inconsistentes.
- [x] c) No hay un bug — la diferencia de resultado se explica por la precondición. El espejo no es una superficie texturizada y se necesita un caso separado para superficies reflectantes.
- [ ] d) Los dos testers deben repetir la prueba simultáneamente para determinar cuál resultado es correcto.

**Respuesta:** c) No hay un bug; el espejo no cumple la precondición de ser una superficie texturizada.

**Explicación:**  
La mesa de madera ofrece detalles visuales que ayudan al sistema AR a detectar puntos de referencia. El espejo es reflectante y no cumple las condiciones definidas, por lo que debe evaluarse mediante otro caso de prueba específico.

---

## Pregunta 9

¿Cuál de los siguientes describe mejor el rol de ARCore en relación con las pruebas de rendimiento en Android?

- [x] a) ARCore consume recursos adicionales de CPU para el análisis de la cámara, lo que puede reducir los FPS disponibles para la lógica del juego y los shaders Unity.
- [ ] b) ARCore optimiza automáticamente el rendimiento del GPU y garantiza 60 FPS en todos los dispositivos certificados.
- [ ] c) ARCore solo consume recursos cuando hay planos detectados; si no hay planos, el consumo de CPU es cero.
- [ ] d) ARCore funciona en el GPU exclusivamente y no afecta el rendimiento de los scripts de Unity que corren en CPU.

**Respuesta:** a) ARCore consume recursos adicionales de CPU para analizar la cámara y el entorno.

**Explicación:**  
ARCore procesa imágenes, movimiento, puntos de seguimiento y superficies. Estas tareas compiten por los recursos del dispositivo con los scripts, la física y el renderizado de Unity, por lo que pueden afectar los FPS.

---

## Pregunta 10

¿Cuál es el propósito de incluir un campo "Reproducibilidad" (ejemplo: "10/10 intentos") en un bug report?

- [ ] a) Indicar al desarrollador cuántas líneas de código están afectadas por el bug.
- [x] b) Comunicar la probabilidad de que el bug ocurra bajo las mismas condiciones, lo que ayuda a priorizar y a verificar que la corrección fue exitosa.
- [ ] c) Limitar al tester a reportar solo bugs que ocurren siempre y descartar los intermitentes.
- [ ] d) Calcular automáticamente la prioridad del bug dividiendo 10 entre el número de intentos fallidos.

**Respuesta:** b) Comunicar la probabilidad de que el bug ocurra bajo las mismas condiciones.

**Explicación:**  
La reproducibilidad indica si un error aparece siempre o de manera intermitente. Este dato ayuda al desarrollador a repetir el problema, priorizarlo y comprobar posteriormente si la solución realmente lo eliminó.

---

# SECCIÓN B — COMPRENSIÓN TÉCNICA

## B.1 — Completar espacios en blanco

### 1.

En Unity, el framework de pruebas integrado se llama **Unity Test Runner** y se accede desde el menú **Window** → General → **Test Runner**.

**Respuesta:**

- Unity Test Runner
- Window
- Test Runner

---

### 2.

El tipo de test que verifica la lógica de un script sin necesitar que Unity esté en Play Mode se llama test de **Edit** Mode.

**Respuesta:**

- Edit

---

### 3.

En NUnit (el framework usado por Unity Test Runner), el atributo que marca un método como un test es **[Test]**, y el método que se ejecuta antes de cada test individual para preparar el estado inicial se marca con **[SetUp]**.

**Respuesta:**

- `[Test]`
- `[SetUp]`

---

### 4.

La métrica de rendimiento que mide cuántos objetos Unity envía al GPU para renderizar en cada frame se llama **Draw Calls** y en proyectos AR móvil debe mantenerse por debajo de **100** para un rendimiento aceptable.

**Respuesta:**

- Draw Calls
- 100

---

### 5.

Cuando la causa de bajo FPS está en el GPU (renderizado de malla, shaders) se llama condición **GPU** bound; cuando está en el CPU (scripts, física, IA) se llama condición **CPU** bound.

**Respuesta:**

- GPU
- CPU

---

### 6.

En el ciclo de vida de un bug en un sistema de tracking, después de que el developer corrige el bug y hace commit, el estado del bug cambia de **"Corregido"** a **"Pendiente de verificación"** hasta que el tester re-ejecuta el caso de prueba original.

**Respuesta:**

- Pendiente de verificación

---

### 7.

El protocolo de pruebas de usabilidad en el que el usuario verbaliza sus pensamientos mientras usa el producto se llama protocolo **Think-Aloud**.

**Respuesta:**

- Think-Aloud

---

### 8.

Una prueba que re-ejecuta todos los casos de prueba aprobados anteriormente después de una corrección se llama prueba de **regresión**.

**Respuesta:**

- Regresión

---

# B.2 — Emparejar columnas

| # | Término | Respuesta | Definición |
|---|---------|:--------:|------------|
| 1 | Severidad | **B** | Impacto técnico de un bug en la funcionalidad del sistema. |
| 2 | Prioridad | **A** | Urgencia con la que un bug debe corregirse según las necesidades del proyecto. |
| 3 | Caso de prueba | **F** | Unidad de prueba con pasos, entradas y resultados esperados. |
| 4 | Plan de pruebas | **E** | Documento que organiza el alcance, recursos y estrategia de las pruebas. |
| 5 | Unity Profiler | **C** | Herramienta que monitorea CPU, GPU, memoria y rendimiento en Unity. |
| 6 | Precondición | **D** | Estado o condición necesaria antes de ejecutar un caso de prueba. |
| 7 | Test de regresión | **H** | Repetición de pruebas previamente aprobadas después de realizar cambios. |
| 8 | Unit test | **G** | Prueba aislada que valida una función o método específico sin dependencias externas. |
| 9 | Think-Aloud | **J** | Técnica donde el usuario expresa en voz alta lo que piensa mientras usa la aplicación. |
| 10 | Integration test | **I** | Verifica que varios módulos trabajen correctamente de manera conjunta. |

---

# B.3 — Verdadero o Falso

### 1.

**Falso (F)**

**Justificación:**  
Los tests de **Edit Mode** no ejecutan el sistema AR en tiempo real; la detección de planos requiere un **Play Mode Test** sobre un dispositivo compatible.

---

### 2.

**Falso (F)**

**Justificación:**  
Si una aplicación se bloquea o deja de funcionar completamente, el error tiene alta prioridad y no puede posponerse indefinidamente.

---

### 3.

**Falso (F)**

**Justificación:**  
El **Happy Path** representa únicamente el flujo normal y esperado de uso, no todos los escenarios posibles ni los casos excepcionales.

---

### 4.

**Falso (F)**

**Justificación:**  
ARCore necesita suficientes características visuales para identificar superficies; una pared completamente lisa dificulta el reconocimiento.

---

### 5.

**Falso (F)**

**Justificación:**  
En el protocolo **Think-Aloud**, el evaluador observa y escucha al participante sin intervenir, para obtener información objetiva sobre su experiencia.

---

### 6.

**Verdadero (V)**

**Justificación:**  
Los **Unit Tests** son rápidos, económicos y fáciles de automatizar, por lo que constituyen la base de la pirámide de pruebas y suelen ser los más numerosos.

---

# SECCIÓN C — ANÁLISIS Y APLICACIÓN

# C.1 — Diagnóstico de plan de pruebas con deficiencias

## a) Identifica 4 deficiencias específicas en este plan de pruebas.

| Deficiencia | ¿Qué falta? | ¿Por qué es importante? |
|-------------|-------------|-------------------------|
| **1. Casos de prueba poco específicos** | No existen pasos detallados ni resultados esperados. | Un caso de prueba debe indicar exactamente qué hacer y qué resultado debe obtenerse para que cualquier tester pueda repetir la prueba. |
| **2. No existen precondiciones** | No indica las condiciones necesarias antes de ejecutar las pruebas (dispositivo, iluminación, detección de plano, etc.). | Las precondiciones garantizan que todas las pruebas se realicen bajo las mismas condiciones y que los resultados sean consistentes. |
| **3. Solo se prueba en un dispositivo** | El plan indica que únicamente se utilizará el celular del estudiante. | Es recomendable probar en diferentes dispositivos para detectar problemas de compatibilidad, rendimiento o funcionamiento específicos de cada equipo. |
| **4. No existe un criterio de aceptación** | El documento no define cuándo una prueba se considera aprobada o fallida. | Establecer criterios de aceptación permite evaluar objetivamente si la funcionalidad cumple con los requisitos del proyecto. |

---

## b) Caso de prueba 1 reescrito en formato profesional

### Caso de Prueba

**ID:** CP-001

**Módulo:** Colocación de objeto AR

**Prioridad:** Alta

**Precondiciones:**

- Aplicación instalada correctamente.
- ARCore compatible y habilitado.
- Cámara con permisos concedidos.
- Superficie plana horizontal correctamente detectada.
- Iluminación adecuada.

**Estado inicial:**

La aplicación se encuentra abierta y muestra la detección de planos sin objetos colocados.

**Pasos:**

1. Abrir la aplicación.
2. Esperar hasta que se detecte una superficie válida.
3. Tocar una vez la superficie detectada.
4. Observar la aparición del modelo 3D.

**Resultado esperado:**

El modelo de la planta aparece sobre la superficie seleccionada, permanece estable y conserva su posición sin presentar errores o movimientos inesperados.

---

## c) ¿Qué problema revela la frase "esperamos que todo funcione"?

**Respuesta:**

La frase demuestra un enfoque poco profesional hacia las pruebas, ya que supone que el sistema funcionará correctamente sin verificar cada funcionalidad mediante casos de prueba definidos.

**Explicación:**

El objetivo del testing no es confirmar que la aplicación funciona, sino descubrir posibles errores antes de que lleguen al usuario final. Un plan de pruebas debe basarse en criterios verificables y resultados esperados, no en suposiciones.

**Una redacción más adecuada sería:**

> *"Se ejecutarán todos los casos de prueba definidos y se registrarán los resultados obtenidos, documentando cualquier incidencia encontrada para su posterior análisis y corrección."*
# C.2 — Análisis de código con bugs

## a) Bug A — Acceso a una posición inexistente en la lista `hits`

### ¿En qué línea está el bug?

El error se encuentra en esta línea:

```csharp
Vector3 posicion = hits[0].pose.position;
```

También afecta esta otra línea:

```csharp
Instantiate(prefabObjeto, posicion, hits[0].pose.rotation);
```

### ¿Qué excepción lanzará?

Puede lanzar una excepción de tipo:

```text
ArgumentOutOfRangeException
```

Esto ocurre porque el código intenta acceder a `hits[0]` aunque la lista esté vacía.

### ¿Cuándo ocurrirá en una situación real?

El error aparecerá cuando el usuario toque una zona de la pantalla donde no exista un plano AR detectado. En ese caso, el método `Raycast()` no agregará resultados a la lista `hits`, pero el programa intentará acceder igualmente al primer elemento.

### Método corregido

```csharp
public void AlTapEnPantalla(Vector2 posicionToque)
{
    bool planoDetectado = raycastManager.Raycast(
        posicionToque,
        hits,
        TrackableType.PlaneWithinPolygon
    );

    if (planoDetectado && hits.Count > 0)
    {
        Pose poseImpacto = hits[0].pose;

        Instantiate(
            prefabObjeto,
            poseImpacto.position,
            poseImpacto.rotation
        );

        contadorObjetos++;
    }
    else
    {
        Debug.LogWarning("No se detectó un plano válido en la posición seleccionada.");
    }
}
```

**Explicación:**

Primero se comprueba si el raycast encontró una superficie válida y si la lista contiene resultados. Solo después de esa validación se accede a `hits[0]`, evitando que la aplicación falle cuando el usuario toca un espacio sin planos detectados.

---

## b) Bug B — Destrucción de todos los objetos de la escena

### ¿Por qué es un problema grave?

El siguiente código obtiene todos los objetos activos de la escena:

```csharp
GameObject[] objetos = GameObject.FindObjectsOfType<GameObject>();
```

Después, destruye cada uno de ellos:

```csharp
Destroy(obj);
```

Esto no elimina únicamente los modelos AR colocados por el usuario. También podría destruir componentes esenciales como:

- La cámara AR.
- El `ARSession`.
- El `ARSessionOrigin` o `XROrigin`.
- El `ARRaycastManager`.
- El Canvas y sus botones.
- Luces y sistemas de audio.
- El propio objeto que contiene este script.

Como resultado, la escena podría quedar inutilizable, perder la cámara o dejar de detectar superficies.

### Corrección recomendada

Se debe guardar una referencia únicamente a los objetos creados mediante `Instantiate()` y destruir solo esos elementos.

```csharp
private List<GameObject> objetosColocados = new List<GameObject>();
```

El método de colocación debe registrar cada objeto creado:

```csharp
public void AlTapEnPantalla(Vector2 posicionToque)
{
    bool planoDetectado = raycastManager.Raycast(
        posicionToque,
        hits,
        TrackableType.PlaneWithinPolygon
    );

    if (planoDetectado && hits.Count > 0)
    {
        Pose poseImpacto = hits[0].pose;

        GameObject nuevoObjeto = Instantiate(
            prefabObjeto,
            poseImpacto.position,
            poseImpacto.rotation
        );

        objetosColocados.Add(nuevoObjeto);
        contadorObjetos++;
    }
}
```

El método de reinicio quedaría así:

```csharp
public void ResetearEscena()
{
    foreach (GameObject obj in objetosColocados)
    {
        if (obj != null)
        {
            Destroy(obj);
        }
    }

    objetosColocados.Clear();
    contadorObjetos = 0;
}
```

**Explicación:**

La lista `objetosColocados` contiene solamente los modelos generados por el usuario. De esta manera, al reiniciar la escena no se eliminan la cámara, el sistema AR ni los componentes necesarios para que la aplicación continúe funcionando.

---

## c) Bug C — Posible `NullReferenceException`

### ¿Cuándo ocurriría?

El error ocurriría cuando la variable `colorManager` no tenga asignado un objeto en el Inspector de Unity o cuando el componente haya sido eliminado o desactivado incorrectamente.

En ese caso, esta línea intentaría ejecutar un método sobre una referencia nula:

```csharp
colorManager.SiguienteModo();
```

### Método corregido

```csharp
public void CambiarColorAccesibilidad()
{
    if (colorManager != null)
    {
        colorManager.SiguienteModo();
    }
    else
    {
        Debug.LogWarning("El GestorAccesibilidadColor no está asignado.");
    }
}
```

**Explicación:**

Antes de llamar a `SiguienteModo()`, el código comprueba que `colorManager` tenga una referencia válida. Si no está asignado, se muestra una advertencia en lugar de provocar el cierre o interrupción de la aplicación.

También puede validarse desde `Awake()`:

```csharp
private void Awake()
{
    if (colorManager == null)
    {
        colorManager = FindObjectOfType<GestorAccesibilidadColor>();
    }
}
```

---

## d) Bug D — Uso repetido de `Debug.Log()` dentro de `Update()`

### ¿Cuál es el problema de rendimiento?

El método `Update()` se ejecuta una vez por cada frame. Si la aplicación funciona a 60 FPS y `contadorObjetos` es mayor que 10, los tres mensajes se imprimirán aproximadamente 180 veces por segundo.

```csharp
Debug.Log("Máximo de objetos alcanzado");
Debug.Log("Máximo de objetos alcanzado");
Debug.Log("Máximo de objetos alcanzado");
```

Esto genera:

- Saturación de la consola.
- Mayor uso de CPU.
- Crecimiento innecesario de los registros.
- Posibles caídas de FPS.
- Dificultad para identificar otros errores importantes.

### Corrección

Se puede utilizar una variable booleana para mostrar el mensaje una sola vez.

```csharp
private bool avisoMaximoMostrado = false;

void Update()
{
    if (contadorObjetos > 10 && !avisoMaximoMostrado)
    {
        Debug.LogWarning("Máximo de objetos alcanzado.");
        avisoMaximoMostrado = true;
    }

    if (contadorObjetos <= 10)
    {
        avisoMaximoMostrado = false;
    }
}
```

Una opción más adecuada es evitar la colocación desde el propio método de interacción:

```csharp
public void AlTapEnPantalla(Vector2 posicionToque)
{
    if (contadorObjetos >= 10)
    {
        Debug.LogWarning("No se pueden colocar más de 10 objetos.");
        return;
    }

    bool planoDetectado = raycastManager.Raycast(
        posicionToque,
        hits,
        TrackableType.PlaneWithinPolygon
    );

    if (planoDetectado && hits.Count > 0)
    {
        Pose poseImpacto = hits[0].pose;

        GameObject nuevoObjeto = Instantiate(
            prefabObjeto,
            poseImpacto.position,
            poseImpacto.rotation
        );

        objetosColocados.Add(nuevoObjeto);
        contadorObjetos++;
    }
}
```

### Clasificación de severidad

**Severidad: Menor o moderada.**

**Justificación:**

El error no impide necesariamente que la aplicación funcione, pero puede reducir el rendimiento y afectar la estabilidad, especialmente en dispositivos móviles de pocos recursos. Su severidad podría aumentar si provoca congelamientos, caídas fuertes de FPS o bloqueos durante el uso.

---

# Resumen de los bugs

| Bug | Problema | Posible consecuencia | Corrección |
|-----|----------|----------------------|------------|
| **A** | Se accede a `hits[0]` sin comprobar resultados | `ArgumentOutOfRangeException` | Verificar el resultado del raycast y `hits.Count > 0` |
| **B** | Se destruyen todos los GameObjects | Se eliminan la cámara, ARSession y la interfaz | Guardar y destruir solo los objetos colocados |
| **C** | `colorManager` puede ser nulo | `NullReferenceException` | Comprobar `colorManager != null` |
| **D** | Se ejecutan varios logs en cada frame | Saturación de consola y pérdida de FPS | Mostrar el aviso una sola vez o validar al colocar |

# C.3 — Caso de gestión de bugs: Priorización bajo presión

## a) Priorización de los bugs

Con un tiempo máximo de **6 horas**, se priorizan los siguientes bugs:

| Prioridad | Bug | Tiempo | Justificación |
|-----------|-----|:------:|---------------|
| **1** | **BUG-C** | **3 h** | Es un error crítico porque la aplicación se bloquea al iniciar en Android 13. Si la app no puede ejecutarse durante la presentación al MINEDU, el resto de las funcionalidades no podrán demostrarse. |
| **2** | **BUG-D** | **0.5 h** | Los subtítulos en quechua son parte importante del contenido educativo. Agregar un backing panel mejora la legibilidad y favorece la accesibilidad sin requerir mucho tiempo de desarrollo. |
| **3** | **BUG-A** | **1 h** | Las texturas incorrectas hacen que el modelo de Machu Picchu se vea completamente negro, afectando la calidad visual de la experiencia. Corregirlo mejora significativamente la presentación del proyecto. |
| **4** | **BUG-E** | **0.25 h** | Aunque es un error cosmético, modificar el nombre de la aplicación requiere poco tiempo y transmite una imagen más profesional durante la demostración oficial. |
| **5** | **BUG-G** | **1.5 h** | Cuando el seguimiento falla, el usuario no recibe ninguna explicación. Incorporar un mensaje informativo evita confusión y mejora la experiencia durante la interacción con la aplicación. |

**Tiempo total:** **6 horas 15 minutos.**

Como el tiempo supera el límite disponible, se decide **posponer el BUG-E**, ya que su impacto es únicamente visual.

### Orden final de corrección

1. BUG-C
2. BUG-D
3. BUG-A
4. BUG-G

**Tiempo utilizado:** **6 horas**

---

## b) Comunicación al cliente (MINEDU)

Los errores que no serán corregidos antes de la presentación corresponden a funcionalidades que no afectan el funcionamiento principal de la aplicación. Estos se encuentran registrados dentro del plan de mantenimiento y serán atendidos en la siguiente versión del proyecto. Durante la demostración se utilizarán escenarios previamente validados para garantizar una experiencia estable y representativa del producto. Asimismo, se entregará un informe técnico donde se detallan los problemas pendientes, su impacto y el cronograma previsto para su solución.

---

## c) Importancia de mostrar mensajes de error cuando falla el tracking

Cuando el seguimiento de la imagen falla, el usuario necesita saber por qué el modelo virtual desapareció o dejó de mostrarse. Un mensaje claro evita que la persona piense que la aplicación dejó de funcionar y le indica qué acción debe realizar para continuar, como acercar la cámara o mejorar el ángulo del libro.

Desde el punto de vista de la **accesibilidad cognitiva**, proporcionar instrucciones sencillas reduce la incertidumbre y facilita la comprensión del sistema. Esto ayuda especialmente a estudiantes con menor experiencia tecnológica, ya que reciben orientación inmediata sin tener que adivinar qué ocurrió. Además, mejora la usabilidad al ofrecer retroalimentación clara durante toda la interacción.

---

# Resumen

## Bugs corregidos

| Prioridad | Bug | Tiempo |
|:---------:|-----|:------:|
| 1 | **BUG-C** | 3 h |
| 2 | **BUG-D** | 0.5 h |
| 3 | **BUG-A** | 1 h |
| 4 | **BUG-G** | 1.5 h |

**Tiempo total:** **6 horas**

---

## Bug pendiente

| Bug | Motivo |
|------|--------|
| **BUG-E** | Tiene un impacto únicamente estético y puede corregirse después de la presentación sin afectar el funcionamiento de la aplicación. |

# SECCIÓN D — SÍNTESIS Y REFLEXIÓN

# Parte D.1 — Plan de pruebas

## 1. Tipos de pruebas

### Prueba funcional

**Justificación:**

Permite comprobar que todas las funciones del simulador VR operen correctamente, como la interacción con los instrumentos médicos, el seguimiento de los pasos del procedimiento y el registro de los resultados del entrenamiento. Es fundamental porque cualquier error puede afectar el aprendizaje del personal de salud.

---

### Prueba de usabilidad

**Justificación:**

Los técnicos de salud trabajarán en zonas rurales y algunos pueden tener poca experiencia utilizando dispositivos de realidad virtual. Estas pruebas permiten verificar que la navegación sea sencilla, que las instrucciones sean claras y que el sistema resulte fácil de utilizar.

---

### Prueba de rendimiento

**Justificación:**

El simulador debe ejecutarse de forma estable en el headset HTC Vive Focus 3. Se debe verificar que no existan retrasos, bloqueos o caídas de rendimiento que puedan afectar la inmersión durante la capacitación.

---

## 2. Casos de prueba

### Caso de prueba 1

**ID:** CP-001

**Precondiciones:**

- Headset encendido.
- Aplicación instalada.
- Usuario autenticado.

**Pasos:**

1. Iniciar la aplicación.
2. Seleccionar el escenario de parto complicado.

**Resultado esperado:**

El escenario carga correctamente sin presentar errores.

---

### Caso de prueba 2

**ID:** CP-002

**Precondiciones:**

Escenario iniciado.

**Pasos:**

1. Tomar un instrumento médico virtual.
2. Utilizarlo durante la simulación.

**Resultado esperado:**

El objeto responde correctamente a los movimientos del usuario.

---

### Caso de prueba 3

**ID:** CP-003

**Precondiciones:**

Simulación en ejecución.

**Pasos:**

1. Completar todo el procedimiento.
2. Finalizar la práctica.

**Resultado esperado:**

El sistema muestra la evaluación final y registra el desempeño del usuario.

---

### Caso de prueba 4

**ID:** CP-004

**Precondiciones:**

Aplicación funcionando.

**Pasos:**

1. Utilizar el simulador durante 30 minutos continuos.

**Resultado esperado:**

La aplicación mantiene un funcionamiento estable sin bloqueos.

---

### Caso de prueba 5

**ID:** CP-005

**Precondiciones:**

Aplicación instalada.

**Pasos:**

1. Reiniciar el dispositivo.
2. Abrir nuevamente la aplicación.

**Resultado esperado:**

La aplicación inicia correctamente y conserva la información registrada.

---

## 3. Criterios de aceptación

- Todas las funciones principales deben ejecutarse correctamente.
- No deben existir errores críticos durante la simulación.
- La aplicación debe mantener un rendimiento estable.
- Las instrucciones deben ser comprensibles para el usuario.
- Los resultados de la práctica deben registrarse correctamente.

---

## 4. Protocolo ante un bug crítico

Si un día antes del despliegue se detecta un error crítico, el equipo debe evaluar inmediatamente su impacto. Si el problema compromete el funcionamiento del simulador o puede afectar el aprendizaje de los usuarios, el despliegue debe posponerse hasta corregirlo y volver a realizar las pruebas correspondientes. La prioridad será garantizar la seguridad y confiabilidad del sistema antes de ponerlo en funcionamiento.

---

# Parte D.2 — Pruebas de accesibilidad críticas

| Barrera | ¿Cómo probarla? | Criterio de aceptación |
|----------|-----------------|-------------------------|
| Usuarios con poca experiencia en VR | Observar si pueden completar el entrenamiento sin ayuda externa. | El usuario logra completar la práctica siguiendo únicamente las instrucciones del sistema. |
| Uso prolongado del headset | Ejecutar sesiones continuas de entrenamiento y consultar el nivel de comodidad. | La mayoría de usuarios puede completar la práctica sin presentar molestias importantes. |
| Zonas con acceso limitado a internet | Ejecutar la aplicación sin conexión a la red. | Todas las funciones esenciales deben operar correctamente en modo local. |

---

# Parte D.3 — Reflexión sobre perseverancia

En un sistema de salud, la definición de "suficientemente probado" es mucho más exigente que en un videojuego. En este tipo de aplicaciones es necesario verificar cuidadosamente todas las funciones, ya que cualquier error puede afectar la preparación del personal médico y, en consecuencia, la atención de los pacientes.

La perseverancia es fundamental durante las pruebas porque obliga al equipo a revisar continuamente el sistema hasta reducir al mínimo la posibilidad de fallos. No basta con que la aplicación funcione una sola vez; es necesario comprobar su comportamiento en diferentes escenarios y condiciones.

Una situación de riesgo sería que el simulador enseñe de forma incorrecta el procedimiento para atender una emergencia obstétrica. Si ese error no es detectado antes del despliegue, un técnico podría aplicar un procedimiento equivocado durante una atención real, poniendo en peligro la vida de la madre y del recién nacido. Por ello, las pruebas deben mantenerse hasta tener la seguridad de que el sistema cumple con los estándares de calidad y confiabilidad necesarios para un entorno de salud.

---

