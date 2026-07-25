# S13 — GUÍA DE TRABAJO DEL ESTUDIANTE
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 13 — Accesibilidad en RA y RV

---

> **Instrucciones generales**
> - Esta guía tiene 4 secciones (A, B, C, D) de complejidad creciente.
> - No hay respuestas en este documento — las encontrarás por tu propio análisis.
> - En la sección A y B: solo una respuesta es correcta.
> - En la sección C y D: se valora la profundidad del análisis y la creatividad.
> - Tiempo estimado: 90–120 minutos.

---

## SECCIÓN A — OPCIÓN MÚLTIPLE (25 puntos, 2.5 pts c/u)

**Instrucción:** Marca con una X la única respuesta correcta para cada pregunta.

---

**A1.** Según el modelo social de la discapacidad, cuando un usuario en silla de ruedas no puede usar una app de VR que requiere ponerse de pie para alcanzar objetos, el problema principal es:

- [ ] a) La condición médica del usuario que le impide ponerse de pie
- [x] b) El diseño de la app que no consideró usuarios con movilidad reducida
- [ ] c) La tecnología VR que todavía no está madura para casos especiales
- [ ] d) El usuario, quien debería usar una versión diferente de la app para discapacitados

**Explicación:** El modelo social de la discapacidad sostiene que la principal barrera es el entorno o el diseño del sistema, no la condición de la persona. En este caso, la aplicación no fue diseñada considerando usuarios con movilidad reducida.

---

**A2.** ¿Cuál es el ratio de contraste mínimo que exige WCAG 2.1 nivel AA para texto normal sobre fondo?

- [ ] a) 2:1
- [ ] b) 3:1
- [x] c) 4.5:1
- [ ] d) 7:1

**Explicación:** WCAG 2.1 establece un contraste mínimo de **4.5:1** para texto normal, con el fin de garantizar una adecuada legibilidad para personas con baja visión.

---

**A3.** Un usuario con **daltonismo rojo-verde (deuteranopia)** usa tu app AR de medicina donde el color rojo indica tejido dañado y verde indica tejido sano. ¿Cuál es la solución de accesibilidad más completa?

- [ ] a) Eliminar todos los colores rojo y verde de la app y usar solo escala de grises
- [ ] b) Agregar un modo especial "para daltónicos" con colores diferentes
- [x] c) Mantener los colores pero añadir forma, icono de advertencia y texto overlay como canales adicionales de información
- [ ] d) Informar al usuario que la app no es compatible con daltonismo en los términos de servicio

**Explicación:** La información importante nunca debe depender únicamente del color. Se deben incorporar elementos adicionales como iconos, formas o texto para asegurar que todos los usuarios puedan interpretarla.

---

**A4.** La técnica "Dwell Time" en VR/AR permite:

- [ ] a) Ajustar el tiempo de renderizado de frames para mejorar rendimiento
- [x] b) Seleccionar objetos simplemente mirándolos durante un tiempo configurado, sin usar las manos
- [ ] c) Medir cuánto tiempo el usuario pasa dentro de una sesión VR
- [ ] d) Controlar la velocidad de locomoción para reducir cybersickness

**Explicación:** Dwell Time es una técnica de accesibilidad que permite seleccionar elementos manteniendo la mirada sobre ellos durante un tiempo determinado, facilitando la interacción a personas con limitaciones motrices.

---

**A5.** ¿Por qué el texto AR sobre fondo transparente es particularmente problemático para personas con baja visión?

- [ ] a) Porque el rendering de texto transparente consume más GPU
- [ ] b) Porque el texto flotante parece falso y rompe la ilusión de realidad
- [x] c) Porque el fondo del mundo real es variable e impredecible, haciendo imposible garantizar contraste suficiente
- [ ] d) Porque el texto AR requiere un shader especial incompatible con la mayoría de dispositivos

**Explicación:** En Realidad Aumentada el fondo corresponde al entorno real y cambia constantemente, por lo que no siempre existe el contraste necesario para que el texto sea legible.

---

**A6.** El **cybersickness** se produce principalmente por:

- [ ] a) La calidad baja de los gráficos en entornos VR económicos
- [x] b) Una discordancia entre la información visual (movimiento en VR) y la información vestibular (el cuerpo no se mueve)
- [ ] c) La duración excesiva de la sesión VR sin descanso
- [ ] d) El peso del headset que causa fatiga en el cuello

**Explicación:** El cybersickness aparece cuando los ojos perciben movimiento mientras el sistema vestibular detecta que el cuerpo permanece inmóvil, provocando náuseas y desorientación.

---

**A7.** ¿Qué es el documento **XAUR** (XR Accessibility User Requirements)?

- [ ] a) Un SDK de Unity para implementar accesibilidad en proyectos XR
- [x] b) La extensión de WCAG publicada por el W3C para definir requisitos de accesibilidad específicos para XR
- [ ] c) El estándar legal obligatorio de accesibilidad XR en la Unión Europea
- [ ] d) Una herramienta de diagnóstico de accesibilidad para headsets Meta Quest

**Explicación:** XAUR es un documento desarrollado por el W3C que reúne recomendaciones de accesibilidad específicas para experiencias de Realidad Extendida (XR).

---

**A8.** En el script `SubtitulosXR.cs` visto en clase, el método se coloca en `LateUpdate()` en lugar de `Update()` porque:

- [ ] a) `LateUpdate()` es más eficiente en términos de memoria para cálculos de UI
- [x] b) `LateUpdate()` se ejecuta después de que la cámara se ha movido, garantizando que los subtítulos se posicionen correctamente respecto a la posición final de la cámara en ese frame
- [ ] c) `LateUpdate()` es el único ciclo de vida que permite modificar transformaciones en VR
- [ ] d) `Update()` no puede acceder a la posición de la cámara, solo `LateUpdate()` puede

**Explicación:** Al ejecutarse después del movimiento de la cámara, `LateUpdate()` asegura que los subtítulos permanezcan correctamente alineados con la posición final del usuario en cada fotograma.

---

**A9.** El "efecto bordillo" (curb cut effect) en diseño accesible se refiere a:

- [ ] a) La necesidad de añadir rampas en todas las entradas de edificios
- [x] b) El principio de que las soluciones diseñadas para personas con discapacidad terminan beneficiando a todos los usuarios
- [ ] c) La técnica de diseño que coloca todos los elementos de UI cerca del borde inferior de la pantalla
- [ ] d) El problema de la fatiga de brazo cuando los menús están muy separados en VR

**Explicación:** El efecto bordillo demuestra que muchas soluciones creadas para mejorar la accesibilidad terminan facilitando la experiencia de todos los usuarios, independientemente de que tengan o no una discapacidad.

---

**A10.** ¿Cuál es la diferencia clave entre **locomoción libre** y **teleportación** en VR desde el punto de vista de la accesibilidad?

- [ ] a) La teleportación es más difícil de implementar y solo se usa en apps avanzadas
- [ ] b) La locomoción libre permite moverse más rápido y es preferida por usuarios profesionales
- [x] c) La locomoción libre con joystick puede causar cybersickness ya que el cuerpo no se mueve físicamente, mientras la teleportación elimina esa discordancia
- [ ] d) No hay diferencia significativa en accesibilidad, solo en la sensación de inmersión

**Explicación:** La teleportación reduce considerablemente el riesgo de cybersickness porque evita el movimiento continuo del escenario, mejorando la comodidad y la accesibilidad para una mayor cantidad de usuarios.

## SECCIÓN B — COMPLETAR Y RELACIONAR (22 puntos)

### B1 — Completar espacios en blanco (12 puntos, 2 pts c/u)

Completa correctamente cada espacio:

1. WCAG son las siglas de **Web Content Accessibility Guidelines** y sus cuatro principios (POUR) son: Perceptible, **Operable**, Comprensible y Robusto.

2. El componente de Unity que permite asignar una etiqueta accesible y descripción a cualquier GameObject para que el lector de pantalla del sistema operativo los pueda leer se llama **Accessibility Node**.

3. El **Cybersickness** es el conjunto de síntomas de náusea, desorientación y malestar causado por la discordancia entre la información visual del entorno VR y las señales del sistema vestibular.

4. Para que el texto en AR sea legible independientemente del fondo del mundo real, se debe añadir un **Backing Panel** semiopaco detrás del texto.

5. Según WCAG 2.1, las imágenes o elementos que contienen información no deben usar **el color** como único medio de transmitir esa información; deben incluir también forma, patrón o texto.

6. La organización que publicó el documento XAUR (XR Accessibility User Requirements) es el **W3C (World Wide Web Consortium)**.

---

### B2 — Relacionar columnas (10 puntos, 1 pt c/u)

Conecta cada barrera de accesibilidad (columna izquierda) con su solución más apropiada en XR:

| # | Barrera de accesibilidad | Letra | Solución en XR |
|---|--------------------------|:-----:|----------------|
| 1 | Usuario sordo no puede escuchar narración de audio en VR | **C** | Subtítulos 3D anclados a la cámara (head-locked) |
| 2 | Usuario con daltonismo no distingue zonas de peligro codificadas en rojo | **D** | Iconos de forma + texto "PELIGRO" redundante al color |
| 3 | Texto AR ilegible sobre fondos claros del mundo real | **A** | Backing panel semiopaco + texto outline |
| 4 | Usuario con Parkinson no puede presionar botones pequeños del controller | **F** | Botones más grandes + zona de toque ampliada + modo hold |
| 5 | Primera vez en VR — usuario adulto mayor siente náuseas con joystick | **E** | Modo teleportación + vignette dinámico + velocidad ajustable |
| 6 | Usuario con autismo siente sobrecarga sensorial con muchos estímulos | **G** | Modo calma: reducir objetos, sonidos y velocidad |
| 7 | Usuario en silla de ruedas no puede alcanzar objetos colocados muy arriba en VR | **H** | Reposicionar UI dentro del rango de movimiento sentado |
| 8 | App sin modo pausa: usuario con epilepsia expuesto a flashes continuos | **J** | Máximo flash rate configurado + botón de pausa siempre visible |
| 9 | App de entrenamiento VR usa solo audio para dar feedback de errores | **I** | Semáforos, iconos y vibración como canales adicionales |
| 10 | Usuario ciego quiere explorar objetos 3D en un museo VR | **K** | Audio descriptivo espacial + hápticos de confirmación |

---

## SECCIÓN C — ANÁLISIS Y DIAGNÓSTICO (28 puntos)

### C1 — Diagnóstico de código con problemas de accesibilidad (12 puntos)

El siguiente script de Unity fue escrito sin considerar accesibilidad. Identifica **al menos 4 problemas concretos de accesibilidad** y para cada uno propón la solución correcta.

```csharp
using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipalVR : MonoBehaviour
{
    public Button botonIniciar;
    public Button botonOpciones;
    public Button botonSalir;
    public Image imagenEstado;  // Rojo = error, Verde = OK
    public AudioSource alarma;  // Sonido de alerta de error

    void Start()
    {
        // Colores de estado
        imagenEstado.color = Color.green;

        // Tamaño fijo de botones
        botonIniciar.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 25);
        botonOpciones.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 25);
        botonSalir.GetComponent<RectTransform>().sizeDelta = new Vector2(80, 25);

        // Timeout automático sin aviso
        Invoke("CerrarSesion", 60f);
    }

    void Update()
    {
        // Animación de parpadeo del estado
        float velocidadParpadeo = 8f;  // 8 ciclos por segundo
        float alpha = Mathf.Abs(Mathf.Sin(Time.time * velocidadParpadeo * Mathf.PI));
        imagenEstado.color = new Color(imagenEstado.color.r,
                                        imagenEstado.color.g,
                                        imagenEstado.color.b, alpha);
    }

    public void MostrarError()
    {
        imagenEstado.color = Color.red;
        alarma.Play();
        // No hay feedback de texto — solo color y sonido
    }

    void CerrarSesion()
    {
        Application.Quit();
    }
}
```

Para cada problema, usa esta tabla:

| # | Línea(s) | Problema de accesibilidad | Tipo de discapacidad afectada | Solución correcta |
|---|----------|--------------------------|-------------------------------|-------------------|
| 1 | 15 y 39 | El estado de la aplicación se comunica únicamente mediante los colores verde y rojo. | Personas con daltonismo o baja visión. | Agregar iconos, texto descriptivo (Ej. "ERROR" o "CORRECTO") y símbolos para que la información no dependa únicamente del color. |
| 2 | 18–20 | Los botones tienen un tamaño muy pequeño (80x25), dificultando su selección. | Personas con discapacidad motriz, Parkinson o temblores. | Aumentar el tamaño de los botones, ampliar la zona táctil e incorporar un modo de selección por Dwell Time o permanencia de la mirada. |
| 3 | 23 | La sesión se cierra automáticamente después de 60 segundos sin advertencia. | Personas con discapacidad cognitiva, adultos mayores o usuarios que requieren más tiempo. | Mostrar un aviso previo, permitir cancelar el cierre y ofrecer una opción para ampliar el tiempo de espera. |
| 4 | 29–32 y 38–41 | El error se comunica solo mediante un sonido y un cambio de color. | Personas sordas, con baja audición o daltonismo. | Incorporar subtítulos, mensajes visuales, vibración (hápticos) e iconos para complementar el sonido. |

---

### C2 — Comparación: Audio Narration vs Spatial Audio Descriptions (8 puntos)

**1. ¿Cuál enfoque representa mejor el modelo social de la discapacidad? Justifica.**

El **Enfoque B** representa mejor el modelo social de la discapacidad porque adapta la experiencia a las necesidades del usuario. En lugar de obligar a escuchar una descripción larga al inicio, proporciona información únicamente cuando el usuario la necesita, facilitando una interacción más natural e inclusiva.

---

**2. ¿Qué limitaciones tiene el Enfoque A que el Enfoque B no tiene?**

- El usuario debe recordar toda la información antes de comenzar la exploración.
- La descripción puede contener información innecesaria.
- No responde a las acciones del usuario en tiempo real.
- Reduce la autonomía durante la navegación.

El Enfoque B evita estas limitaciones al ofrecer información contextual según la posición o interacción del usuario.

---

**3. ¿En qué tipo de app VR el Enfoque A sería más apropiado que el B?**

El Enfoque A sería más adecuado en aplicaciones donde el contenido es lineal o guiado, como visitas virtuales, recorridos históricos, documentales inmersivos o presentaciones educativas, donde primero se explica el contexto general antes de comenzar la interacción.

---

**4. ¿Cómo implementarías el Enfoque B en Unity a nivel técnico (qué componente y evento usarías)?**

En Unity utilizaría un **Collider** configurado como **Trigger** junto con un **AudioSource** para reproducir la descripción cuando el usuario se acerque al objeto. La detección puede realizarse mediante el evento **OnTriggerEnter()** o, en proyectos XR con XR Interaction Toolkit, utilizando eventos como **Hover Entered** o **Select Entered** para activar el audio descriptivo correspondiente.

---

### C3 — Caso: App de rehabilitación física en VR (8 puntos)

| Paciente | Barrera 1 | Solución 1 | Barrera 2 | Solución 2 |
|----------|-----------|-----------|-----------|-----------|
| **A (65 años, cirugía hombro)** | Dificultad para realizar movimientos amplios del brazo debido a la cirugía. | Permitir ajustar el rango de movimiento y realizar los ejercicios sentado. | Puede experimentar desorientación o cybersickness por ser su primera experiencia en VR. | Implementar modo de teleportación, velocidad de movimiento reducida y tutorial guiado paso a paso. |
| **B (parálisis mano derecha)** | Dificultad para utilizar el controlador con la mano afectada. | Permitir el uso de una sola mano y reasignar todos los controles al controlador izquierdo. | Problemas para presionar botones pequeños o realizar gestos complejos. | Incorporar botones grandes, selección por mirada (Dwell Time) y comandos por voz cuando sea posible. |
| **C (sordo, 22 años)** | No puede escuchar instrucciones o avisos por audio. | Incluir subtítulos sincronizados y mensajes visuales dentro del entorno VR. | No percibe alertas sonoras durante la rehabilitación. | Complementar las alertas con iconos, cambios de color y vibración háptica del controlador. |
| **D (daltonismo, codos)** | No distingue colores utilizados para indicar aciertos o errores. | Utilizar iconos, formas y texto además del color para mostrar el estado del ejercicio. | Limitación de movimiento en ambos codos durante la rehabilitación. | Ajustar automáticamente la dificultad y permitir configurar el rango de movimiento según la evolución del paciente. |

---

# SECCIÓN D — CASO AVANZADO (25 puntos)

## Caso: Sistema XR de Educación Inclusiva para Zonas Rurales del Perú

### Parte 1 — Análisis de requerimientos de accesibilidad (8 puntos)

**¿Qué tipos de discapacidad debes considerar? ¿Por qué?**

El sistema debe considerar estudiantes con discapacidad visual, auditiva, motriz y cognitiva, ya que todos deben tener igualdad de oportunidades para acceder al contenido educativo. También es importante contemplar usuarios con daltonismo, baja visión y dificultades de aprendizaje para garantizar una experiencia realmente inclusiva.

**¿Qué restricciones del contexto afectan las soluciones de accesibilidad disponibles?**

Al tratarse de colegios rurales con presupuesto limitado, se utilizarán dispositivos de bajo costo que poseen menor capacidad de procesamiento. Además, la conectividad es limitada, por lo que el sistema debe funcionar sin conexión permanente a Internet. Como los docentes no cuentan con formación técnica especializada, la aplicación debe ser sencilla de instalar, configurar y utilizar.

**¿Qué contenidos del currículo plantean desafíos específicos de accesibilidad?**

Temas como el ciclo del agua, la fotosíntesis y los ecosistemas utilizan muchas animaciones, colores y representaciones visuales. Esto representa un reto para estudiantes con discapacidad visual o daltonismo, por lo que será necesario incorporar descripciones de audio, subtítulos, iconografía y elementos táctiles o sonoros que complementen la información.

---

### Parte 2 — Propuesta de diseño inclusivo (10 puntos)

**Características de accesibilidad**

1. Subtítulos permanentes en español, con tamaño de letra ajustable y fondo semiopaco para facilitar la lectura.
2. Narración de audio con descripciones espaciales para estudiantes con discapacidad visual.
3. Modo de alto contraste y paletas de colores compatibles con distintos tipos de daltonismo.
4. Interacción mediante mirada (Dwell Time), permitiendo usar la aplicación sin necesidad de controladores complejos.
5. Modo de lectura fácil con lenguaje simplificado, apoyo mediante pictogramas e instrucciones paso a paso.

**Adaptación automática**

Al iniciar la aplicación, el sistema presenta un breve asistente donde el estudiante responde unas preguntas sencillas. Según sus respuestas, activa automáticamente el tamaño del texto, el contraste, los subtítulos, la narración o el modo de interacción más adecuado, sin requerir configuraciones técnicas.

**Propuesta creativa**

Incorporar un **modo bilingüe español–quechua**, donde todas las instrucciones, narraciones y subtítulos puedan reproducirse en ambos idiomas. Esta función facilitaría el aprendizaje en comunidades rurales donde el quechua sigue siendo la lengua materna de muchos estudiantes.

---

### Parte 3 — Validación (7 puntos)

**¿Cómo probarías la accesibilidad del sistema antes del lanzamiento?**

Realizaría pruebas piloto en colegios rurales utilizando los mismos dispositivos que se emplearán en las aulas. Se evaluaría la facilidad de uso, comprensión de las actividades y el tiempo necesario para completar cada ejercicio.

**¿Qué personas incluirías en las pruebas?**

- Estudiantes con discapacidad visual.
- Estudiantes con discapacidad auditiva.
- Estudiantes con discapacidad motriz.
- Estudiantes con dificultades cognitivas.
- Docentes de colegios rurales.
- Especialistas en educación inclusiva y accesibilidad.

**¿Qué métricas utilizarías?**

- Tiempo para completar las actividades.
- Número de errores durante el uso.
- Porcentaje de tareas completadas correctamente.
- Nivel de satisfacción de estudiantes y docentes mediante encuestas.
- Cantidad de ayuda requerida durante la interacción.

**¿Cómo incorporarías el feedback de personas con discapacidad?**

El proceso sería iterativo. Después de cada sesión de pruebas se recogerían opiniones mediante entrevistas y cuestionarios. Posteriormente se realizarían mejoras en el sistema y se volvería a evaluar con los mismos usuarios hasta comprobar que las barreras de accesibilidad fueron eliminadas o reducidas significativamente.

---

## CRITERIOS DE EVALUACIÓN

| Sección | Puntos | Criterio |
|---------|--------|---------|
| A — Opción Múltiple | 25 pts | Respuesta correcta única por pregunta |
| B1 — Espacios en blanco | 12 pts | Término técnico exacto en cada espacio |
| B2 — Relacionar columnas | 10 pts | Correspondencia correcta |
| C1 — Diagnóstico de código | 12 pts | 4 problemas identificados con solución correcta |
| C2 — Comparación enfoques | 8 pts | Análisis profundo de diferencias y casos |
| C3 — Caso rehabilitación | 8 pts | Barreras y soluciones específicas por perfil |
| D — Caso avanzado | 25 pts | Análisis contextualizado, creatividad, validación |
| **TOTAL** | **100 pts** | |

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 13 | 2026-1*
