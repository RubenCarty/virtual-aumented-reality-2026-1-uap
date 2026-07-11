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
# Reporte de Implementación de Accesibilidad — Semana 13

**Curso:** Realidad Virtual y Aumentada  
**Laboratorio:** Semana 13 – Implementación de Accesibilidad en el Proyecto XR  
**Estudiante:** Villalobos Acuña Briseth Maricielo **Código:** 2231893890
**Fecha:** 11/07/2026 | **Puntuación total:** ____/20

---
---

## SECCIÓN A — OPCIÓN MÚIPLE (25 puntos, 2.5 pts c/u)

**Instrucción:** Marca con una X la única respuesta correcta para cada pregunta.

---

**A1.** Según el modelo social de la discapacidad, cuando un usuario en silla de ruedas no puede usar una app de VR que requiere ponerse de pie para alcanzar objetos, el problema principal es:

- [ ] a) La condición médica del usuario que le impide ponerse de pie
- [X] b) El diseño de la app que no consideró usuarios con movilidad reducida
- [ ] c) La tecnología VR que todavía no está madura para casos especiales
- [ ] d) El usuario, quien debería usar una versión diferente de la app para discapacitados

---

**A2.** ¿Cuál es el ratio de contraste mínimo que exige WCAG 2.1 nivel AA para texto normal sobre fondo?

- [ ] a) 2:1
- [ ] b) 3:1
- [X] c) 4.5:1
- [ ] d) 7:1

---

**A3.** Un usuario con **daltonismo rojo-verde (deuteranopia)** usa tu app AR de medicina donde el color rojo indica tejido dañado y verde indica tejido sano. ¿Cuál es la solución de accesibilidad más completa?

- [ ] a) Eliminar todos los colores rojo y verde de la app y usar solo escala de grises
- [ ] b) Agregar un modo especial "para daltónicos" con colores diferentes
- [X] c) Mantener los colores pero añadir forma, icono de advertencia y texto overlay como canales adicionales de información
- [ ] d) Informar al usuario que la app no es compatible con daltonismo en los términos de servicio

---

**A4.** La técnica "Dwell Time" en VR/AR permite:

- [ ] a) Ajustar el tiempo de renderizado de frames para mejorar rendimiento
- [X] b) Seleccionar objetos simplemente mirándolos durante un tiempo configurado, sin usar las manos
- [ ] c) Medir cuánto tiempo el usuario pasa dentro de una sesión VR
- [ ] d) Controlar la velocidad de locomoción para reducir cybersickness

---

**A5.** ¿Por qué el texto AR sobre fondo transparente es particularmente problemático para personas con baja visión?

- [ ] a) Porque el rendering de texto transparente consume más GPU
- [ ] b) Porque el texto flotante parece falso y rompe la ilusión de realidad
- [X] c) Porque el fondo del mundo real es variable e impredecible, haciendo imposible garantizar contraste suficiente
- [ ] d) Porque el texto AR requiere un shader especial incompatible con la mayoría de dispositivos

---

**A6.** El **cybersickness** se produce principalmente por:

- [ ] a) La calidad baja de los gráficos en entornos VR económicos
- [X] b) Una discordancia entre la información visual (movimiento en VR) y la información vestibular (el cuerpo no se mueve)
- [ ] c) La duración excesiva de la sesión VR sin descanso
- [ ] d) El peso del headset que causa fatiga en el cuello

---

**A7.** ¿Qué es el documento **XAUR** (XR Accessibility User Requirements)?

- [ ] a) Un SDK de Unity para implementar accesibilidad en proyectos XR
- [X] b) La extensión de WCAG publicada por el W3C para definir requisitos de accesibilidad específicos para XR
- [ ] c) El estándar legal obligatorio de accesibilidad XR en la Unión Europea
- [ ] d) Una herramienta de diagnóstico de accesibilidad para headsets Meta Quest

---

**A8.** En el script `SubtitulosXR.cs` visto en clase, el método se coloca en `LateUpdate()` en lugar de `Update()` porque:

- [ ] a) `LateUpdate()` es más eficiente en términos de memoria para cálculos de UI
- [X] b) `LateUpdate()` se ejecuta después de que la cámara se ha movido, garantizando que los subtítulos se posicionen correctamente respecto a la posición final de la cámara en ese frame
- [ ] c) `LateUpdate()` es el único ciclo de vida que permite modificar transformaciones en VR
- [ ] d) `Update()` no puede acceder a la posición de la cámara, solo `LateUpdate()` puede

---

**A9.** El "efecto bordillo" (curb cut effect) en diseño accesible se refiere a:

- [ ] a) La necesidad de añadir rampas en todas las entradas de edificios
- [X] b) El principio de que las soluciones diseñadas para personas con discapacidad terminan beneficiando a todos los usuarios
- [ ] c) La técnica de diseño que coloca todos los elementos de UI cerca del borde inferior de la pantalla
- [ ] d) El problema de la fatiga de brazo cuando los menús están muy separados en VR

---

**A10.** ¿Cuál es la diferencia clave entre **locomoción libre** y **teleportación** en VR desde el punto de vista de la accesibilidad?

- [ ] a) La teleportación es más difícil de implementar y solo se usa en apps avanzadas
- [ ] b) La locomoción libre permite moverse más rápido y es preferida por usuarios profesionales
- [X] c) La locomoción libre con joystick puede causar cybersickness ya que el cuerpo no se mueve físicamente, mientras la teleportación elimina esa discordancia
- [ ] d) No hay diferencia significativa en accesibilidad, solo en la sensación de inmersión

---

## SECCIÓN B — COMPLETAR Y RELACIONAR (22 puntos)

### B1 — Completar espacios en blanco (12 puntos, 2 pts c/u)

Completa correctamente cada espacio:

1. WCAG son las siglas de **Web Content Accessibility Guidelines** y sus cuatro principios (POUR) son: Perceptible, **Operable**, Comprensible y Robusto.

2. El componente de Unity que permite asignar una etiqueta accesible y descripción a cualquier GameObject para que el lector de pantalla del sistema operativo los pueda leer se llama **Accessibility Node (o componente del UI Accessibility Plugin)**.

3. El **Cybersickness (o Mareo por Movimiento Virtual)** es el conjunto de síntomas de náusea, desorientación y malestar causado por la discordancia entre la información visual del entorno VR y las señales del sistema vestibular.

4. Para que el texto en AR sea legible independientemente del fondo del mundo real, se debe añadir un **Backing Panel (o fondo sólido/semiopaco)** semiopaco detrás del texto.

5. Según WCAG 2.1, las imágenes o elementos que contienen información no deben usar **el color** como único medio de transmitir esa información — deben incluir también forma, patrón o texto.

6. La organización que publicó el documento XAUR (XR Accessibility User Requirements) es el **W3C (World Wide Web Consortium)**.

---

### B2 — Relacionar columnas (10 puntos, 1 pt c/u)

Conecta cada barrera de accesibilidad (columna izquierda) con su solución más apropiada en XR (columna derecha):

| # | Barrera de accesibilidad | Letra | Solución en XR |
|---|--------------------------|-------|----------------|
| 1 | Usuario sordo no puede escuchar narración de audio en VR | **C** | A. Backing panel semiopaco + texto outline |
| 2 | Usuario con daltonismo no distingue zonas de peligro codificadas en rojo | **D** | B. Dwell time (selección por mirada con tiempo configurable) |
| 3 | Texto AR ilegible sobre fondos claros del mundo real | **A** | C. Subtítulos 3D anclados a la cámara (head-locked) |
| 4 | Usuario con Parkinson no puede presionar botones pequeños del controller | **F** | D. Iconos de forma + texto "PELIGRO" redundante al color |
| 5 | Primera vez en VR — usuario adulto mayor siente náuseas con joystick | **E** | E. Modo teleportación + vignette dinámico + velocidad ajustable |
| 6 | Usuario con autismo siente sobrecarga sensorial con muchos estímulos | **G** | F. Botones más grandes + zona de toque ampliada + modo hold |
| 7 | Usuario en silla de ruedas no puede alcanzar objetos colocados muy arriba en VR | **H** | G. Modo calma: reducir objetos, sonidos y velocidad |
| 8 | App sin modo pausa: usuario con epilepsia expuesto a flashes continuos | **J** | H. Reposicionar UI dentro del rango de movimiento sentado |
| 9 | App de entrenamiento VR usa solo audio para dar feedback de errores | **I** | I. Semáforos, iconos y vibración como canales adicionales |
| 10 | Usuario ciego quiere explorar objetos 3D en un museo VR | **K** | J. Máximo flash rate configurado + botón de pausa siempre visible |
| | | | K. Audio descriptivo espacial + hápticos de confirmación |

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
| # | Línea(s) | Problema de accesibilidad | Tipo de discapacidad afectada | Solución correcta |
|---|----------|--------------------------|-------------------------------|-------------------|
| 1 | 16, 39 | **Dependencia exclusiva del color** para transmitir el estado del sistema (Verde/Rojo) sin alternativas visuales o textuales redundantes. | Daltonismo (Deuteranopia, Protanopia) y baja visión. | Añadir un componente de texto (`TextMeshProUGUI`) que explícitamente cambie entre "ESTADO: OK" y "ESTADO: ERROR", además de alternar un icono geométrico descriptivo. |
| 2 | 19-21 | **Tamaño de botones fijo y extremadamente pequeño** (`80x25`) para un entorno de interacción VR, lo que dificulta apuntar adecuadamente. | Discapacidad motriz (temblores, Parkinson) y baja visión. | Incrementar las dimensiones mínimas del RectTransform del botón (por ejemplo, `160x50` o superior) o ampliar sustancialmente el área de colisión física (`BoxCollider`/Hitbox) de interacción. |
| 3 | 24 | **Límite de tiempo automático (Timeout) abrupto** e inflexible de 60 segundos sin previo aviso visual/auditivo ni opción a extensión. | Discapacidad cognitiva, de aprendizaje o motriz (usuarios que requieren mayor tiempo para procesar o interactuar). | Implementar un temporizador visible con una alerta (pop-up) cuando resten 15 segundos, ofreciendo un botón accesible para extender el tiempo de la sesión de manera segura. |
| 4 | 29-34 | **Animación de parpadeo de alta frecuencia** en `Update` calculada a `8f` (8 ciclos por segundo). Supera ampliamente el umbral de parpadeo seguro. | Epilepsia fotosensible y condiciones neurológicas propensas a convulsiones. | Eliminar por completo el parpadeo cíclico rápido de la UI. En su lugar, usar un cambio de color estático o limitar cualquier pulsación visual por debajo de los 3 Hz, permitiendo además desactivarlo mediante un menú de "Reducir movimiento". |

---

### C2 — Comparación: Audio Narration vs Spatial Audio Descriptions (8 puntos)

Explica la diferencia entre estos dos enfoques para hacer una app VR accesible a usuarios ciegos:

**Enfoque A:** La app tiene una narración lineal de audio que describe todo el contenido de la escena al inicio de cada nivel — el usuario escucha una descripción completa en 2 minutos y luego navega libremente.

**Enfoque B:** La app usa "audio descriptions espaciales" — cuando el usuario gira la cabeza o se aproxima a un objeto, el sistema dice en voz alta el nombre, función y estado de ese objeto específico.

Responde:
1. **¿Cuál enfoque representa mejor el modelo social de la discapacidad? Justifica.**
   El **Enfoque B** representa mejor el modelo social. El modelo social establece que la discapacidad surge a raíz de las barreras del entorno diseñado. El Enfoque A obliga al usuario a sobrecargar su memoria de trabajo memorizando un bloque lineal de 2 minutos antes de explorar (forzando al individuo a adaptarse). El Enfoque B elimina la barrera interactiva del entorno volviendo el espacio tridimensional intrínsecamente responsivo e inclusivo a la libre exploración táctil/auditiva del usuario.

2. **¿Qué limitaciones tiene el Enfoque A que el Enfoque B no tiene?**
   - **Alta carga cognitiva y de memoria:** Recordar la posición de múltiples objetos tras 2 minutos de narración es sumamente difícil.
   - **Falta de correspondencia espacial dinámica:** Si el usuario se desorienta o los elementos se mueven, la narración inicial pierde total validez y utilidad.
   - **Pérdida de autonomía e inmersión:** Convierte la experiencia XR en un flujo pasivo y monótono en lugar de una experiencia interactiva fluida.

3. **¿En qué tipo de app VR el Enfoque A sería más apropiado que el B?**
   Sería más apropiado en experiencias cinematográficas en 360°, cinemáticas introductorias fijas de un videojuego, o en la introducción histórica de una sala de museo virtual estática, donde se requiere contextualizar al usuario de manera estrictamente lineal antes de otorgarle el control del entorno.

4. **¿Cómo implementarías el Enfoque B in Unity a nivel técnico (qué componente y evento usarías)?**
   Colocaría un componente **AudioSource** en cada objeto interactivo configurando su propiedad *Spatial Blend* a `1.0` (3D total) y con curvas de atenuación logarítmica optimizadas. Para el gatillado del evento, utilizaría el sistema de interacción de Unity (XR Interaction Toolkit) mapeando el evento **On Hover Entered** o **On First Hover Entered** del interactuable, o un disparo de raycast continuo desde la cámara (*Gaze Interaction System Screen/Reticle*) apuntando al objeto para reproducir la descripción vía script empleando `audioSource.PlayOneShot(descripcionClip)`.

---

### C3 — Caso: App de rehabilitación física en VR (8 puntos)

Una empresa de Lima está desarrollando una app de **rehabilitación física en VR** para pacientes post-operados en hospitales peruanos. La app pide a los pacientes hacer movimientos específicos de brazos para recuperar rango de movimiento (cirugía de hombro, codo, muñeca). El headset es un Meta Quest 3.

El equipo identificó estos usuarios objetivo:
- Paciente A: mujer de 65 años, primera vez con VR, operada del hombro derecho
- Paciente B: hombre de 45 años, usa VR ocasionalmente, con parálisis parcial de mano derecha por accidente
- Paciente C: joven de 22 años, sordo desde nacimiento
- Paciente D: hombre de 55 años, con daltonismo rojo-verde, operado de ambos codos

Para cada paciente:
1. Identifica las 2 principales barreras de accesibilidad que encontraría en una app diseñada sin accesibilidad
2. Propón 1 solución concreta de diseño XR para cada barrera

**Formato de respuesta:**

| Paciente | Barrera 1 | Solución 1 | Barrera 2 | Solución 2 |
|----------|-----------|-----------|-----------|-----------|
| **A** (65 años, cirugía hombro) | Interfaz predeterminada alta que exige levantar el brazo afectado para iniciar ejercicios, provocando dolor o imposibilidad física. | **Calibración dinámica de UI y altura:** Panel de control inicial reubicable que se posiciona automáticamente a la altura del pecho o zona cómoda según el rango libre actual del paciente. | Tecnofobia / Desorientación espacial en la primera sesión inmersiva ante tutoriales complejos con texto pequeño. | **Asistente de voz pausado en español local** con un tutorial introductorio simplificado paso a paso y soporte interactivo sin requerir uso de botones múltiples. |
| **B** (parálisis mano derecha) | Exigencia de presionar mandos o botones (como Trigger o Grip) con la mano derecha afectada para sujetar herramientas de terapia virtuales. | **Modo Unimanual Alternativo y Auto-Grip:** Mapeo completo de las acciones esenciales hacia el controlador izquierdo funcional o activación por proximidad sin botones. | Dificultad para mantener la sujeción del mando físico derecho debido a la debilidad o parálisis de agarre. | **Uso de correas de mano estilo "Active Straps"** integradas al Meta Quest 3 combinadas con Hand Tracking para prescindir por completo del mando si es necesario. |
| **C** (sordo, 22 años) | Instrucciones de voz del terapeuta virtual sobre cómo realizar adecuadamente los arcos mecánicos sin soporte escrito. | **Subtítulos 3D "Head-locked" con guías visuales:** Inclusión de texto claro con panel de fondo semiopaco y hologramas fantasma que modelan visualmente el ejercicio a imitar. | Ausencia de retroalimentación (feedback) de éxito sonoro al completar correctamente las metas angulares establecidas. | **Feedback háptico diferenciado** (patrones de vibración específicos en los mandos) junto con sutiles destellos visuales perimetrales de validación. |
| **D** (daltonismo, codos) | Incapacidad de distinguir indicadores cromáticos rojo/verde que evalúan si la extensión del codo está en zona segura o peligrosa. | **Codificación redundante por formas e indicadores numéricos:** Uso de texturas (líneas cruzadas/puntos), signos matemáticos y textos explícitos de alerta ("EXCESO" / "OK"). | Rigidez del software que asume extensiones articulares simétricas o estándar de ambos brazos, frustrando el progreso general. | **Configuración independiente de umbrales angulares** parametrizables por brazo en el backend del software clínico para personalizar los objetivos de cada codo de forma aislada. |

---

## SECCIÓN D — CASO AVANZADO (25 puntos)

### Caso: Sistema XR de Educación Inclusiva para Zonas Rurales del Perú

El **Programa Nacional de Innovación Educativa** contrata a tu equipo para desarrollar un sistema XR educativo para colegios de zonas rurales de Ayacucho y Huancavelica. Las características del contexto:

- Estudiantes de 12-17 años con diversidad de capacidades
- Algunos colegios tienen estudiantes con discapacidad visual, auditiva o cognitiva
- Conectividad limitada (solo WiFi, sin 4G estable)
- Presupuesto limitado → headsets económicos (no Meta Quest Pro — sino Quest Go o cardboard con Android)
- El contenido educativo es ciencias naturales: ciclo del agua, fotosíntesis, ecosistemas
- El sistema debe ser usado por profesores sin formación técnica avanzada

**Parte 1 — Análisis de requerimientos de accesibilidad (8 puntos)**

Diseña un análisis de los requisitos de accesibilidad para este sistema. Incluye:
- **¿Qué tipos de discapacidad debes considerar? ¿Por qué?**

  Se deben considerar prioritariamente la **discapacidad visual** (baja visión, daltonismo), la **discapacidad auditiva** (hipoacusia, sordera total) y la **discapacidad cognitiva/neurodivergencias** (dificultades de aprendizaje, procesamiento lento o déficit de atención). La razón principal es que el entorno escolar rural cuenta con recursos de educación especial sumamente limitados; el software XR debe asumir proactivamente la carga de adaptación para garantizar que ningún alumno quede excluido de la experiencia pedagógica por barreras físicas o sensoriales del propio diseño informático.

- **¿Qué restricciones del contexto (rural, económico, sin expertos técnicos) afectan las soluciones de accesibilidad disponibles?**
  1. *Económica y de Hardware (Quest Go / Cardboard):* Al no contar con visores de gama alta, carecemos de *Hand Tracking* preciso o de posicionamiento libre 6DOF (grados de libertad). La accesibilidad motriz no puede apoyarse en gestos complejos de manos; la navegación debe simplificarse al máximo usando interacciones 3DOF basadas en la orientación de la cabeza o clics mecánicos únicos.
  2. *Conectividad Limitada e Inestable:* Descarta por completo el uso de APIs en la nube en tiempo real para traducción automática de texto a voz (TTS) o transcripciones instantáneas. Toda la arquitectura de accesibilidad (pistas de audio, subtítulos estructurados, lógicas de traducción) debe compilarse de forma local y nativa para funcionar al 100% *offline*.
  3. *Profesores sin Formación Técnica:* El docente rural no dispone de tiempo ni capacitación para lidiar con complejos paneles de configuración de accesibilidad. Si el sistema toma más de unos pocos clics para ajustarse a las necesidades de un alumno con baja visión o sordera, la herramienta dejará de ser utilizada.

- **¿Qué contenidos del currículum (ciclo del agua, fotosíntesis) plantean desafíos específicos de accesibilidad?**
  1. *Ciclo del agua:* Representar la evaporación o la condensación gaseosa implica hacer visibles dinámicas microscópicas o macroscópicas abstractas. Para un estudiante con baja visión o ceguera, esto requiere un riguroso diseño de audio espacial descriptivo que traduzca el flujo termodinámico en coordenadas de sonido.
  2. *Fotosíntesis:* Involucra un intercambio molecular químico complejo (fotones, CO2, cloroplastos, O2). Mostrar estas partículas flotando de forma puramente visual excluye a usuarios con discapacidades visuales y genera sobrecarga cognitiva en alumnos con discapacidades de aprendizaje. Exige una codificación dual estricta (formas geométricas + texto de alto contraste) para desglosar la información sin saturar el canal perceptivo.

**Parte 2 — Propuesta de diseño inclusivo (10 puntos)**

Diseña un sistema XR accesible para este contexto. Tu diseño debe incluir:
- **Mínimo 5 características de accesibilidad concretas (no genéricas: "agregar subtítulos" → especifica cómo, en qué idiomas, en qué formato)**
  1. *Subtítulos Bilingües y Legibles (Castellano/Quechua Chanka):* Los componentes de audio explicativos contarán con transcripciones completas editadas a mano. Se renderizarán mediante *TextMeshPro* usando fuentes sans-serif escalables, letras blancas con un borde contundente (*outline*) negro de 2px, posicionadas sobre un panel de fondo (*backing panel*) negro semiopaco fijado al 70% de opacidad. Esto asegura un contraste mínimo de `7:1` independiente del entorno virtual trasero.
  2. *Navegación Universal por Tiempo de Mirada (Dwell Time):* Diseñado para mitigar la falta de mandos avanzados en Cardboard. El alumno interactúa mediante un retículo o cursor céntrico en pantalla; mantener la mirada fija sobre un elemento clave de la ciencia (como una raíz absorbiendo agua) por un umbral de `2.0 segundos` activará de forma autónoma el evento explicativo, eliminando la necesidad de presionar pulsadores físicos.
  3. *Audiodescripciones Espaciales Pre-renderizadas Locales:* Cada hito del ecosistema incluirá detonadores esféricos (*triggers 3D*). Al aproximarse al área o enfocar el elemento, se activará un canal narrativo en estéreo local de alta definición que explicará de manera clara, pausada y descriptiva las características del entorno, ideal para alumnos con discapacidad visual o de lectura.
  4. *Modos de Codificación de Información Alternativos por Forma:* Para los modelos químicos de la fotosíntesis y ciclos gaseosos, se eliminará la dependencia exclusiva del color (rojo para CO2, verde para O2). Se aplicará un diseño adaptativo donde cada molécula posea una geometría única tridimensional texturizada (esferas rugosas, cubos, prismas) acompañada de etiquetas textuales flotantes explícitas.
  5. *Ajuste de Optimización Sensorial ("Modo Calma"):* Un switch en el menú que desactiva sistemas de partículas dinámicos complejos (reflejos de luz solar, polvo ambiental, simulaciones de viento, ruidos de fondo disruptivos). Esto no solo previene la sobrecarga cognitiva en alumnos dentro del espectro autista o con déficit de atención, sino que optimiza drásticamente el rendimiento del frame-rate en procesadores móviles antiguos, reduciendo los riesgos de *cybersickness*.

- **Cómo el sistema se adapta a diferentes niveles de capacidad sin necesitar configuración técnica compleja**

  El sistema implementará un menú de bienvenida basado en **"Tarjetas de Perfil de Accesibilidad Automatizadas"**. Al iniciar la aplicación, el profesor o el alumno se encontrará con tres grandes botones visuales e iconográficos: "Perfil Auditivo" (activa subtítulos automáticos bilingües y guías visuales), "Perfil Visual" (activa audiodescripciones, alto contraste y duplica el tamaño de los textos) y "Perfil Simple" (activa la navegación automatizada guiada por la mirada y el Modo Calma). Al pulsar un solo botón, el motor XR reconfigura todas las variables internas de inmediato.

- **Una característica creativa que no existe en las apps XR actuales y que sería especialmente útil para este contexto peruano específico**

  El sistema incluirá la función **"Llaqta-XR Companion" (El Sabio de la Naturaleza)**. Se trata de un tutor holográfico interactivo personificado en un animal místico local de la fauna andina (un colibrí o un zorro). Esta herramienta prescinde por completo de los textos técnicos en pantalla. El personaje acompaña al alumno narrándole los procesos científicos mediante el uso de analogías socioculturales de la agricultura familiar tradicional y la cosmovisión de Ayacucho y Huancavelica (por ejemplo, explicando el ciclo de la condensación del agua mediante la comparación con el vapor de las ollas comunitarias a fogón, o la fotosíntesis como el alimento de la 'Pachamama'). El avatar habla de manera nativa tanto en castellano como en quechua chanka, y detecta si el estudiante requiere repeticiones del contenido mediante el rastreo de sus pausas de mirada.

**Parte 3 — Validación (7 puntos)**

Diseña un plan de validación de accesibilidad para el sistema. Responde:
- **¿Cómo probarías la accesibilidad del sistema antes del lanzamiento?**

     Se ejecutará una validación en dos etapas. La primera consistirá en pruebas técnicas controladas en el motor de desarrollo empleando simuladores de visión reducida, filtros de daltonismo digitales y perfiles de degradación de hardware para asegurar que la tasa de refresco sea estable. La segunda etapa consistirá en un testeo beta cualitativo de campo (*usability testing*) directamente en las aulas físicas de los colegios seleccionados, observando el comportamiento biomecánico real del alumno con el visor puesto.

- **¿Qué personas específicas incluirías en el proceso de prueba?**

  El grupo focal de validación estará integrado obligatoriamente por una muestra representativa del ecosistema escolar rural: al menos 10 estudiantes de la región de entre 12 y 17 años que presenten de manera diagnosticada o comunitaria baja visión, daltonismo, hipoacusia o dificultades de procesamiento cognitivo; junto con 4 docentes de escuelas rurales locales que no posean competencias digitales avanzadas, para validar la usabilidad de la interfaz de inicio.

- **¿Qué métricas usarías para determinar si el sistema es "accessible"?**
  1. *Tasa de Completitud de Tarea (TCR):* El porcentaje de estudiantes con diversidad funcional que logran completar con éxito la secuencia educativa (ej. armar el ciclo del agua) de manera autónoma.
  2. *Tiempo de Selección Dwell Time:* Monitoreo de la latencia y efectividad al fijar la mirada, midiendo que el tiempo de activación no cause falsos positivos ni frustración por lentitud.
  3. *Escala de Confort Visual y Cinetosis:* Un test visual simplificado post-sesión basado en emoticonos para reportar mareos, náuseas o fatiga ocular en una escala de 1 a 5.
  4. *Métrica de Configuración Docente:* El tiempo total requerido por un profesor para inicializar un perfil accesible para el estudiante (la meta de diseño es menor a 30 segundos).

- **¿Cómo incorporarías feedback de personas con discapacidad al proceso de diseño (no solo de prueba)?**
    
  Se aplicará una metodología de **Co-diseño Participativo** desde las fases iniciales del proyecto. Antes de escribir el código definitivo o renderizar los modelos 3D, se realizarán talleres presenciales en las comunidades utilizando maquetas físicas de baja fidelidad y prototipos interactivos 2D en pantallas tradicionales. Los alumnos con baja visión y dificultades auditivas validarán la tipografía, la pertinencia de las iconografías diseñadas y la precisión lingüística y contextual de las audiodescripciones en quechua. Sus sugerencias e inconformidades reescribirán la arquitectura de la aplicación en los ciclos de desarrollo iterativo temprano.

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