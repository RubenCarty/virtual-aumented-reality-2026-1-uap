# REPORTE_ACCESIBILIDAD.md

# Reporte de Implementación de Accesibilidad — Semana 13

**Curso:** Realidad Virtual y Aumentada  
**Laboratorio:** Semana 13 – Implementación de Accesibilidad en XR  
**Estudiante:** Salazar Mondragón Jael Santiago  **Código: 2221898131** 
**Fecha:** 10/07/2026 | **Puntuación total:** ____/20

---

# PARTE 1 — Implementación del sistema de subtítulos XR

## Objetivo

Desarrollar un sistema de subtítulos para una aplicación XR que permita mostrar mensajes de manera clara dentro del entorno virtual, facilitando el acceso a la información para personas con discapacidad auditiva y mejorando la experiencia general de todos los usuarios.

---

# 1. Creación de la interfaz de subtítulos

## Procedimiento

Se añadió un **Canvas** a la escena utilizando la siguiente ruta:

```text
Hierarchy → UI → Canvas
```

El objeto recibió el nombre:

```text
CanvasSubtitulos
```

Después se configuró el modo de renderizado del Canvas como:

```text
World Space
```

Esta configuración permite que la interfaz forme parte del entorno tridimensional y pueda desplazarse junto con el usuario durante la experiencia XR.

Para mantener un tamaño adecuado dentro del escenario se ajustaron las siguientes dimensiones:

| Propiedad | Valor |
|-----------|-------|
| Width | 2 |
| Height | 0.3 |
| Scale | 0.01, 0.01, 0.01 |

---

## Creación del panel de fondo

Dentro del Canvas se agregó un componente **Image**, denominado:

```text
PanelSubtitulos
```

Este panel tiene la función de mejorar la visibilidad del texto cuando el fondo de la escena presenta muchos colores o elementos.

Configuración aplicada:

| Propiedad | Valor |
|-----------|-------|
| Color | Negro |
| Opacidad | 70 % |
| Anchor | Stretch |

Con esta configuración se consigue un mejor contraste sin ocultar completamente el contenido del escenario.

---

## Configuración del texto

Se incorporó un objeto **TextMeshProUGUI** con el nombre:

```text
TextoSubtitulo
```

Parámetros utilizados:

| Propiedad | Valor |
|-----------|-------|
| Color | Blanco |
| Tamaño de fuente | 0.08 |
| Alineación | Centrada |
| Texto inicial | Vacío |

El uso de texto blanco sobre un fondo oscuro facilita la lectura y cumple con las recomendaciones de accesibilidad para interfaces digitales.

---

# 2. Desarrollo del script SubtitulosXR.cs

Se creó el archivo:

```text
Assets/Scripts/SubtitulosXR.cs
```

Este script se encarga de administrar el funcionamiento completo del sistema de subtítulos.

Entre sus principales funciones se encuentran:

- Mostrar mensajes al usuario.
- Ocultar automáticamente los subtítulos después de un tiempo determinado.
- Mantener el panel frente a la cámara.
- Controlar la visibilidad del sistema de subtítulos.

---

## Inicialización del sistema

Cuando comienza la escena, el método `Start()` realiza varias tareas importantes.

Primero obtiene una referencia de la cámara principal. Luego configura el estado inicial del panel y deja ocultos los subtítulos hasta que sea necesario mostrar un mensaje.

De esta manera se evita que aparezca información innecesaria al iniciar la aplicación.

---

## Uso de LateUpdate()

El movimiento del panel se controla mediante el método:

```csharp
LateUpdate()
```

Este método se ejecuta una vez que todos los objetos de la escena han actualizado su posición.

Gracias a ello, el panel siempre se coloca utilizando la posición definitiva de la cámara en cada fotograma, evitando retrasos o movimientos poco naturales cuando el usuario gira la cabeza.

Esta técnica proporciona una experiencia visual más estable dentro del entorno XR.

---

## Posicionamiento del panel

Durante cada actualización el sistema calcula una nueva posición para el Canvas.

El panel se coloca aproximadamente:

- Dos metros delante del usuario.
- Medio metro por debajo del centro de la cámara.

Esta ubicación permite leer cómodamente los mensajes sin bloquear la visión de los objetos principales de la escena.

---

## Movimiento suave

Para evitar desplazamientos bruscos se utiliza:

```csharp
Vector3.Lerp()
```

Esta función realiza una transición progresiva entre la posición actual y la nueva posición calculada.

Como resultado, el panel acompaña el movimiento del usuario de manera fluida.

---

## Mostrar un subtítulo

Los mensajes se presentan mediante el método:

```csharp
MostrarSubtitulo()
```

Este método recibe dos parámetros:

- El texto que se mostrará.
- El tiempo que permanecerá visible.

Ejemplo:

```csharp
MostrarSubtitulo(
    "Experimento completado correctamente",
    4f
);
```

Cuando aparece un nuevo mensaje, reemplaza automáticamente al anterior.

---

## Ocultar el mensaje

Una vez transcurrido el tiempo indicado, el sistema ejecuta el método:

```csharp
OcultarSubtitulo();
```

De esta forma el panel desaparece sin que el usuario tenga que realizar ninguna acción adicional.

---

# 3. Integración dentro del proyecto

El componente **SubtitulosXR** fue añadido al objeto:

```text
CanvasSubtitulos
```

Posteriormente se enlazaron desde el Inspector los siguientes elementos:

| Campo | Objeto asignado |
|--------|-----------------|
| Texto | TextoSubtitulo |
| Panel | PanelSubtitulos |

Con estas referencias el script puede modificar el contenido y controlar la visibilidad del sistema de subtítulos.

---

# 4. Verificación del funcionamiento

Para comprobar que el sistema respondía correctamente se creó un pequeño script de prueba.

Este script permite mostrar diferentes mensajes utilizando el teclado durante la ejecución.

## Controles

| Tecla | Acción |
|--------|--------|
| S | Mostrar un subtítulo corto |
| A | Mostrar un mensaje más extenso |
| D | Ocultar el subtítulo |

Estas pruebas permitieron verificar que el sistema responde correctamente ante diferentes situaciones.

---

# 5. Resultados obtenidos

Después de completar la implementación se obtuvieron los siguientes resultados:

- Los subtítulos aparecen cuando la aplicación envía un mensaje.
- El panel mantiene una posición constante frente al usuario.
- Los mensajes permanecen visibles únicamente durante el tiempo configurado.
- El desplazamiento del panel resulta suave y natural.
- El contraste facilita la lectura incluso cuando el fondo contiene muchos detalles.

---

# Aporte a la accesibilidad

Este sistema mejora la accesibilidad porque permite presentar la información mediante texto, ofreciendo una alternativa para usuarios que no pueden escuchar el contenido de audio.

Además, el panel de fondo evita problemas de visibilidad cuando existen escenarios con colores intensos o iluminación variable.

La solución también beneficia a usuarios que aprenden mejor mediante información visual o que utilizan la aplicación en lugares donde el sonido no puede reproducirse adecuadamente.

---

# Evidencias

## Evidencia 1

Captura de la jerarquía mostrando la estructura:

```text
CanvasSubtitulos
├── PanelSubtitulos
└── TextoSubtitulo
```

---

## Evidencia 2

Captura del Inspector donde se observen las referencias del componente **SubtitulosXR** correctamente configuradas.

---

## Evidencia 3

Captura de la escena mostrando un subtítulo visible durante la ejecución.

---

## Evidencia 4

Captura donde se observe que el panel continúa frente al usuario después de mover la cámara.

---

# Lista de verificación

| Actividad | Estado |
|-----------|:------:|
| Canvas configurado en World Space | ✅ |
| Panel de fondo implementado | ✅ |
| Texto con alto contraste | ✅ |
| Script SubtitulosXR agregado | ✅ |
| Seguimiento de la cámara mediante LateUpdate() | ✅ |
| Aparición automática de subtítulos | ✅ |
| Ocultamiento automático del mensaje | ✅ |
| Sistema integrado correctamente en la escena | ✅ |

---

# Conclusión

El sistema de subtítulos desarrollado mejora la accesibilidad dentro de la aplicación XR al ofrecer una forma adicional de presentar la información. Gracias al uso de un Canvas en **World Space** y al seguimiento continuo de la cámara mediante `LateUpdate()`, los mensajes permanecen siempre visibles sin afectar la interacción del usuario. Asimismo, el empleo de un panel semitransparente y texto de alto contraste favorece la lectura en distintos escenarios. En conjunto, esta implementación contribuye a crear una experiencia más cómoda, inclusiva y adaptable para una mayor variedad de usuarios.

# PARTE 2 — Desarrollo de una Paleta de Colores Accesible

## Objetivo

Diseñar e implementar una paleta de colores que facilite la identificación de la información para todos los usuarios, especialmente para personas con daltonismo. La propuesta busca evitar que el color sea el único recurso para comunicar estados o acciones dentro de la aplicación XR.

---

# 1. Identificación de la necesidad

En muchas interfaces de realidad virtual y aumentada es común representar estados mediante colores como rojo, verde o amarillo. Sin embargo, este método puede generar dificultades para usuarios que presentan alteraciones en la percepción de los colores.

Por ello, fue necesario seleccionar una combinación cromática que ofreciera mayor contraste y complementarla con otros elementos visuales que facilitaran la interpretación de la información.

---

# 2. Selección de colores accesibles

Se definió una nueva paleta con colores que presentan una mejor diferenciación visual.

| Estado | Color seleccionado | Código HEX |
|---------|-------------------|------------|
| Correcto | Azul | `#0078D4` |
| Advertencia | Amarillo | `#FFC107` |
| Error | Naranja | `#E67E22` |
| Información | Blanco | `#FFFFFF` |
| Fondo | Gris oscuro | `#2C2C2C` |

Esta combinación permite distinguir cada estado con mayor facilidad, incluso para personas con dificultades para identificar los colores rojo y verde.

---

# 3. Incorporación de elementos complementarios

Además del color, cada estado incorpora un recurso gráfico adicional para transmitir el mensaje de forma más clara.

| Estado | Color | Elemento visual |
|---------|--------|----------------|
| Correcto | Azul | ✔ Símbolo de confirmación |
| Advertencia | Amarillo | ⚠ Icono de advertencia |
| Error | Naranja | ✖ Símbolo de error |
| Información | Blanco | ℹ Icono informativo |

De esta manera, el usuario puede comprender el significado del mensaje sin depender únicamente de la percepción del color.

---

# 4. Implementación en Unity

Para administrar los colores de la interfaz se desarrolló el siguiente script.

Archivo:

```text
Assets/Scripts/PaletaAccesible.cs
```

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

    public void MostrarCorrecto()
    {
        indicador.color = colorCorrecto;
    }

    public void MostrarAdvertencia()
    {
        indicador.color = colorAdvertencia;
    }

    public void MostrarError()
    {
        indicador.color = colorError;
    }
}
```

---

# 5. Funcionamiento del script

El script controla el color del indicador según el estado de la aplicación.

Cada método modifica automáticamente el color del componente `Image`.

- `MostrarCorrecto()` cambia el indicador al color azul.
- `MostrarAdvertencia()` establece el color amarillo para representar una advertencia.
- `MostrarError()` asigna el color naranja para indicar una situación de error.

Al centralizar la configuración de colores en un solo script, resulta más sencillo realizar cambios futuros y mantener una apariencia uniforme en toda la aplicación.

---

# 6. Comprobación de la accesibilidad

Una vez aplicada la nueva paleta, se verificó que:

- Los distintos estados se distinguen con mayor facilidad.
- Los iconos complementan la información proporcionada por el color.
- La interfaz resulta más clara para usuarios con diferentes capacidades visuales.
- El contraste mejora la lectura de los elementos en pantalla.

---

# Ventajas de la solución

La implementación de esta paleta aporta diversos beneficios.

- Favorece la comprensión de la información para personas con daltonismo.
- Reduce la posibilidad de interpretar incorrectamente un estado del sistema.
- Cumple con las recomendaciones de accesibilidad al utilizar múltiples recursos para comunicar información.
- Mejora la experiencia de uso para todos los usuarios, no solo para quienes presentan discapacidad visual.

---

# Resultados obtenidos

Tras la implementación de la nueva paleta se observaron los siguientes resultados:

- Los estados son más fáciles de identificar.
- La interfaz presenta una mejor organización visual.
- La información es comprensible incluso cuando el usuario no distingue correctamente algunos colores.
- La aplicación ofrece una experiencia más inclusiva.

---

# Evidencias

## Evidencia 1

Captura de la interfaz original antes de modificar la paleta de colores.

---

## Evidencia 2

Captura de la interfaz utilizando la nueva combinación de colores accesibles.

---

## Evidencia 3

Captura donde se aprecien los iconos incorporados para reforzar el significado de cada estado.

---

## Evidencia 4

Captura del Inspector mostrando el componente **PaletaAccesible** con la configuración de los nuevos colores.

---

# Lista de verificación

| Actividad | Estado |
|-----------|:------:|
| Nueva paleta de colores implementada | ✅ |
| Colores con mejor contraste | ✅ |
| Iconos añadidos como apoyo visual | ✅ |
| Información independiente del color | ✅ |
| Script PaletaAccesible integrado | ✅ |
| Validación visual completada | ✅ |

---

# Conclusión

La incorporación de una paleta de colores accesible permitió que la información visual sea más clara y fácil de interpretar para una mayor variedad de usuarios. Al combinar colores con iconos y otros elementos gráficos, se evita depender exclusivamente de la percepción cromática para transmitir mensajes importantes. Esta mejora fortalece la accesibilidad de la aplicación XR y contribuye a ofrecer una experiencia más inclusiva y comprensible para todos los usuarios.

# PARTE 3 — Informe de Evaluación de Accesibilidad

## Objetivo

Analizar las mejoras de accesibilidad incorporadas al proyecto XR y comprobar cómo estas contribuyen a que la aplicación pueda ser utilizada por personas con distintas capacidades. Asimismo, se busca identificar los cambios obtenidos después de implementar las funciones desarrolladas durante el laboratorio.

---

# 1. Comparación de la aplicación antes y después

Para verificar el impacto de las mejoras implementadas, se realizó una comparación entre la versión original de la aplicación y la versión con funciones de accesibilidad.

| Aspecto evaluado | Antes | Después |
|------------------|-------|----------|
| Sistema de subtítulos | No estaba disponible. | Se implementaron subtítulos visibles durante las explicaciones. |
| Legibilidad del texto | Dependía del fondo de la escena. | Se incorporó un panel de fondo que mejora el contraste. |
| Identificación de estados | Se utilizaban únicamente colores. | Los estados incluyen colores, iconos y texto descriptivo. |
| Accesibilidad para usuarios con discapacidad auditiva | La información se transmitía principalmente mediante audio. | Los mensajes importantes también se presentan mediante subtítulos. |
| Accesibilidad para usuarios con daltonismo | Algunos estados podían confundirse por el uso de rojo y verde. | Se implementó una paleta de colores con mejor diferenciación visual. |
| Comprensión general | Algunas acciones podían resultar difíciles de interpretar. | La información se comunica utilizando diferentes recursos visuales y auditivos. |

---

# 2. Análisis de las mejoras realizadas

Las modificaciones implementadas permitieron aumentar el nivel de accesibilidad de la aplicación sin afectar su funcionamiento.

Entre los cambios más importantes destacan:

- Inclusión de subtítulos para acompañar las narraciones.
- Uso de una combinación de colores más adecuada para personas con daltonismo.
- Incorporación de iconos como apoyo visual.
- Mejora del contraste entre el texto y el fondo.
- Presentación de la información mediante diferentes canales de comunicación.

Estas mejoras facilitan la interacción y permiten que un mayor número de usuarios pueda utilizar la aplicación de forma cómoda.

---

# 3. Impacto de las funciones de accesibilidad

La incorporación de estas herramientas genera beneficios que no solo favorecen a personas con discapacidad, sino también a cualquier usuario que utilice la aplicación en distintas condiciones.

Entre los principales resultados obtenidos se encuentran:

- Mayor claridad al mostrar información importante.
- Reducción de posibles errores durante la interacción.
- Mejor comprensión de las instrucciones.
- Interfaz más sencilla de interpretar.
- Experiencia de usuario más inclusiva.

---

# 4. Reflexión

La accesibilidad es un aspecto esencial en el desarrollo de aplicaciones de realidad virtual y aumentada, ya que permite que un mayor número de personas pueda utilizar la tecnología sin encontrar barreras durante la interacción. Diseñar pensando únicamente en un tipo de usuario puede excluir a quienes presentan limitaciones visuales, auditivas, motoras o cognitivas.

Durante el desarrollo de este laboratorio se comprobó que pequeñas modificaciones pueden generar un impacto importante en la experiencia del usuario. La incorporación de subtítulos facilita la comprensión de la información para personas con discapacidad auditiva, mientras que el uso de una paleta de colores accesible reduce las dificultades que enfrentan quienes presentan daltonismo. Del mismo modo, mejorar el contraste entre el texto y el fondo incrementa la legibilidad para todos los usuarios.

Otro aspecto importante consiste en ofrecer la información mediante diferentes medios de comunicación. Cuando un mensaje combina texto, iconos, colores y sonido, la probabilidad de que el usuario comprenda correctamente el contenido aumenta considerablemente. Por esta razón, la accesibilidad no debe verse únicamente como un requisito técnico, sino como una práctica de diseño que contribuye a desarrollar aplicaciones más inclusivas, funcionales y fáciles de utilizar en distintos contextos.

---

# 5. Propuestas de mejora

Aunque la aplicación ya incorpora diversas funciones de accesibilidad, es posible seguir ampliando sus capacidades.

Entre las mejoras que podrían añadirse en futuras versiones se encuentran:

- Incorporar comandos de voz para facilitar la interacción.
- Implementar control mediante seguimiento de la mirada.
- Permitir modificar el tamaño del texto desde la configuración.
- Añadir descripciones de audio para los objetos principales.
- Crear perfiles de accesibilidad configurables por el usuario.
- Ofrecer soporte para diferentes idiomas y lenguas originarias.

Estas funciones permitirían que la aplicación pueda adaptarse a un mayor número de usuarios y escenarios de uso.

---

# 6. Resultados obtenidos

Después de implementar las mejoras de accesibilidad, la aplicación presenta las siguientes características:

- Sistema de subtítulos integrado.
- Mayor contraste entre texto y fondo.
- Colores adaptados para usuarios con daltonismo.
- Uso de iconos para reforzar la información.
- Interfaz más clara y sencilla de comprender.
- Mejor experiencia de uso para distintos perfiles de usuario.

---

# Evidencias

## Evidencia 1

Captura donde se observe el funcionamiento del sistema de subtítulos.

---

## Evidencia 2

Captura mostrando la nueva paleta de colores utilizada en la interfaz.

---

## Evidencia 3

Comparación entre la versión inicial de la aplicación y la versión accesible.

---

## Evidencia 4

Captura del proyecto en Unity mostrando los scripts implementados para mejorar la accesibilidad.

---

# Lista de verificación

| Actividad | Estado |
|-----------|:------:|
| Subtítulos implementados | ✅ |
| Paleta accesible aplicada | ✅ |
| Contraste visual mejorado | ✅ |
| Uso de iconos complementarios | ✅ |
| Comparación antes y después realizada | ✅ |
| Reflexión elaborada | ✅ |
| Reporte final completado | ✅ |

---

# Conclusión

La implementación de mejoras de accesibilidad permitió que la aplicación XR ofreciera una experiencia más inclusiva para diferentes tipos de usuarios. La incorporación de subtítulos, una paleta de colores accesible y el uso de múltiples recursos para presentar la información reducen las barreras de interacción y facilitan la comprensión del contenido. Además, la evaluación realizada demuestra que aplicar principios de accesibilidad desde las primeras etapas del desarrollo contribuye a crear aplicaciones más funcionales, intuitivas y preparadas para atender las necesidades de una población diversa.