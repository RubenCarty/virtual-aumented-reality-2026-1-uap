# REPORTE_ACCESIBILIDAD.md

# Reporte de Implementación de Accesibilidad — Semana 13

**Curso:** Realidad Virtual y Aumentada  
**Laboratorio:** Semana 13 – Implementación de Accesibilidad en el Proyecto XR  
**Estudiante:** Palacios Vergaray Jhener Erick **Código:** 2231890156
**Fecha:** 10/07/2026 | **Puntuación total:** ____/20

---

# PARTE 1 — Sistema de Subtítulos XR

## Objetivo

Implementar un sistema de subtítulos tridimensionales que permanezcan visibles en la parte inferior del campo visual del usuario durante toda la experiencia XR, permitiendo que las personas con discapacidad auditiva puedan comprender la información presentada por la aplicación.

---

# 1. Creación de la interfaz de subtítulos

## Procedimiento

Se creó un **Canvas** desde la jerarquía de Unity siguiendo la ruta:

```text
Hierarchy → UI → Canvas
```

El objeto fue renombrado como:

```text
CanvasSubtitulos
```

Posteriormente se configuró el componente **Canvas** con el modo:

```text
Render Mode = World Space
```

Este modo permite que el Canvas exista como un objeto tridimensional dentro de la escena y pueda seguir la posición del usuario en realidad virtual.

El tamaño del Canvas fue configurado con las siguientes dimensiones:

| Propiedad | Valor |
|-----------|-------|
| Width | 2 |
| Height | 0.3 |
| Scale X | 0.01 |
| Scale Y | 0.01 |
| Scale Z | 0.01 |

---

## Panel de fondo

Dentro del Canvas se creó un componente **Image** llamado:

```text
PanelSubtitulos
```

Su función consiste en mejorar el contraste entre el texto y el entorno virtual.

Configuración:

| Propiedad | Valor |
|-----------|-------|
| Color | Negro |
| Transparencia | 70 % |
| Anchor | Stretch |

Gracias a este panel, los subtítulos permanecen legibles incluso cuando el fondo posee colores similares al texto.

---

## Texto de subtítulos

Se añadió un objeto **TextMeshProUGUI** con el nombre:

```text
TextoSubtitulo
```

Configuración utilizada:

| Propiedad | Valor |
|-----------|-------|
| Color | Blanco |
| Font Size | 0.08 |
| Alignment | Center |
| Texto inicial | Vacío |

La combinación de texto blanco y panel oscuro cumple con las recomendaciones de contraste establecidas por WCAG para mejorar la accesibilidad.

---

# 2. Implementación del script SubtitulosXR.cs

Se creó el archivo:

```text
Assets/Scripts/SubtitulosXR.cs
```

El script controla completamente el sistema de subtítulos.

Sus funciones principales son:

- Mostrar mensajes.
- Ocultar automáticamente los mensajes.
- Hacer que el panel siga la cámara.
- Activar o desactivar los subtítulos desde el menú de accesibilidad.

---

## Funcionamiento del método Start()

Al iniciar la escena el script realiza las siguientes acciones:

- Obtiene la cámara principal.
- Configura los colores del texto y del panel.
- Verifica que exista una Main Camera.
- Oculta inicialmente el panel de subtítulos.

Esto garantiza que la interfaz solamente aparezca cuando exista un mensaje para mostrar.

---

## ¿Por qué se utiliza LateUpdate()?

El movimiento del panel se realiza mediante:

```csharp
LateUpdate()
```

En Unity este método se ejecuta después de que todos los objetos terminaron de actualizar su posición mediante `Update()`.

Esto evita que el panel tenga pequeños retrasos respecto al movimiento de la cámara.

Si se utilizara únicamente `Update()`, podrían observarse ligeros desplazamientos o vibraciones cuando el usuario mueve rápidamente la cabeza.

Por ello, `LateUpdate()` permite mantener los subtítulos correctamente alineados con el campo visual durante toda la experiencia XR.

---

## Posicionamiento del panel

La posición del panel se calcula utilizando la posición actual de la cámara.

El sistema coloca el Canvas:

- Aproximadamente **2 metros delante del usuario**.
- **0.5 metros por debajo** del centro de la cámara.

Esto hace que los subtítulos permanezcan en una posición cómoda para la lectura sin bloquear la visión del escenario.

---

## Movimiento suavizado

El desplazamiento del panel utiliza:

```csharp
Vector3.Lerp()
```

Este método interpola suavemente entre la posición actual y la posición objetivo.

Gracias a ello se evita el efecto de movimientos bruscos cuando el usuario gira rápidamente la cabeza.

El nivel de suavizado puede modificarse mediante la variable:

```text
suavizadoMovimiento
```

---

## Mostrar subtítulos

Para mostrar un mensaje se utiliza:

```csharp
MostrarSubtitulo()
```

Este método recibe:

- El texto.
- El tiempo durante el cual permanecerá visible.

Ejemplo:

```csharp
MostrarSubtitulo(
    "Objeto colocado correctamente",
    3f
);
```

Cuando aparece un nuevo subtítulo, el anterior se reemplaza automáticamente.

---

## Ocultar subtítulos

Después del tiempo indicado, una corrutina ejecuta:

```csharp
OcultarSubtitulo();
```

Con esto el panel desaparece automáticamente sin requerir intervención del usuario.

---

# 3. Integración en Unity

Una vez creado el script, se añadió al objeto:

```text
CanvasSubtitulos
```

Posteriormente se conectaron las referencias desde el Inspector.

| Campo | Objeto asignado |
|--------|-----------------|
| Texto Subtitulo | TextoSubtitulo |
| Panel Subtitulos | CanvasSubtitulos |

Esto permitió que el script pudiera controlar directamente los elementos de la interfaz.

---

# 4. Script de prueba

Para comprobar el funcionamiento del sistema se creó el archivo:

```text
PruebaSubtitulos.cs
```

Este script permite mostrar subtítulos mediante el teclado.

## Controles utilizados

| Tecla | Acción |
|--------|--------|
| S | Mostrar subtítulo corto |
| A | Mostrar subtítulo largo |
| D | Ocultar subtítulo |

Con estas pruebas fue posible verificar que los mensajes aparecen correctamente durante el tiempo indicado.

---

# 5. Resultados obtenidos

Después de implementar el sistema se observaron los siguientes resultados:

- Los subtítulos aparecen inmediatamente al solicitarse.
- El panel permanece siempre frente al usuario.
- Los mensajes desaparecen automáticamente al finalizar el tiempo establecido.
- El movimiento del panel es suave y estable.
- El texto mantiene una buena legibilidad gracias al panel oscuro.

---

# Beneficios para la accesibilidad

La implementación del sistema de subtítulos aporta importantes mejoras para distintos tipos de usuarios.

- Personas con discapacidad auditiva pueden comprender la información sin depender únicamente del sonido.
- Usuarios en ambientes ruidosos pueden seguir las instrucciones sin dificultad.
- Estudiantes que prefieren apoyo visual pueden leer las explicaciones mientras interactúan con la aplicación.
- La experiencia resulta más inclusiva al ofrecer múltiples formas de acceder a la información.

---

# Evidencias

## Evidencia 1

Captura de la jerarquía mostrando:

```text
CanvasSubtitulos
├── PanelSubtitulos
└── TextoSubtitulo
```

---

## Evidencia 2

Captura del Inspector del componente **SubtitulosXR** mostrando las referencias correctamente asignadas.

---

## Evidencia 3

Captura del subtítulo visible durante la ejecución de la escena.

---

## Evidencia 4

Captura donde se observa que el subtítulo permanece frente al usuario después de mover la cámara.

---

# Verificación

| Criterio | Estado |
|----------|:------:|
| Canvas configurado en World Space | ✅ |
| Panel oscuro detrás del texto | ✅ |
| Texto blanco con alto contraste | ✅ |
| Script SubtitulosXR agregado | ✅ |
| LateUpdate funcionando correctamente | ✅ |
| El panel sigue la cámara | ✅ |
| El subtítulo desaparece automáticamente | ✅ |
| Sistema listo para integrarse con el proyecto | ✅ |

---

# Conclusión

La implementación del sistema de subtítulos XR permitió mejorar significativamente la accesibilidad de la aplicación. El uso de un Canvas en **World Space**, junto con el posicionamiento dinámico mediante `LateUpdate()`, garantiza que los subtítulos permanezcan visibles sin importar la dirección en la que mire el usuario. Además, el panel de fondo oscuro mejora la legibilidad del texto y facilita la comprensión del contenido para personas con discapacidad auditiva o usuarios que prefieren información visual. Este sistema constituye una base importante para desarrollar experiencias XR más inclusivas y alineadas con las buenas prácticas de accesibilidad.

# PARTE 2 — Implementación de Paleta Accesible para Daltonismo

## Objetivo

Implementar una paleta de colores accesible que permita diferenciar correctamente los elementos de la interfaz sin depender únicamente del color. Con esta mejora, los usuarios con distintos tipos de daltonismo podrán identificar información importante utilizando colores con mayor contraste, además de apoyarse en iconos y texto cuando sea necesario.

---

# 1. Análisis del problema

En muchas aplicaciones XR se utilizan colores como rojo, verde o amarillo para indicar estados del sistema. Sin embargo, estas combinaciones pueden resultar difíciles de distinguir para personas con alteraciones en la percepción del color, especialmente quienes presentan deuteranopia o protanopia.

Si la información depende exclusivamente del color, algunos usuarios podrían interpretar incorrectamente los mensajes o el estado de un objeto.

Por este motivo fue necesario reemplazar la paleta tradicional por una combinación de colores más accesible.

---

# 2. Selección de la nueva paleta

Se eligieron colores con mayor contraste y mejor diferenciación visual.

| Estado | Color utilizado | Código HEX |
|---------|----------------|------------|
| Correcto | Azul | `#0078D4` |
| Advertencia | Amarillo | `#FFC107` |
| Error | Naranja | `#E67E22` |
| Información | Blanco | `#FFFFFF` |
| Fondo | Gris oscuro | `#2C2C2C` |

Esta combinación facilita la identificación de cada estado incluso cuando el usuario presenta dificultades para distinguir ciertos colores.

---

# 3. Sustitución de indicadores basados únicamente en color

Además del cambio de colores, cada estado incorpora un elemento visual adicional.

| Estado | Color | Elemento adicional |
|---------|-------|-------------------|
| Correcto | Azul | ✔ Icono de verificación |
| Advertencia | Amarillo | ⚠ Triángulo de advertencia |
| Error | Naranja | ✖ Símbolo de error |
| Información | Blanco | ℹ Icono informativo |

De esta manera, el usuario puede reconocer el significado del mensaje aunque no perciba correctamente los colores.

---

# 4. Implementación en Unity

Se creó un script para administrar automáticamente los colores de la interfaz.

Archivo:

```text
Assets/Scripts/PaletaAccesible.cs
```

---

## Código

```csharp
using UnityEngine;
using UnityEngine.UI;

public class PaletaAccesible : MonoBehaviour
{
    public Image indicador;

    public Color colorCorrecto = new Color32(0,120,212,255);
    public Color colorAdvertencia = new Color32(255,193,7,255);
    public Color colorError = new Color32(230,126,34,255);

    public void EstadoCorrecto()
    {
        indicador.color = colorCorrecto;
    }

    public void EstadoAdvertencia()
    {
        indicador.color = colorAdvertencia;
    }

    public void EstadoError()
    {
        indicador.color = colorError;
    }
}
```

---

# 5. Funcionamiento del script

El componente permite modificar el color del indicador según el estado del sistema.

Cada función asigna automáticamente el color correspondiente.

```text
EstadoCorrecto()
```

Muestra el indicador en color azul.

```text
EstadoAdvertencia()
```

Cambia el indicador a color amarillo.

```text
EstadoError()
```

Asigna el color naranja para representar una situación de error.

Esta organización facilita futuras modificaciones de la paleta sin necesidad de cambiar múltiples objetos de la escena.

---

# 6. Verificación de accesibilidad

Después de implementar la nueva paleta se comprobó que:

- Los estados pueden distinguirse fácilmente.
- La información ya no depende únicamente del color.
- Los iconos ayudan a interpretar rápidamente cada mensaje.
- El contraste mejora la lectura en diferentes condiciones de iluminación.

---

# Beneficios de la implementación

La nueva paleta ofrece varias ventajas para la accesibilidad.

- Reduce las dificultades de interpretación en usuarios con daltonismo.
- Facilita la identificación rápida de los diferentes estados del sistema.
- Cumple con la recomendación de WCAG de no utilizar únicamente el color para comunicar información.
- Hace que la interfaz sea más comprensible para todos los usuarios, independientemente de sus capacidades visuales.

---

# Resultados obtenidos

Después de aplicar la nueva configuración se observaron las siguientes mejoras:

- Mayor contraste entre los elementos de la interfaz.
- Mejor diferenciación entre estados.
- Mayor claridad durante la interacción con la aplicación.
- Interfaz más uniforme y fácil de interpretar.

---

# Evidencias

## Evidencia 1

Captura de la interfaz antes de aplicar la nueva paleta de colores.

---

## Evidencia 2

Captura mostrando la nueva combinación de colores accesibles.

---

## Evidencia 3

Captura donde se observen los iconos utilizados junto con los colores.

---

## Evidencia 4

Captura del Inspector mostrando el componente **PaletaAccesible** con los colores configurados.

---

# Lista de verificación

| Actividad | Estado |
|-----------|:------:|
| Paleta de colores modificada | ✅ |
| Colores accesibles implementados | ✅ |
| Iconos agregados a cada estado | ✅ |
| Información independiente del color | ✅ |
| Script PaletaAccesible creado | ✅ |
| Interfaz validada visualmente | ✅ |

---

# Conclusión

La implementación de una paleta accesible permitió mejorar significativamente la comprensión de la interfaz para usuarios con diferentes tipos de daltonismo. Además del cambio de colores, se incorporaron iconos que refuerzan el significado de cada estado, evitando depender exclusivamente de la percepción cromática. Esta solución hace que la aplicación sea más inclusiva y se alinea con las recomendaciones de accesibilidad establecidas para el desarrollo de experiencias XR.

# PARTE 3 — REPORTE DE ACCESIBILIDAD

## Objetivo

Evaluar el nivel de accesibilidad de la aplicación XR después de implementar las mejoras desarrolladas durante el laboratorio. Además, se busca identificar los beneficios obtenidos y verificar que la experiencia sea más inclusiva para diferentes tipos de usuarios.

---

# 1. Auditoría de accesibilidad

Para comprobar las mejoras realizadas, se comparó el funcionamiento de la aplicación antes y después de implementar las herramientas de accesibilidad.

| Aspecto evaluado | Antes de la implementación | Después de la implementación |
|------------------|---------------------------|------------------------------|
| Subtítulos | No existían subtítulos para las narraciones. | Se incorporaron subtítulos visibles durante toda la experiencia. |
| Contraste del texto | Algunos mensajes eran difíciles de leer dependiendo del fondo. | Se añadió un panel semitransparente que mejora la legibilidad. |
| Información basada únicamente en colores | Los estados dependían principalmente de colores como rojo y verde. | Se añadieron iconos y textos para reforzar el significado de cada estado. |
| Usuarios con discapacidad auditiva | Dependían completamente del audio para comprender la aplicación. | Pueden seguir las instrucciones mediante subtítulos sincronizados. |
| Usuarios con daltonismo | Existía riesgo de confusión entre algunos estados. | La nueva paleta facilita la diferenciación entre los distintos mensajes. |
| Comprensión de la interfaz | Algunas acciones requerían interpretar únicamente señales visuales o sonoras. | La información se presenta mediante varios canales de comunicación. |

---

# 2. Evaluación de las mejoras implementadas

Después de aplicar las modificaciones, la aplicación presenta un comportamiento más accesible para distintos perfiles de usuarios.

Las principales mejoras observadas fueron:

- Incorporación de subtítulos para todas las explicaciones importantes.
- Uso de una paleta de colores con mayor contraste.
- Inclusión de iconos que complementan la información visual.
- Mejor visibilidad del texto gracias al panel de fondo.
- Mayor facilidad para interpretar el estado de la aplicación.

Estas mejoras permiten que la experiencia resulte más comprensible y cómoda durante su utilización.

---

# 3. Beneficios obtenidos

La implementación de herramientas de accesibilidad aporta ventajas tanto para usuarios con discapacidad como para el resto de personas que utilizan la aplicación.

Entre los principales beneficios se encuentran:

- Mayor facilidad para comprender la información presentada.
- Reducción de errores durante la interacción.
- Mejor legibilidad de los textos en diferentes escenarios.
- Experiencia más inclusiva para distintos tipos de usuarios.
- Interfaz más organizada y fácil de utilizar.

---

# 4. Reflexión sobre la accesibilidad en XR

La accesibilidad representa un aspecto fundamental durante el desarrollo de aplicaciones de realidad virtual y aumentada. Diseñar pensando únicamente en usuarios sin limitaciones puede excluir a muchas personas que también podrían beneficiarse de estas tecnologías.

Durante este laboratorio se comprobó que pequeñas modificaciones, como incorporar subtítulos, mejorar el contraste de los textos o utilizar una paleta de colores accesible, producen una diferencia significativa en la experiencia de uso. Estas mejoras no solo benefician a personas con discapacidad auditiva o visual, sino también a cualquier usuario que utilice la aplicación en diferentes condiciones de iluminación, ruido o concentración.

Otro aspecto importante es evitar depender exclusivamente de un único canal para transmitir información. Cuando un mensaje se comunica únicamente mediante sonido o color, existe el riesgo de que parte de los usuarios no pueda comprenderlo correctamente. Por ello, combinar texto, iconos, colores y otros recursos permite construir aplicaciones mucho más inclusivas.

Finalmente, desarrollar experiencias accesibles no debe considerarse una tarea adicional, sino una parte esencial del proceso de diseño. Incorporar estas prácticas desde las primeras etapas del proyecto facilita la creación de aplicaciones XR capaces de ofrecer una experiencia equitativa para una mayor diversidad de personas.

---

# 5. Recomendaciones para futuras mejoras

Aunque la aplicación incorporó diversas funciones de accesibilidad, todavía existen oportunidades de mejora.

Algunas recomendaciones son:

- Implementar reconocimiento de voz para facilitar la interacción.
- Incorporar comandos mediante seguimiento de la mirada.
- Permitir cambiar el tamaño del texto desde el menú de configuración.
- Añadir descripciones de audio para usuarios con discapacidad visual.
- Ofrecer perfiles de accesibilidad personalizables según las necesidades de cada usuario.
- Traducir los subtítulos a diferentes idiomas cuando sea necesario.

Estas funciones ampliarían el alcance de la aplicación y permitirían atender una mayor variedad de usuarios.

---

# 6. Resultados finales

Después de completar el laboratorio se obtuvo una aplicación con mejores condiciones de accesibilidad.

Las principales mejoras alcanzadas fueron:

- Subtítulos integrados.
- Mayor contraste en la interfaz.
- Colores accesibles para usuarios con daltonismo.
- Información presentada mediante diferentes recursos visuales.
- Mejor comprensión de la información durante la experiencia XR.

---

# Evidencias

## Evidencia 1

Captura mostrando el funcionamiento del sistema de subtítulos durante la ejecución de la aplicación.

---

## Evidencia 2

Captura donde se observe la nueva paleta de colores implementada.

---

## Evidencia 3

Captura comparativa entre la interfaz original y la versión accesible.

---

## Evidencia 4

Captura del proyecto en Unity mostrando los scripts de accesibilidad incorporados.

---

# Lista de verificación

| Actividad | Estado |
|-----------|:------:|
| Sistema de subtítulos implementado | ✅ |
| Paleta de colores accesible aplicada | ✅ |
| Contraste de la interfaz mejorado | ✅ |
| Iconos agregados para reforzar la información | ✅ |
| Auditoría de accesibilidad realizada | ✅ |
| Reflexión desarrollada (más de 150 palabras) | ✅ |
| Reporte final elaborado | ✅ |

---

# Conclusión

Las mejoras implementadas durante este laboratorio permitieron incrementar el nivel de accesibilidad de la aplicación XR. La incorporación de subtítulos, una paleta de colores más adecuada y el uso de múltiples formas para comunicar la información contribuyen a que un mayor número de usuarios pueda interactuar con la aplicación de manera cómoda y comprensible. Además, la auditoría realizada permitió verificar que las modificaciones responden a principios básicos de accesibilidad y representan un avance hacia el desarrollo de experiencias XR más inclusivas y adaptadas a las necesidades de diferentes personas.