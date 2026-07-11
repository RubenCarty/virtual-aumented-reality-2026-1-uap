# SECCIÓN A — OPCIÓN MÚLTIPLE (25 puntos, 2.5 pts c/u)

**Estudiante:** Salazar Mondragón Jael Santiago  **Código: 2221898131** 
**Fecha:** 10/07/2026 | **Puntuación total:** ____/20

## A1.

Según el modelo social de la discapacidad, cuando un usuario en silla de ruedas no puede usar una app de VR que requiere ponerse de pie para alcanzar objetos, el problema principal es:

- [ ] a) La condición médica del usuario que le impide ponerse de pie
- [x] b) El diseño de la app que no consideró usuarios con movilidad reducida
- [ ] c) La tecnología VR que todavía no está madura para casos especiales
- [ ] d) El usuario, quien debería usar una versión diferente de la app para discapacitados

**Respuesta:** b) El diseño de la app que no consideró usuarios con movilidad reducida.

**Explicación:**  
El modelo social considera que las limitaciones aparecen cuando un producto o servicio no está diseñado para atender la diversidad de usuarios. En este caso, la aplicación excluye a quienes no pueden interactuar de pie.

---

## A2.

¿Cuál es el ratio de contraste mínimo que exige WCAG 2.1 nivel AA para texto normal sobre fondo?

- [ ] a) 2:1
- [ ] b) 3:1
- [x] c) 4.5:1
- [ ] d) 7:1

**Respuesta:** c) 4.5:1

**Explicación:**  
Este nivel de contraste facilita que personas con baja visión puedan leer el contenido sin dificultad, mejorando la percepción del texto sobre distintos fondos.

---

## A3.

Un usuario con **daltonismo rojo-verde (deuteranopia)** usa tu app AR de medicina donde el color rojo indica tejido dañado y verde indica tejido sano. ¿Cuál es la solución de accesibilidad más completa?

- [ ] a) Eliminar todos los colores rojo y verde de la app y usar solo escala de grises
- [ ] b) Agregar un modo especial "para daltónicos" con colores diferentes
- [x] c) Mantener los colores pero añadir forma, icono de advertencia y texto overlay como canales adicionales de información
- [ ] d) Informar al usuario que la app no es compatible con daltonismo en los términos de servicio

**Respuesta:** c) Mantener los colores pero añadir forma, icono de advertencia y texto overlay como canales adicionales de información.

**Explicación:**  
Una interfaz accesible ofrece la misma información mediante diferentes recursos visuales. Así, si el usuario no distingue los colores, puede comprender el contenido mediante símbolos o textos.

---

## A4.

La técnica "Dwell Time" en VR/AR permite:

- [ ] a) Ajustar el tiempo de renderizado de frames para mejorar rendimiento
- [x] b) Seleccionar objetos simplemente mirándolos durante un tiempo configurado, sin usar las manos
- [ ] c) Medir cuánto tiempo el usuario pasa dentro de una sesión VR
- [ ] d) Controlar la velocidad de locomoción para reducir cybersickness

**Respuesta:** b) Seleccionar objetos simplemente mirándolos durante un tiempo configurado, sin usar las manos.

**Explicación:**  
Esta técnica permite interactuar únicamente con la mirada. Después de mantener el enfoque durante unos segundos, la acción se ejecuta automáticamente sin necesidad de utilizar controles físicos.

---

## A5.

¿Por qué el texto AR sobre fondo transparente es particularmente problemático para personas con baja visión?

- [ ] a) Porque el rendering de texto transparente consume más GPU
- [ ] b) Porque el texto flotante parece falso y rompe la ilusión de realidad
- [x] c) Porque el fondo del mundo real es variable e impredecible, haciendo imposible garantizar contraste suficiente
- [ ] d) Porque el texto AR requiere un shader especial incompatible con la mayoría de dispositivos

**Respuesta:** c) Porque el fondo del mundo real es variable e impredecible, haciendo imposible garantizar contraste suficiente.

**Explicación:**  
Como el fondo cambia constantemente según el entorno real, el texto puede mezclarse con colores o elementos similares, dificultando su lectura para personas con visión reducida.

---

## A6.

El **cybersickness** se produce principalmente por:

- [ ] a) La calidad baja de los gráficos en entornos VR económicos
- [x] b) Una discordancia entre la información visual (movimiento en VR) y la información vestibular (el cuerpo no se mueve)
- [ ] c) La duración excesiva de la sesión VR sin descanso
- [ ] d) El peso del headset que causa fatiga en el cuello

**Respuesta:** b) Una discordancia entre la información visual (movimiento en VR) y la información vestibular (el cuerpo no se mueve).

**Explicación:**  
El cerebro recibe información contradictoria entre lo que observa y lo que percibe el equilibrio corporal, lo que puede provocar mareos, náuseas y sensación de desorientación.

---

## A7.

¿Qué es el documento **XAUR** (XR Accessibility User Requirements)?

- [ ] a) Un SDK de Unity para implementar accesibilidad en proyectos XR
- [x] b) La extensión de WCAG publicada por el W3C para definir requisitos de accesibilidad específicos para XR
- [ ] c) El estándar legal obligatorio de accesibilidad XR en la Unión Europea
- [ ] d) Una herramienta de diagnóstico de accesibilidad para headsets Meta Quest

**Respuesta:** b) La extensión de WCAG publicada por el W3C para definir requisitos de accesibilidad específicos para XR.

**Explicación:**  
XAUR reúne recomendaciones orientadas a que las experiencias de realidad extendida puedan ser utilizadas por personas con diferentes capacidades y necesidades.

---

## A8.

En el script `SubtitulosXR.cs` visto en clase, el método se coloca en `LateUpdate()` en lugar de `Update()` porque:

- [ ] a) `LateUpdate()` es más eficiente en términos de memoria para cálculos de UI
- [x] b) `LateUpdate()` se ejecuta después de que la cámara se ha movido, garantizando que los subtítulos se posicionen correctamente respecto a la posición final de la cámara en ese frame
- [ ] c) `LateUpdate()` es el único ciclo de vida que permite modificar transformaciones en VR
- [ ] d) `Update()` no puede acceder a la posición de la cámara, solo `LateUpdate()` puede

**Respuesta:** b) `LateUpdate()` se ejecuta después de que la cámara se ha movido, garantizando que los subtítulos se posicionen correctamente respecto a la posición final de la cámara en ese frame.

**Explicación:**  
Al actualizar los subtítulos al final del ciclo de renderizado, estos permanecen alineados con la posición definitiva de la cámara y ofrecen una visualización más estable.

---

## A9.

El "efecto bordillo" (curb cut effect) en diseño accesible se refiere a:

- [ ] a) La necesidad de añadir rampas en todas las entradas de edificios
- [x] b) El principio de que las soluciones diseñadas para personas con discapacidad terminan beneficiando a todos los usuarios
- [ ] c) La técnica de diseño que coloca todos los elementos de UI cerca del borde inferior de la pantalla
- [ ] d) El problema de la fatiga de brazo cuando los menús están muy separados en VR

**Respuesta:** b) El principio de que las soluciones diseñadas para personas con discapacidad terminan beneficiando a todos los usuarios.

**Explicación:**  
Muchas funciones creadas para mejorar la accesibilidad también hacen que el producto sea más cómodo, práctico y fácil de utilizar para cualquier persona.

---

## A10.

¿Cuál es la diferencia clave entre **locomoción libre** y **teleportación** en VR desde el punto de vista de la accesibilidad?

- [ ] a) La teleportación es más difícil de implementar y solo se usa en apps avanzadas
- [ ] b) La locomoción libre permite moverse más rápido y es preferida por usuarios profesionales
- [x] c) La locomoción libre con joystick puede causar cybersickness ya que el cuerpo no se mueve físicamente, mientras la teleportación elimina esa discordancia
- [ ] d) No hay diferencia significativa en accesibilidad, solo en la sensación de inmersión

**Respuesta:** c) La locomoción libre con joystick puede causar cybersickness ya que el cuerpo no se mueve físicamente, mientras la teleportación elimina esa discordancia.

**Explicación:**  
La teleportación disminuye la sensación de movimiento continuo que suele provocar malestar en algunos usuarios, ofreciendo una experiencia más cómoda y accesible para personas sensibles al movimiento virtual.

# SECCIÓN B — COMPLETAR Y RELACIONAR (22 puntos)

## B1 — Completar espacios en blanco (12 puntos, 2 pts c/u)

### 1.

WCAG son las siglas de **Web Content Accessibility Guidelines** y sus cuatro principios (POUR) son: Perceptible, **Operable**, Comprensible y Robusto.

**Respuesta:**  
- **Web Content Accessibility Guidelines**
- **Operable**

**Explicación:**  
Las WCAG proporcionan criterios para que los contenidos digitales puedan ser utilizados por la mayor cantidad posible de personas. Uno de sus principios es que todas las funciones de la interfaz deben poder utilizarse fácilmente por cualquier usuario.

---

### 2.

El componente de Unity que permite asignar una etiqueta accesible y descripción a cualquier GameObject para que el lector de pantalla del sistema operativo los pueda leer se llama **Accessibility Node**.

**Respuesta:** **Accessibility Node**

**Explicación:**  
Este componente añade información descriptiva a los objetos de la escena, permitiendo que los sistemas de accesibilidad identifiquen y comuniquen su función al usuario.

---

### 3.

El **cybersickness** es el conjunto de síntomas de náusea, desorientación y malestar causado por la discordancia entre la información visual del entorno VR y las señales del sistema vestibular.

**Respuesta:** **Cybersickness**

**Explicación:**  
Es un efecto secundario común en realidad virtual que aparece cuando el usuario percibe un movimiento visual diferente al movimiento que experimenta físicamente.

---

### 4.

Para que el texto en AR sea legible independientemente del fondo del mundo real, se debe añadir un **backing panel** semiopaco detrás del texto.

**Respuesta:** **Backing panel**

**Explicación:**  
Este panel crea una superficie uniforme detrás del texto, evitando que el contenido del entorno reduzca la visibilidad de la información mostrada.

---

### 5.

Según WCAG 2.1, las imágenes o elementos que contienen información no deben usar **el color** como único medio de transmitir esa información; deben incluir también forma, patrón o texto.

**Respuesta:** **El color**

**Explicación:**  
La información debe presentarse mediante varios recursos visuales para que pueda ser comprendida incluso por usuarios que presentan alteraciones en la percepción de los colores.

---

### 6.

La organización que publicó el documento XAUR (XR Accessibility User Requirements) es el **W3C (World Wide Web Consortium)**.

**Respuesta:** **W3C (World Wide Web Consortium)**

**Explicación:**  
El W3C desarrolla recomendaciones y estándares internacionales relacionados con la accesibilidad, incluyendo lineamientos específicos para experiencias de realidad extendida (XR).

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
| 8 | App sin modo pausa: usuario con epilepsia expuesto a flashes continuos | **J** | Máximo flash rate configurado + botón de pausa siempre visible. |
| 9 | App de entrenamiento VR usa solo audio para dar feedback de errores | **I** | Semáforos, iconos y vibración como canales adicionales. |
| 10 | Usuario ciego quiere explorar objetos 3D en un museo VR | **K** | Audio descriptivo espacial + hápticos de confirmación. |

### Explicación

Cada barrera de accesibilidad requiere una solución específica que permita al usuario interactuar con la aplicación sin depender de una única capacidad física o sensorial. Estas estrategias buscan que la experiencia XR sea inclusiva mediante el uso de apoyos visuales, auditivos, hápticos y opciones de interacción adaptadas a las necesidades de cada persona.

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

El sistema debe diseñarse considerando la diversidad de estudiantes que pueden encontrarse en los colegios rurales.

- **Discapacidad visual:** algunos estudiantes pueden tener baja visión o dificultades para distinguir detalles, por lo que será necesario incorporar audio descriptivo, textos ampliados y alto contraste.
- **Discapacidad auditiva:** las explicaciones no deben depender únicamente del audio, por lo que deberán incluir subtítulos, elementos gráficos y señales visuales.
- **Discapacidad motora:** algunos usuarios pueden presentar dificultades para manipular controles o realizar movimientos amplios, por lo que se requieren métodos de interacción alternativos.
- **Discapacidad cognitiva:** los contenidos deben organizarse de forma sencilla, utilizando instrucciones claras, lenguaje simple y actividades guiadas paso a paso.

Considerar estas necesidades permitirá que el sistema sea utilizado por una mayor cantidad de estudiantes sin generar barreras durante el aprendizaje.

---

### 2. ¿Qué restricciones del contexto afectan las soluciones de accesibilidad?

El contexto donde se utilizará el sistema impone varias limitaciones importantes.

- **Acceso limitado a Internet:** la aplicación debe funcionar sin conexión permanente y almacenar localmente los recursos educativos.
- **Equipos de bajo costo:** al utilizar visores económicos y teléfonos Android, el sistema debe consumir pocos recursos para mantener un buen rendimiento.
- **Profesores con poca experiencia tecnológica:** la interfaz debe ser intuitiva y requerir la menor cantidad posible de configuraciones.
- **Escasos recursos tecnológicos:** el mantenimiento y la actualización del sistema deben ser sencillos para evitar depender de personal especializado.

Estas condiciones obligan a desarrollar una aplicación ligera, fácil de utilizar y adaptable a distintos entornos educativos.

---

### 3. ¿Qué contenidos presentan desafíos de accesibilidad?

Los temas de ciencias naturales requieren representar procesos que normalmente se explican mediante imágenes, colores y animaciones.

- En el **ciclo del agua**, los estudiantes deben comprender procesos como evaporación, condensación y precipitación, por lo que las animaciones deben acompañarse de explicaciones auditivas y textuales.
- En la **fotosíntesis**, es importante diferenciar los elementos que intervienen en el proceso sin depender únicamente del color.
- En los **ecosistemas**, la gran cantidad de organismos y relaciones puede dificultar la comprensión, por lo que conviene dividir la información en pequeñas secciones y utilizar apoyos audiovisuales.

---

# Parte 2 — Propuesta de diseño inclusivo (10 puntos)

El sistema XR debe ofrecer herramientas que permitan a todos los estudiantes participar en las actividades sin importar sus capacidades o experiencia tecnológica.

## Características de accesibilidad

### 1. Subtítulos sincronizados

Todas las narraciones aparecerán acompañadas por subtítulos sincronizados que podrán visualizarse en español y, cuando sea necesario, también en quechua. Los subtítulos utilizarán letras grandes y alto contraste para facilitar su lectura.

---

### 2. Descripción por audio de los objetos

Cada elemento importante del escenario contará con una explicación en audio que se reproducirá automáticamente cuando el estudiante se acerque o seleccione el objeto. Esto facilitará el aprendizaje de estudiantes con discapacidad visual.

---

### 3. Interfaz adaptable

La aplicación permitirá activar un modo de accesibilidad que aumentará automáticamente el tamaño de los textos, botones e iconos, además de mejorar el contraste entre los elementos de la interfaz y el fondo.

---

### 4. Interacción simplificada

Los usuarios podrán seleccionar objetos mediante **Dwell Time**, manteniendo la mirada sobre ellos durante algunos segundos. De esta forma, los estudiantes con dificultades motoras podrán utilizar la aplicación sin depender completamente de controles físicos.

---

### 5. Retroalimentación multisensorial

Cada acción importante combinará distintos medios de comunicación, incluyendo texto, iconos, sonidos y vibración (cuando el dispositivo lo permita). Esto evita depender exclusivamente de un solo canal de información.

---

### Adaptación automática según el usuario

Al iniciar la aplicación, el profesor podrá seleccionar un perfil de accesibilidad para cada estudiante. El sistema activará automáticamente funciones como:

- Letras grandes.
- Alto contraste.
- Subtítulos.
- Audio descriptivo.
- Interacción mediante Dwell Time.
- Animaciones más lentas.

Esto permitirá utilizar la aplicación sin realizar configuraciones técnicas complicadas.

---

### Característica innovadora

Como propuesta adicional, el sistema incorporará un **Modo Aprendizaje Local**.

Este modo utilizará ejemplos relacionados con la realidad de Ayacucho y Huancavelica, mostrando especies de la zona, paisajes andinos, cultivos y fenómenos naturales propios de la región. Además, incluirá explicaciones en español y quechua para facilitar la comprensión de los contenidos y fortalecer la identidad cultural de los estudiantes.