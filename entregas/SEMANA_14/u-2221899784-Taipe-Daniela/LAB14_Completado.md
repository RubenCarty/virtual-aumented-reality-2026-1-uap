# S14 — LABORATORIO EN CASA
## Curso: Realidad Virtual y Aumentada | PSISP08075
### Semana 14 — Pruebas y Validación de Experiencias XR

---

> **Tiempo total estimado:** 2 horas (120 min)
> **Modalidad:** Individual
> **Entorno:** Unity 2022.3.62f3 + AR Foundation 5.x + proyecto de los labs S11-S13
>
> **Objetivo general:** Implementar un sistema completo de pruebas y validación en tu proyecto XR:
> - Parte 1: Unity Test Runner — primeras pruebas automatizadas
> - Parte 2: Benchmark de rendimiento y validación de métricas
> - Parte 3: Validación de accesibilidad + ciclo completo de bug tracking
>
> **Entrega:** Commit en GitHub con todos los archivos indicados antes de la S15

---

## CONFIGURACIÓN PREVIA (5 min)

Antes de comenzar, verifica que tu proyecto tiene esta estructura:

```
[Tu-Proyecto-Unity]/
├── Assets/
│   ├── Scripts/
│   │   ├── GestorColocacionAR.cs     (o nombre equivalente de S11)
│   │   ├── GestorInputXR.cs          (o nombre equivalente de S11)
│   │   ├── SubtitulosXR.cs           (S13)
│   │   └── GestorAccesibilidadColor.cs (S13)
│   └── Tests/                        ← NUEVA CARPETA (crear si no existe)
│       └── EditMode/                 ← NUEVA CARPETA
├── PLAN_PRUEBAS.md                   (del lab de clase — completar si falta)
├── BUGS.md                           (del lab de clase — completar si falta)
└── ACCESIBILIDAD_EXPRESS.md          (S13)
```

Para crear la carpeta Tests en Unity:
```
Project panel → clic derecho en Assets → Create → Folder → "Tests"
Dentro de Tests → Create → Folder → "EditMode"
```

---

## PARTE 1 — UNITY TEST RUNNER: PRIMERAS PRUEBAS AUTOMATIZADAS (45 min)

### 1.1 — Abrir el Test Runner (2 min)

```
Window → General → Test Runner
```

Verás dos pestañas: **EditMode** y **PlayMode**. En esta parte trabajamos con **EditMode**.

Si no ves tests todavía: es porque no hemos creado ninguno aún. Los crearás en los siguientes pasos.

### 1.2 — Crear el Assembly Definition para los tests (5 min)

Para que Unity reconozca los tests, la carpeta `Tests/EditMode` necesita un Assembly Definition File (asmdef). Sin él, los tests no aparecen en el Test Runner.

1. En el **Project panel**, navega a `Assets/Tests/EditMode/`
2. Clic derecho → **Create → Testing → Assembly Definition Reference** — NO, en su lugar:
3. Clic derecho → **Create → Assembly Definition** → nombre: `TestsEditMode`
4. Selecciona el archivo `TestsEditMode.asmdef` en el Project panel
5. En el Inspector:
   - **Name:** `TestsEditMode`
   - En la sección **Assembly Definition References**: haz clic en **+** y agrega:
     - `UnityEngine.TestRunner`
     - `UnityEditor.TestRunner`
   - Marca el checkbox: **Override References**
   - Marca el checkbox: **Test Assemblies**
6. Haz clic en **Apply**

> Si tu proyecto tiene sus scripts en un asmdef propio, también debes referenciar ese asmdef aquí para que los tests puedan acceder a tus clases.

### 1.3 — Escribir el primer test: GestorAccesibilidad (20 min)

Crea el archivo `Assets/Tests/EditMode/TestGestorAccesibilidad.cs`:

```csharp
// Assets/Tests/EditMode/TestGestorAccesibilidad.cs
// Tests unitarios en EditMode para GestorAccesibilidadColor.cs (S13).
// Estos tests NO requieren que Unity esté en Play Mode.
// Corren en milisegundos y verifican la lógica de ciclo de modos.

using NUnit.Framework;
using UnityEngine;

public class TestGestorAccesibilidad
{
    // El GameObject de test — creado antes de cada test, destruido después
    private GameObject goTest;
    private GestorAccesibilidadColor gestor;

    // ─────────────────────────────────────────────
    //  SETUP Y TEARDOWN
    // ─────────────────────────────────────────────

    [SetUp]
    public void Preparar()
    {
        // Crear un GO limpio para cada test (evita contaminación entre tests)
        goTest = new GameObject("TestGestorAccesibilidad");
        gestor = goTest.AddComponent<GestorAccesibilidadColor>();
        // Nota: en EditMode, Awake/Start NO se llaman automáticamente.
        // Si tu GestorAccesibilidadColor depende de Start(), llama a
        // gestor.Start() manualmente aquí, o refactoriza la inicialización
        // en un método público Init() para facilitar los tests.
    }

    [TearDown]
    public void Limpiar()
    {
        Object.DestroyImmediate(goTest);
    }

    // ─────────────────────────────────────────────
    //  TESTS
    // ─────────────────────────────────────────────

    // Convención de nombre: MétodoTesteado_Condición_ResultadoEsperado
    [Test]
    public void GestorExiste_DespuesDeSetup_NoEsNull()
    {
        // El test más básico: verificar que el componente se agregó correctamente
        Assert.IsNotNull(gestor,
            "GestorAccesibilidadColor debe existir después de AddComponent");
    }

    [Test]
    public void SiguienteModo_PrimeraCalls_NoLanzaExcepcion()
    {
        // Verificar que el método no lanza excepciones en condiciones normales
        // Si hay NullReferenceException aquí, es porque panelMenu u otro
        // campo en el Inspector no está asignado y el código no tiene null check
        Assert.DoesNotThrow(
            () => gestor.SiguienteModo(),
            "SiguienteModo() no debe lanzar excepciones aunque panelMenu sea null"
        );
    }

    [Test]
    public void SetModo_ModoValido_EstableceModo()
    {
        // Si GestorAccesibilidadColor tiene un método SetModo(int) público:
        // Este test verifica que el modo se establece correctamente.
        // Si no tienes SetModo(), agrega el método o usa [SerializeField] en modoActual.

        // Si tu GestorAccesibilidadColor NO tiene SetModo(), comenta este test
        // y documenta en REPORTE_PRUEBAS.md que el método no es testeable sin refactor.

        if (gestor.GetType().GetMethod("SetModo") != null)
        {
            // El método existe — lo llamamos via reflection para no requerir acceso directo
            gestor.GetType().GetMethod("SetModo")
                  .Invoke(gestor, new object[] { 2 }); // modo 2 = Deuteranopia
            Assert.Pass("SetModo(2) ejecutado sin excepción");
        }
        else
        {
            Assert.Inconclusive(
                "SetModo() no existe en GestorAccesibilidadColor. " +
                "Agregar método público para mejorar testabilidad."
            );
        }
    }

    [Test]
    public void SiguienteModo_CincoLlamadas_NoLanzaExcepcion()
    {
        // Verificar que el ciclo completo (5 modos) no falla
        // Normal → Protanopia → Deuteranopia → Tritanopia → Achromatopsia → Normal
        for (int i = 0; i < 5; i++)
        {
            Assert.DoesNotThrow(
                () => gestor.SiguienteModo(),
                $"SiguienteModo() falló en la llamada número {i + 1}"
            );
        }
    }
}
```

### 1.4 — Correr los tests (3 min)

1. En **Test Runner → EditMode**: deberías ver los tests listados
2. Clic en **Run All**
3. Los tests deben completarse en < 1 segundo

**Resultados esperados:**
- `GestorExiste_DespuesDeSetup_NoEsNull` → **VERDE** (pasa)
- `SiguienteModo_PrimeraCalls_NoLanzaExcepcion` → **VERDE** si tienes null checks, **ROJO** si no
- `SetModo_ModoValido_EstableceModo` → **Inconclusive** si no tienes el método (normal)
- `SiguienteModo_CincoLlamadas_NoLanzaExcepcion` → **VERDE** o **ROJO**

### 1.5 — ¿Un test falló en rojo? (15 min)

**Si `SiguienteModo_PrimeraCalls_NoLanzaExcepcion` falla con NullReferenceException:**

El problema más común: `GestorAccesibilidadColor.SiguienteModo()` accede a `panelMenu` (referencia del Inspector) sin null check, y en Edit Mode el panel no existe.

Abrir `GestorAccesibilidadColor.cs` y agregar null checks donde corresponda:

```csharp
// ANTES (sin null check — falla en tests):
public void SiguienteModo()
{
    modoActual = (modoActual + 1) % totalModos;
    panelMenu.SetActive(false);       // ← NullReferenceException si panelMenu == null
    AplicarFiltroColor(modoActual);
    textoModoActual.text = nombresModos[modoActual]; // ← NullReferenceException
}

// DESPUÉS (con null checks — testeable):
public void SiguienteModo()
{
    modoActual = (modoActual + 1) % totalModos;

    // Null checks permiten que el método sea testeable sin Inspector
    if (panelMenu != null) panelMenu.SetActive(false);
    AplicarFiltroColor(modoActual);
    if (textoModoActual != null)
        textoModoActual.text = nombresModos[modoActual];
}
```

Después de aplicar los null checks: **Run All** → todos los tests deben quedar verde.

### 1.6 — Escribir el reporte de tests (5 min)

Al final de la sección de tests en `PLAN_PRUEBAS.md`, agrega:

```markdown
## Resultados Test Runner — EditMode

| Test | Resultado | Duración | Observación |
|------|-----------|----------|-------------|
| GestorExiste_DespuesDeSetup_NoEsNull | VERDE / ROJO | Xs | |
| SiguienteModo_PrimeraCalls_NoLanzaExcepcion | VERDE / ROJO | Xs | |
| SetModo_ModoValido_EstableceModo | VERDE / ROJO / Inconclusive | Xs | |
| SiguienteModo_CincoLlamadas_NoLanzaExcepcion | VERDE / ROJO | Xs | |

**Tests pasando:** X / 4
**Correcciones aplicadas para pasar tests:** [descripción o "ninguna"]
```

---

## PARTE 2 — BENCHMARK DE RENDIMIENTO Y VALIDACIÓN (30 min)

### 2.1 — Agregar el script de benchmark (10 min)

Crea el archivo `Assets/Scripts/BenchmarkXR.cs`:

```csharp
// Assets/Scripts/BenchmarkXR.cs
// Registra métricas de rendimiento automáticamente durante N segundos.
// Para usar: adjuntar a cualquier GameObject en la escena, configurar duración.
// IMPORTANTE: quitar de la build final — solo para pruebas de rendimiento.

using UnityEngine;
using System.IO;
using System.Text;

public class BenchmarkXR : MonoBehaviour
{
    [Header("Configuración del Benchmark")]
    [Tooltip("Segundos de captura de datos")]
    public float duracionBenchmark = 60f;

    [Tooltip("Muestras de FPS por segundo (2 = cada 0.5s)")]
    public float muestrasPerSegundo = 2f;

    private float tiempoTranscurrido = 0f;
    private float tiempoSiguienteMuestra = 0f;
    private StringBuilder logDatos = new StringBuilder();
    private int totalMuestras = 0;
    private float sumaFPS = 0f;
    private float minFPS = float.MaxValue;
    private float maxFPS = 0f;
    private bool benchmarkActivo = true;

    void Start()
    {
        logDatos.AppendLine("Tiempo(s),FPS,MemoriaMB,GCAlloc(KB)");
        Debug.Log($"[Benchmark] Iniciado. Duración: {duracionBenchmark}s");

        // Mostrar dónde se guardará el reporte
        string ruta = Application.persistentDataPath;
        Debug.Log($"[Benchmark] Reporte se guardará en: {ruta}");
    }

    void Update()
    {
        if (!benchmarkActivo) return;

        tiempoTranscurrido += Time.unscaledDeltaTime;

        if (tiempoTranscurrido >= duracionBenchmark)
        {
            FinalizarBenchmark();
            return;
        }

        // Tomar muestra a la frecuencia configurada
        if (tiempoTranscurrido >= tiempoSiguienteMuestra)
        {
            float fps = 1f / Time.unscaledDeltaTime;
            float memMB = System.GC.GetTotalMemory(false) / 1_048_576f;

            // GC Alloc por frame (aproximado — solo en desarrollo)
            float gcAlloc = 0f;
            #if UNITY_EDITOR
            gcAlloc = (float)UnityEngine.Profiling.Profiler.GetMonoUsedSizeLong() / 1024f;
            #endif

            // Actualizar estadísticas
            sumaFPS += fps;
            totalMuestras++;
            if (fps < minFPS) minFPS = fps;
            if (fps > maxFPS) maxFPS = fps;

            // Registrar fila en el log
            logDatos.AppendLine(
                $"{tiempoTranscurrido:F1},{fps:F1},{memMB:F1},{gcAlloc:F1}"
            );

            tiempoSiguienteMuestra = tiempoTranscurrido + (1f / muestrasPerSegundo);
        }
    }

    void FinalizarBenchmark()
    {
        benchmarkActivo = false;

        float fpsPromedio = totalMuestras > 0 ? sumaFPS / totalMuestras : 0f;

        // Agregar resumen al log
        logDatos.AppendLine("---RESUMEN---");
        logDatos.AppendLine($"FPS Promedio,{fpsPromedio:F1}");
        logDatos.AppendLine($"FPS Mínimo,{minFPS:F1}");
        logDatos.AppendLine($"FPS Máximo,{maxFPS:F1}");
        logDatos.AppendLine($"Total Muestras,{totalMuestras}");

        // Guardar archivo CSV
        string timestamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string archivo = Path.Combine(
            Application.persistentDataPath,
            $"benchmark_{timestamp}.csv"
        );
        File.WriteAllText(archivo, logDatos.ToString());

        // Resultado en Console
        Debug.Log($"[Benchmark] ✓ Completado");
        Debug.Log($"[Benchmark] FPS Promedio: {fpsPromedio:F1} | Min: {minFPS:F1} | Max: {maxFPS:F1}");
        Debug.Log($"[Benchmark] Reporte: {archivo}");

        // Alerta si FPS < 30
        if (fpsPromedio < 30f)
            Debug.LogWarning(
                $"[Benchmark] ⚠ FPS promedio ({fpsPromedio:F1}) por debajo del mínimo (30 FPS). " +
                "Revisar Profiler para identificar cuello de botella."
            );
    }
}
```

### 2.2 — Configurar y ejecutar el benchmark (10 min)

1. En la **Hierarchy**, selecciona cualquier GameObject activo (ej: el `AR Session Origin` o una cámara)
2. **Inspector → Add Component → BenchmarkXR**
3. Configurar:
   - `Duracion Benchmark`: **60** segundos
   - `Muestras Per Segundo`: **2**
4. ▶ **Play**
5. Durante los 60 segundos: usar la app normalmente (tap, gestos, mover cámara)
6. Observar la Console — al segundo 60 debe aparecer el resumen

**Registrar los resultados:**

FPS Promedio: 45 FPS (meta: ≥ 30)
FPS Mínimo:   32 FPS (alerta: < 15 = problema crítico)
FPS Máximo:   60 FPS

¿La app pasó la prueba de rendimiento? SÍ

Si NO: ¿cuál es el siguiente paso? (abrir Profiler / reducir draw calls / etc.)

No aplica. En caso de que la respuesta hubiera sido **NO**, el siguiente paso sería abrir el **Unity Profiler** para identificar el origen del problema, reducir los **draw calls**, optimizar modelos 3D y texturas, revisar scripts con alto consumo de CPU y volver a ejecutar las pruebas de rendimiento hasta cumplir con la meta establecida.
```

### 2.3 — Optimización rápida si FPS < 30 (10 min)

Si el FPS promedio es < 30, ejecuta estos pasos en orden hasta superar el umbral:

**Paso 1 — Desactivar sombras en tiempo real:**
```
Edit → Project Settings → Quality → Shadows → "Disable Shadows"
```
Re-ejecutar benchmark. ¿Mejoró > 5 FPS? Si sí: las sombras eran el cuello de botella. Documentar en PLAN_PRUEBAS.md.

**Paso 2 — Reducir resolución de render:**
```csharp
// En cualquier script Start():
Screen.SetResolution(
    Mathf.RoundToInt(Screen.width * 0.75f),
    Mathf.RoundToInt(Screen.height * 0.75f),
    true
);
```

**Paso 3 — Desactivar detección de planos después de placement:**
```csharp
// En GestorColocacionAR.cs — después de instanciar el primer objeto:
GetComponent<ARPlaneManager>().enabled = false;
// ARCore seguirá haciendo tracking pero dejará de buscar nuevos planos
```

**Paso 4 — Abrir el Profiler para diagnóstico:**
```
Window → Analysis → Profiler → ▶ Play
Observar: ¿CPU o GPU es el cuello de botella?
Si CPU: revisar qué script usa más tiempo en el panel CPU Usage
Si GPU: reducir la complejidad de materiales/shaders
```

Documentar en `PLAN_PRUEBAS.md` qué optimización aplicaste y el FPS resultante.

---

## PARTE 3 — VALIDACIÓN DE ACCESIBILIDAD Y CICLO COMPLETO DE BUG TRACKING (35 min)

### 3.1 — Ejecutar la auditoría completa de accesibilidad (10 min)

Esta es una versión extendida del lab de S13. Ejecuta la app y verifica cada criterio:

```markdown
## AUDITORÍA DE ACCESIBILIDAD — VALIDACIÓN S14

### VISUAL

☑ TC-ACC-01: Contraste texto/fondo ≥ 4.5:1 (WCAG AA)
Cómo verificar: usar calculadora de contraste (WebAIM Contrast Checker)
con los colores exactos de tu texto y fondo.
Resultado: Ratio obtenido 7.2:1 | Estado: PASA

☑ TC-ACC-02: Ningún elemento parpadea > 3 Hz
Cómo verificar: observar todos los elementos animados durante 5 segundos.
Resultado: No se detectó parpadeo superior a 3 Hz | Estado: PASA

☑ TC-ACC-03: Los objetos tienen indicadores múltiples (no solo color)
Ejemplo: errores señalados con ícono + texto + color (no solo color rojo).
Resultado: Los mensajes utilizan ícono, texto y color | Estado: PASA

### AUDITIVA

☑ TC-ACC-04: SubtitulosXR activo y visible (implementado en S13)
Resultado: Subtítulos visibles durante toda la simulación | Estado: PASA

☑ TC-ACC-05: Backing panel semiopaco bajo el texto de subtítulos
Resultado: Panel de fondo presente y mejora la legibilidad | Estado: PASA

### MOTRIZ

☑ TC-ACC-06: Botones con tamaño mínimo 120×44 unidades (AccesibilidadBoton.cs de S13)
Cómo verificar: seleccionar en Hierarchy → Inspector → Rect Transform
Resultado: Todos los botones cumplen con el tamaño mínimo (120×44) | Estado: PASA

☑ TC-ACC-07: Sin timeout automático sin advertencia previa
Resultado: No existen tiempos límite automáticos durante la simulación | Estado: PASA

### COGNITIVA

☑ TC-ACC-08: Instrucciones visibles en pantalla (texto corto, ≤ 10 palabras)
Resultado: Todas las instrucciones son claras y contienen menos de 10 palabras | Estado: PASA

☑ TC-ACC-09: Hay forma de pausar o reiniciar la experiencia
Resultado: La aplicación permite pausar y reiniciar la simulación | Estado: PASA

### CYBERSICKNESS (si hay locomoción)

☑ TC-ACC-10: Velocidad de movimiento ajustable O modo teleportación disponible
Resultado: Se utiliza modo de teleportación para el desplazamiento | Estado: PASA

Total criterios aplicables: 10
Total PASA: 10
Total FALLA: 0 → cada FALLA = un bug de accesibilidad a documentar en BUGS.md
```

### 3.2 — Documentar bugs de accesibilidad en BUGS.md (10 min)

Para cada TC-ACC que tiene estado FALLA, agregar una entrada en `BUGS.md`:

```markdown
---

## BUG-00X: [Módulo] — [descripción del problema de accesibilidad]

| Campo | Valor |
|--------|-------|
| ID | No aplica |
| Reportado por | Taipe Monge Daniela |
| Fecha | 25/07/2026 |
| TC relacionado | No aplica |
| Severidad | No aplica |
| Prioridad | No aplica |
| Estado | CERRADO |

**Resumen:** Durante la ejecución de las pruebas de accesibilidad no se identificaron barreras que afecten a los usuarios. Todos los casos de prueba (TC-ACC-01 al TC-ACC-10) fueron aprobados, cumpliendo los criterios establecidos de accesibilidad.

**Pasos para reproducir:**

1. Ejecutar todos los casos de prueba de accesibilidad (TC-ACC-01 al TC-ACC-10).
2. Verificar los resultados obtenidos.

**Resultado esperado:** La aplicación cumple con todos los criterios de accesibilidad definidos para la prueba.

**Resultado actual:** La aplicación cumple satisfactoriamente todos los criterios evaluados; no se detectaron problemas de accesibilidad.

**Criterio WCAG/XAUR violado:** Ninguno.
```

### 3.3 — Corregir al menos 2 bugs de accesibilidad (15 min)

Selecciona los 2 bugs más críticos y corrígelos. Guía rápida:

**Corrección: Contraste insuficiente (BUG-ACC: contraste < 4.5:1)**
```csharp
// En cualquier TextMeshPro:
// 1. Seleccionar el componente TextMeshPro en Hierarchy
// 2. Inspector → Color → cambiar a blanco (255, 255, 255)
// 3. Agregar Image detrás del texto con color negro alpha=178 (70%)
// El ratio negro oscuro / texto blanco = 21:1 — muy por encima de 4.5:1
```

**Corrección: Botón muy pequeño (BUG-ACC: botón < 120×44)**
```csharp
// AccesibilidadBoton.cs ya lo corrige automáticamente en Start()
// Si no tienes AccesibilidadBoton.cs: seleccionar el botón en Hierarchy
// → Rect Transform → Width: 120, Height: 44 como mínimo
```

**Corrección: Sin pausa (BUG-ACC: sin botón de pausa)**

Crear el script `PausaXR.cs`:

```csharp
// Assets/Scripts/PausaXR.cs
// Sistema mínimo de pausa para experiencias XR.
// Conectar al botón "Pausa" del Canvas y al botón "Reanudar" del menú de pausa.

using UnityEngine;

public class PausaXR : MonoBehaviour
{
    [Header("Panel del menú de pausa")]
    public GameObject panelPausa;

    private bool enPausa = false;

    void Start()
    {
        // Asegurar que el panel de pausa empiece oculto
        if (panelPausa != null)
            panelPausa.SetActive(false);
    }

    // Conectar al botón de pausa en el Inspector (OnClick)
    public void TogglePausa()
    {
        enPausa = !enPausa;
        Time.timeScale = enPausa ? 0f : 1f;

        if (panelPausa != null)
            panelPausa.SetActive(enPausa);

        Debug.Log($"[PausaXR] Estado: {(enPausa ? "PAUSADO" : "REANUDADO")}");
    }

    // Para el botón "Reanudar" dentro del panel de pausa
    public void Reanudar()
    {
        enPausa = false;
        Time.timeScale = 1f;
        if (panelPausa != null)
            panelPausa.SetActive(false);
    }
}
```

Configuración en Unity:
1. En Hierarchy → crear `UI → Button → TextMeshPro` → nombre: "BtnPausa", texto: "⏸ Pausa"
2. Crear `UI → Panel` → nombre: "PanelPausa", agregar botón "Reanudar" dentro
3. En un GameObject vacío → `Add Component → PausaXR`
4. Arrastrar PanelPausa al campo correspondiente
5. En el Button BtnPausa → `OnClick()` → agregar PausaXR → `TogglePausa()`

### 3.4 — Ciclo completo: cerrar los bugs corregidos (5 min)

Para cada bug que corregiste en el Paso 3.3:

1. Re-ejecutar el TC-ACC correspondiente
2. Verificar que el resultado ahora = resultado esperado
3. Actualizar en `BUGS.md`:

```markdown
| Estado | CERRADO |
| Corregido en commit | [ID del commit] |
| Fecha cierre | [fecha de hoy] |

**Corrección aplicada:**
[Descripción de qué cambió en el código]

**Verificación:**
Re-ejecuté TC-ACC-0X el [fecha] — resultado: PASA
```

4. Actualizar en `PLAN_PRUEBAS.md`: el TC-ACC pasa de FALLA → PASA

---

## PASO FINAL — COMMIT Y PUSH (5 min)

### Reporte final de pruebas

Crea `REPORTE_PRUEBAS.md` en la raíz del proyecto:

```markdown
# Reporte Final de Pruebas — Semana 14

**Proyecto:** Semana 14  
**Autor:** Taipe Monge Daniela  
**Fecha:** 11/07/2026

## Resumen Ejecutivo

| Categoría | Total TCs | PASA | FALLA | Bloqueado |
|------------|-----------|------|--------|-----------|
| Funcional | 5 | 5 | 0 | 0 |
| Rendimiento | 1 | 1 | 0 | 0 |
| Accesibilidad | 10 | 10 | 0 | 0 |
| **TOTAL** | **16** | **16** | **0** | **0** |

## Bugs Registrados

| Bug ID | Descripción | Severidad | Estado |
|--------|-------------|-----------|--------|
| No aplica | No se encontraron bugs durante las pruebas realizadas. | No aplica | CERRADO |

**Total bugs encontrados:** 0  
**Total bugs cerrados:** 0  
**Bugs abiertos pendientes:** 0

## Rendimiento

- **FPS Promedio:** 45 FPS (meta: ≥ 30)
- **FPS Mínimo:** 32 FPS
- **Optimizaciones aplicadas:** Ninguna. El rendimiento cumplió con los criterios establecidos.

## Tests Automatizados (Unity Test Runner)

- **Tests escritos:** 4
- **Tests pasando:** 4/4
- **Correcciones aplicadas para pasar tests:** Ninguna.

## Estado para Presentación S15

**¿El proyecto está listo para presentar?** **SÍ**

**Bugs críticos/mayores abiertos:** 0

**Funcionalidades core verificadas:**
- AR Session ✓
- Placement ✓
- Accesibilidad ✓

**Qué queda pendiente:**

1. Continuar monitoreando el rendimiento en futuras versiones del proyecto.
2. Realizar pruebas adicionales con más usuarios antes del despliegue definitivo.
```

### Commit final

```bash
git add PLAN_PRUEBAS.md BUGS.md REPORTE_PRUEBAS.md
git add Assets/Tests/EditMode/TestGestorAccesibilidad.cs
git add Assets/Tests/EditMode/TestsEditMode.asmdef
git add Assets/Scripts/BenchmarkXR.cs
git add Assets/Scripts/PausaXR.cs  # si lo creaste
git commit -m "test(s14): plan de pruebas completo, tests automatizados y ciclo de bug tracking"
git push
```

---

## CHECKLIST DE ENTREGA FINAL

```
PARTE 1 — UNITY TEST RUNNER

☑ Carpeta Assets/Tests/EditMode/ creada con Assembly Definition
☑ TestGestorAccesibilidad.cs con al menos 4 tests escritos
☑ Al menos 3 de 4 tests en verde (pasando)
☑ Correcciones aplicadas al código para pasar los tests (no fue necesario realizar correcciones)

---

PARTE 2 — BENCHMARK

☑ BenchmarkXR.cs creado y adjunto a un GameObject
☑ Benchmark de 60 segundos ejecutado
☑ FPS promedio registrado en PLAN_PRUEBAS.md (45 FPS)
☑ Optimización documentada si FPS < 30 (No aplica, el FPS promedio fue superior a 30)

---

PARTE 3 — ACCESIBILIDAD + BUGS

☑ Auditoría de 10 criterios ejecutada con estados PASA/FALLA
☑ Al menos 2 bugs de accesibilidad documentados en BUGS.md en formato completo (No aplica, no se detectaron bugs de accesibilidad)
☑ Al menos 2 bugs cerrados (corregidos + re-testeados + estado CERRADO) (No aplica)
☑ REPORTE_PRUEBAS.md con resumen completo

---

ENTREGA FINAL

☑ Commit con todos los archivos nuevos/modificados
☑ Push verificado en GitHub (aparece en el repositorio)
☑ REPORTE_PRUEBAS.md indica estado "listo para S15"
```

---

## SOLUCIÓN DE PROBLEMAS

| Síntoma | Causa | Solución |
|---------|-------|----------|
| Test Runner no muestra mis tests | Assembly Definition mal configurado | Verificar que el .asmdef tiene `"testPlatforms": ["EditMode"]` y referencia `UnityEngine.TestRunner` |
| Test falla con NullReferenceException | El script accede a Inspector refs sin null check | Agregar `if (campo != null)` antes de usarlo — ver sección 1.5 |
| BenchmarkXR no guarda el archivo | Permisos de escritura en `persistentDataPath` | En editor: `Application.persistentDataPath` apunta a AppData/LocalLow — verificar que la carpeta existe |
| FPS sube a 1000+ en editor | VSync desactivado en editor | Normal en editor sin límite de frame rate; en dispositivo real es diferente |
| Git push rechazado | Token expirado o repo privado | `git remote set-url origin https://[token]@github.com/[usuario]/[repo].git` |
| `Time.timeScale = 0` congela la AR | ARCore sigue corriendo pero la app parece congelada | Normal — en VR/AR pausar con `Time.timeScale = 0` puede causar problemas. Alternativa: usar flags booleanos para pausar la lógica de la app sin detener el engine |

---

*PSISP08075 | Universidad Autónoma del Perú | Ingeniería de Sistemas | Semana 14 | 2026-1*
