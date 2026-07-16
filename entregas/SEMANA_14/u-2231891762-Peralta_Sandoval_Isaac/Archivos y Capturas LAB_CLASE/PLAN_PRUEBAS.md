# Plan de Pruebas — Monitoreo de Sensores AR Accesible
**Autor:** Peralta Sandoval, Isaac Josue
**Fecha:** 14 de Julio de 2026
**Versión Unity:** 2022.3.62f3
**Dispositivo target:** Android 12+ (Samsung, Xiaomi o similar con soporte ARCore)
**Versión ARCore:** 5.2.2 (AR Foundation)

---

## Alcance

**En scope (qué vamos a probar):**
- [✓] Detección de planos AR e inicio de la sesión
- [✓] Mapeo y colocación de sensores en la escena con un Tap (si está implementado)
- [✓] Visualización de la telemetría en tiempo real de la API de sensores
- [✓] Accesibilidad: subtítulos automáticos ante alertas de sensores (S13)
- [✓] Accesibilidad: cambio de paleta cromática, brillo y contraste desde el menú
- [✓] Rendimiento: FPS estable en el editor y simulación

**Fuera de scope (justificado):**
- Tests en iOS: No se cuenta con compilador Xcode ni equipo Mac para la prueba.
- Tests de carga simultánea: El sistema AR simula un único operario a la vez.

---

## Casos de Prueba

| TC-ID | Módulo | Descripción | Precondiciones | Pasos | Resultado Esperado | Estado |
|-------|--------|-------------|----------------|-------|-------------------|--------|
| TC-001 | ARSession | AR Session inicia y detecta plano correctamente | Permiso de cámara concedido, entorno iluminado | 1. Iniciar el modo Play en Unity | La consola no muestra errores. El sistema se inicializa en estado Tracking en < 10s. | PASA |
| TC-002 | API UI | Telemetría de sensores se actualiza en tiempo real | API activa o simulación de lectura de JSON cargada | 1. Iniciar modo Play y observar paneles de sensores | Los datos de temperatura, estado y nombre se despliegan en las tarjetas AR de forma dinámica. | PASA |
| TC-003 | Accesibilidad | Subtítulos automáticos ante alertas de la API | Script de SubtítulosXR e integración con SensorARManager activos | 1. Iniciar modo Play 2. Esperar a que la API detecte un sensor con estado "alerta" (ej. Compresor A) | Se despliega automáticamente el subtítulo abajo de la pantalla con fondo oscuro. Se oculta tras 3 o 4 segundos. | Pendiente |
| TC-004 | Accesibilidad | Menú de color cambia el modo y brillo | Menú de accesibilidad configurado en ARCamera | 1. Abrir PanelAccesibilidad 2. Clic en "Siguiente modo de color" 3. Deslizar slider de Brillo | El texto amarillo actualiza el nombre del modo. En consola se registran los cambios de color y brillo sin errores. | PASA |
| TC-005 | Rendimiento | Estabilidad de FPS en ejecución | Escena principal activa en modo Play | 1. Activar el panel "Stats" en el Game View 2. Observar el rendimiento durante 60 segundos | El promedio de FPS se mantiene igual o superior a 30 FPS sin tirones visuales drásticos. | 400-800 fps PASA |
| TC-006 | Estabilidad | Robustez general libre de excepciones críticas | Proyecto completo | 1. Interactuar con la simulación durante 5 minutos usando sliders y botones alternadamente | La consola se mantiene con 0 "NullReferenceException" o errores en rojo durante el ciclo de uso. | PASA |

---

## Criterios de Aceptación para Presentación

- 0 bugs de severidad CRÍTICA abiertos.
- 0 bugs de severidad MAYOR abiertos.
- TC-001, TC-002 y TC-003 en estado PASA (Funcionalidad core del sistema).