# Guía de Trabajo 12 — Datos y APIs en XR
## ⚠️ VERSIÓN ESTUDIANTE

**Estudiante:** _Isaac Josue Peralta Sandoval_  **Código:** _2231891762_
**Fecha:** _27/06/2026_ | **Puntuación total:** ____/20

---

## PARTE I — Opción Múltiple (4 puntos)

**1.** En Unity, para hacer una petición HTTP sin bloquear el hilo principal se usa:
- [ ] a) Thread.Sleep() + HttpClient
- [X] b) IEnumerator + UnityWebRequest + yield return
- [ ] c) async/await con Task.Run()
- [ ] d) Socket.ReceiveAsync()

**2.** `[System.Serializable]` en una clase de Unity es necesario para:
- [ ] a) Que la clase pueda heredar de MonoBehaviour
- [X] b) Que JsonUtility.FromJson pueda deserializar la clase
- [ ] c) Que los campos aparezcan en el Inspector
- [ ] d) Que la clase sea visible en la Hierarchy

**3.** JSON Server sirve para:
- [ ] a) Parsear JSON dentro de Unity más rápido
- [X] b) Crear un servidor REST mock local para desarrollo
- [ ] c) Convertir assets de Unity a formato JSON
- [ ] d) Serializar las escenas de Unity a JSON

**4.** ¿Por qué es mejor actualizar datos de API cada 10 segundos (no cada frame)?
- [ ] a) Unity no puede hacer requests más frecuentes
- [X] b) Demasiadas requests por segundo pueden saturar el servidor y gastar batería
- [ ] c) `UnityWebRequest` tiene un límite de 60 requests por minuto
- [ ] d) Los datos de sensores cambian solo cada 10 segundos

---

## PARTE II — Completar (4 puntos)

1. `yield return request.SendWebRequest()` pausa la coroutine hasta que la petición HTTP termina.

2. `JsonUtility.FromJson<TipoDeClase>(json)` convierte un string JSON a un objeto de C#.

3. Para que la API siempre retorne datos aunque no haya internet, se puede implementar un _cache_ local con el último dato válido.

4. En HTTPS, las comunicaciones van _encriptadas_ — importante para APIs que manejan datos sensibles.

---

## PARTE III — Análisis de código (8 puntos)

```csharp
IEnumerator ObtenerTemperatura()
{
    using (UnityWebRequest req = UnityWebRequest.Get("https://api.fabrica.com/sensor/1"))
    {
        yield return req.SendWebRequest();

        if (req.result == UnityWebRequest.Result.Success)
        {
            SensorData data = JsonUtility.FromJson<SensorData>(req.downloadHandler.text);
            textoTemp.text = $"Temp: {data.temperatura}°C";
            textoTemp.color = data.temperatura > 85f ? Color.red : Color.green;
        }
        else
        {
            textoTemp.text = "Sin conexión";
        }
    }
}
```

**3.1** (2 pt) Explica qué hace este método paso a paso.

> _1, Prepara la orden para pedir los datos del sensor a la web (https://api.fabrica.com/sensor/1). El using asegura que todo se limpie bien al terminar. 2, Envía la petición y espera a que el servidor responda. Gracias al yield return, el juego no se congela mientras espera. 3, Revisa si la respuesta llegó bien y no hubo errores de conexión. 4, Si todo salió bien, convierte el texto JSON en un objeto de C# (SensorData), pone la temperatura en pantalla con el "°C" y cambia el texto a rojo si pasa los 85f, o a verde si está normal. 5, Si algo falló (por ejemplo, te quedaste sin internet), pone en la pantalla el mensaje "Sin conexión"._

**3.2** (2 pt) Si la API retorna este JSON, ¿cómo debe definirse la clase `SensorData`?

```json
{"sensor_id": 1, "temperatura": 78.3, "humedad": 45.0, "estado": "normal"}
```

```csharp
[System.Serializable]
public class SensorData
{
    // Completa los campos:
    public int sensor_id;
    public float temperatura;
    public float humedad;
    public string estado;
}

}
```

**3.3** (2 pt) ¿Qué limitación tiene JsonUtility con el campo `sensor_id` (con guión bajo)? ¿Cómo se soluciona?

> _JsonUtility es bastante básico y no es compatible nativamente con renombrado de atributos ni anotaciones (como [JsonProperty]). Obligatoriamente tienes que nombrar la variable en C# usando el guión bajo (sensor_id), rompiendo la convención estándar de nomenclatura de C# (CamelCase o PascalCase), por ello la solución es usando librerías de serialización más completas como Newtonsoft Json.NET, la cual permite mapear la clave usando la etiqueta [JsonProperty("sensor_id")] public int sensorId;. Si estás obligado a usar JsonUtility, la única solución directa es aguantarse y dejar el nombre de la variable con el guión bajo exacto del JSON._

**3.4** (2 pt) Modifica el código para que si la temperatura > 100°C, llame además al método `ActivarAlarma()`.

```csharp
// Modificación:

SensorData data = JsonUtility.FromJson<SensorData>(req.downloadHandler.text);
textoTemp.text = $"Temp: {data.temperatura}°C";
textoTemp.color = data.temperatura > 85f ? Color.red : Color.green;

// Nueva lógica para la alarma
if (data.temperatura > 100f)
{
    ActivarAlarma();
}

```

---

## PARTE IV — Diseño (4 puntos)

**4.1** (4 pt) Para el proyecto de tu grupo, describe cómo integrarías una API de datos:
- ¿Qué datos necesitaría la app? (tipo de API)
- ¿Cómo se mostrarían esos datos en AR/VR?
- ¿Cada cuánto se actualizarían?
- ¿Qué pasaría si no hay conexión?

> _________________________________________________________________
> _________________________________________________________________
> _________________________________________________________________

*PSISP08075 | Universidad Autónoma del Perú | 2026-1*
