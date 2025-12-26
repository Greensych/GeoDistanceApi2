# GeoDistanceApi

REST API для расчёта расстояния между двумя точками на карте.

## Что это

Простой веб-сервис, который принимает координаты двух точек (широта/долгота) и возвращает расстояние между ними в километрах. Использует формулу гаверсинусов.

## Стек

- .NET 8
- ASP.NET Core
- xUnit для тестов
- Swagger для документации

## Как запустить

```bash
cd src/GeoDistanceApi
dotnet run
```

API будет доступен по адресу `https://localhost:5001`

Swagger UI: `https://localhost:5001/swagger`

## Пример

POST на `/api/distance/calculate`:

```json
{
  "from": {
    "latitude": 55.7558,
    "longitude": 37.6173
  },
  "to": {
    "latitude": 59.9311,
    "longitude": 30.3609
  }
}
```

Ответ:
```json
{
  "distanceKm": 633.45
}
```

## Тесты

```bash
cd tests/GeoDistanceApi.Tests
dotnet test
```

## Структура

```
src/
  GeoDistanceApi/          - основной проект API
    Controllers/           - контроллеры
    Models/                - модели данных
    Services/              - бизнес-логика
tests/
  GeoDistanceApi.Tests/    - unit-тесты
```
