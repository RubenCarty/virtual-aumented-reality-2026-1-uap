# S14 — GUÍA DE TRABAJO ESTUDIANTIL
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 14 — Pruebas y Validación de Experiencias XR
**Estudiante:** Salazar Mondragón Jael Santiago  **Código: 2221898131**  

# SECCIÓN A — COMPRENSIÓN CONCEPTUAL

## Pregunta 1

¿Cuál es la diferencia entre "testing" (pruebas) y "debugging" (depuración)?

- [ ] a) Son sinónimos — ambos términos se refieren a encontrar errores en el código.
- [x] b) El testing detecta la existencia de defectos; el debugging localiza y corrige la causa raíz de defectos ya conocidos.
- [ ] c) El testing es manual; el debugging es automático.
- [ ] d) El testing ocurre antes del desarrollo; el debugging ocurre durante el desarrollo.

**Respuesta:** b) El testing detecta la existencia de defectos; el debugging localiza y corrige la causa raíz de defectos ya conocidos.

**Explicación:**  
Las pruebas sirven para comprobar si el sistema presenta fallos o resultados diferentes a los esperados. La depuración se realiza después, cuando el desarrollador analiza el programa para descubrir qué parte del código originó el problema y aplicar una solución.

---

## Pregunta 2

Un desarrollador encuentra que su app AR tiene 30 FPS en el editor Unity pero solo 18 FPS en el dispositivo Android físico. ¿Cuál es el primer paso lógico para diagnosticar esta diferencia?

- [ ] a) Cambiar el target platform a iOS y ver si mejora.
- [ ] b) Desactivar ARCore en el proyecto porque consume demasiado.
- [x] c) Conectar el dispositivo Android al Profiler de Unity y capturar datos de CPU/GPU en el dispositivo real.
- [ ] d) Reinstalar Unity en el dispositivo Android.

**Respuesta:** c) Conectar el dispositivo Android al Profiler de Unity y capturar datos de CPU/GPU en el dispositivo real.

**Explicación:**  
La computadora y el celular tienen capacidades diferentes, por lo que probar solo en el editor puede producir resultados engañosos. El Profiler permite observar el comportamiento real del dispositivo y determinar qué proceso está causando la disminución de FPS.

---

## Pregunta 3

En Unity Test Runner, ¿cuál es la diferencia entre un test de "Edit Mode" y uno de "Play Mode"?

- [ ] a) Edit Mode funciona solo en Windows; Play Mode funciona en todas las plataformas.
- [x] b) Edit Mode prueba la lógica de scripts sin iniciar el ciclo de juego de Unity; Play Mode prueba con el ciclo completo (`Start`, `Update`, etc.) activo.
- [ ] c) Edit Mode es más lento porque requiere compilar; Play Mode es más rápido porque usa caché.
- [ ] d) No hay diferencia funcional — son alias del mismo tipo de test en Unity.

**Respuesta:** b) Edit Mode prueba la lógica de scripts sin iniciar el ciclo de juego de Unity; Play Mode prueba con el ciclo completo activo.

**Explicación:**  
En **Edit Mode** se evalúan métodos, cálculos y reglas independientes de una escena en ejecución. En **Play Mode**, Unity activa el comportamiento normal del juego, permitiendo probar objetos, componentes, físicas y métodos del ciclo de vida.

---

## Pregunta 4

¿Cuál de los siguientes es un ejemplo de bug con severidad "cosmética" pero prioridad P1?

- [ ] a) La app crashea al iniciar — día antes de la presentación final.
- [ ] b) La detección de planos no funciona en superficies oscuras — se reporta 3 meses antes del lanzamiento.
- [x] c) El logo de la empresa en la pantalla de inicio muestra la versión antigua — demo con el cliente mañana.
- [ ] d) El texto de ayuda tiene un error de ortografía — versión 1.0 recién publicada.

**Respuesta:** c) El logo de la empresa en la pantalla de inicio muestra la versión antigua — demo con el cliente mañana.

**Explicación:**  
La severidad es cosmética porque el logo no altera ninguna función del sistema. Aun así, debe corregirse con urgencia porque puede causar una mala impresión durante una reunión importante con el cliente.

---

## Pregunta 5

¿Qué es una "prueba de regresión" y cuándo se ejecuta?

- [ ] a) Es una prueba que verifica que el hardware del dispositivo es compatible con la app; se ejecuta al inicio del proyecto.
- [x] b) Es una prueba que re-ejecuta casos previamente aprobados para verificar que las correcciones de bugs no rompieron funcionalidades existentes; se ejecuta después de cada corrección.
- [ ] c) Es una prueba de rendimiento bajo condiciones extremas de carga; se ejecuta antes del lanzamiento.
- [ ] d) Es una prueba que verifica la accesibilidad del producto; se ejecuta una vez al final del proyecto.

**Respuesta:** b) Es una prueba que re-ejecuta casos previamente aprobados para verificar que las correcciones no rompieron funcionalidades existentes.

**Explicación:**  
Modificar una parte del código puede afectar accidentalmente otras funciones que antes trabajaban correctamente. Las pruebas de regresión permiten confirmar que el sistema mantiene su estabilidad después de cada cambio o corrección.

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
El identificador conecta el reporte con el cambio realizado y facilita el seguimiento del trabajo. Sin embargo, no controla los reportes creados por otras personas, por lo que todavía podría registrarse un duplicado.

---

## Pregunta 7

¿Por qué el protocolo Think-Aloud es especialmente valioso para pruebas de usabilidad en XR comparado con una app de escritorio convencional?

- [ ] a) Porque en XR el evaluador no puede ver la pantalla del usuario, entonces necesita escuchar lo que dice.
- [x] b) Porque en XR las interacciones son gestos y movimientos físicos difíciles de registrar solo con clickstream — la verbalización revela en tiempo real dónde el usuario se confunde en el espacio 3D.
- [ ] c) Porque en XR el software no tiene logs de error, entonces la voz del usuario es la única fuente de datos.
- [ ] d) Porque en XR todos los usuarios son principiantes y necesitan ser guiados durante la prueba.

**Respuesta:** b) Porque las interacciones XR incluyen gestos y movimientos físicos difíciles de registrar únicamente con datos de clics.

**Explicación:**  
En una experiencia XR el usuario puede mirar, caminar, girar o mover las manos sin hacer clic. Escuchar sus pensamientos permite entender qué esperaba encontrar, qué objeto no pudo localizar y en qué momento se sintió confundido.

---

## Pregunta 8

Un caso de prueba para AR tiene la siguiente precondición: "Superficie plana horizontal, texturizada, iluminación 300-600 lux". Dos testers ejecutan el mismo caso: uno sobre una mesa de madera (PASA), otro sobre un espejo horizontal (FALLA). ¿Cuál es la conclusión correcta?

- [ ] a) Hay un bug en el código de ARCore que debe reportarse a Google.
- [ ] b) El caso de prueba está mal diseñado porque los resultados son inconsistentes.
- [x] c) No hay un bug — la diferencia de resultado se explica por la precondición. El espejo no es una superficie texturizada y se necesita un caso separado para superficies reflectantes.
- [ ] d) Los dos testers deben repetir la prueba simultáneamente para determinar cuál resultado es correcto.

**Respuesta:** c) No hay un bug; el espejo no cumple la precondición de ser una superficie texturizada.

**Explicación:**  
Los sistemas AR necesitan características visuales estables para reconocer superficies. La madera presenta detalles que facilitan el tracking, mientras que el espejo genera reflejos y no ofrece una textura confiable para la detección.

---

## Pregunta 9

¿Cuál de los siguientes describe mejor el rol de ARCore en relación con las pruebas de rendimiento en Android?

- [x] a) ARCore consume recursos adicionales de CPU para el análisis de la cámara, lo que puede reducir los FPS disponibles para la lógica del juego y los shaders Unity.
- [ ] b) ARCore optimiza automáticamente el rendimiento del GPU y garantiza 60 FPS en todos los dispositivos certificados.
- [ ] c) ARCore solo consume recursos cuando hay planos detectados; si no hay planos, el consumo de CPU es cero.
- [ ] d) ARCore funciona en el GPU exclusivamente y no afecta el rendimiento de los scripts de Unity que corren en CPU.

**Respuesta:** a) ARCore consume recursos adicionales de CPU para analizar la cámara y el entorno.

**Explicación:**  
Mientras la aplicación está activa, ARCore procesa constantemente la imagen de la cámara y el movimiento del dispositivo. Esta carga se suma a los modelos, scripts y efectos de Unity, por lo que puede disminuir el rendimiento disponible.

---

## Pregunta 10

¿Cuál es el propósito de incluir un campo "Reproducibilidad" (ejemplo: "10/10 intentos") en un bug report?

- [ ] a) Indicar al desarrollador cuántas líneas de código están afectadas por el bug.
- [x] b) Comunicar la probabilidad de que el bug ocurra bajo las mismas condiciones, lo que ayuda a priorizar y a verificar que la corrección fue exitosa.
- [ ] c) Limitar al tester a reportar solo bugs que ocurren siempre y descartar los intermitentes.
- [ ] d) Calcular automáticamente la prioridad del bug dividiendo 10 entre el número de intentos fallidos.

**Respuesta:** b) Comunicar la probabilidad de que el bug ocurra bajo las mismas condiciones.

**Explicación:**  
Un resultado como `10/10` indica que el fallo sucede siempre, mientras que `2/10` muestra que es intermitente. Esta información ayuda a repetir el error, estimar su impacto y confirmar si dejó de aparecer después de corregirlo.

---

# SECCIÓN B — COMPRENSIÓN TÉCNICA

## B.1 — Completar espacios en blanco

### 1.

En Unity, el framework de pruebas integrado se llama **Unity Test Runner** y se accede desde el menú **Window** → General → **Test Runner**.

**Respuesta:**

- Unity Test Runner
- Window
- Test Runner

**Explicación:**  
Unity incorpora una herramienta propia para crear y ejecutar pruebas automáticas. Se encuentra dentro del menú **Window**, permitiendo validar el funcionamiento de scripts y componentes sin instalar software adicional.

---

### 2.

El tipo de test que verifica la lógica de un script sin necesitar que Unity esté en Play Mode se llama test de **Edit** Mode.

**Respuesta:**

- Edit

**Explicación:**  
Los **Edit Mode Tests** permiten evaluar métodos y clases directamente desde el editor, sin ejecutar la escena ni activar el ciclo de vida de Unity, lo que hace que sean rápidos y eficientes.

---

### 3.

En NUnit (el framework usado por Unity Test Runner), el atributo que marca un método como un test es **[Test]**, y el método que se ejecuta antes de cada test individual para preparar el estado inicial se marca con **[SetUp]**.

**Respuesta:**

- `[Test]`
- `[SetUp]`

**Explicación:**  
El atributo **[Test]** identifica qué método corresponde a una prueba. Por otro lado, **[SetUp]** prepara el entorno antes de ejecutar cada test, garantizando que todos comiencen bajo las mismas condiciones.

---

### 4.

La métrica de rendimiento que mide cuántos objetos Unity envía al GPU para renderizar en cada frame se llama **Draw Calls** y en proyectos AR móvil debe mantenerse por debajo de **100** para un rendimiento aceptable.

**Respuesta:**

- Draw Calls
- 100

**Explicación:**  
Cada Draw Call representa una solicitud enviada al GPU para dibujar un objeto. Reducir esta cantidad mejora el rendimiento, especialmente en dispositivos móviles con recursos limitados.

---

### 5.

Cuando la causa de bajo FPS está en el GPU (renderizado de malla, shaders) se llama condición **GPU** bound; cuando está en el CPU (scripts, física, IA) se llama condición **CPU** bound.

**Respuesta:**

- GPU
- CPU

**Explicación:**  
Si el cuello de botella se encuentra en el procesamiento gráfico, el problema es **GPU bound**. Si el mayor tiempo de procesamiento ocurre en los scripts, la física o la inteligencia artificial, se considera **CPU bound**.

---

### 6.

En el ciclo de vida de un bug en un sistema de tracking, después de que el developer corrige el bug y hace commit, el estado del bug cambia de **"Corregido"** a **"Pendiente de verificación"** hasta que el tester re-ejecuta el caso de prueba original.

**Respuesta:**

- Pendiente de verificación

**Explicación:**  
Aunque el desarrollador haya corregido el error, este todavía debe ser validado por el equipo de pruebas. Solo después de comprobar que el problema desapareció, el bug puede cerrarse definitivamente.

---

### 7.

El protocolo de pruebas de usabilidad en el que el usuario verbaliza sus pensamientos mientras usa el producto se llama protocolo **Think-Aloud**.

**Respuesta:**

- Think-Aloud

**Explicación:**  
Esta técnica consiste en pedir al usuario que exprese en voz alta lo que piensa durante la interacción. De esta forma se identifican dudas, errores o dificultades que no siempre son visibles mediante registros automáticos.

---

### 8.

Una prueba que re-ejecuta todos los casos de prueba aprobados anteriormente después de una corrección se llama prueba de **regresión**.

**Respuesta:**

- Regresión

**Explicación:**  
Después de modificar el código es importante verificar nuevamente las funciones existentes para asegurar que continúan funcionando correctamente y que los cambios no introdujeron nuevos errores.

---

# B.2 — Emparejar columnas

| # | Término | Respuesta | Definición |
|---|---------|:--------:|------------|
| 1 | Severidad | **B** | Evalúa el nivel de impacto que produce un defecto sobre el funcionamiento del sistema. |
| 2 | Prioridad | **A** | Indica qué tan urgente resulta solucionar un problema según las necesidades del proyecto. |
| 3 | Caso de prueba | **F** | Describe de forma detallada los pasos, datos de entrada y resultados esperados para validar una función. |
| 4 | Plan de pruebas | **E** | Documento donde se organiza la estrategia, alcance y recursos necesarios para las pruebas. |
| 5 | Unity Profiler | **C** | Herramienta que permite monitorear el rendimiento del proyecto analizando CPU, GPU y memoria. |
| 6 | Precondición | **D** | Requisito que debe cumplirse antes de ejecutar un caso de prueba específico. |
| 7 | Test de regresión | **H** | Consiste en repetir pruebas anteriores para confirmar que las modificaciones no afectaron otras funciones. |
| 8 | Unit test | **G** | Prueba enfocada en validar una unidad de código de manera independiente. |
| 9 | Think-Aloud | **J** | Método de evaluación donde el usuario explica lo que piensa mientras interactúa con el sistema. |
| 10 | Integration test | **I** | Verifica que distintos módulos funcionen correctamente cuando trabajan en conjunto. |

---

# B.3 — Verdadero o Falso

### 1.

**Falso (F)**

**Justificación:**  
La detección de planos requiere que la aplicación esté ejecutándose con AR Foundation y un dispositivo compatible, por lo que no puede validarse únicamente mediante un test de Edit Mode.

---

### 2.

**Falso (F)**

**Justificación:**  
Si un error provoca que la aplicación deje de funcionar, normalmente recibe una prioridad alta para evitar afectar a los usuarios o impedir el uso del sistema.

---

### 3.

**Falso (F)**

**Justificación:**  
El concepto **Happy Path** representa el recorrido ideal del usuario cuando todo funciona correctamente, sin contemplar situaciones excepcionales o errores.

---

### 4.

**Falso (F)**

**Justificación:**  
ARCore utiliza puntos característicos del entorno para identificar superficies. Las superficies lisas y sin detalles visuales dificultan ese proceso.

---

### 5.

**Falso (F)**

**Justificación:**  
Durante una prueba Think-Aloud el evaluador debe intervenir lo menos posible para no influir en el comportamiento natural del participante.

---

### 6.

**Verdadero (V)**

**Justificación:**  
Los tests unitarios se ejecutan rápidamente y requieren pocos recursos, por lo que es recomendable crear una gran cantidad de ellos para detectar errores desde etapas tempranas.

---

# SECCIÓN C — ANÁLISIS Y APLICACIÓN

# C.1 — Diagnóstico de plan de pruebas con deficiencias

## a) Identifica 4 deficiencias específicas en este plan de pruebas.

| Deficiencia | ¿Qué falta? | ¿Por qué es importante? |
|-------------|-------------|-------------------------|
| **1. Falta de información detallada en los casos de prueba** | Los casos solo contienen descripciones generales y no especifican cómo realizar la prueba. | Un caso de prueba debe ser suficientemente claro para que cualquier miembro del equipo pueda ejecutarlo y obtener resultados similares. |
| **2. Ausencia de condiciones iniciales** | No se indica el estado en que debe encontrarse la aplicación antes de iniciar cada prueba. | Definir las condiciones iniciales evita diferencias durante la ejecución y mejora la confiabilidad de los resultados. |
| **3. Cobertura de pruebas limitada** | Solo se menciona un único dispositivo para realizar las pruebas. | Evaluar la aplicación en distintos equipos ayuda a identificar problemas relacionados con compatibilidad, resolución o rendimiento. |
| **4. No existe documentación de resultados** | El plan no contempla registrar si una prueba fue aprobada, falló o presentó observaciones. | Documentar los resultados permite realizar seguimiento de errores y comprobar posteriormente que fueron corregidos. |

---

## b) Caso de prueba 1 reescrito en formato profesional

### Caso de Prueba

**ID:** CP-001

**Módulo:** Visualización del modelo AR

**Prioridad:** Alta

**Precondiciones:**

- La aplicación está instalada correctamente.
- El dispositivo cuenta con soporte para ARCore.
- Los permisos de cámara están habilitados.
- Existe una superficie horizontal detectada.
- La iluminación del entorno es adecuada.

**Estado inicial:**

La aplicación se encuentra ejecutándose y lista para detectar una superficie donde colocar el objeto virtual.

**Pasos:**

1. Iniciar la aplicación.
2. Esperar hasta que el sistema detecte una superficie válida.
3. Pulsar sobre la superficie detectada.
4. Verificar la aparición del modelo de la planta.

**Resultado esperado:**

La planta debe generarse sobre la superficie seleccionada, mantenerse estable y visualizarse correctamente sin presentar errores de posicionamiento.

---

## c) ¿Qué problema revela la frase "esperamos que todo funcione"?

**Respuesta:**

Esta frase evidencia que el equipo basa sus pruebas en una expectativa y no en un proceso de validación planificado.

**Explicación:**

Las pruebas de software deben ejecutarse siguiendo procedimientos definidos y comparando los resultados obtenidos con los resultados esperados. Expresar únicamente que "todo funcione" no establece criterios objetivos para determinar si la aplicación cumple o no con los requisitos de calidad.

**Una redacción más adecuada sería:**

> *"Se realizarán las pruebas establecidas en el plan, registrando los resultados obtenidos y documentando cualquier incidencia para su posterior evaluación y corrección."*

# C.2 — Análisis de código con bugs

## a) Bug A — Acceso incorrecto a la lista de impactos (`hits`)

### ¿En qué línea está el bug?

El error se presenta en la línea:

```csharp
Vector3 posicion = hits[0].pose.position;
```

y también afecta la siguiente instrucción:

```csharp
Instantiate(prefabObjeto, posicion, hits[0].pose.rotation);
```

### ¿Qué excepción lanzará?

La excepción será:

```text
ArgumentOutOfRangeException
```

porque se intenta acceder al primer elemento de la lista cuando esta no contiene ningún resultado.

### ¿Cuándo ocurrirá?

Este problema aparecerá cuando el usuario toque la pantalla y el sistema no detecte ningún plano válido mediante el `Raycast()`. Como la lista `hits` estará vacía, el acceso a `hits[0]` provocará el error.

### Método corregido

```csharp
public void AlTapEnPantalla(Vector2 posicionToque)
{
    if (raycastManager.Raycast(posicionToque, hits, TrackableType.PlaneWithinPolygon))
    {
        Pose pose = hits[0].pose;

        Instantiate(
            prefabObjeto,
            pose.position,
            pose.rotation
        );

        contadorObjetos++;
    }
}
```

**Explicación:**

Antes de utilizar la información obtenida por el `Raycast`, es necesario comprobar que realmente exista un impacto sobre una superficie. Así se evita acceder a posiciones inexistentes dentro de la lista y la aplicación continúa funcionando correctamente aunque no se detecte ningún plano.

---

## b) Bug B — Eliminación indiscriminada de objetos

### ¿Por qué es un problema grave?

El método utiliza:

```csharp
GameObject.FindObjectsOfType<GameObject>();
```

para localizar todos los objetos activos y posteriormente ejecuta:

```csharp
Destroy(obj);
```

sobre cada uno de ellos.

Esto significa que no solo eliminará los modelos creados por el usuario, sino también elementos fundamentales de la aplicación, por ejemplo:

- Cámara AR.
- AR Session.
- AR Session Origin (XR Origin).
- Canvas.
- Botones.
- Administradores del sistema.

Como consecuencia, la escena dejará de funcionar correctamente.

### Corrección

Lo recomendable es destruir únicamente los objetos que fueron creados dinámicamente.

```csharp
private List<GameObject> objetosAR = new List<GameObject>();
```

Cada vez que se instancia un objeto:

```csharp
GameObject objeto = Instantiate(
    prefabObjeto,
    pose.position,
    pose.rotation
);

objetosAR.Add(objeto);
```

Luego, el reinicio queda así:

```csharp
public void ResetearEscena()
{
    foreach(GameObject objeto in objetosAR)
    {
        if(objeto != null)
        {
            Destroy(objeto);
        }
    }

    objetosAR.Clear();
    contadorObjetos = 0;
}
```

**Explicación:**

La aplicación debe eliminar únicamente los objetos que pertenecen al contenido generado por el usuario. De esta manera se protege la infraestructura del sistema AR y se evita perder componentes indispensables para el funcionamiento de la escena.

---

## c) Bug C — Posible referencia nula

### ¿Cuándo ocurrirá?

Sucederá cuando la variable:

```csharp
colorManager
```

no tenga un componente asignado desde el Inspector o haya sido eliminada durante la ejecución.

En ese momento la línea:

```csharp
colorManager.SiguienteModo();
```

intentará utilizar una referencia inexistente y producirá una:

```text
NullReferenceException
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
        Debug.LogWarning("No existe un GestorAccesibilidadColor asignado.");
    }
}
```

**Explicación:**

Antes de utilizar cualquier componente es recomendable comprobar que la referencia exista. Si el objeto no está disponible, la aplicación muestra un aviso y continúa funcionando sin interrumpir la experiencia del usuario.

---

## d) Bug D — Uso ineficiente de `Debug.Log()` en `Update()`

### ¿Cuál es el problema?

El método `Update()` se ejecuta continuamente mientras la aplicación está abierta. Si el contador supera el límite establecido, los tres mensajes se imprimirán en todos los fotogramas.

```csharp
Debug.Log("Máximo de objetos alcanzado");
Debug.Log("Máximo de objetos alcanzado");
Debug.Log("Máximo de objetos alcanzado");
```

Esto provoca:

- Gran cantidad de mensajes repetidos.
- Mayor consumo de recursos.
- Disminución del rendimiento.
- Dificultad para revisar otros errores en la consola.

### Corrección

Mostrar el mensaje solo la primera vez que ocurra la condición.

```csharp
private bool mensajeMostrado = false;

void Update()
{
    if(contadorObjetos > 10 && !mensajeMostrado)
    {
        Debug.LogWarning("Máximo de objetos alcanzado.");
        mensajeMostrado = true;
    }

    if(contadorObjetos <= 10)
    {
        mensajeMostrado = false;
    }
}
```

### Severidad

**Severidad: Menor.**

**Justificación:**

El defecto no impide que la aplicación continúe funcionando, pero sí afecta el rendimiento y genera información innecesaria en la consola, lo que dificulta el monitoreo y mantenimiento del proyecto.

---

# Resumen

| Bug | Problema identificado | Solución propuesta |
|------|----------------------|--------------------|
| **A** | Acceso a `hits[0]` sin comprobar si existen resultados. | Validar el resultado del `Raycast()` antes de acceder a la lista. |
| **B** | Se eliminan todos los GameObjects de la escena. | Destruir únicamente los objetos creados durante la ejecución. |
| **C** | `colorManager` puede ser una referencia nula. | Verificar que el componente exista antes de utilizarlo. |
| **D** | `Debug.Log()` se ejecuta repetidamente en cada `Update()`. | Mostrar el mensaje una sola vez utilizando una variable de control. |
# C.3 — Caso de gestión de bugs: Priorización bajo presión

## a) Priorización de los bugs

Considerando que solo se dispone de **6 horas** para realizar correcciones antes de la presentación al MINEDU, se priorizan los errores que afectan el funcionamiento principal de la aplicación y la experiencia de los usuarios.

| Prioridad | Bug | Tiempo | Justificación |
|-----------|-----|:------:|---------------|
| **1** | **BUG-C** | **3 h** | Este es el problema más importante porque la aplicación no puede iniciarse correctamente en algunos dispositivos Android. Si la app falla al abrirse, no será posible realizar la demostración ni utilizar ninguna de sus funciones. |
| **2** | **BUG-A** | **1 h** | El modelo de Machu Picchu es uno de los elementos principales de la aplicación educativa. Corregir las texturas mejora la comprensión del contenido y ofrece una mejor impresión durante la presentación. |
| **3** | **BUG-D** | **0.5 h** | Los subtítulos deben ser fáciles de leer para todos los estudiantes. Agregar un fondo mejora la visibilidad del texto y fortalece la accesibilidad del recurso educativo. |
| **4** | **BUG-G** | **1.5 h** | Cuando el seguimiento del libro falla, el usuario no recibe ninguna explicación. Incorporar un mensaje informativo ayuda a entender qué ocurrió y cómo solucionar el problema sin generar confusión. |

**Tiempo total utilizado:** **6 horas**

---

## b) Comunicación al cliente (MINEDU)

Algunos aspectos identificados durante las pruebas no podrán ser corregidos antes de la presentación debido al tiempo disponible y a la necesidad de priorizar errores que afectan el funcionamiento principal de la aplicación. Estos puntos ya fueron registrados por el equipo y forman parte del plan de mejoras de la siguiente versión. Ninguno de ellos impide demostrar las funcionalidades educativas previstas para la reunión. Posteriormente se entregará una actualización que incluirá estas mejoras junto con nuevas funciones orientadas a optimizar la experiencia del usuario.

---

## c) Importancia de mostrar mensajes de error cuando falla el tracking

Cuando el sistema pierde el seguimiento del libro, el usuario puede pensar que la aplicación presenta una falla o que dejó de responder. Mostrar un mensaje claro permite explicar qué sucedió y ofrecer indicaciones sencillas para recuperar el seguimiento, como acercar la cámara o colocar el libro en una posición adecuada.

Este tipo de retroalimentación está relacionado con la **accesibilidad cognitiva**, ya que reduce la incertidumbre y facilita que cualquier persona comprenda el comportamiento del sistema. Además, mejora la experiencia de aprendizaje porque el usuario recibe orientación inmediata y puede continuar utilizando la aplicación sin necesidad de ayuda externa.

---

# Resumen

## Bugs priorizados

| Prioridad | Bug | Tiempo |
|:---------:|------|:------:|
| 1 | **BUG-C** | 3 h |
| 2 | **BUG-A** | 1 h |
| 3 | **BUG-D** | 0.5 h |
| 4 | **BUG-G** | 1.5 h |

**Tiempo total:** **6 horas**

---

## Bugs pendientes

| Bug | Motivo |
|------|--------|
| **BUG-B** | Su impacto es reducido y no afecta el funcionamiento principal de la aplicación durante la demostración. |
| **BUG-E** | Es un detalle visual que no influye en la ejecución del sistema. |
| **BUG-F** | Requiere mayor tiempo de desarrollo y será incorporado en una versión posterior como mejora de accesibilidad. |

# SECCIÓN D — SÍNTESIS Y REFLEXIÓN

# Parte D.1 — Plan de pruebas

## 1. Tipos de pruebas

### Pruebas funcionales

**Justificación:**

Estas pruebas permiten verificar que todas las funciones del simulador se ejecuten correctamente, desde el inicio de la práctica hasta la finalización del procedimiento. En un entorno de capacitación médica es indispensable asegurar que cada acción responda de forma correcta para evitar errores durante el aprendizaje.

---

### Pruebas de rendimiento

**Justificación:**

El sistema debe mantener un funcionamiento estable durante toda la sesión de entrenamiento. Es importante comprobar que no existan caídas de rendimiento, tiempos de respuesta elevados o interrupciones que afecten la experiencia inmersiva del usuario.

---

### Pruebas de usabilidad

**Justificación:**

Los técnicos de salud utilizarán la aplicación para aprender procedimientos médicos, por lo que la interfaz debe ser sencilla e intuitiva. Estas pruebas ayudan a confirmar que cualquier usuario pueda comprender las instrucciones y completar la capacitación sin dificultades.

---

## 2. Casos de prueba

### Caso de prueba 1

**ID:** CP-001

**Precondiciones:**

- Headset correctamente configurado.
- Aplicación instalada.

**Pasos:**

1. Abrir la aplicación.
2. Seleccionar el módulo de capacitación.

**Resultado esperado:**

El escenario VR inicia correctamente y carga todos los elementos necesarios.

---

### Caso de prueba 2

**ID:** CP-002

**Precondiciones:**

Escenario iniciado.

**Pasos:**

1. Manipular los instrumentos médicos virtuales.
2. Ejecutar el procedimiento indicado.

**Resultado esperado:**

Los objetos responden correctamente a la interacción del usuario.

---

### Caso de prueba 3

**ID:** CP-003

**Precondiciones:**

Sesión de práctica en ejecución.

**Pasos:**

1. Completar el procedimiento obstétrico.
2. Finalizar la simulación.

**Resultado esperado:**

El sistema registra el desempeño y muestra la evaluación correspondiente.

---

### Caso de prueba 4

**ID:** CP-004

**Precondiciones:**

Aplicación funcionando normalmente.

**Pasos:**

1. Mantener una sesión continua durante 30 minutos.

**Resultado esperado:**

La aplicación conserva un rendimiento estable sin cierres inesperados.

---

### Caso de prueba 5

**ID:** CP-005

**Precondiciones:**

Aplicación instalada.

**Pasos:**

1. Reiniciar el visor VR.
2. Abrir nuevamente la aplicación.

**Resultado esperado:**

La aplicación inicia correctamente y mantiene la información del usuario.

---

## 3. Criterios de aceptación

- El simulador debe ejecutar todas las funciones principales sin errores.
- No deben presentarse fallos críticos durante el entrenamiento.
- El rendimiento debe mantenerse estable durante toda la práctica.
- Las instrucciones deben ser claras y comprensibles.
- El progreso y los resultados del usuario deben almacenarse correctamente.

---

## 4. Protocolo ante un bug crítico

Si se detecta un error crítico un día antes del despliegue, el equipo debe analizar inmediatamente el impacto que tendría sobre la capacitación. Si el fallo compromete la seguridad, la estabilidad o el correcto desarrollo de la simulación, se debe detener el despliegue hasta solucionar el problema y validar nuevamente el sistema. La decisión debe priorizar la confiabilidad del producto antes que cumplir con la fecha programada.

---

# Parte D.2 — Pruebas de accesibilidad críticas

| Barrera | ¿Cómo probarla? | Criterio de aceptación |
|----------|-----------------|-------------------------|
| Poco conocimiento del uso de dispositivos VR | Solicitar a usuarios sin experiencia que completen el entrenamiento utilizando únicamente las instrucciones del sistema. | Los usuarios logran completar la práctica sin requerir asistencia externa. |
| Limitaciones de conectividad en zonas rurales | Ejecutar la aplicación sin conexión a internet durante toda la capacitación. | El simulador funciona correctamente utilizando únicamente los recursos almacenados localmente. |
| Uso prolongado del visor VR | Realizar sesiones continuas y registrar posibles molestias o fatiga de los usuarios. | La mayoría de participantes completa la práctica sin presentar incomodidad significativa. |

---

# Parte D.3 — Reflexión sobre perseverancia

En aplicaciones destinadas al sector salud, el nivel de exigencia durante las pruebas es mucho mayor que en un videojuego. Antes de implementar el sistema es necesario comprobar repetidamente que cada función opere de manera correcta, ya que los conocimientos adquiridos mediante la simulación serán utilizados posteriormente en situaciones reales.

La perseverancia permite identificar errores que podrían pasar desapercibidos durante una única prueba. Repetir las validaciones en diferentes condiciones aumenta la confiabilidad del sistema y reduce la probabilidad de que ocurran fallos durante su uso.

Por ejemplo, si el simulador presenta un error al enseñar un procedimiento obstétrico y dicho problema no se detecta antes del despliegue, un técnico podría aprender una secuencia incorrecta de atención. Esto podría afectar la calidad de la atención brindada a una paciente durante una emergencia real. Por esa razón, en proyectos relacionados con la salud es indispensable mantener un proceso de pruebas constante hasta asegurar que el sistema cumple con los estándares requeridos.

---

