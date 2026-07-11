# SECCIÓN A — OPCIÓN MÚLTIPLE (25 puntos, 2.5 pts c/u)

**Estudiante:** Palacios Vergaray Jhener Erick **Código:** 2231890156
**Fecha:** 10/07/2026 | **Puntuación total:** ____/20

## A1.

Según el modelo social de la discapacidad, cuando un usuario en silla de ruedas no puede usar una app de VR que requiere ponerse de pie para alcanzar objetos, el problema principal es:

- [ ] a) La condición médica del usuario que le impide ponerse de pie
- [x] b) El diseño de la app que no consideró usuarios con movilidad reducida
- [ ] c) La tecnología VR que todavía no está madura para casos especiales
- [ ] d) El usuario, quien debería usar una versión diferente de la app para discapacitados

**Respuesta:** b) El diseño de la app que no consideró usuarios con movilidad reducida.

**Explicación:**  
El modelo social de la discapacidad sostiene que la principal barrera no es la condición de la persona, sino el entorno o el diseño del sistema. En este caso, la aplicación no fue diseñada considerando usuarios que utilizan silla de ruedas.

---

## A2.

¿Cuál es el ratio de contraste mínimo que exige WCAG 2.1 nivel AA para texto normal sobre fondo?

- [ ] a) 2:1
- [ ] b) 3:1
- [x] c) 4.5:1
- [ ] d) 7:1

**Respuesta:** c) 4.5:1

**Explicación:**  
Las pautas WCAG 2.1 establecen un contraste mínimo de **4.5:1** para texto normal, garantizando una adecuada legibilidad para personas con baja visión.

---

## A3.

Un usuario con **daltonismo rojo-verde (deuteranopia)** usa tu app AR de medicina donde el color rojo indica tejido dañado y verde indica tejido sano. ¿Cuál es la solución de accesibilidad más completa?

- [ ] a) Eliminar todos los colores rojo y verde de la app y usar solo escala de grises
- [ ] b) Agregar un modo especial "para daltónicos" con colores diferentes
- [x] c) Mantener los colores pero añadir forma, icono de advertencia y texto overlay como canales adicionales de información
- [ ] d) Informar al usuario que la app no es compatible con daltonismo en los términos de servicio

**Respuesta:** c) Mantener los colores pero añadir forma, icono de advertencia y texto overlay como canales adicionales de información.

**Explicación:**  
La accesibilidad recomienda no depender únicamente del color para transmitir información. Agregar iconos, formas y texto permite que cualquier usuario pueda interpretar correctamente el contenido.

---

## A4.

La técnica "Dwell Time" en VR/AR permite:

- [ ] a) Ajustar el tiempo de renderizado de frames para mejorar rendimiento
- [x] b) Seleccionar objetos simplemente mirándolos durante un tiempo configurado, sin usar las manos
- [ ] c) Medir cuánto tiempo el usuario pasa dentro de una sesión VR
- [ ] d) Controlar la velocidad de locomoción para reducir cybersickness

**Respuesta:** b) Seleccionar objetos simplemente mirándolos durante un tiempo configurado, sin usar las manos.

**Explicación:**  
La técnica **Dwell Time** facilita la interacción mediante la mirada. Cuando el usuario fija la vista sobre un objeto durante un tiempo determinado, este se selecciona automáticamente, mejorando la accesibilidad para personas con movilidad reducida.

---

## A5.

¿Por qué el texto AR sobre fondo transparente es particularmente problemático para personas con baja visión?

- [ ] a) Porque el rendering de texto transparente consume más GPU
- [ ] b) Porque el texto flotante parece falso y rompe la ilusión de realidad
- [x] c) Porque el fondo del mundo real es variable e impredecible, haciendo imposible garantizar contraste suficiente
- [ ] d) Porque el texto AR requiere un shader especial incompatible con la mayoría de dispositivos

**Respuesta:** c) Porque el fondo del mundo real es variable e impredecible, haciendo imposible garantizar contraste suficiente.

**Explicación:**  
En realidad aumentada el fondo cambia constantemente según el entorno del usuario. Esto dificulta mantener un contraste adecuado, por lo que normalmente se utilizan paneles semitransparentes detrás del texto.

---

## A6.

El **cybersickness** se produce principalmente por:

- [ ] a) La calidad baja de los gráficos en entornos VR económicos
- [x] b) Una discordancia entre la información visual (movimiento en VR) y la información vestibular (el cuerpo no se mueve)
- [ ] c) La duración excesiva de la sesión VR sin descanso
- [ ] d) El peso del headset que causa fatiga en el cuello

**Respuesta:** b) Una discordancia entre la información visual (movimiento en VR) y la información vestibular (el cuerpo no se mueve).

**Explicación:**  
El cybersickness aparece cuando lo que perciben los ojos no coincide con lo que detecta el sistema vestibular del oído interno, provocando síntomas como mareo, náuseas y desorientación.

---

## A7.

¿Qué es el documento **XAUR** (XR Accessibility User Requirements)?

- [ ] a) Un SDK de Unity para implementar accesibilidad en proyectos XR
- [x] b) La extensión de WCAG publicada por el W3C para definir requisitos de accesibilidad específicos para XR
- [ ] c) El estándar legal obligatorio de accesibilidad XR en la Unión Europea
- [ ] d) Una herramienta de diagnóstico de accesibilidad para headsets Meta Quest

**Respuesta:** b) La extensión de WCAG publicada por el W3C para definir requisitos de accesibilidad específicos para XR.

**Explicación:**  
XAUR es un documento desarrollado por el **W3C** que reúne recomendaciones de accesibilidad específicas para aplicaciones de realidad aumentada, realidad virtual y realidad mixta.

---

## A8.

En el script `SubtitulosXR.cs` visto en clase, el método se coloca en `LateUpdate()` en lugar de `Update()` porque:

- [ ] a) `LateUpdate()` es más eficiente en términos de memoria para cálculos de UI
- [x] b) `LateUpdate()` se ejecuta después de que la cámara se ha movido, garantizando que los subtítulos se posicionen correctamente respecto a la posición final de la cámara en ese frame
- [ ] c) `LateUpdate()` es el único ciclo de vida que permite modificar transformaciones en VR
- [ ] d) `Update()` no puede acceder a la posición de la cámara, solo `LateUpdate()` puede

**Respuesta:** b) `LateUpdate()` se ejecuta después de que la cámara se ha movido, garantizando que los subtítulos se posicionen correctamente respecto a la posición final de la cámara en ese frame.

**Explicación:**  
Al ejecutarse después de `Update()`, **LateUpdate()** permite que la posición de la cámara ya esté actualizada antes de colocar los subtítulos, evitando movimientos o desfases visuales.

---

## A9.

El "efecto bordillo" (curb cut effect) en diseño accesible se refiere a:

- [ ] a) La necesidad de añadir rampas en todas las entradas de edificios
- [x] b) El principio de que las soluciones diseñadas para personas con discapacidad terminan beneficiando a todos los usuarios
- [ ] c) La técnica de diseño que coloca todos los elementos de UI cerca del borde inferior de la pantalla
- [ ] d) El problema de la fatiga de brazo cuando los menús están muy separados en VR

**Respuesta:** b) El principio de que las soluciones diseñadas para personas con discapacidad terminan beneficiando a todos los usuarios.

**Explicación:**  
El efecto bordillo demuestra que muchas soluciones creadas para mejorar la accesibilidad terminan siendo útiles para toda la población, como las rampas, los subtítulos o los asistentes por voz.

---

## A10.

¿Cuál es la diferencia clave entre **locomoción libre** y **teleportación** en VR desde el punto de vista de la accesibilidad?

- [ ] a) La teleportación es más difícil de implementar y solo se usa en apps avanzadas
- [ ] b) La locomoción libre permite moverse más rápido y es preferida por usuarios profesionales
- [x] c) La locomoción libre con joystick puede causar cybersickness ya que el cuerpo no se mueve físicamente, mientras la teleportación elimina esa discordancia
- [ ] d) No hay diferencia significativa en accesibilidad, solo en la sensación de inmersión

**Respuesta:** c) La locomoción libre con joystick puede causar cybersickness ya que el cuerpo no se mueve físicamente, mientras la teleportación elimina esa discordancia.

**Explicación:**  
La locomoción mediante joystick puede provocar mareos porque el usuario percibe movimiento visual sin desplazamiento físico. La teleportación reduce este efecto y mejora la accesibilidad para personas sensibles al cybersickness.

# SECCIÓN B — COMPLETAR Y RELACIONAR (22 puntos)

## B1 — Completar espacios en blanco (12 puntos, 2 pts c/u)

### 1.

WCAG son las siglas de **Web Content Accessibility Guidelines** y sus cuatro principios (POUR) son: Perceptible, **Operable**, Comprensible y Robusto.

**Respuesta:**  
- **Web Content Accessibility Guidelines**
- **Operable**

**Explicación:**  
Las WCAG son un conjunto de pautas internacionales para desarrollar contenido digital accesible. Sus principios POUR establecen que toda interfaz debe ser perceptible, operable, comprensible y robusta.

---

### 2.

El componente de Unity que permite asignar una etiqueta accesible y descripción a cualquier GameObject para que el lector de pantalla del sistema operativo los pueda leer se llama **Accessibility Node**.

**Respuesta:** **Accessibility Node**

**Explicación:**  
Este componente permite asociar información descriptiva a los objetos de la escena para que pueda ser interpretada por tecnologías de asistencia como los lectores de pantalla.

---

### 3.

El **cybersickness** es el conjunto de síntomas de náusea, desorientación y malestar causado por la discordancia entre la información visual del entorno VR y las señales del sistema vestibular.

**Respuesta:** **Cybersickness**

**Explicación:**  
Este fenómeno ocurre cuando existe una diferencia entre el movimiento que perciben los ojos y el que realmente detecta el cuerpo, generando incomodidad durante la experiencia de realidad virtual.

---

### 4.

Para que el texto en AR sea legible independientemente del fondo del mundo real, se debe añadir un **backing panel** semiopaco detrás del texto.

**Respuesta:** **Backing panel**

**Explicación:**  
El panel de fondo mejora el contraste entre el texto y el entorno real, facilitando la lectura incluso cuando el fondo presenta colores o imágenes muy variables.

---

### 5.

Según WCAG 2.1, las imágenes o elementos que contienen información no deben usar **el color** como único medio de transmitir esa información; deben incluir también forma, patrón o texto.

**Respuesta:** **El color**

**Explicación:**  
La información importante debe presentarse mediante diferentes recursos visuales para que pueda ser comprendida por personas con alteraciones en la percepción del color.

---

### 6.

La organización que publicó el documento XAUR (XR Accessibility User Requirements) es el **W3C (World Wide Web Consortium)**.

**Respuesta:** **W3C (World Wide Web Consortium)**

**Explicación:**  
El W3C desarrolla estándares internacionales relacionados con la accesibilidad web y también publica recomendaciones específicas para tecnologías XR mediante el documento XAUR.

---

# B2 — Relacionar columnas (10 puntos, 1 pt c/u)

| # | Barrera de accesibilidad | Respuesta | Solución en XR |
|:-:|--------------------------|:--------:|----------------|
| 1 | Usuario sordo no puede escuchar narración de audio en VR | **C** | Subtítulos 3D anclados a la cámara (head-locked). |
| 2 | Usuario con daltonismo no distingue zonas de peligro codificadas en rojo | **D** | Iconos de forma + texto "PELIGRO" redundante al color. |
| 3 | Texto AR ilegible sobre fondos claros del mundo real | **A** | Backing panel semiopaco + texto outline. |
| 4 | Usuario con Parkinson no puede presionar botones pequeños del controller | **F** | Botones más grandes + zona de toque ampliada + modo hold. |
| 5 | Primera vez en VR — usuario adulto mayor siente náuseas con joystick | **E** | Modo teleportación + vignette dinámico + velocidad ajustable. |
| 6 | Usuario con autismo siente sobrecarga sensorial con muchos estímulos | **G** | Modo calma: reducir objetos, sonidos y velocidad. |
| 7 | Usuario en silla de ruedas no puede alcanzar objetos colocados muy arriba en VR | **H** | Reposicionar la interfaz dentro del rango de movimiento sentado. |
| 8 | App sin modo pausa: usuario con epilepsia expuesto a flashes continuos | **J** | Configurar una tasa máxima de destellos y ofrecer un botón de pausa siempre visible. |
| 9 | App de entrenamiento VR usa solo audio para dar feedback de errores | **I** | Semáforos, iconos y vibración como canales adicionales. |
| 10 | Usuario ciego quiere explorar objetos 3D en un museo VR | **K** | Audio descriptivo espacial + hápticos de confirmación. |

## Respuestas finales

| Nº | Respuesta |
|:--:|:---------:|
| 1 | **C** |
| 2 | **D** |
| 3 | **A** |
| 4 | **F** |
| 5 | **E** |
| 6 | **G** |
| 7 | **H** |
| 8 | **J** |
| 9 | **I** |
| 10 | **K** |

# SECCIÓN C — ANÁLISIS Y DIAGNÓSTICO (28 puntos)

## C1 — Diagnóstico de código con problemas de accesibilidad (12 puntos)

El siguiente script presenta varios problemas de accesibilidad que pueden dificultar su uso por personas con discapacidad visual, auditiva, motora y cognitiva.

| # | Línea(s) | Problema de accesibilidad | Tipo de discapacidad afectada | Solución correcta |
|---:|-----------|--------------------------|-------------------------------|-------------------|
| 1 | `imagenEstado.color = Color.green;` y `imagenEstado.color = Color.red;` | El estado de la aplicación se comunica únicamente mediante colores. | Discapacidad visual (daltonismo). | Añadir texto descriptivo e iconos que indiquen claramente el estado del sistema. |
| 2 | `sizeDelta = new Vector2(80,25);` | Los botones son demasiado pequeños para algunos usuarios. | Discapacidad motora y adultos mayores. | Aumentar el tamaño de los botones y ampliar la zona de interacción. |
| 3 | `Invoke("CerrarSesion",60f);` | La aplicación se cierra automáticamente sin avisar al usuario. | Discapacidad cognitiva y motora. | Mostrar una advertencia antes del cierre y permitir ampliar o cancelar el tiempo de espera. |
| 4 | `velocidadParpadeo = 8f;` | El parpadeo rápido puede provocar molestias o crisis fotosensibles. | Epilepsia fotosensible y sensibilidad visual. | Reducir la frecuencia del parpadeo o permitir desactivar la animación. |
| 5 | `alarma.Play();` | La alerta se comunica únicamente mediante sonido. | Discapacidad auditiva. | Incorporar subtítulos, mensajes visuales e indicadores hápticos. |
| 6 | `// No hay feedback de texto — solo color y sonido` | No existe retroalimentación accesible para todos los usuarios. | Discapacidad visual, auditiva y cognitiva. | Utilizar varios canales de información como texto, iconos, sonido y vibración. |

### Conclusión

El código depende principalmente del color y del sonido para comunicar información al usuario. Una aplicación accesible debe ofrecer diferentes formas de interacción y retroalimentación para que cualquier persona pueda utilizarla independientemente de sus capacidades.

---

# C2 — Comparación: Audio Narration vs Spatial Audio Descriptions (8 puntos)

### 1. ¿Cuál enfoque representa mejor el modelo social de la discapacidad? Justifica.

El **Enfoque B** representa mejor el modelo social de la discapacidad, porque adapta la aplicación a las necesidades del usuario. En lugar de obligar a la persona a memorizar toda la información al inicio, proporciona descripciones cuando realmente las necesita, permitiendo una navegación más independiente.

---

### 2. ¿Qué limitaciones tiene el Enfoque A que el Enfoque B no tiene?

El Enfoque A presenta varias limitaciones:

- El usuario debe recordar una gran cantidad de información.
- No proporciona información actualizada durante la exploración.
- No identifica qué objeto está cerca del usuario.
- La descripción puede perder utilidad si el escenario cambia.
- Hace la navegación menos interactiva.

El Enfoque B evita estas limitaciones porque describe únicamente el objeto con el que el usuario está interactuando en ese momento.

---

### 3. ¿En qué tipo de app VR el Enfoque A sería más apropiado que el B?

El Enfoque A sería adecuado para aplicaciones donde el recorrido es lineal y la información no cambia constantemente, por ejemplo:

- Museos virtuales guiados.
- Documentales inmersivos.
- Presentaciones educativas.
- Experiencias narrativas.
- Visitas virtuales con un recorrido definido.

---

### 4. ¿Cómo implementarías el Enfoque B en Unity a nivel técnico (qué componente y evento usarías)?

Cada objeto importante tendría un componente **AudioSource** con su descripción correspondiente y un **Collider** configurado como Trigger.

Cuando el usuario se acerque al objeto, el evento `OnTriggerEnter()` reproducirá automáticamente la descripción.

```csharp
using UnityEngine;

public class AudioDescripcion : MonoBehaviour
{
    public AudioSource descripcion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            descripcion.Play();
        }
    }
}
```

También puede implementarse mediante **XR Ray Interactor**, reproduciendo el audio cuando el usuario dirija la mirada al objeto utilizando eventos como **Hover Entered** o **Select Entered**.

---

# C3 — Caso: App de rehabilitación física en VR (8 puntos)

| Paciente | Barrera 1 | Solución 1 | Barrera 2 | Solución 2 |
|----------|-----------|------------|-----------|------------|
| **A (65 años, cirugía de hombro)** | Puede sentir mareos al desplazarse con joystick. | Utilizar teleportación y un tutorial guiado antes de iniciar la sesión. | Los ejercicios pueden exigir movimientos superiores a su capacidad física. | Calibrar el rango máximo de movimiento antes de comenzar la terapia. |
| **B (Parálisis parcial de mano derecha)** | Dificultad para utilizar el controlador derecho. | Permitir configurar controles con una sola mano o mediante seguimiento de manos. | No puede realizar acciones que requieren ambas manos simultáneamente. | Adaptar los ejercicios para ejecutarlos con una sola extremidad cuando sea necesario. |
| **C (Sordo desde nacimiento)** | No puede escuchar instrucciones o avisos de audio. | Mostrar subtítulos 3D permanentes y mensajes visuales. | No percibe sonidos de confirmación o error. | Utilizar iconos, cambios visuales y vibración en los controles. |
| **D (Daltonismo rojo-verde, cirugía en ambos codos)** | No distingue correctamente indicadores basados solo en colores. | Añadir iconos, formas y texto además del color. | Tiene limitación para extender completamente ambos brazos. | Reubicar los objetos interactivos y ajustar la dificultad según el rango de movimiento disponible. |

### Conclusión

Una aplicación de rehabilitación en realidad virtual debe adaptarse a las características de cada paciente. Para ello es importante ofrecer diferentes métodos de interacción, retroalimentación visual y auditiva, así como permitir configurar la intensidad y dificultad de los ejercicios según las necesidades individuales.

# SECCIÓN D — CASO AVANZADO (25 puntos)

# Caso: Sistema XR de Educación Inclusiva para Zonas Rurales del Perú

## Parte 1 — Análisis de requerimientos de accesibilidad (8 puntos)

### 1. ¿Qué tipos de discapacidad debes considerar? ¿Por qué?

Para este proyecto es necesario considerar diferentes tipos de discapacidad, ya que el sistema será utilizado por estudiantes con diversas necesidades de aprendizaje.

- **Discapacidad visual:** algunos estudiantes pueden presentar baja visión o ceguera parcial, por lo que será necesario incorporar narraciones, audio descriptivo, alto contraste y textos de gran tamaño.
- **Discapacidad auditiva:** las explicaciones por voz deberán complementarse con subtítulos, iconos y elementos visuales para que toda la información pueda comprenderse sin depender del audio.
- **Discapacidad motora:** algunos estudiantes pueden presentar movilidad reducida en brazos o manos, por lo que el sistema debe ofrecer botones grandes, selección por mirada y controles simplificados.
- **Discapacidad cognitiva o dificultades de aprendizaje:** las actividades deben ser sencillas, con instrucciones claras, lenguaje simple y apoyo mediante imágenes y ejemplos interactivos.

Considerar estas necesidades permitirá que todos los estudiantes participen en igualdad de condiciones durante las actividades educativas.

---

### 2. ¿Qué restricciones del contexto afectan las soluciones de accesibilidad?

El contexto rural presenta varias limitaciones que deben tenerse en cuenta durante el diseño del sistema.

- **Conectividad limitada:** el sistema debe funcionar sin conexión permanente a Internet, almacenando todos los recursos de manera local.
- **Presupuesto reducido:** al utilizar dispositivos económicos como Cardboard o Quest Go, las aplicaciones deben estar optimizadas para consumir pocos recursos.
- **Docentes sin conocimientos técnicos:** la interfaz debe ser intuitiva y fácil de utilizar, evitando configuraciones complejas.
- **Equipos compartidos:** varios estudiantes utilizarán el mismo dispositivo, por lo que el cambio entre usuarios debe realizarse rápidamente.
- **Infraestructura limitada:** el sistema debe requerir poco mantenimiento y funcionar correctamente incluso en colegios con pocos recursos tecnológicos.

---

### 3. ¿Qué contenidos presentan desafíos de accesibilidad?

Los temas de ciencias naturales incluyen procesos que normalmente se representan mediante imágenes, colores y animaciones.

- **Ciclo del agua:** utiliza flechas, colores y movimientos que deben complementarse con narraciones y etiquetas descriptivas.
- **Fotosíntesis:** requiere diferenciar elementos como dióxido de carbono, agua, oxígeno y luz solar, por lo que no debe depender únicamente del color.
- **Ecosistemas:** contiene numerosos organismos y relaciones entre ellos, siendo necesario incorporar audio descriptivo, subtítulos e iconografía para facilitar la comprensión.

---

# Parte 2 — Propuesta de diseño inclusivo (10 puntos)

El sistema XR debe ser sencillo de utilizar, accesible para todos los estudiantes y compatible con dispositivos de bajo costo.

## Características de accesibilidad

### 1. Subtítulos inteligentes

Todas las explicaciones del docente y las narraciones aparecerán como subtítulos sincronizados en español. Además, podrán mostrarse en quechua cuando el profesor seleccione este idioma al iniciar la aplicación.

---

### 2. Narración y audio descriptivo

Cada objeto importante del escenario contará con una descripción en audio que se reproducirá cuando el estudiante se acerque o lo seleccione. Esto permitirá que los alumnos con baja visión comprendan el contenido sin depender únicamente de elementos gráficos.

---

### 3. Modo de alto contraste

La aplicación incluirá un botón para activar un modo de alto contraste que aumentará el tamaño de las letras, cambiará los colores de la interfaz y añadirá un fondo oscuro detrás de los textos para mejorar su legibilidad.

---

### 4. Selección por mirada (Dwell Time)

Los estudiantes podrán interactuar con los botones simplemente mirando un elemento durante unos segundos, evitando depender exclusivamente de controles físicos o movimientos precisos de las manos.

---

### 5. Información mediante múltiples canales

La aplicación no utilizará únicamente colores para transmitir información. Cada mensaje importante combinará:

- Texto descriptivo.
- Iconos.
- Colores.
- Sonidos.
- Vibración (cuando el dispositivo lo permita).

De esta manera, todos los estudiantes podrán comprender el contenido independientemente de sus capacidades sensoriales.

---

### Adaptación automática del sistema

Al iniciar la aplicación, el docente responderá un breve cuestionario indicando las necesidades del estudiante.

Con esa información, el sistema activará automáticamente las funciones de accesibilidad correspondientes, como:

- Subtítulos.
- Alto contraste.
- Letras grandes.
- Audio descriptivo.
- Dwell Time.
- Velocidad reducida de animaciones.

Esto evita configuraciones técnicas complejas y facilita el uso por parte de cualquier profesor.

---

### Característica creativa

Como propuesta innovadora para el contexto peruano, el sistema incorporará un **Asistente Educativo Intercultural**.

Este asistente explicará los contenidos de ciencias utilizando ejemplos relacionados con el entorno local de Ayacucho y Huancavelica, como los ríos, montañas, cultivos y ecosistemas propios de la región. Además, podrá reproducir las explicaciones tanto en español como en quechua, favoreciendo una educación más inclusiva y cercana a la realidad de los estudiantes.